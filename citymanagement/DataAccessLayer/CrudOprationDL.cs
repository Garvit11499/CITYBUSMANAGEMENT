using citymanagement.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citymanagement.DataAccessLayer
{
    public class CrudOprationDL : ICrudOprationDL
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<InsertRecordRequest> _mongoCollection;
        public CrudOprationDL(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration[key: "DatabaseSettings:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration[key: "DatabaseSettings:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<InsertRecordRequest>(_configuration[key: "DatabaseSettings:CollectionName"]);
        }



        public async Task<InsertRecordResponse> InsertRecord(InsertRecordRequest _request)
        { 
            InsertRecordResponse response = new InsertRecordResponse();

            try
            {
                _request.CreatedDate = DateTime.Now.ToString();
                _request.UpdatedDate = string.Empty;



                await _mongoCollection.InsertOneAsync(_request);

            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Massage = "Exepction occur:" + ex.Message;
            }

            return response;


        }

        public async Task<GetAllRecordResponse> GetAllRecord()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();
            response.IsSuccess = true;
            response.Message = "Data Fetch Successfully";

            try
            {
                response.data = new List<InsertRecordRequest>();
                response.data = await _mongoCollection.Find(x => true).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "No Record Found";
                }

            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;




        }

        public async Task<GetRecordByNameResponse> GetRecordByName(string Name)
        {
            GetRecordByNameResponse response = new GetRecordByNameResponse();


            try
            {
                response.data = new List<InsertRecordRequest>();
                response.data = await _mongoCollection.Find(x => (x.RouteName == Name)).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

   

        public async Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request)
        {
            
                DeleteRecordByIdResponse response = new DeleteRecordByIdResponse();
                response.IsSuccess = true;
                response.Message = "Delete Record Successfully By Id";

                try
                {

                    var result = await _mongoCollection.DeleteOneAsync(x => x.Id == request.Id);
                    if (!result.IsAcknowledged)
                    {
                        response.IsSuccess = true;
                        response.Message = "Record Not Found In Database For Deletion, Please Enter Valid Id";
                    }

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Exception Occurs : " + ex.Message;
                }

                return response;
            }

       

        public async Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request)
        {
            
                UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
                response.IsSuccess = true;
                response.Message = "Update Record Successfully By Id";

                try
                {
                GetRecordByNameResponse Response1 = await GetRecordByName(request.Id);
                    

                   
                    request.UpdatedDate = DateTime.Now.ToString();

                    var Result = await _mongoCollection.ReplaceOneAsync(x => x.Id == request.Id, request);
                    if (!Result.IsAcknowledged)
                    {
                        response.Message = "Input Id Not Found / Updation Not Occurs";
                    }
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Exception Occurs : " + ex.Message;
                }

                return response;
            }
        }
    }
    
    


