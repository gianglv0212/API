using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Common;
using API.Models;
using System.Data;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class MovieController : ApiController
    {
        
        // GET api/movie
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/movie/5
        public string Get(int id)
        {
            return "value";
        }
        // GET api/movie/genres
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public void Genres(int genreid = 0)
        {
            Common.Common.DataSetToJson((new CateModels()).Category_Select(0, genreid));
        }
        // GET api/movie/GetMovies
        public void GetMovies(string order = "", int page = 1, int pagesize = 20)
        {
            int orderby, startrow, endrow;
            if (order.Equals("new")) orderby = 0;
            else orderby = 1;
            startrow = (page - 1) * pagesize + 1;
            endrow = page * pagesize;
            
            Common.Common.DataSetToJson((new MovieModels()).Movie_Select(orderby, startrow, endrow));
        }
        //GET api/Movie/GetMoviesByGenre?
        public void GetMoviesByGenre(int genreid = 0, string order = "", int page = 1, int pagesize = 20)
        {
            DataSet dsO = (new OptionVideoModels()).Video_GetOptionByOptionId(genreid, 4);
            if (dsO != null && dsO.Tables.Count > 0 && dsO.Tables[0].Rows.Count > 0)
            {
                string listvideoid = "";
                for (int i = 0; i < dsO.Tables[0].Rows.Count; i++)
                {
                    if (i == dsO.Tables[0].Rows.Count - 1) listvideoid += dsO.Tables[0].Rows[i]["videoid"].ToString();
                    else listvideoid += dsO.Tables[0].Rows[i]["videoid"].ToString() + ",";
                }
                int orderby, startrow, endrow;
                if (order.Equals("new")) orderby = 0;
                else orderby = 1;
                startrow = (page - 1) * pagesize + 1;
                endrow = page * pagesize;
                DataSet dsVideo = (new MovieModels()).Movie_SelectByListId(listvideoid, orderby, startrow, endrow);
                
                Common.Common.DataSetToJson(dsVideo);
            }
            else
                System.Web.HttpContext.Current.Response.Write("");
        }
        //GET api/movie/GetMovieDetail?movieid=
        public void GetMovieDetail(int movieid = 0)
        {
            DataSet ds = (new MovieModels()).Movie_Detail(movieid);
            Common.Common.DataSetToJson(ds);
        }
        //GET api/movie/GetMovieStream?streamid=
        public void GetMovieStream(int movieid = 0)
        {
            DataSet dsFile = (new FileModels()).File_Stream(movieid, 0);
            Common.Common.DataSetToJson(dsFile);
        }
    }
}
