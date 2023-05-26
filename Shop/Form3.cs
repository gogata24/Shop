using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Shop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string st = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (radioButton2.Checked)
            {
                List<string> items = new List<string>();
                using (SqlConnection con = new SqlConnection("Data Source=GEORGI\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;TrustServerCertificate=True"))
                {
                    string qry = "";
                    switch (st)
                    {
                        case "АЛКОХОЛ": { qry = "Select Name from Alcohol"; break; }
                        case "НАПИТКИ": { qry = "Select Name from Drinks"; ; break; }
                        case "СЛАДКИ ИЗДЕЛИЯ": { qry = "Select Name from Sweet"; break; }
                        case "ПЛОДОВЕ И ЗЕЛЕНЧУЦИ": { qry = "Select Name from FruitsVegetables"; break; }
                        case "СНАКС": { qry = "Select Name from Snacks"; break; }


                    }
                    SqlCommand cmd2 = new SqlCommand(qry, con);
                    cmd2.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader reader = cmd2.ExecuteReader())
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            SqlConnection conn = new SqlConnection("Data Source=GEORGI\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;TrustServerCertificate=True") ;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            string st = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (radioButton1.Checked)
            {
                switch (st)
                {
                    case "АЛКОХОЛ": { cmd.CommandText = $"Insert into Alcohol (Name, Stock, Price) values ( '{textBox1.Text}', {int.Parse(textBox2.Text)}, {textBox3.Text})"; break; }
                    case "НАПИТКИ": { cmd.CommandText = $"Insert into Drinks (Name, Stock, Price) values ( '{textBox1.Text}', {int.Parse(textBox2.Text)}, {textBox3.Text})"; ; break; }
                    case "СЛАДКИ ИЗДЕЛИЯ": { cmd.CommandText = $"Insert into Sweet (Name, Stock, Price) values ( '{textBox1.Text}', {int.Parse(textBox2.Text)}, {textBox3.Text})"; break; }
                    case "ПЛОДОВЕ И ЗЕЛЕНЧУЦИ": { cmd.CommandText = $"Insert into FruitsVegetables (Name, Stock, Price) values ( '{textBox1.Text}', {int.Parse(textBox2.Text)}, {textBox3.Text})"; break; }
                    case "СНАКС": { cmd.CommandText = $"Insert into Snacks (Name, Stock, Price) values ( '{textBox1.Text}', {int.Parse(textBox2.Text)}, {textBox3.Text})"; break; }


                }
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        cmd.ExecuteScalar();
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                if (radioButton2.Checked)
                {   
                    string name = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                    using (SqlConnection con = new SqlConnection("Data Source=GEORGI\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;TrustServerCertificate=True"))
                    {                       
                        string qry2 = "";
                        switch (st)
                        {
                            case "АЛКОХОЛ": {  qry2 = $"UPDATE Alcohol SET Stock = Stock+{int.Parse(textBox2.Text)} WHERE Name = '{name}'"; break; }
                            case "НАПИТКИ": {  qry2 = $"UPDATE Drinks SET Stock = Stock+{int.Parse(textBox2.Text)} WHERE Name = '{name}'"; break; }
                            case "СЛАДКИ ИЗДЕЛИЯ": { qry2 = $"UPDATE Sweet SET Stock = Stock+{int.Parse(textBox2.Text)} WHERE Name = '{name}'"; break; }
                            case "ПЛОДОВЕ И ЗЕЛЕНЧУЦИ": { qry2 = $"UPDATE FruitsVegetables SET Stock = Stock+{int.Parse(textBox2.Text)} WHERE Name = '{name}'"; break; }
                            case "СНАКС": { qry2 = $"UPDATE Snacks SET Stock = Stock +{int.Parse(textBox2.Text)} WHERE Name = '{name}'"; break; }


                        }
                        con.Open();
                        cmd = new SqlCommand(qry2, con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteScalar();
                        con.Close();
                    }
                }
            }
            
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label4.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = false;
            label4.Visible = false;
        }
    }
}
