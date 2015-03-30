using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoursCount
{
    
    public partial class HoursCount : Form
    {
        float runningTotal = 0f;
        float cumTotal = 0f;
        int entries = 0;
        string lastValue0;
        string lastValue1;
        string priorValue0;
        string priorValue1;
        

        public HoursCount()
        {
            this.InitializeComponent();
            base.ActiveControl = this.textBox1;
            label1.Text = "0.00";
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            undoBtn.Enabled = false;
            priorValue0 = "";
            priorValue1 = "";
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                     
            
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = ":";
            string text = this.textBox1.Text;
            string str3 = this.textBox2.Text;
            priorValue0 = lastValue0;
            priorValue1 = lastValue1;
            lastValue0 = text;
            lastValue1 = str3;
           
            if ((text == "") | (str3 == ""))
            {
                MessageBox.Show("Fields can not be blank!");
            }
            else
            {
                int num;
                int num2;
                int num3;
                int num4;
                string[] strArray = text.Split(new string[] { str }, StringSplitOptions.None);
                string[] strArray2 = str3.Split(new string[] { str }, StringSplitOptions.None);
                bool flag = int.TryParse(strArray[0], out num);
                bool flag2 = int.TryParse(strArray[1], out num2);
                bool flag3 = int.TryParse(strArray2[0], out num3);
                bool flag4 = int.TryParse(strArray2[1], out num4);
                int num5 = num3 - num;
                int num6 = num4 - num2;
                float num7 = num6;
                if (num7 < 0f)
                {
                    num7 += 60f;
                    num5--;
                }
                float num8 = num7 / 60f;

                this.runningTotal = num5 + num8;
                this.cumTotal += this.runningTotal;
                this.label1.Text = this.cumTotal.ToString("N2");
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                base.ActiveControl = this.textBox1;
                undoBtn.Enabled = true;
                entries++;
                label5.Text = "Entries: " +entries;
                label6.Text = "Last Entries: "+lastValue0+ ", " +lastValue1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            this.cumTotal = this.cumTotal - this.runningTotal;
            this.label1.Text = this.cumTotal.ToString("N2");
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            undoBtn.Enabled = false;
            entries--;
            label5.Text = "Entries: " +entries;
            lastValue0 = priorValue0;
            lastValue1 = priorValue1;
            label6.Text = "Last Entries: " + lastValue0 + ", " + lastValue1;
        }

    }
}
