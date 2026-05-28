namespace EntornoGrafico
{
    public partial class FormPrincipal : Form
    {
        private ControladorPersona controladorPersona;
        private Persona persona;
        private List<Persona> personaList;
        public FormPrincipal()
        {
            InitializeComponent();
            controladorPersona = new ControladorPersona();
            persona = new Persona();
            personaList = new List<Persona>();

        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            Persona newPersona = new Persona();
            newPersona.Nombre = nombreTextBox.Text;
            newPersona.Apellido = apellidoTextBox.Text;
            newPersona.Edad = Convert.ToInt32(edadTextBox.Text);
            newPersona.Direccion = direccionTextBox.Text;
            newPersona.Genero = Convert.ToString(comboBoxGenero.Items[comboBoxGenero.SelectedIndex]);

            persona = newPersona;
            controladorPersona.AgregarPersona(persona);
            personaList = controladorPersona.ObtenerPersonas();

            MessageBox.Show("Bienvenido/a al sistema " + newPersona.Nombre + " " + newPersona.Apellido + " de " + newPersona.Edad + " años de edad.");

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            nombreTextBox.Text = "";
            apellidoTextBox.Text = "";
            edadTextBox.Text = "";
            direccionTextBox.Text = "";
            comboBoxGenero.SelectedIndex = 0;

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPantallaDos_Click(object sender, EventArgs e)
        {
            Pantalla2 pantalla2 = new Pantalla2();
            pantalla2.Person = persona;
            pantalla2.ShowDialog();
        }

        private void buttonPantallaTres_Click(object sender, EventArgs e)
        {
            Pantalla3 pantalla3 = new Pantalla3();
            pantalla3.PersonaList = personaList;
            pantalla3.ShowDialog();
        }
    }
}
