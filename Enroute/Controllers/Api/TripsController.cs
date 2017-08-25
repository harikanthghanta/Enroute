using AutoMapper;
using Enroute.Models;
using Enroute.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enroute.Controllers.Api
{
    [Route("api/trips")]
    [Authorize]
    public class TripsController:Controller
    {
        private IWorldRepository _repository;

        public TripsController(IWorldRepository repository)
        {
            _repository = repository;

        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            { 
            var results = _repository.GetTripsByUsername(this.User.Identity.Name);
            return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]TripViewModel trip)
        {
            var newTrip = Mapper.Map<Trip>(trip);
            _repository.AddTrip(newTrip);

            if (await _repository.SaveChangesAsync())
            {
                return Created($"api/trips/{trip.Name}",trip);
            }
            return BadRequest("Failed to save changes to Db");
          
        }
    }
}
