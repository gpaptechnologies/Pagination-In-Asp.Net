using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Paging
{
    public class BLL_Paging
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataAdapter sqlDA = null;
        DataTable dtEmployeeData = null;

        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionstring"].ToString());

        public DataTable GetEmployeeData()
        {
            using (connection = connString)
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_GetEmployees";
                sqlDA = new SqlDataAdapter(command);
                dtEmployeeData = new DataTable();
                sqlDA.Fill(dtEmployeeData);
            }
            return dtEmployeeData;
        }

    }
}