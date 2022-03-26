using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private bool IsOperatorClicked;
        private double firstNumber;
        string operatorName;
        private void ButtonClear_Clicked(object sender, EventArgs e)
        {
            label.Text = "0";
            firstNumber = 0;
            IsOperatorClicked = false; 
        }
        private void ButtonX_Clicked(object sender, EventArgs e)
        {
            string text = label.Text;
            if (text != "0")
            {
                text = text.Remove(text.Length - 1, 1);
                if (string.IsNullOrEmpty(text))
                {
                    label.Text = "0";
                }
                else
                {
                    label.Text = text;
                }
            }

        }

        private void ButtonPercentage_Clicked(object sender, EventArgs e)
        {
            string num = label.Text;
            double percentage = Convert.ToDouble(num);
            percentage = percentage / 100;
            label.Text = percentage.ToString();
        }

        private void ButtonNumber_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(label.Text == "0" || IsOperatorClicked)
            {
                label.Text = button.Text;
                IsOperatorClicked = false;
            }
            else
            {
                label.Text += button.Text;
            }
        }
        private void ButtonOperation_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsOperatorClicked = true;
            operatorName = button.Text;
            try
            {
                firstNumber = Convert.ToDouble(label.Text);
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }

        }
        private void ButtonEqual_Clicked(object sender, EventArgs e)
        {
            double secondNumber = Convert.ToDouble(label.Text);
            string result = Operation(firstNumber, secondNumber).ToString();
            label.Text = result;
        }
        private void ButtonSquare_Clicked(object sender, EventArgs e)
        {
            double squareNumber = Convert.ToDouble(label.Text);
            squareNumber = squareNumber * squareNumber;
            label.Text = squareNumber.ToString();
        }

        public double Operation(double first, double second)
        {
            double result = 0;
            if(operatorName == "+")
            {
                result = first + second;
            }
            else if(operatorName == "-")
            {
                result = first - second;
            }
            else if(operatorName== "*")
            {
                result = first * second;
            }
            else
            {
                result = first / second;
            }
            return result;
        }
    }
}
