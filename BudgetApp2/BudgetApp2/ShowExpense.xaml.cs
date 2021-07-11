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

        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Jul.json");
        public ShowExpense()
        {

            InitializeComponent();
             //   Helper.ShowExpense = this;


        }
     

        protected override void OnAppearing()
        {
            var showexplist = new List<Expense>();
            decimal ExpenseSum = 0;

            //System.IO.DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            //foreach (FileInfo file in di.GetFiles())
            //{
            //    file.Delete();
            //}
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.exp.txt");
            if (files.Count()>0)

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
                //ExpenseListView.ItemsSource = showexplist.OrderByDescending(n => n.Date).ToList();

            }
            label1.Text = "$ "+(App.BudgetAmt - ExpenseSum).ToString();

        }

        private async void Add_EditExpenseButton_Clicked(object sender, EventArgs e)
        {
            var ExpPage = new AddExpense();

            await Navigation.PushAsync(ExpPage);

            //await Navigation.PushModalAsync(new AddExpense
            //{
            //    BindingContext = new AddExpense()
            //});
        }

        private void EditBudget_Clicked(object sender, EventArgs e)
        {

       

        }
    }
    }
