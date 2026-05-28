namespace BetterWindowsFormDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{firstNameTextBox.Text} {textBox1.Text}");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
