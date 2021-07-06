using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string Category;
        public string CategoryImage;
        public ObservableCollection<AddExpense> expenses;
        public AddExpense()
        {
            InitializeComponent();
            expenses = new ObservableCollection<AddExpense>();
            expenses.Add(new AddExpense
            {
                Category = "Grocery",
                CategoryImage = $@"Assets/Groceries.jfif"

            });
            expenses.Add(new AddExpense
            {
                Category = "Travel",
                CategoryImage = $@"Assets/Travel.png"

            });
            
        }

     

        
    }
}