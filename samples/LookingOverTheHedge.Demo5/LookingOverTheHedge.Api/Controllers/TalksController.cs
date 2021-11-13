using Amazon.DynamoDBv2.DataModel;
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
        public async Task<IActionResult> TalksAsync()
        {
            var talks = new List<Talk>();

            var dbClient = new Amazon.DynamoDBv2.AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(dbClient);

            // Create the query to fetch all the talks from Haxx2021;
            DynamoDBOperationConfig operation = new DynamoDBOperationConfig();
            operation.QueryFilter.Add(new ScanCondition("SK", Amazon.DynamoDBv2.DocumentModel.ScanOperator.BeginsWith, "TALK#"));
            var query = context.QueryAsync<Talk>("CONFERENCE#LiveOnStage", operation);
            do
            {
                var resultSet = await query.GetNextSetAsync();
                talks.AddRange(resultSet);

            } while (!query.IsDone);

            return Ok(talks);

        }
    }
}
