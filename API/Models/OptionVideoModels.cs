using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace API.Models
{
    public class OptionVideoModels : Config
    {
        public DataSet Video_GetOptionByOptionId(int optionid, int type)
        {
            SqlCommand cmd = new SqlCommand("API_OptionVideoByOptionId");
            cmd.Parameters.Add(new SqlParameter("@optionid", optionid));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            return getDataSet(cmd);
        }
    }
}