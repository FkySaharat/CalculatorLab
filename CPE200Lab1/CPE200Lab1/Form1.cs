using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        int i=0;
        double Firstnum=0;
        double Secondnum = 0;
        double result = 0;

        public Form1()
        {
            InitializeComponent();
        }

       
        

        private void btnClear_Click(object sender, EventArgs e)
        {   
            lblDisplay.Text ="0";
            i = 0;
            dot = 0;
        }
     

        private void btnEqual_Click(object sender, EventArgs e)
        {
           
            Secondnum= Double.Parse(lblDisplay.Text);
            if (btn_Operator == "+")
            {
                result=Firstnum + Secondnum;
            }
            else if (btn_Operator == "-")
            {
                result = Firstnum - Secondnum;
            }
            else if(btn_Operator == "X")
            {
                result = Firstnum * Secondnum;
            }
            else if(btn_Operator == "÷")
            {
                if(Firstnum==0 && Secondnum == 0)
                {
                    Firstnum = 1;
                }
                result = Firstnum / Secondnum;
            }
             Firstnum = result;


            int width = Convert.ToString(result).Length;
            if (width>7)
            {
                result = Math.Round(result, 2);
                if (result > 99999999)
                {
                    result = result / Math.Pow(10, width-1);
                    result = Math.Round(result, 2);
                    lblDisplay.Text = Convert.ToString(result) + "*(10^" + Convert.ToString(width-1)+")";
                    if (lblDisplay.Text.Length > 8)
                    {
                        lblDisplay.Text = "Error";

                    }
                }
                else
                {

                    lblDisplay.Text = Convert.ToString(result);
                }
       
            }
            
            else
            {
                lblDisplay.Text = Convert.ToString(result);
            }

            dot = 0;
            i = 5;
        }

       

        private void btnNumber_Click(object sender, EventArgs e)
        {
            
            if (i == 5)
            {
                i = 0;
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8) { 
                if (lblDisplay.Text == "0")
                {
                    
                    lblDisplay.Text = ((Button)sender).Text;
                }
                else
                {
                lblDisplay.Text = lblDisplay.Text + ((Button)sender).Text;
                }
            }
        }

        string btn_Operator=" ";
        private void btnOperatort_Click(object sender, EventArgs e)
        {
            btn_Operator=((Button)sender).Text;
            if (i == 0)
            {   
                Firstnum = Convert.ToDouble(lblDisplay.Text);
            }
           
            lblDisplay.Text = " ";
            dot = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            
            if (lblDisplay.Text == " ")
            {
               lblDisplay.Text=Convert.ToString(Firstnum * (Firstnum / 100.00));
                
            }
            else
            {
                double hold = Convert.ToDouble(lblDisplay.Text);
                lblDisplay.Text = Convert.ToString(Firstnum * (hold / 100.00));
            }
        }

        int dot = 0;
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (dot == 0)
            {
                if (lblDisplay.Text == "0" || lblDisplay.Text == " ")
                {
                    lblDisplay.Text = "0" + ".";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + ".";
                }

                dot = 1;
            }
        }
    }
}
