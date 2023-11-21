using Microsoft.AspNetCore.Mvc;
using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.Adapters.HttpsAdapters
{
    [ApiController]
    [Route("[controller]")]
    public class RacketHttpsAdapter : ControllerBase
    {
        protected IRegisterRacketUseCase registerRacketUseCase;
        protected IRacketCore racketCore;
        protected IRacketRepository racketRepository;
        protected IDeleteRacketUseCase deleteRacketUseCase;

        public RacketHttpsAdapter(IRegisterRacketUseCase registerRacketUseCase, IRacketCore racketCore,
            IRacketRepository racketRepository, IDeleteRacketUseCase deleteRacketUseCase)
        {
            this.registerRacketUseCase = registerRacketUseCase;
            this.racketCore = racketCore;
            this.racketRepository = racketRepository;
            this.deleteRacketUseCase = deleteRacketUseCase;
        }

        [HttpGet("/GetRacketById", Name = "/GetRacketById")]
        public ActionResult GetRacketById(int id)
        {
            try
            {
                var racket = racketRepository.FindRacketById(id);
                return Ok(racket);
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

        [HttpPost("/RegisterRacket", Name = "RegisterRacket")]
        public ActionResult RegisterRacket(RacketEntity racketEntity)
        {
            try
            {
                var request = registerRacketUseCase.RegisterRacket(racketEntity);
                return Ok(racketEntity);
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

        [HttpDelete("/DeleteRacket", Name = "DeleteRacket")]
        public IActionResult Delete(int racketId)
        {
            try
            {
                deleteRacketUseCase.DeleteRacket(racketId);
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
