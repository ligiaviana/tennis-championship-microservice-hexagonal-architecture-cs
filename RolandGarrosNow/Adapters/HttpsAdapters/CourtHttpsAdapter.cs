using Microsoft.AspNetCore.Mvc;
using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.Adapters.HttpsAdapters
{
    [ApiController]
    [Route("Controller")]
    public class CourtHttpsAdapter : ControllerBase
    {
        protected IRegisterCourtUseCase registerCourtUseCase;
        protected ICourtCore courtCore;
        protected ICourtRepository courtRepository;
        protected IDeleteCourtUseCase deleteCourtUseCase;

        public CourtHttpsAdapter(IRegisterCourtUseCase registerCourtUseCase, ICourtCore courtCore,
            ICourtRepository courtRepository, IDeleteCourtUseCase deleteCourtUseCase)
        {
            this.registerCourtUseCase = registerCourtUseCase;
            this.courtCore = courtCore;
            this.courtRepository = courtRepository;
            this.deleteCourtUseCase = deleteCourtUseCase;
        }

        [HttpGet("/GetCourtById", Name = "/GetCourtById")]
        public ActionResult GetCourtById(int id)
        {
            try
            {
                var court = courtRepository.FindCourtById(id);
                return Ok(court);
            }
            catch (ArgumentNullException ane)
            {
                return StatusCode(404, ane.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("/RegisterCourt", Name = "/RegisterCourt")]
        public ActionResult RegisterCourt(CourtEntity courtEntity)
        {
            try 
            { 
                var request = registerCourtUseCase.RegisterCourt(courtEntity);
                return Ok(request);
            }
            catch (ArgumentNullException ane)
            {
                return StatusCode(406, ane.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("/DeleteCourt", Name = "DeleteCourt")]
        public IActionResult Delete(int courtId)
        {
            try
            {
                deleteCourtUseCase.DeleteCourt(courtId);
                return Ok();
            }
            catch (ArgumentNullException nf)
            {
                return StatusCode(404, nf.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
