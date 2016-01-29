using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace API.Models
{
    public class VideoModels : Config
    {
        public DataSet Video_Select(int orderby, int intStartRow, int intEndRow)
        {
            SqlCommand cmd = new SqlCommand("API_GetVideos");
            cmd.Parameters.Add(new SqlParameter("@orderby", orderby));
            cmd.Parameters.Add(new SqlParameter("@intStartRow", intStartRow));
            cmd.Parameters.Add(new SqlParameter("@intEndRow", intEndRow));
            return getDataSet(cmd);
        }
        public DataSet Video_SelectByListId(string listid ,int orderby, int intStartRow, int intEndRow)
        {
            SqlCommand cmd = new SqlCommand("API_GetVideosByListId");
            cmd.Parameters.Add(new SqlParameter("@listid", listid));
            cmd.Parameters.Add(new SqlParameter("@orderby", orderby));
            cmd.Parameters.Add(new SqlParameter("@intStartRow", intStartRow));
            cmd.Parameters.Add(new SqlParameter("@intEndRow", intEndRow));
            return getDataSet(cmd);
        }

        public DataSet Video_Detail(int videoid)
        {
            SqlCommand cmd = new SqlCommand("API_GetVideoDetail");
            cmd.Parameters.Add(new SqlParameter("@id", videoid));
            return getDataSet(cmd);
        }
    }
}