using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace API.Common
{
    public class Common
    {
        public static void DataSetToJson(DataSet ds)
        {
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            //return JSONresult;
            System.Web.HttpContext.Current.Response.Write(JSONresult);
        }
        public static string DataSetToString(DataSet ds)
        {
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
            //System.Web.HttpContext.Current.Response.Write(JSONresult);
        }
        public static string DataTableToJsonObj(DataTable dt)
        {

            DataSet ds = new DataSet();
            ds.Merge(dt);
            StringBuilder JsonString = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                JsonString.Append("{");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //JsonString.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j < ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\",");
                        }
                        else if (j == ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        //JsonString.Append("}");
                        JsonString.Append("");
                    }
                    else
                    {
                        //JsonString.Append("},");
                        JsonString.Append(",");
                    }
                }
                JsonString.Append("}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }  
        public static string ds2json(DataSet ds)
        {
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
        }
    }
}