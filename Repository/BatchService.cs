using Dapper;
using Fireball.Utilities.ExceptionManagment;
using Models;
using Newtonsoft.Json;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class BatchService : IBatchRepository
    {
       // IErrorLogRepostory _errorLogRepostory;
        string connectionString;
        public BatchService(string connectionString)
        {
            this.connectionString = connectionString;
           // _errorLogRepostory = errorLogRepostory;
        }

        public async Task<IEnumerable<Batch>> Select(string BatchId)
        {

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    para.Add("@BatchId", BatchId);
                    var results = await connection.QueryAsync<Batch>("[dbo].[SelectBatch]", para, commandType: CommandType.StoredProcedure);
                    return results;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<int> Delete(string BatchId)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                DynamicParameters para = new DynamicParameters();

                para.Add("@BatchId", BatchId);
                var affectedRows = await connection.ExecuteAsync("[dbo].[DeleteBatch]", para, commandType: CommandType.StoredProcedure);
                return affectedRows;
            }

        }
        public async Task<int> Insert(Batch batch)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(batch);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "I", DbType.String);
                    var affectedRows = await connection.ExecuteAsync("InsertBatch", para, commandType: CommandType.StoredProcedure);
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Update(Batch batch)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(batch);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "U", DbType.String);
                    var affectedRows = await connection.ExecuteAsync("InsertBatch", para, commandType: CommandType.StoredProcedure);
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

