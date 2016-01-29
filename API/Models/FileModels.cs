using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace API.Models
{
    public class FileModels:Config
    {
        public DataSet File_Stream(int movieid, int type)
        {
            SqlCommand cmd = new SqlCommand("API_FileStreamByVideoId");
            cmd.Parameters.Add(new SqlParameter("@videoid", movieid));
            cmd.Parameters.Add(new SqlParameter("@type", type));
            return getDataSet(cmd);
        }
    }
}