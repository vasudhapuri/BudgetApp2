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
            EditBudgetEditor.Text = App.BudgetAmt.ToString();
        }

        private async void OnEditExpenseSaveButton_Clicked(object sender, EventArgs e)
        {
            App.BudgetFile = Path.Combine(App.MyPath, "BudgetSetFile.txt"); //creating budget file in folder
            App.IsBudgetSet = true;
            File.Delete(App.BudgetFile);
            File.WriteAllText(App.BudgetFile, App.IsBudgetSet.ToString()); //writing 'true' in BudgetSetFile.txt
            using (StreamWriter w = File.AppendText(App.BudgetFile))
            {
                w.Write("=" + decimal.Parse(EditBudgetEditor.Text)); //eg. true=500 (500 is the budget amt set by user)
                App.BudgetAmt = decimal.Parse(EditBudgetEditor.Text);
            }
            var ExpPage = new ShowExpense();


            await Navigation.PushAsync(ExpPage);


        }

        private async void OnEditExpenseCancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowExpense());
        }
    }
}

