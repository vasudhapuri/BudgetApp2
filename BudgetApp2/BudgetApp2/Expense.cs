using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApp2
{
    public class Expense
    {
        //public enum SpendingCategory
        //{

        //    Bills,
        //    Grocery,
        //    Shopping,
        //    Travel,
        //    EMI

        //}
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public int  CategoryCost { get; set; }       
        public string Date { get; set; }
        public Expense()
        {

        }

       

    }
}


