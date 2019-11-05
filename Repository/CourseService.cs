using Dapper;
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
    public class CourseService : ICourseRepository
    {
        string connectionString;
        public CourseService(string connectionString)
        {
            this.connectionString = connectionString;

        }

        public async Task<IEnumerable<Course>> Select(string CourseId)
        {

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    para.Add("@CourseId", CourseId);
                    var results = await connection.QueryAsync<Course>("[dbo].[SelectCourse]", para, commandType: CommandType.StoredProcedure);
                    return results;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<int> Delete(string CourseId)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                DynamicParameters para = new DynamicParameters();

                para.Add("@CourseId", CourseId);
                var affectedRows = await connection.ExecuteAsync("[dbo].[DeleteCourse]", para, commandType: CommandType.StoredProcedure);
                return affectedRows;
            }

        }
        public async Task<int> Insert(Course course)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(course);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "I", DbType.String);
                    var affectedRows = await connection.ExecuteAsync("InsertCourse", para, commandType: CommandType.StoredProcedure);
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Update(Course course)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(course);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "U", DbType.String);
                    var affectedRows = await connection.ExecuteAsync("InsertCourse", para, commandType: CommandType.StoredProcedure);
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
