using Microsoft.AspNetCore.Mvc;
using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.Adapters.HttpsAdapters
{
    [ApiController]
    [Route("[controller]")]

    public class LaundryHttpsAdapter : ControllerBase
    {
        protected ICreateLaundryUseCase createLaundryUseCase;
        protected ILaundryRepository laundryRepository;
        protected IDeleteLaundryUseCase deleteLaundryUseCase;

        public LaundryHttpsAdapter(ICreateLaundryUseCase createLaundryUseCase, 
            ILaundryRepository laundryRepository, IDeleteLaundryUseCase deleteLaundryUseCase)
        {
            this.createLaundryUseCase = createLaundryUseCase;
            this.laundryRepository = laundryRepository;
            this.deleteLaundryUseCase = deleteLaundryUseCase;
        }

        [HttpGet("/GetLaundryById", Name = "GetLaundryById")]
        public ActionResult GetLaundryById(int id)
        {
            try
            {
                var laundry = laundryRepository.FindByBagId(id);
                return Ok(laundry);
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

        [HttpPost("/CreateLaundry", Name = "CreateLaundry")]
        public ActionResult CreateLaundry(LaundryEntity laundryEntity)
        {
            try
            {
                var laundry = createLaundryUseCase.CreateLaundry(laundryEntity);
                return Ok(laundry);
            }
            catch (ArgumentNullException ane)
            {
                return StatusCode(404, ane.Message);
            }
            catch(Exception e) 
            { 
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("/DeleteLaundry", Name = "DeleteLaundry")]
        public IActionResult Delete(int laundryId)
        {
            try
            {
                deleteLaundryUseCase.DeleteLaundry(laundryId);
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
