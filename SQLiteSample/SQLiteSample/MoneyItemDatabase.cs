using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteSample
{
    class MoneyItemDatabase
    {

        readonly SQLiteAsyncConnection database;



        public MoneyItemDatabase(string dbPath)

        {

            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<MoneyItem>().Wait();

        }



        public Task<List<MoneyItem>> GetItemsAsync()

        {

            return database.Table<MoneyItem>().ToListAsync();

        }







        public Task<List<MoneyItem>> GetItemsNotDoneAsync()

        {

            return database.QueryAsync<MoneyItem>("SELECT * FROM [MoneyItem] WHERE [Done] = 0 "

                                                  + " order by [Created] desc"

                                                );

        }



        public Task<MoneyItem> GetItemAsync(int id)

        {

            return database.Table<MoneyItem>().Where(i => i.ID == id).FirstOrDefaultAsync();

        }



        public Task<int> SaveItemAsync(MoneyItem item)

        {

            if (item.ID != 0)

            {

                return database.UpdateAsync(item);

            }

            else

            {

                return database.InsertAsync(item);

            }

        }



        public Task<int> DeleteItemAsync(MoneyItem item)

        {

            return database.DeleteAsync(item);

        }



        private static MoneyItemDatabase db = null;



        public static MoneyItemDatabase getDatabase()

        {

            if (db == null)

            {

                db = new MoneyItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("MoneyItemSQLite.db3"));

            }

            return db;

        }



    }


}

