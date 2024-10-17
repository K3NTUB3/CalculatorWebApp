using CalculatorWebApp.Project_Class;
using System;
using System.Windows.Forms;

namespace CalculatorWebApp
{
    public partial class UC_history : UserControl
    {
        public UC_history()
        {
            InitializeComponent();
        }

        public void SetHistory(HistoryClass history)
        {
            txtHistory.Text = history.GetHistory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
