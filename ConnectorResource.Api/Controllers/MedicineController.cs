using ConnectorResource.Api.Services;
using ConnectorResource.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConnectorResource.Api.Controllers
{
    [Route("api/v1/medicines")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateMedicine(Medicine medicine)
        {
            if(medicine == null)
            {
                return BadRequest();
            }

            await medicineService.CreateAsync(medicine);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMedicine(Medicine medicine)
        {
            if(medicine == null)
            {
                return BadRequest();
            }
            await medicineService.UpdateAsync(medicine);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicines()
        {
            var response = await medicineService.GetAllAsync();
            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetMedicine(string Id)
        {
            var response = await medicineService.GetAsync(Id);
            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
