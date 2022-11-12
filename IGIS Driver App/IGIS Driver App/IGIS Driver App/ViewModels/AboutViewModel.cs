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
        private string _Stop;
        private string _NextTime;
        private string _PrevTime;

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
            transport = App.currentTransport;
            GetData(transport);
            Device.StartTimer(TimeSpan.FromSeconds(40), () =>
            {
                GetData(transport);
                return true;
            });
        }
        public void GetData(Transport ts)
        {
            API.GetRequest(0, ts.ts_code);
            Debug.WriteLine("Обновление данных с сервера" + DateTime.Now.Minute + DateTime.Now.Second);
            PrevTime = GetTimeNoun(API.GetTimePrev());
            NextTime = GetTimeNoun(API.GetTimeNext());
            GetStopName(API.GetNextStopId());
        }
    }
}