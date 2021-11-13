using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace LookingOverTheHedge.Api.Data
{
    [DynamoDBTable("LookingOverTheHedge")]
    public class Talk
    {
        [DynamoDBHashKey]
        public string  PK{ get; set; }

        [DynamoDBRangeKey]
        public string SK { get; set; }

        public string Name { get; set; }

        public string Speaker { get; set; }

    }
}