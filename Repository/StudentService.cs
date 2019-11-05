using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Fireball.Utilities.ExceptionManagment;
using Repository.Interfaces;

namespace Repository
{
    public class StudentService : IStudentRepository
    {
       // IErrorLogRepostory _errorLogRepostory;
        string connectionString;
        public StudentService(string connectionString)
        {
            this.connectionString = connectionString;
            
        }
       
        public async Task<IEnumerable<Student>> Select(string StudentId)
        {

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                     para.Add("@StudentId", StudentId);
                    var results = await connection.QueryAsync<Student>("[dbo].[SelectStudent]", para, commandType: CommandType.StoredProcedure);
                    return results;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<int> Delete(string StudentId)
        {
            
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    para.Add("@StudentId", StudentId);
                    var affectedRows=await connection.ExecuteAsync("[dbo].[DeleteStudent]", para, commandType: CommandType.StoredProcedure);
                    return affectedRows;
                }
           
        }
        public async Task<int> Insert(Student student)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(student);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "I", DbType.String);
                    var affectedRows = await connection.ExecuteAsync("InsertStudent", para, commandType: CommandType.StoredProcedure);
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Update(Student student)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(student);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "U", DbType.String);
                    var affectedRows = await connection.ExecuteAsync("InsertStudent", para, commandType: CommandType.StoredProcedure);
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

