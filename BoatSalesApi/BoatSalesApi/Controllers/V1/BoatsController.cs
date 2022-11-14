using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BoatSalesApi.Contracts.V1;
using BoatSalesApi.Domain;
using BoatSalesApi.Contracts.V1.Request;
using BoatSalesApi.Services;
using BoatSalesApi.Contracts.V1.Response;

namespace BoatSalesApi.Controllers.V1
{
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class BoatsController : ControllerBase
    {
        private IBoatService _boatService;   
        public BoatsController(IBoatService boatService)
        {
           _boatService = boatService;
        }
        
        [HttpGet(ApiRoutes.Boats.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            List<Boat>? boats = await _boatService.GetBoatsAsync();
            if (boats == null)
                return NoContent();
                
            List<BoatResponse> responseModel = new();
            foreach (var dataModel in boats)
            {
                responseModel.Add(new BoatResponse
                { 
                    Id = dataModel.Id,
                    Name = dataModel.Name
                });
            }
            
            return Ok(responseModel);
        }


        [HttpGet(ApiRoutes.Boats.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid boatId)
        {
            if (boatId == Guid.Empty)
                return NotFound();
            
            Boat? boat = await _boatService.GetBoatByIdAsync(boatId);

            if (boat == null)
                return NotFound();

            BoatResponse responseModel = new ()
            {
                Id = boat.Id,
                Name = boat.Name
            };
            return Ok(responseModel);
        }

        [HttpPost(ApiRoutes.Boats.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBoatRequest request)
        {

            Boat boat = new()
            { 
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _boatService.CreateBoatAsync(boat);
            
            BoatResponse boatResponse = new()
            {
                Id = boat.Id,
                Name = boat.Name
            };

            //TODO: Created URL FIX

            return Created("todo:createdurl", boatResponse);
        }

        [HttpPut(ApiRoutes.Boats.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid boatId, [FromBody] UpdateBoatRequest request)
        {
            if (request == null || request.Id == Guid.Empty)
                return NotFound();
            
            request.Id = boatId;

            Boat boat = new(){
                Id = request.Id,
                Name = request.Name
            };

            if(await _boatService.UpdateBoatAsync(boat))
            {
                BoatResponse boatResponse = new()
                {
                    Id = boat.Id,
                    Name = boat.Name
                };
                return Ok(boatResponse);
            }

            return NotFound();
            
        }

        [HttpDelete(ApiRoutes.Boats.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid boatId)
        {
            if (boatId == Guid.Empty)
                return NotFound();

            Boat? boat = await _boatService.GetBoatByIdAsync(boatId);
            if(boat == null)
                return NotFound();

            BoatResponse boatResponse = new()
            {
                Id = boat.Id,
                Name = boat.Name
            };

            if (await _boatService.DeleteBoatAsync(boatId))
                return Ok(boatResponse);
            
            return NotFound();
        }
    }

}
