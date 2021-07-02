using System;
using System.Collections.Generic;
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

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //BudgetSet = true;


            Navigation.PushAsync(new ShowExpense());
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            SetBudget.Text = string.Empty;
        }
    }
}