namespace Shop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
      
            if (textBox1.Text == "12345678")
            {
               
                f2.Show();
                this.Hide();
            }
            else
            {
                label2.Text = "Грешна паролоа! Опитай отново.";
            }
                
        }
    }
}