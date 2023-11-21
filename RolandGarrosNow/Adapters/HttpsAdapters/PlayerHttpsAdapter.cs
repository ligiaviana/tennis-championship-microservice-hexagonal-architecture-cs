using Microsoft.AspNetCore.Mvc;
using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.Adapters.HttpsAdapters
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerHttpsAdapter : ControllerBase
    {
        protected IRegisterPlayerUseCase registerPlayerUseCase;
        protected ILoginPlayerUseCase loginPlayerUseCase;
        protected IPlayerRepository playerRepository;
        protected IDeletePlayerUseCase deletePlayerUseCase;

        public PlayerHttpsAdapter(IRegisterPlayerUseCase registerPlayerUseCase, ILoginPlayerUseCase loginPlayerUseCase,
            IPlayerRepository playerRepository, IDeletePlayerUseCase deletePlayerUseCase)
        {
            this.registerPlayerUseCase = registerPlayerUseCase;
            this.loginPlayerUseCase = loginPlayerUseCase;
            this.playerRepository = playerRepository;
            this.deletePlayerUseCase = deletePlayerUseCase;
        }

        [HttpGet("/GetPlayerById", Name = "GetPlayerById")]
        public ActionResult GetPlayerById(int id)
        {
            try
            {
                var player = playerRepository.FindById(id);
                return Ok(player);

            }
            catch(ArgumentNullException nf)
            {
                return StatusCode(404, nf.Message);

            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("/RegisterPlayer", Name = "RegisterPlayer")]
        public ActionResult Register(PlayerEntity playerEntity)
        {
            try
            {
                var playerRequest = registerPlayerUseCase.Register(playerEntity);
                return Ok(playerRequest);
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

        [HttpPost("/LoginPlayer", Name = "LoginPlayer")]
        public ActionResult Login(PlayerEntity playerEntity)
        {
            try
            {
                var result = loginPlayerUseCase.Login(playerEntity);
                return Ok(result);

            }
            catch (ArgumentNullException ane)
            {
                return StatusCode(406, ane.Message);
            }
            catch (UnauthorizedAccessException uae)
            {
                return StatusCode(401, uae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("/DeletePlayer", Name = "DeletePlayer")]
        public IActionResult Delete(int playerId)
        {
            try
            {
                deletePlayerUseCase.DeletePlayer(playerId);
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
