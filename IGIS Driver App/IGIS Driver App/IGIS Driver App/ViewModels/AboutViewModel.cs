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
        private Route route;
        private Transport transport;
        private string _Stop;
        private string _NextTime;
        private string _PrevTime;
        private object locker = new object();

        private string GetTimeNoun(string time)
        {
            int n = int.Parse(time);
            string s = " минут";
            if (n % 10 == 1) s = " минута";
            if (n % 10 >= 2 && n % 10 <= 4) s = " минуты";
            return s;
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
            transport = new Transport("Aboba202");
            Thread updateThread = new Thread(UpdateInfo);
            updateThread.Start();
        }
        public void GetData(Transport ts)
        {
            API.GetRequest(0, ts.Code);
            PrevTime = API.GetTimePrev() + GetTimeNoun(API.GetTimePrev());
            NextTime = API.GetTimeNext() + GetTimeNoun(API.GetTimePrev());
            Stop = "Следующая остановка: " + API.GetNextStopId();
        }
        private void UpdateInfo()
        {
            while (true)
            {
                try
                {
                    lock(locker) 
                    {
                        Debug.WriteLine("Получение данных с сервера: " + DateTime.Now);
                        GetData(transport);
                        Thread.Sleep(10000);
                    }
                }
                catch 
                {

                }
            }
        }
    }
}