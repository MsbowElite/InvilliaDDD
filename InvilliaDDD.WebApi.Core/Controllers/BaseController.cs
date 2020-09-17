using System.Collections.Generic;
using System.Linq;
using InvilliaDDD.Core.Communication;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InvilliaDDD.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult resposta)
        {
            ResponsePossuiErros(resposta);

            return CustomResponse();
        }

        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta == null || !resposta.Errors.Messages.Any()) return false;

            foreach (var message in resposta.Errors.Messages)
            {
                AdicionarErroProcessamento(message);
            }

            return true;
        }

        protected bool ValidOperation()
        {
            return !Errors.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            Errors.Add(erro);
        }

        protected void LimparErrosProcessamento()
        {
            Errors.Clear();
        }
    }
}
