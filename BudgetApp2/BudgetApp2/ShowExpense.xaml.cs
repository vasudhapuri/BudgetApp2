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
    public partial class ShowExpense : ContentPage
    {
        public static int BudgetAmt { get; set; }
        public static int TotalAmtSpent { get; set; }
        public decimal AmountLeft { get; set; }
        public string Category { get; set; }
        public string CategorySpent { get; set; }
     
        public ShowExpense()
        {
            InitializeComponent();
        }

       
        protected override void OnAppearing()
        {
           
        }

        private async void Add_EditExpenseButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new AddExpense
            {
                BindingContext = new AddExpense()
            });

           
        }
    }
}