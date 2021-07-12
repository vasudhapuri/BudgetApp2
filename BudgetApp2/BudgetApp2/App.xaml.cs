using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetApp2
{
    public partial class App : Application
    {
        public static string MyPath { get; set; }
        public static string BudgetFile { get; set; }
        public static bool IsBudgetSet { get; set; }
        public static string BudgetSetOrNot { get; set; }        
        
           public static decimal BudgetAmt { get; set; }
        
        public App()
        {
          //  for deletion of files
            System.IO.DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            InitializeComponent();
            MainPage = new NavigationPage(new EnterBudget());

            MyPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);             
            App.BudgetFile = Path.Combine(App.MyPath, "BudgetSetFile.txt");
            if (File.Exists(BudgetFile))
            {
                string BudgetFileText = File.ReadAllText(BudgetFile);
                var splitarr = BudgetFileText.Split('=');
                BudgetSetOrNot = splitarr[0];

                if (BudgetSetOrNot == "True")
                {
                    BudgetAmt = decimal.Parse(splitarr[1]);
                    MainPage = new NavigationPage(new ShowExpense());
                }
                else
                {
                    MainPage = new NavigationPage(new EnterBudget());
                }
            }
        }

        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
