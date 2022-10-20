using citymanagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citymanagement.DataAccessLayer
{
      public interface ICrudOprationDL
    {


        public Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request);
        public Task<GetAllRecordResponse> GetAllRecord();

        public Task<GetRecordByNameResponse> GetRecordByName(string Name);

        public Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request);

        public Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request);


    }
}
