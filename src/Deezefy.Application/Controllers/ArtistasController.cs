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
    [Route("api/artistas")]
    public class ArtistasController : MainController
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;
        public ArtistasController(IArtistaRepository artistaRepository, IMapper mapper)
        {
            _artistaRepository = artistaRepository;
            _mapper = mapper;
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<ArtistaViewModel>> ObterPorEmail(string email)
        {
            if (!new EmailAddressAttribute().IsValid(email))
            {
                ModelState.AddModelError("", "Não é um e-mail válido.");
                return CustomResponse();
            }
            var artistaViewModel = _mapper.Map<ArtistaViewModel>(await _artistaRepository.ObterPorEmail(email));

            if (artistaViewModel == null)
                return NotFound();

            return CustomResponse(artistaViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ArtistaViewModel>>> ObterTodos()
        {
            var artistasViewModel = _mapper.Map<ICollection<ArtistaViewModel>>(await _artistaRepository.ObterTodos());

            return CustomResponse(artistasViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<ArtistaViewModel>> Adicionar(ArtistaViewModel artistaViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse();

            await _artistaRepository.Adicionar(_mapper.Map<Artista>(artistaViewModel));

            return CustomResponse(artistaViewModel);
        }

        [HttpPut("{email}")]
        public async Task<ActionResult<ArtistaViewModel>> Atualizar(string email, ArtistaViewModel artistaViewModel)
        {
            if (email != artistaViewModel.Email)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            await _artistaRepository.Atualizar(_mapper.Map<Artista>(artistaViewModel));

            return CustomResponse();
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> Delete(string email)
        {
            var artista = await _artistaRepository.ObterPorEmail(email);

            if (artista == null)
                return NotFound();

            await _artistaRepository.Remover(email);

            return CustomResponse();
        }



    }
}
