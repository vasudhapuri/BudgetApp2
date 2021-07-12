using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpense : ContentPage
    {
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Jul1.json");

        public AddExpense() //constructor
        {
            InitializeComponent();           


        }
        protected override void OnAppearing()
        {

        }

        private void ExpensesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void OnAddExpenseSaveButton_Clicked(object sender, EventArgs e)
        {
            string fileName=null;
            //var exp2 = (Expense)BindingContext;
            var exp2 = new Expense();
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.exp.txt");

                
                if (categorypicker.SelectedItem == null)
                {
                    await DisplayAlert("","Please select a category", "OK"); //validation to catch user's errors
                    return;
                }
                exp2.CategoryName = (categorypicker.SelectedItem).ToString();


                
                if (string.IsNullOrEmpty(AmountSpentEditor.Text.ToString())) //validation to catch user's errors
                {
                    await DisplayAlert("", "Amount cannot be blank", "OK");
                    return;                  

                }
                exp2.CategoryCost = decimal.Parse(AmountSpentEditor.Text.ToString());
                
                if (string.IsNullOrEmpty(Expensenotes.Text)) //validation to catch user's errors
                {
                    DisplayAlert("", "Expense description cannot be blank", "OK");
                    return;

                }
                exp2.CategoryDesc = Expensenotes.Text;
                exp2.Date = PickDateEditor.Date.ToShortDateString();
                if (exp2.CategoryName == "Travel")
                    exp2.CategoryImage = "Travel.png";
                else if (exp2.CategoryName == "EMI")
                    exp2.CategoryImage = "EMI.jfif";
                else if (exp2.CategoryName=="Grocery")
                    exp2.CategoryImage = "Groceries.jfif";
                else if (exp2.CategoryName == "Utility Bills")
                    exp2.CategoryImage = "Bills.png";
                else if (exp2.CategoryName== "Shopping")
                    exp2.CategoryImage = "Shopping.jfif";
                else
                    exp2.CategoryImage= "Miscellaneous.png";

                string serializedJson = JsonConvert.SerializeObject(exp2, Formatting.Indented);
                System.IO.File.WriteAllText(fileName, serializedJson);
            }


            await Navigation.PushAsync( new ShowExpense());
        }

            private async void OnAddExpenseCancelButton_Clicked(object sender, EventArgs e)
            {
               await Navigation.PushAsync(new ShowExpense());
        }
        
    }
}
    
