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
    public partial class EnterBudget : ContentPage
    {
        public EnterBudget()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            App.BudgetFile = Path.Combine(App.MyPath, "BudgetSetFile.txt"); //creating budget file in folder
            App.IsBudgetSet = true; 
            File.WriteAllText(App.BudgetFile, App.IsBudgetSet.ToString()); //writing 'true' in BudgetSetFile.txt
            using (StreamWriter w = File.AppendText(App.BudgetFile))
            {
                w.Write("=" + int.Parse(SetBudgetEditor.Text)); //eg. true=500 (500 is the budget amt set by user)
            }
            var ExpPage = new ShowExpense();


            await Navigation.PushAsync(ExpPage);

        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            SetBudgetEditor.Text = string.Empty;
        }
    }
}