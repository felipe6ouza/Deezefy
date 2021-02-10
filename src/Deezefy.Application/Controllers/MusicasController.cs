using AutoMapper;
using Deezefy.Application.ViewModels;
using Deezefy.Business.Interfaces;
using Deezefy.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deezefy.Application.Controllers
{
    [Route("api/musicas")]
    public class MusicasController : MainController
    {
        private readonly IMusicaRepository _musicaRepository;
        private readonly IMapper _mapper;
        public MusicasController(IMusicaRepository musicaRepository, IMapper mapper)
        {
            _musicaRepository = musicaRepository;
            _mapper = mapper;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<MusicaViewModel>> ObterPorId(int id)
        {
            
            var musicaViewModel = _mapper.Map<MusicaViewModel>(await _musicaRepository.ObterPorId(id));

            if (musicaViewModel == null)
                return NotFound();

            return CustomResponse(musicaViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<MusicaViewModel>>> ObterTodos()
        {
            var musicasViewModel = _mapper.Map<ICollection<MusicaViewModel>>(await _musicaRepository.ObterTodos());

            return CustomResponse(musicasViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<MusicaViewModel>> Adicionar(MusicaViewModel musicaViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse();

            await _musicaRepository.Adicionar(_mapper.Map<Musica>(musicaViewModel));

            return CustomResponse(musicaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MusicaViewModel>> Atualizar(int id, MusicaViewModel musicaViewModel)
        {
            if (id != musicaViewModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse();

            await _musicaRepository.Atualizar(_mapper.Map<Musica>(musicaViewModel));

            return CustomResponse();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var musica = await _musicaRepository.ObterPorId(id);

            if (musica == null)
                return NotFound();

            await _musicaRepository.Remover(id);

            return CustomResponse();
        }



    }
}
