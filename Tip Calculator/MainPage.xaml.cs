/*************************************************/
/* Name: Alfin Rahardja                          */
/* Class: CS 364                                 */
/* Due-date: Feb 11, 2016                        */
/*************************************************/

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Tip_Calculator
{
    /// This program calculates the total amount customers pay for their meal.
    /// The program asks for the bill amount and tip amount,
    /// then calculates the total amount they must pay.
    public sealed partial class MainPage : Page
    {
        // Constant variables
        const float PERCENT_1 = 0.15f;
        const float PERCENT_2 = 0.18f;
        const float PERCENT_3 = 0.20f;
        const float PERCENT_4 = 0.25f;

        // Member variables
        float tip;
        float checkAmount;
        float totalAmount;

        public MainPage()
        {
            this.InitializeComponent();
        }

        // Check the bill amount whether it is a numeric value
        private void billAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            String billInput = billAmount.Text.Trim();
            float billValid;
            bool isBillValid = float.TryParse(billInput, out billValid);
            try
            {
                if (isBillValid)
                {
                    if(float.Parse(billAmount.Text) < 0.0f)
                    {
                        throw new ArgumentOutOfRangeException("Bill Amount");
                    } 
                    errorMessage.Text = "";
                    checkAmount = float.Parse(billAmount.Text);
                    totalCalculation();
                }
                else if(billAmount.Text.Length == 0)
                {
                    errorMessage.Text = "";
                    checkAmount = 0.0f;
                    totalCalculation();
                }
                else
                {
                    errorMessage.Text = "You enter invalid input! Please enter a numeric value.";
                    checkAmount = 0.0f;
                    totalCalculation();
                }
            }
            catch(Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        // Check the tip amount whether the input is a numeric value
        private void tipAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            String tipInput = tipAmount.Text.Trim();
            float tipValid;
            bool isTipValid = float.TryParse(tipInput, out tipValid);
            try
            {
                if (isTipValid)
                {
                    if (float.Parse(tipAmount.Text) < 0.0f)
                    {
                        throw new ArgumentOutOfRangeException("Tip Amount");
                    }
                    errorMessage2.Text = "";
                    tip = float.Parse(tipAmount.Text);
                    totalCalculation();
                }
                else if(tipAmount.Text.Length == 0)
                {
                    errorMessage2.Text = "";
                    tip = 0.0f;
                    totalCalculation();
                }
                else
                {
                    errorMessage2.Text = "You enter invalid input! Please enter a numeric value.";
                    tip = 0.0f;
                    totalCalculation();
                }
            }
            catch(Exception ex)
            {
                errorMessage2.Text = ex.Message;
            }
        }

        // Calculate the tip amount if the tip percentage is 15%
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            tip = checkAmount * PERCENT_1;
            tipAmount.Text = tip.ToString("###,##0.00");
            totalCalculation();
        }

        // Calculate the tip amount if the tip percentage is 18%
        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            tip = checkAmount * PERCENT_2;
            tipAmount.Text = tip.ToString("###,##0.00");
            totalCalculation();
        }

        // Calculate the tip amount if the tip percentage is 20%
        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            tip = checkAmount * PERCENT_3;
            tipAmount.Text = tip.ToString("###,##0.00");
            totalCalculation();
        }

        // Calculate the tip amount if the tip percentage is 25%
        private void radioButton4_Checked(object sender, RoutedEventArgs e)
        {
            tip = checkAmount * PERCENT_4;
            tipAmount.Text = tip.ToString("###,##0.00");
            totalCalculation();
        }

        // Calculate the total amount after adding the tip amount
        private void totalCalculation()
        {
            totalAmount = checkAmount + tip;
            billTotal.Text = totalAmount.ToString("$###,##0.00");
        }
    }
}
