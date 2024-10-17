using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWebApp.Project_Class
{
    internal class HistoryClass
    {
        private string history;
        public void AddToHistory(string input)
        {
            history += input;
        }
        public string GetHistory()
        {
            return history; 
        }
    }
}
