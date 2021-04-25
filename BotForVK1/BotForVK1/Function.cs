using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BotForVK1
{
    class Function
    {
        static public async Task<HttpResponseMessage> TakeInf(string address, Dictionary<string, string> Params)
        {
            HttpClient client = new HttpClient();

            try
            {
                Uri uri = new Uri(address);
                FormUrlEncodedContent content = new FormUrlEncodedContent(Params);
                var c = client.PostAsync(address, content).Result;
                string Inf = c.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(Inf);
                if (Inf.Contains("Миша") && Inf.Contains("Кольцов"))
                {
                    bool d = true;
                    Kick(d);

                }
                else
                {
                    bool d = false;
                    Kick(d);
                }


            }
            catch (Exception x)
            {
                Console.WriteLine("ОШИБКА:" + x.Message);

            }
            finally
            {
                client.Dispose();
            }
            return null;
        }


        static async void Kick(bool i)
        {
            string adr = "https://api.vk.com/method/messages.removeChatUser/";
            HttpClient client = new HttpClient();
            if (i)
            {

                Console.WriteLine("Дошло до проверки");
                Data data = new Data();
                data.Params["v"] = "5.81";
                data.Params["chat_id"] = "58";
                //айди чата
                data.Params["user_id"] = "349716005";
                //айди человека, которого хочешь кикнуть
                try
                {
                    Console.WriteLine("Проверка");
                    Uri uri = new Uri(adr);
                    FormUrlEncodedContent content = new FormUrlEncodedContent(data.Params);
                    var c = client.PostAsync(adr, content);
                    Console.WriteLine(c.Result);
                    data.Params["v"] = "5.81";
                    data.Params["chat_id"] = "49";
                    //айди чата
                    data.Params["fields"] = "nickname";
                    Thread.Sleep(900000);
                    var b = TakeInf("https://api.vk.com/method/messages.getChat/", data.Params);
                }

                catch (Exception x)
                {
                    Console.WriteLine("Ошибка");
                    Console.WriteLine(x.ToString());
                }

                finally
                {
                    client.Dispose();
                }

            }
            else
            {
                Data data = new Data();
                Console.WriteLine(i);
                data.Params["v"] = "5.81";
                data.Params["chat_id"] = "49";
                //айди чата
                data.Params["fields"] = "nickname";
                Thread.Sleep(900000);
                var b = TakeInf("https://api.vk.com/method/messages.getChat/", data.Params);
            }
        }
    }
}
