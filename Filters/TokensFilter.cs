using CrudCarsTokens.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CrudCarsTokens.Filters
{
    public class TokensFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly ITokenService _tokenService;

        public TokensFilter(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var path = filterContext.HttpContext.Request.Path;

            if (path.HasValue && path.Value.ToLower().Contains("auth")) return;

            string metodo = filterContext.HttpContext.Request.Method;

            if (!string.IsNullOrEmpty(metodo) && metodo == "GET")
            {
                var tokenLeitura = filterContext.HttpContext.Request.Headers["token-leitura"].ToString();
                ValidarRequisicaoLeitura(filterContext, tokenLeitura);
                return;
            }

            var tokenEscrita = filterContext.HttpContext.Request.Headers["token-escrita"].ToString();
            ValidarRequisacaoEscrita(filterContext, tokenEscrita);
        }
        
        private void ValidarRequisicaoLeitura(ActionExecutingContext context, string tokenLeitura)
        {
            if (string.IsNullOrEmpty(tokenLeitura))
            {
                context.Result = new BadRequestObjectResult(new { Erro = "Token não encontrado" });
                return;
            }

            var result = _tokenService.ValidarTokenLeitura(tokenLeitura);

            if (!result) context.Result = new BadRequestObjectResult(new { Erro = "Token Inválido." });
        }

        private void ValidarRequisacaoEscrita(ActionExecutingContext context, string tokenEscrita)
        {
            if (string.IsNullOrEmpty(tokenEscrita))
            {
                context.Result = new BadRequestObjectResult(new { Erro = "Token não encontrado" });
                return;
            }

            var result = _tokenService.ValidarTokenEscrita(tokenEscrita);

            if (!result) context.Result = new BadRequestObjectResult(new { Erro = "Token Inválido." });
        }

    }
}
