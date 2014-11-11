using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMessenger.Models
{
    public class MessageModel
    {
        public string text;
        public int lastMessage;
        public bool isError;

        public MessageModel()
        {
            text = "";
            lastMessage = 0;
            isError = false;
        }
    }

    public class PasswordModel
    {
        public int group_id;
        public bool isError;

        public PasswordModel()
        {
            group_id = -1;
            isError = false;
        }
    }
}