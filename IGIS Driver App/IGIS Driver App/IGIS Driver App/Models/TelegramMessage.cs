using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IGIS_Driver_App.Models
{
    public class TelegramMessage
    {
        private string token = "https://api.telegram.org/bot5615188519:AAEMwlqjNpyUiFXlRbrPhtOGnTPDu35Lh68/sendMessage?chat_id=-1001899412406&text=";
        string chat_id = "429523468";
        string methodName = "";
        private HttpWebRequest request;

        public void SendReport(string message, string tsNum, string currStop)
        {
            using (var client = new HttpClient())
            {
                string fullMessage = $"{tsNum} ост. {currStop} - {message}";
                string resUrl = token + fullMessage;
                client.GetAsync(resUrl).Wait();
            }
            
        }
    }
}
