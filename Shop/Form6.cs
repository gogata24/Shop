using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Form6 : Form
    {
              
        public Form6()
        { 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (var x in Form4.products)
            {
                listBox1.Items.Add($"{x.Name} - {x.Price} - {x.Stock}");
            }
        }
    }
}
