using System;
using System.Collections.Generic;

namespace CalculatorWebApp.Project_Class
{
    public class HistoryClass
    {
        private string history;

        public void AddToHistory(string input)
        {
            history += input + Environment.NewLine;
        }

        public string GetHistory()
        {
            return history;
        }
    }
}
