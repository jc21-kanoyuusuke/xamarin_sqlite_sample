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
            btnInsert.Clicked += btnInsertclicked;
            btnList.Clicked += btnListClicked;

        }

        private async void btnListClicked(object sender, EventArgs e)
        {
            var db = MoneyItemDatabase.getDatabase();

            List<MoneyItem> itemList;

            itemList = await db.GetItemsNotDoneAsync();

            int size = itemList.Count;

            await DisplayAlert("SQLite", size + "件のデータ", "OK");

        }

        private void btnInsertclicked(object sender, EventArgs e)
        {
            var db = MoneyItemDatabase.getDatabase();
            MoneyItem m = new MoneyItem() { ID = 10, Name = "HELLO" };
            db.SaveItemAsync(m);
            DisplayAlert("SQLite", "追加されたよ", "OK");
        }


    }
}
