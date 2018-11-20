using System;
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

        private void btnFactors_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                // Show error
                MessageBox.Show(this, "You must enter a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<int> factorsList = new List<int>();
                int input = Convert.ToInt32(txtNumber.Text);
                for (int divisor = 1; divisor < input; divisor++)
                {
                    if (input % divisor == 0)
                    {
                        if (!factorsList.Contains(divisor))
                        {
                            factorsList.Add(divisor);
                        }
                        int factor = input / divisor;
                        if (!factorsList.Contains(factor))
                        {
                            factorsList.Add(factor);
                        }
                    }
                }

                factorsList.Sort();

                for (int i = 0; i < factorsList.Count; i++)
                {
                    this.txtOutput.Text += (factorsList[i] + Environment.NewLine);
                }
            }
            
        }
    }
}
