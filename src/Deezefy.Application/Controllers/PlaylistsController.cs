using AutoMapper;
using Deezefy.Application.ViewModels;
using Deezefy.Business.Interfaces;
using Deezefy.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deezefy.Application.Controllers
{
    [Route("api/playlists")]
    public class PlaylistsController : MainController
    {

        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;
        public PlaylistsController(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<PlaylistViewModel>> ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest();
            }
            var playlistViewModel = _mapper.Map<PlaylistViewModel>(await _playlistRepository.ObterPlaylist(nome));

            if (playlistViewModel == null)
                return NotFound();

            return CustomResponse(playlistViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<PlaylistViewModel>>> ObterTodos()
        {
            var playlistsViewModel = _mapper.Map<ICollection<PlaylistViewModel>>(await _playlistRepository.ObterTodos());

            return CustomResponse(playlistsViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistViewModel>> Adicionar(PlaylistViewModel playlistViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _playlistRepository.Adicionar(_mapper.Map<Playlist>(playlistViewModel));

            return CustomResponse(playlistViewModel);
        }

        [HttpPut("{nome}")]
        public async Task<ActionResult<PlaylistViewModel>> Atualizar(string nome, PlaylistViewModel playlistViewModel)
        {
            if (nome != playlistViewModel.Nome)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse();

            await _playlistRepository.Atualizar(_mapper.Map<Playlist>(playlistViewModel));

            return NoContent();
        }

        [HttpDelete("{nome}")]
        public async Task<ActionResult> Delete(string nome)
        {
            var ouvinte = await _playlistRepository.ObterPlaylist(nome);

            if (ouvinte == null)
                return NotFound();

            await _playlistRepository.Remover(nome);

            return CustomResponse();
        }


    }
}
