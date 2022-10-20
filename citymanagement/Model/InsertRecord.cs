using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace citymanagement.Model
{
    public class InsertRecordRequest
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }

        [BsonElement("Name")]
        [Required]
        public string RouteName { get; set; }

        [Required]
        public string StartLocation{ get; set; }

        [Required]
        public string EndLocation { get; set; }

        [Required]
        public int  DepatureTime { get; set; }

        [Required]
        public int ArrivalTime { get; set; }


        [Required]
        public int  RunningTime { get; set; }

    }



    public class InsertRecordResponse
    {

        public bool IsSuccess { get; set; }
        public string Massage { get; set; }
    }
}
