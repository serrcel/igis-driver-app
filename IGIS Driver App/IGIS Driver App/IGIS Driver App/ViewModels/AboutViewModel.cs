using IGIS_Driver_App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IGIS_Driver_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private Transport transport;
        private TelegramMessage telegramMessage;
        public Command SendMSG { get; }
        private string _Stop;
        private string _NextTime;
        private string _PrevTime;
        private string _CurTS;

        public void OnSendMsgClicked(object obj)
        {
            string message = obj.ToString();
            telegramMessage.SendReport(message, CurTS, _Stop);
        }

        private string GetTimeNoun(string time)
        {
            int time_val = int.Parse(time);
            var value = Math.Abs(time_val) % 100;
            var num = value % 10;
            if (value > 10 && value < 20) return time + " минут";
            if (num > 1 && num < 5) return time + " минуты";
            if (num == 1) return time + " минута";
            return time + " минут";
        }
        private async void GetStopName(string stop_id)
        {
            int stopID = int.Parse(stop_id);
            Stop stop = await App.InternalDB.GetStopAsync(stopID);
            if (stop != null)
            {
                Stop = stop.ShortName;
            }
            
        }
        private async void GetRoute(string route_id)
        {
            int routeID = int.Parse(route_id);
            Route route =  await App.InternalDB.GetRouteAsync(routeID);
            if (route != null)
            {
                if (route.RouteTransportType == "bus")
                    CurTS = "Автобус " + route.RouteSignature;
                else
                    CurTS = "Троллейбус " + route.RouteSignature;
            }

        }
        public string CurTS
        {
            get { return _CurTS; }
            set { _CurTS = value; OnPropertyChanged("CurTS"); }
        }
        public string Stop
        {
            get { return _Stop; }
            set { _Stop = value; OnPropertyChanged("Stop"); }
        }
        public string NextTime
        {
            get { return _NextTime; }
            set { _NextTime = value; OnPropertyChanged("NextTime"); }
        }
        public string PrevTime
        {
            get { return _PrevTime; }
            set { _PrevTime = value; OnPropertyChanged("PrevTime"); }
        }

        public AboutViewModel()
        {
            telegramMessage = new TelegramMessage();
            SendMSG = new Command(OnSendMsgClicked);
            transport = App.currentTransport;
            GetData(transport);
            DeviceDisplay.KeepScreenOn = true;
            Device.StartTimer(TimeSpan.FromSeconds(15), () =>
            {
                GetData(transport);
                return true;
            });
        }
        public async void GetData(Transport ts)
        {
            try
            {
                await API.GetReq(0, ts.ts_code);
                Debug.WriteLine("Обновление данных с сервера");
                PrevTime = GetTimeNoun(API.GetTimePrev());
                NextTime = GetTimeNoun(API.GetTimeNext());
                GetStopName(API.GetNextStopId());
                GetRoute(API.GetRouteId());
            }
            catch
            {
                Debug.WriteLine("Ошибка с апи");
            }
        }
    }
}