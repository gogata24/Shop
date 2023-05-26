using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Shop
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            using (SqlConnection con = new SqlConnection("Data Source=GEORGI\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;TrustServerCertificate=True"))
            {
                string qry = "";
                string st = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                switch (st)
                {
                    case "АЛКОХОЛ": { qry = "Select Name from Alcohol"; break; }
                    case "НАПИТКИ": { qry = "Select Name from Drinks"; ; break; }
                    case "СЛАДКИ ИЗДЕЛИЯ": { qry = "Select Name from Sweet"; break; }
                    case "ПЛОДОВЕ И ЗЕЛЕНЧУЦИ": { qry = "Select Name from FruitsVegetables"; break; }
                    case "СНАКС": { qry = "Select Name from Snacks"; break; }


                }
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string item = reader.GetString(0);
                            items.Add(item);
                        }
                    }
                }
                con.Close();
            }
            comboBox2.Items.Clear();
            foreach (var x in items)
            {
                comboBox2.Items.Add(x);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stock = "";
            string st = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            string name = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            using (SqlConnection con = new SqlConnection("Data Source=GEORGI\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;TrustServerCertificate=True"))
            {
                string qry = "";

                switch (st)
                {
                    case "АЛКОХОЛ": { qry = $"Select Stock from Alcohol where Name = '{name}'"; break; }
                    case "НАПИТКИ": { qry = $"Select Stock from Drinks where Name = '{name}'"; break; }
                    case "СЛАДКИ ИЗДЕЛИЯ": { qry = $"Select Stock from Sweet where Name = '{name}'"; break; }
                    case "ПЛОДОВЕ И ЗЕЛЕНЧУЦИ": { qry = $"Select Stock from FruitsVegetables where Name = '{name}'"; break; }
                    case "СНАКС": { qry = $"Select Stock from Snacks where Name = '{name}'"; break; }


                }
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {


                    List<string> prices = new List<string>();
                    
                    while (reader.Read())
                    {
                        if (st == "ПЛОДОВЕ И ЗЕЛЕНЧУЦИ")
                            stock = reader.GetDecimal(0).ToString("f2");
                        else
                            stock = reader.GetInt32(0).ToString("f2");

                    }
                    
                }
                con.Close();
                listBox1.Items.Add($"Product: {name}, quantity: {Math.Round( double.Parse(stock),0)}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
