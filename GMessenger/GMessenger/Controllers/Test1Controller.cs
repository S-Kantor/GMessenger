using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using GMessenger.Models;

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
        [System.Web.Http.ActionName("GetGroup")]
        public PasswordModel GetGroup(string id)
        {
            PasswordModel pm = new PasswordModel();
            pm.isError = true;
            try
            {
                string[] info = id.Split(',');

                string group_name = info[0];
                string group_password = info[1];

                gconnectdbEntities db = new gconnectdbEntities();
           

                var a = (from e in db.Groups
                         where e.group_name.ToUpper().Equals(group_name.ToUpper()) && e.group_user_pass.ToUpper().Equals(group_password.ToUpper())
                         select e).ToList();


                if (a.Count > 0)
                {
                    pm.group_id = a.FirstOrDefault().group_id;
                    pm.isError = false;
                }

                return pm;
            }
            catch (Exception ex)
            {
                return pm;
            }
        }

        [System.Web.Http.ActionName("GetMessage")]
        public MessageModel GetMessage(string id)
        {
            try
            {
                string[] info = id.Split(',');

                string groupNo = "";
                string messageNo = "";
                int group2 = -1;
                int message = -1;

                if(info.Count() > 0)
                {
                    groupNo = info[0];
                    group2 = Int32.Parse(groupNo);
               
                }
                if(info.Count() > 1)
                {
                    messageNo = info[1];
                    message = Int32.Parse(messageNo);
                }
                
                gconnectdbEntities db = new gconnectdbEntities();



                var msgs = (from e in db.Messages
                            where e.group_id.Equals(group2)
                             select e).ToList();

                string messageText = "";

                if (msgs.Count > 0)
                {
                    if (message == -1)
                    {
                        messageText = msgs.Last().text;
                    }
                    else
                    {
                        try
                        {
                            messageText = msgs.FirstOrDefault(m => m.message_id.Equals(message)).text;
                        }
                        catch(Exception)
                        {
                            messageText = "This message doesn't exist";
                        }
                    }
                }

                MessageModel msgModel = new MessageModel();
                msgModel.text = messageText;
                msgModel.lastMessage = msgs.Count;
                msgModel.isError = false;

                return msgModel;
            }
            catch (Exception ex)
            {
                MessageModel msgModel = new MessageModel();
                msgModel.isError = true;
                msgModel.lastMessage = 0;
                msgModel.text = "You sent:" + id + " an exception happened " + ex.Message;
                return msgModel;
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
