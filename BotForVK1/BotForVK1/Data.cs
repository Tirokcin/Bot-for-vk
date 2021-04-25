using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForVK1
{
    class Data
    {
        public Dictionary<string, string> Params = new Dictionary<string, string>()
        {
            {"access_token", "менять это"},
            //меняй токен на свой, если хочешь на себе или на токен группы
            {"v", ""},
            {"chat_id", ""},
            {"fields", ""},
            {"user_id", "" },
        };
    }
}
