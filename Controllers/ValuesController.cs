using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eshu_api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;




namespace eshu_api.Controllers
{
    public class ValuesController : ApiController
    {
        
        // GET api/values
        devtestdbEntities db = new devtestdbEntities();
        public List<SEND_EMAIL_BULK> Get()
        {
            SEND_EMAIL_BULK sEND_EMAIL = new SEND_EMAIL_BULK();
            List<SEND_EMAIL_BULK> esws = new List<SEND_EMAIL_BULK>();
            esws.AddRange((from esw in db.SEND_EMAIL_BULK
                          where esw.SEB_STATUS==1
                          select new SEND_EMAIL_BULK
                          {
                              HOST_EMAIL_ID=esw.HOST_EMAIL_ID,
                              HOST_PWD=esw.HOST_PWD
                          }));
            return esws;
        }
        // GET api/values/5
        public string Get(int id)
        {
            var list = from esw in db.SEND_EMAIL_BULK
                       where esw.ID==id
                       select new
                       {
                           esw.ID,
                           esw.HOST_EMAIL_ID,
                           esw.HOST_PWD
                       };
            string json = JsonConvert.SerializeObject(list);
            return json;
        }

        // POST api/values
        
        public string Insert(string Email,string pwd)
        {
            db.INSERT_EMAILS(hOST_EMAIL_ID: Email, hOST_PWD: pwd);
            var list = from esw in db.SEND_EMAIL_BULK
                       where esw.HOST_EMAIL_ID == Email
                       select esw;
            return list.ToString();
        }

        // PUT api/values/5
        public string Put(int id,string eMAIL,string pwd)
        {
            db.UPDATE_EMAILS(hOST_EMAIL_ID: eMAIL, hOST_PWD: pwd, iD: id);
            //var list = from esw in db.SEND_EMAIL_BULK
            //           where esw.ID == id
            //           select esw;
            string json = JsonConvert.SerializeObject(Get(id: id));
            return json;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            db.DELETE_EMAILS(iD: id);
            var list = from esw in db.SEND_EMAIL_BULK
                       where esw.ID == id
                       select esw;
            return list.ToString();
            
        }
    }
}
