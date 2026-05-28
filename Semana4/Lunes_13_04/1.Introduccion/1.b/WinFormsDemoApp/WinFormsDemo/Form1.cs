namespace WinFormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = "Apellidos";
            label3.Text = "Full Nanmes";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello World!");
            //MessageBox.Show($"{textBox1.Text}, {textBox2.Text}");
            //textBox3.Text = $"{textBox1.Text}, {textBox2.Text}";
            //progressBar1.Value += 10;
            Form2 form2 = new Form2("Hello desde Form1");
            form2.Show();

            //toolStripProgressBar1.Value += 5;
            //toolStripStatusLabel1.Text = $"Progress: {toolStripProgressBar1.Value}%";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WinForms Demo - Codigo-TECSUP\n\nBy: Gabriel\n\n2024");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
