using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BoatSalesApi.Contracts.V1;
using BoatSalesApi.Domain.V1;
using BoatSalesApi.Contracts.V1.Request;
using BoatSalesApi.Services;

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
        public IActionResult GetAll()
        {
            List<Boat> boats = _boatService.GetBoats();
            List<BoatResponse> responseModel = new();
            foreach (var dataModel in boats)
            {
                responseModel.Add(new BoatResponse { Id = dataModel.Id});
            }
            
            return Ok(responseModel);
        }

        [HttpPost(ApiRoutes.Boats.Create)]
        public IActionResult Create([FromBody] CreateBoatRequest boatRequest)
        {

            // for easy testing
            if (boatRequest.Id == Guid.Empty)
                boatRequest.Id = Guid.NewGuid();

            Boat boat = new() { Id = boatRequest.Id};
            
            _boatService.CreateBoat(boat);
            
            BoatResponse boatResponse = new() { Id = boat.Id };

            return Created("todo:createdurl", boatResponse);
        }

        [HttpGet(ApiRoutes.Boats.Get)]
        public IActionResult Get([FromRoute] Guid boatId)
        {
            Boat boat = _boatService.GetBoatById(boatId);

            if (boat == null)
                return NotFound();

            BoatResponse responseModel = new ()
            {
                Id = boat.Id
            };
            // stop returning datamodel
            return Ok(responseModel);
        }
    }
}
