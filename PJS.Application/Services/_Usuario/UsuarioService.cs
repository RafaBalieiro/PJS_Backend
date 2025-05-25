using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Perfil;
using PJS.Application.DTO._Usuario;
using PJS.Application.Interfaces.Services._Auth;
using PJS.Application.Interfaces.Services._Perfil;
using PJS.Application.Services._Base;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Entities._Usuario;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Repository._UnitWork;
using PJS.Domain.Interfaces.Repository._Usuario;
using PJS.Domain.Interfaces.Services;
using PJS.Domain.Interfaces.Services._Usuario;

namespace PJS.Application.Services._Usuario
{
    public class UsuarioService : ServiceBase<UsuarioEntity>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IPerfilService _perfilService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUsuarioRepository repository, ITokenService tokenService, IPerfilService perfilService, IMapper mapper, IUnitOfWork unitOfWork) : base(repository)
        {
            _repository = repository;
            _tokenService = tokenService;
            _perfilService = perfilService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Login(string email, string senha)
        {
            var usuario = await _repository.GetByEmailAsync(email);

            if (usuario == null)
                throw new UnauthorizedAccessException("Usuario não encontrado!");

            if (!BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
                throw new UnauthorizedAccessException("Senha Inválida!");

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }

        public async Task<UsuarioResponseDto> Register(UsuarioCadastroDto user)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var existente = await _repository.GetByEmailAsync(user.Email);

                if (existente != null)
                    throw new InvalidOperationException("Já existe um usuário com este e-mail.");

                var senhaHash = BCrypt.Net.BCrypt.HashPassword(user.Senha);

                var novoUsuario = new UsuarioEntity(user.Email, senhaHash);
                var usuarioCriado = await _repository.AddAsync(novoUsuario);

                if (usuarioCriado == null)
                    throw new Exception("Falha ao salvar o usuário no banco de dados.");

                var perfil = new PerfilEntity(user.Nome, user.DataNascimento, usuarioCriado.Id);
                await _perfilService.CreateAsync(perfil);

                await _unitOfWork.CommitAsync();

                return _mapper.Map<UsuarioResponseDto>(usuarioCriado);
            }
            catch (InvalidOperationException ex)
            {
                await _unitOfWork.RollbackAsync();
                // repropaga a exceção com mensagem clara
                throw new InvalidOperationException($"Erro de validação: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                // exceção genérica para falhas internas
                throw new ApplicationException("Erro interno ao cadastrar o usuário.", ex);
            }
        }
    }
}