using System;
using System.Collections.Generic;
using System.Text;
using IGIS_Driver_App.DBModels;
using SQLite;
using SQLitePCL;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace IGIS_Driver_App
{
    public class InternalDB
    {
        private readonly SQLiteAsyncConnection database;

        public InternalDB(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Carrier>();
            database.CreateTableAsync<City>();
            database.CreateTableAsync<Route>();
            database.CreateTableAsync<Stage>();
            database.CreateTableAsync<Stop>();
            database.CreateTableAsync<Subroute>();
        }

        public Task<List<T>> GetSomethingsAsync<T>()
            where T : new() // required to avoid error CS0310 about T having to be
                            // non-abstract public type with a public parameterless constructor;
                            // might also be bad and/or dangerous for some reason
                            // in that case will have to have GetSomething functions
                            // for each table and I'd rather not do that
                            // even if they're THAT tiny
                            // would look meh
        {
            return database.Table<T>().ToListAsync();
        }

        public void SaveSomethingAsync<T>(T something)
            where T : new()
        {
            database.InsertAsync(something);
        }

        // other stuff shoudln't be too hard to add later as we need it
    }
}
