using AutoMapper;
using Deezefy.Application.ViewModels;
using Deezefy.Business.Interfaces;
using Deezefy.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Deezefy.Application.Controllers
{
    namespace Deezefy.Application.Controllers
    {
        [Route("api/usuarios")]
        public class UsuariosController : MainController
        {
            private readonly IUsuarioRepository _usuarioRepository;
            private readonly IMapper _mapper;
            public UsuariosController(IUsuarioRepository usuarioRepository, IMapper mapper)
            {
                _usuarioRepository = usuarioRepository;
                _mapper = mapper;
            }

            [HttpGet("{email}")]
            public async Task<ActionResult<UsuarioViewModel>> ObterPorEmail(string email)
            {
                if (!new EmailAddressAttribute().IsValid(email))
                {
                    ModelState.AddModelError("", "Não é um e-mail válido.");
                    return CustomResponse();
                }
                var usuariosViewModel = _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorEmail(email));

                if (usuariosViewModel == null)
                    return NotFound();

                return CustomResponse(usuariosViewModel);
            }

            [HttpGet]
            public async Task<ActionResult<ICollection<UsuarioViewModel>>> ObterTodos()
            {
                var usuariosViewModel = _mapper.Map<ICollection<UsuarioViewModel>>(await _usuarioRepository.ObterTodos());

                return CustomResponse(usuariosViewModel);
            }


            [HttpPost]
            public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuarioViewModel)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                await _usuarioRepository.Adicionar(_mapper.Map<Usuario>(usuarioViewModel));

                return CustomResponse(usuarioViewModel);
            }

            [HttpPut("{email}")]
            public async Task<ActionResult<UsuarioViewModel>> Atualizar(string email, UsuarioViewModel usuarioViewModel)
            {
                if (email != usuarioViewModel.Email)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return CustomResponse();

                await _usuarioRepository.Atualizar(_mapper.Map<Usuario>(usuarioViewModel));

                return NoContent();
            }


            [HttpDelete("{email}")]
            public async Task<ActionResult> Delete(string email)
            {
                var usuario = await _usuarioRepository.ObterPorEmail(email);

                if (usuario == null)
                    return NotFound();

                await _usuarioRepository.Remover(email);

                return CustomResponse();
            }



        }
    }

}
