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
    [Route("api/ouvintes")]
    public class OuvintesController : MainController
    {
        private readonly IOuvinteRepository _ouvinteRepository;
        private readonly IMapper _mapper;
        public OuvintesController(IOuvinteRepository ouvinteRepository, IMapper mapper)
        {
            _ouvinteRepository = ouvinteRepository;
            _mapper = mapper;
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<OuvinteViewModel>> ObterPorEmail(string email)
        {
            if (!new EmailAddressAttribute().IsValid(email))
            {
                ModelState.AddModelError("", "Não é um e-mail válido.");
                return CustomResponse();
            }
            var ouvinteViewModel = _mapper.Map<OuvinteViewModel>(await _ouvinteRepository.ObterPorEmail(email));

            if (ouvinteViewModel == null)
                return NotFound();

            return CustomResponse(ouvinteViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<OuvinteViewModel>>> ObterTodos()
        {
            var ouvintesViewModel = _mapper.Map<ICollection<OuvinteViewModel>>(await _ouvinteRepository.ObterTodos());

            return CustomResponse(ouvintesViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<OuvinteViewModel>> Adicionar(OuvinteViewModel ouvinteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _ouvinteRepository.Adicionar(_mapper.Map<Ouvinte>(ouvinteViewModel));

            return CustomResponse(ouvinteViewModel);
        }

        [HttpPut("{email}")]
        public async Task<ActionResult<OuvinteViewModel>> Atualizar(string email, OuvinteViewModel ouvinteViewModel)
        {
            if (email != ouvinteViewModel.Email)
                return BadRequest();

            if (!ModelState.IsValid)
                return CustomResponse();

            await _ouvinteRepository.Atualizar(_mapper.Map<Ouvinte>(ouvinteViewModel));

            return CustomResponse();
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> Delete(string email)
        {
            var ouvinte = await _ouvinteRepository.ObterPorEmail(email);

            if (ouvinte == null)
                return NotFound();

            await _ouvinteRepository.Remover(email);

            return CustomResponse();
        }


    }
}
