using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;



namespace BotForVK1
{



    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            data.Params["v"] = "5.130";
            data.Params["chat_id"] = "58";
            //айди чата нужно писать вот выше

            var c =Function.TakeInf("https://api.vk.com/method/messages.getChat/", data.Params);
            Console.WriteLine(c);
        }

    }
}
