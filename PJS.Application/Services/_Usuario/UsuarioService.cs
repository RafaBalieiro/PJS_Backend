using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Usuario;
using PJS.Application.Interfaces.Services._Auth;
using PJS.Application.Services._Base;
using PJS.Domain.Entities._Usuario;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Repository._Usuario;
using PJS.Domain.Interfaces.Services;
using PJS.Domain.Interfaces.Services._Usuario;

namespace PJS.Application.Services._Usuario
{
    public class UsuarioService : ServiceBase<UsuarioEntity>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, ITokenService tokenService, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _tokenService = tokenService;
            _mapper = mapper;
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
            var existente = await _repository.GetByEmailAsync(user.Email);

            if (existente != null)
                throw new InvalidOperationException("Já existe um usuário com este email!");

            var senhaHash = BCrypt.Net.BCrypt.HashPassword(user.Senha);

            var novoUsuario = new UsuarioEntity(user.Email, senhaHash);

            await _repository.AddAsync(novoUsuario);

            return _mapper.Map<UsuarioResponseDto>(novoUsuario);
        }
    }
}