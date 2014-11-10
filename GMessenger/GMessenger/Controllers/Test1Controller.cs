using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GMessenger.Controllers
{
    public class Test1Controller : ApiController
    {
        // GET: api/Test1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test1/5
        [System.Web.Http.ActionName("GetLastCount")]
        public string GetLastCount(string id)
        {
            // return "10";
            try
            {
                gconnectdbEntities db = new gconnectdbEntities();
           

                var a = (from e in db.Messages
                         select e).ToList();

                string txtsummary = "";

                foreach (var m in a)
                {
                    txtsummary += m.text + ";";
                }

                return txtsummary;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [System.Web.Http.ActionName("GetMessage")]
        public string GetMessage(string id)
        {
            try
            {
                string[] info = id.Split(',');
                return "This is a content of a sample message for group" + info[0] + "and id" + info[1];
            }
            catch (Exception ex)
            {
                return "You sent:" + id + " an exception happened " + ex.Message;
            }
        }

        // POST: api/Test1
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test1/5
        public void Delete(int id)
        {
        }
    }
}
