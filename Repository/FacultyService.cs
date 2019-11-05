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
    public class FacultyService : IFacultyRepository
    {
        string connectionString;
        public FacultyService(string connectionString)
        {
            this.connectionString = connectionString;

        }

        public async Task<IEnumerable<Faculty>> Select(string FacultyId)
        {

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();

                    para.Add("@FacultyId", FacultyId);
                    var results = await connection.QueryAsync<Faculty>("[dbo].[SelectFaculty]", para, commandType: CommandType.StoredProcedure);
                    return results;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<int> Delete(string FacultyId)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                DynamicParameters para = new DynamicParameters();

                para.Add("@FacultyId", FacultyId);
                var affectedRows = await connection.ExecuteAsync("[dbo].[DeleteFaculty]", para, commandType: CommandType.StoredProcedure);
                return affectedRows;
            }

        }
        public async Task<int> Insert(Faculty faculty)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(faculty);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "I", DbType.String);
                    var affectedRows = await connection.ExecuteAsync("InsertFaculty", para, commandType: CommandType.StoredProcedure);
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Update(Faculty faculty)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    string JsonData = JsonConvert.SerializeObject(faculty);
                    para.Add("@JsonData", JsonData, DbType.String);
                    para.Add("@Operation", "U", DbType.String);
                    var affectedRows = await connection.ExecuteAsync("InsertFaculty", para, commandType: CommandType.StoredProcedure);
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
