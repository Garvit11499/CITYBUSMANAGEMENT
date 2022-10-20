using citymanagement.DataAccessLayer;
using citymanagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using citymanagement.Model;

namespace citymanagement.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class routemanagement : ControllerBase
    {
        private readonly ICrudOprationDL _crudOprationDL;


        public routemanagement(ICrudOprationDL crudOprationDL)
        {
            _crudOprationDL = crudOprationDL;
        }
        [HttpPost]
        public async Task<IActionResult> InsertRecord(InsertRecordRequest request)
        {
            InsertRecordResponse response = new InsertRecordResponse();


            try
            {
                response = await _crudOprationDL.InsertRecord(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Massage = "Exception Occurs:" + ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<List<InsertRecordRequest> > GetAllRecord()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();
            try
            {
                response = await _crudOprationDL.GetAllRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response.data.ToList();
        }
        [HttpGet]
        public async Task<IActionResult> GetRecordByName([FromQuery] string Name)
        {




            GetRecordByNameResponse response = new GetRecordByNameResponse();
            try
            {
                response = await _crudOprationDL.GetRecordByName(Name);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecordById(InsertRecordRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            try
            {
                response = await _crudOprationDL.UpdateRecordById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("DeleteRecordById/{id}")]
        public async Task<IActionResult> DeleteRecordById(string id)
        {

            DeleteRecordByIdRequest request = new DeleteRecordByIdRequest();
            request.Id = id;
            DeleteRecordByIdResponse response = new DeleteRecordByIdResponse();
            try
            {
                response = await _crudOprationDL.DeleteRecordById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }
    }
}
