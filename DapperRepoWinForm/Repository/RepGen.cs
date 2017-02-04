using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperRepoWinForm.Utilities;
namespace DapperRepoWinForm.Repository
{
    class RepGen
{

    public SqlConnection con;
    private void connection()
    {
        con = new SqlConnection(Globals.stringConn);
    }

        public string executeNonQuery(string query, DynamicParameters param)
    {
         try
                {
        connection();
        con.Open();
        con.Execute(query, param, commandType: CommandType.StoredProcedure);
        con.Close();
        return "0";
                }
         catch (Exception ex)
         {
             return ex.Message;
         }

    }

    public string returnScalar(string query, DynamicParameters param)
    {
        try
        {
            string valor = "";
            connection();
            con.Open();
            valor =  con.ExecuteScalar<string>(query, param, commandType: CommandType.StoredProcedure);
            con.Close();
            return valor;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }

        public string returnNumericValue(string query, DynamicParameters param)
        {
            try
            {
                string valor = "";
                param.Add("@output", dbType: DbType.Int32 , direction: ParameterDirection.Output);
                param.Add("@Returnvalue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                // Getting Return value   
                connection();
                con.Open();
                valor = con.ExecuteScalar<string>(query, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return valor;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }



    }
}

