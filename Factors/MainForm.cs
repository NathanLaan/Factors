﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factors
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDivisors_Click(object sender, EventArgs e)
        {
            // First, we make sure that the user has entered something
            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                // Show error
                MessageBox.Show(this, "You must enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // This is the input number
                int input = 0;

                // Try and convert the text input into an Integer
                if (Int32.TryParse(txtNumber.Text, out input))
                {
                    // Clear the output
                    this.txtOutput.Clear();

                    // This is the list of output numbers
                    List<int> divisorList = new List<int>();

                    // Loop through all possible divisors less than the input
                    for (int divisor = 1; divisor < input; divisor++)
                    {
                        // If input % divisor is equal to zero, then it divides with no remainder
                        if (input % divisor == 0)
                        {
                            // Don't add the divisor if it's already in the list
                            if (!divisorList.Contains(divisor))
                            {
                                divisorList.Add(divisor);
                            }
                            int factor = input / divisor;
                            if (!divisorList.Contains(factor))
                            {
                                divisorList.Add(factor);
                            }
                        }
                    }

                    // Sort the numbers in the list smallest to largest
                    divisorList.Sort();

                    // Show the numbers to the user.
                    for (int i = 0; i < divisorList.Count; i++)
                    {
                        this.txtOutput.Text += (divisorList[i] + Environment.NewLine);
                    }
                }
                else
                {
                    // Show error
                    MessageBox.Show(this, "You must enter a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
