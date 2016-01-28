using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using API.Common;

namespace API.Controllers
{
    public class VideoController : ApiController
    {

        // GET api/video
        public string Get()
        {
            return "aa";
            //return Common.Common.ds2json((new CateModels()).Category_Select(1, genreid));
        }

        // GET api/video/5
        public string Get(int id)
        {
            return "value";
        }

        //GET api/video/genres
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public string Genres(int genreid = 0)
        {
            return Common.Common.ds2json((new CateModels()).Category_Select(1, genreid));
        }

        //GET api/video/GetVideos
        public string GetVideos(string order = "", int page = 1, int pagesize = 20)
        {
            int orderby, startrow, endrow;
            if (order.Equals("new")) orderby = 0;
            else orderby = 1;
            startrow = (page - 1) * pagesize + 1;
            endrow = page * pagesize;
            return Common.Common.ds2json((new VideoModels()).Video_Select(orderby, startrow, endrow));
        }
        //GET api/video/GetVideosByGenre
        public string GetVideosByGenre(int genreid = 0, string order = "", int page = 1, int pagesize = 20)
        {
            DataSet dsO = (new OptionVideoModels()).Video_GetOptionByOptionId(genreid, 1);
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
                DataSet dsVideo = (new VideoModels()).Video_SelectByListId(listvideoid, orderby, startrow, endrow);
                return Common.Common.ds2json(dsVideo);
            }
            else
                return "";

        }
    }
}
