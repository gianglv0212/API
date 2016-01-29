using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace API.Models
{
    public class MovieModels : Config
    {
        public DataSet Movie_Select(int orderby, int intStartRow, int intEndRow)
        {
            SqlCommand cmd = new SqlCommand("API_GetMovies");
            cmd.Parameters.Add(new SqlParameter("@orderby", orderby));
            cmd.Parameters.Add(new SqlParameter("@intStartRow", intStartRow));
            cmd.Parameters.Add(new SqlParameter("@intEndRow", intEndRow));
            return getDataSet(cmd);
        }

        public DataSet Movie_SelectByListId(string listid, int orderby, int startrow, int endrow)
        {
            SqlCommand cmd = new SqlCommand("API_GetMoviesByListId");
            cmd.Parameters.Add(new SqlParameter("@listid", listid));
            cmd.Parameters.Add(new SqlParameter("@orderby", orderby));
            cmd.Parameters.Add(new SqlParameter("@intStartRow", startrow));
            cmd.Parameters.Add(new SqlParameter("@intEndRow", endrow));
            return getDataSet(cmd);
        }


        public DataSet Movie_Detail(int movieid)
        {
            SqlCommand cmd = new SqlCommand("API_GetMoviesDetail");
            cmd.Parameters.Add(new SqlParameter("@id", movieid));
            return getDataSet(cmd);
        }
    }
}