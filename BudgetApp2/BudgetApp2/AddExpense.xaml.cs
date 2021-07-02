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
    public partial class AddExpense : ContentPage
    {
        public AddExpense()
        {
            InitializeComponent();
        }

        private void CategoriesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

   

        private void ExpCatCost_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void ExpensesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}