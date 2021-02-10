using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Deezefy.Application.Controllers
{

    [ApiController]
	public class MainController : ControllerBase
	{
		protected ActionResult CustomResponse(object result = null)
		{
			if (IsValidOperation())
			{
				return Ok(new
				{
					sucess = true,
					data = result
				});
			}

			return BadRequest(new
			{
				sucess = false,
				erros = GetErros()
			});
		}


		protected bool IsValidOperation()
		{
			if(ModelState.IsValid)
				return true;

			return false;
		}

		protected ICollection<string> GetErros()
		{
			var errosModelState = ModelState.Values.SelectMany(e => e.Errors);

			ICollection<string> ListaErros = new Collection<string>();

			foreach (var erro in errosModelState)
            {
				var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
				ListaErros.Add(errorMsg);

			}

			return ListaErros;
		}
	}
}