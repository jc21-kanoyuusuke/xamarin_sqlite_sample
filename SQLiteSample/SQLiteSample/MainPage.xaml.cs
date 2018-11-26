using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnInsert1.Clicked += btnInsertclicked1;
            btnInsert2.Clicked += btnInsertclicked2;
            btnList.Clicked += btnListClicked;

        }

        private async void btnListClicked(object sender, EventArgs e)
        {
            var db = MoneyItemDatabase.getDatabase();

            List<MoneyItem> itemList;

            //            itemList = await db.GetItemsNotDoneAsync();
            itemList = await db.GetItemsAsync();

            int size = itemList.Count;

            await DisplayAlert("SQLite", size + "件のデータ", "OK");

        }

        private void btnInsertclicked1(object sender, EventArgs e)
        {
            var db = MoneyItemDatabase.getDatabase();
            MoneyItem m = new MoneyItem() { ID = 10, Name = "HELLO"　, Done=true };
            db.SaveItemAsync(m);
            DisplayAlert("SQLite", "追加されたよ", "OK");
        }
        private void btnInsertclicked2(object sender, EventArgs e)
        {
            var db = MoneyItemDatabase.getDatabase();
            MoneyItem m = new MoneyItem() { ID = 20, Name = "HELLO", Done = false };
            db.SaveItemAsync(m);
            DisplayAlert("SQLite", "追加されたよ", "OK");
        }


    }
}
