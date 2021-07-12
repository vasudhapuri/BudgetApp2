using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowExpense : ContentPage
    {
        public static decimal BudgetAmt { get; set; }
        public static decimal TotalAmtSpent { get; set; }
        public decimal AmountLeft { get; set; }
        public string Category { get; set; }
        public string CategorySpent { get; set; }
        public ObservableCollection<Expense> showexp;

        public ShowExpense()
        {

            InitializeComponent();
            TotalBudgetLabel.Text = "$"+ App.BudgetAmt.ToString();



        }


        protected override void OnAppearing()
        {
            var showexplist = new List<Expense>();
            decimal ExpenseSum = 0;

            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.exp.txt");
            if (files.Count() > 0)

            {
                showexplist.Clear();
                foreach (var filename in files)
                {
                    string text = File.ReadAllText(filename);
                    Expense ex = JsonConvert.DeserializeObject<Expense>(text);
                    showexplist.Add(ex);
                    ExpenseSum = ExpenseSum + ex.CategoryCost;

                }

                ExpenseListView.ItemsSource = showexplist.OrderByDescending(n => DateTime.Parse(n.Date)).ToList();


            }
            label1.Text = "$ " + (App.BudgetAmt - ExpenseSum).ToString();
            TotalBudgetLabel.Text = "$ "+ App.BudgetAmt.ToString();
            AmountSpentLabel.Text = "$ "+ ExpenseSum.ToString();

        }

        private async void AddExpenseButton_Clicked(object sender, EventArgs e)
        {
            var ExpPage = new AddExpense();

            await Navigation.PushAsync(ExpPage);


        }

        private async void EditBudget_Clicked(object sender, EventArgs e)
        {


            await Navigation.PushAsync(new EditBudget());

        }
    }
}
