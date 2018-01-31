using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Facade.Contracts;
using Models.Domain;
using Service.Contracts.Services;

namespace CrawfishCupWebAPI.Controllers
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

        //public RegisterController()
        //{
            
        //}

        [HttpGet, Route("Testing")]
        public IHttpActionResult Testing()
        {
            return Ok();
        }

        [HttpPost, Route("RegisterTeam")]
        public IHttpActionResult RegisterTeam(TeamWithPlayers teamWithPlayers, StripePaymentRequest stripePaymentRequest)
        {
            try
            {
                _stripePaymentService.Charge(stripePaymentRequest);
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

            _registerFacade.RegisterTeam(teamWithPlayers);

            return Ok();
        }
    }
}