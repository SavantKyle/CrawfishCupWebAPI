using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Facade.Contracts;
using Models.Domain;
using Service.Contracts.Services;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Register")]
    public class RegisterController : ApiController
    {
        private readonly IRegisterFacade _registerFacade;
        private readonly IStripePaymentService _stripePaymentService;

        public RegisterController(IRegisterFacade registerFacade, IStripePaymentService stripePaymentService)
        {
            _registerFacade = registerFacade;
            _stripePaymentService = stripePaymentService;
        }

        [HttpGet, Route("Testing({text})")]
        public IHttpActionResult Testing(string text)
        {
            return Ok($"{text}, IT WORKED!");
        }

        [HttpPost, Route("RegisterTeam")]
        public IHttpActionResult RegisterTeam([FromBody] TeamAndPaymentInfo teamAndPaymentInfo)
        {
            try
            {
                _stripePaymentService.Charge(teamAndPaymentInfo.StripePaymentRequest);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.PaymentRequired)
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        ReasonPhrase = ex.Message
                    });
            }
            
            _registerFacade.RegisterTeam(teamAndPaymentInfo.TeamWithPlayers);

            return Ok();
        }
    }
}