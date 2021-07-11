using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBudget : ContentPage
    {
        public static string MyPath { get; set; }
        public EditBudget()
        {
            InitializeComponent();
        }

        private async void OnEditExpenseSaveButton_Clicked(object sender, EventArgs e)
        {
            //    MyPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //    App.BudgetFile = Path.Combine(App.MyPath, "BudgetSetFile.txt");
            //    if (File.Exists(App.BudgetFile))
            //    {
            //string BudgetFileText = File.ReadAllText(App.BudgetFile);//read text from budgetfile
            //var splitarr = BudgetFileText.Split('=');
            //App.BudgetSetOrNot = splitarr[0];

            //if (App.BudgetSetOrNot == "True")
            //{
            App.BudgetAmt = decimal.Parse(EditBudgetEditor.Text);
            //App.BudgetAmt = decimal.Parse(splitarr[1]);
            //ShowExpense.label1.Text=
            await Navigation.PushAsync(new ShowExpense());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new EnterBudget());
            //}
        }

        private async void OnEditExpenseCancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowExpense());
        }
    }
}

