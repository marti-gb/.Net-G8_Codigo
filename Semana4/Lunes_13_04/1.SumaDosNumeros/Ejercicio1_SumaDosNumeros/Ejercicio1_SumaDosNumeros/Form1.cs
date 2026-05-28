namespace Ejercicio1_SumaDosNumeros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            primerNumeroText.Text = "";
            segundoNumeroText.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numero1 = Convert.ToInt32(primerNumeroText.Text);
            int numero2 = Convert.ToInt32(segundoNumeroText.Text);

            int resultado = numero1 + numero2;
            resultadoLabel.Text = resultado.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
