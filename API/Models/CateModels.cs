using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace API.Models
{
    public class CateModels : Config
    {
        public DataSet Category_Select(int type, int parentid)
        {
            SqlCommand cmd = new SqlCommand("API_CateSelect");
            cmd.Parameters.Add(new SqlParameter("@type", type));
            cmd.Parameters.Add(new SqlParameter("@parentid", parentid));
            return getDataSet(cmd);
        }
    }
}