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
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Jul.json");
        //string directory = $@"{location}\Expense.json";          
        public List<Expense> exp1;        
        public AddExpense() //constructor
        {
            InitializeComponent();
            
                exp1 = new List<Expense>
            {
                new Expense
              {
                CategoryName = "Travel",
                CategoryImage = $"Assets/Images/Travel.png",
                CategoryCost = 120,
                Date = "01 / 01 / 2020"
              },
            new Expense
              {
                CategoryName = "Bills",
                CategoryImage = $"Assets/Images/Travel.png",
                CategoryCost = 130,
                Date = "01 / 01 / 2020"
              },
            new Expense
              {
                CategoryName = "EMI",
                CategoryImage = $"Assets/Images/Travel.png",
                CategoryCost = 140,
                Date = "01 / 01 / 2020"
              }
            };



            string serializedJson = JsonConvert.SerializeObject(exp1, Formatting.Indented);
            System.IO.File.WriteAllText(fileName, serializedJson);

            if (File.Exists(fileName))
            {
                string temp = "parul";
            }


        }
        protected override void OnAppearing()
        {

        }
        
        private void ExpensesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
    
