﻿using System;
using System.Windows.Forms;
using CalculatorWebApp.Project_Class;

namespace CalculatorWebApp
{
    public partial class MainForm : Form
    {
        private OperationClass calculator = new OperationClass();
        private HistoryClass history = new HistoryClass();
        private string lastHistory;
        private bool isTaskPerfomed = false;
        private bool hasDecimal = false;

        public MainForm()
        {
            InitializeComponent();
            UC_history.Visible = false;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtCalculator.Text.Equals("0")) //checking if the textbox has a value 0 at the beginning.
            {
                return;
            }
            if (txtCalculator.Text.StartsWith("0")) // check if the first character is a 0.
            {
                if(txtCalculator.Text.Contains("0.")) //check if it has decimal after the 0.
                txtCalculator.Text += "0";
                return; // created so that if this condition is met, it will not proceed.
            }

            txtCalculator.Text += "0";
        }
        private void NumericValue_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtCalculator.Text += btn.Text;
        }
        private void OperatorValue_Click(object sender, EventArgs e)
        {
            isTaskPerfomed = false;
            hasDecimal = false;
            Button operand = (Button)sender;
            AddOperator(operand.Text);
        }
        private void DecimalValue_Click(object sender, EventArgs e)
        {
            if (hasDecimal)
            {
                return;
            }
            if (IsLastCharacterOperator() || txtCalculator.Text.Equals(""))
            {
                txtCalculator.Text += "0";
            }
            Button decim = (Button)sender;
            hasDecimal = true;
            txtCalculator.Text += decim.Text;
        }
        private void btnClear_Click(object sender, EventArgs e) 
        { 
            txtCalculator.Clear(); 
            hasDecimal = false;
            isTaskPerfomed = false;
        }
        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsLastCharacterOperator() || isTaskPerfomed || lastHistory == txtCalculator.Text) 
                {
                    return;
                }
                if (txtCalculator.Text.Contains("/0"))
                {
                    txtCalculator.Text = "Error";
                    return;
                }
                isTaskPerfomed = true;
                double result = calculator.ProcessExpression(txtCalculator.Text);
                lblCurrentHistory.Text = txtCalculator.Text + " =";
                lastHistory = txtCalculator.Text;
                history.AddToHistory(txtCalculator.Text + " = " + result.ToString());
                txtCalculator.Text = result.ToString();
            }
            catch
            {
                return;
            }
        }
        private void AddOperator(string operatorSymbol)
        {
            if (!string.IsNullOrEmpty(txtCalculator.Text) && !IsLastCharacterOperator())
            {
                txtCalculator.Text += operatorSymbol;
            }
        }
        private bool IsLastCharacterOperator()
        {
            return txtCalculator.Text.EndsWith("+") || txtCalculator.Text.EndsWith("-") ||
                   txtCalculator.Text.EndsWith("*") || txtCalculator.Text.EndsWith("/");
        }
        private void btnHistory_Click(object sender, EventArgs e) 
        {
            UC_history.Visible = true;
            UC_history.SetHistory(history);
        }
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (txtCalculator.Text.Length > 0)
            {
                char removedChar = txtCalculator.Text[txtCalculator.TextLength - 1];
                if (removedChar == '.')
                {
                    hasDecimal = false;
                }
                txtCalculator.Text = txtCalculator.Text.Remove(txtCalculator.TextLength - 1, 1);
            }
        }     
    }
}
