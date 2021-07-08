using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

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
        public ObservableCollection<Expense> showexp;

        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Jul.json");
        public ShowExpense()
        {
            InitializeComponent();
           
            if (File.Exists(fileName))
            
                  {
                    string Text = System.IO.File.ReadAllText(fileName);
                    List<Expense> expenses = JsonConvert.DeserializeObject<List<Expense>>(Text);

                showexp = new ObservableCollection<Expense>();
                foreach (var ele in expenses)
                    showexp.Add(ele);

                }


            }
     

        protected override void OnAppearing()
        {
            if (File.Exists(fileName))

            {
                string Text = System.IO.File.ReadAllText(fileName);
                List<Expense> expenses = JsonConvert.DeserializeObject<List<Expense>>(Text);

                showexp = new ObservableCollection<Expense>();
                foreach (var ele in expenses)
                    showexp.Add(ele);

            }


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



        }
    }
