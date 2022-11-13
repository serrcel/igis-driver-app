using IGIS_Driver_App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Reflection;

namespace IGIS_Driver_App.Data
{
    public class IgisDatabase
    {
        private readonly SQLiteAsyncConnection database;
        public Transport currentTransport;

       public IgisDatabase()
        {
            string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "igis.db");

            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream embededDBStream = assembly.GetManifestResourceStream("IGIS_Driver_App.igis.db");

            if (!File.Exists(DatabasePath))
            {
                FileStream fileStream = File.Create(DatabasePath);
                embededDBStream.Seek(0, SeekOrigin.Begin);
                embededDBStream.CopyTo(fileStream);
                fileStream.Close();
            }

            database = new SQLiteAsyncConnection(DatabasePath);
            database.CreateTableAsync<Transport>().Wait();
            database.CreateTableAsync<Route>().Wait();
            database.CreateTableAsync<Stop>().Wait();
        }

        public Task<List<T>> GetSomethingsAsync<T>() where T : new()
        {
            return database.Table<T>().ToListAsync();
        }

        public Task<Transport> GetTransportAsync(string user_gosnumber)
        {
            return database.Table<Transport>().Where(ts => ts.gosnumber == user_gosnumber).FirstOrDefaultAsync();
        }
        public Task<Stop> GetStopAsync(int stop_id)
        {
            return database.Table<Stop>().Where(stop => stop.StopID == stop_id).FirstOrDefaultAsync();
        }
        public Task<Route> GetRouteAsync(int route_id)
        {
            return database.Table<Route>().Where(route => route.ts_code == route_id).FirstOrDefaultAsync();
        }
        public Task<Transport> GetOneTsAsync()
        {
            return database.Table<Transport>().FirstOrDefaultAsync();
        }

    }
}
