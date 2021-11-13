using LookingOverTheHedge.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookingOverTheHedge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TalksController : ControllerBase
    {
        private readonly ConferenceContext dbContext;

        public TalksController(ConferenceContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Talks()
        {
            var talks = dbContext.Speakers
                .Include(t => t.ScheduledTalks)
                .ToList();

            return Ok(talks);
        }
    }
}
