using Infrastructure.Persistance;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Common;

namespace Infrastructure.DapperRepository
{
    public class DataAccess
    {
        public async Task<Result> Execute<T>(string command, object conditionValues, int? timeOut = null) where T : new()
        {
            var result = new Result(false);
            try
            {
                using (var connection = new SqlConnection(new ConnectionFactory().GetConnectionString()))
                {

                    connection.Execute(command, connection, commandTimeout: timeOut);

                    await connection.CloseAsync();

                    result.State = true;
                    
                }
            }
            catch (Exception ex)
            {
                result.State = false;
            }

            return result;
        }
        public async Task<List<T>> SelectList<T>(string command, object conditionValues, int? timeOut = null) where T : new()
        {
            //IEnumerable<T> result;
            try
            {
                using (var connection = new SqlConnection(new ConnectionFactory().GetConnectionString()))
                {

                    var result = await connection.QueryAsync<T>(command, conditionValues, commandTimeout: timeOut);
                    await connection.CloseAsync();

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T> Select<T>(string command, object conditionValues, int? timeOut = null) where T : new()
        {
            try
            {
                using (var connection = new SqlConnection(new ConnectionFactory().GetConnectionString()))
                {

                    var result = await connection.QueryAsync<T>(command, conditionValues, commandTimeout: timeOut);
                    await connection.CloseAsync();

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return new T();
            }
        }


    }
}
