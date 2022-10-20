using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citymanagement.Model
{
    
        public class GetAllRecordResponse
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public List<InsertRecordRequest> data { get; set; }
        }


    public class GetRecordByNameResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<InsertRecordRequest> data { get; set; }
    }



}
