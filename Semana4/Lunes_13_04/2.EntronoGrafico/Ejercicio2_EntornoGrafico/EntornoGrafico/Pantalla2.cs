using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntornoGrafico
{
    public partial class Pantalla2 : Form
    {
        private Persona person;
        public Pantalla2()
        {
            InitializeComponent();
            person = new Persona();
        }

        public Persona Person
        {
            get { return person; }
            set { person = value; }
        }

        private void Pantalla2_Load(object sender, EventArgs e)
        {
            labelNombre.Text = person.Nombre;
            labelApellido.Text = person.Apellido;
            labelEdad.Text = Convert.ToString(person.Edad);
            labelDireccion.Text = person.Direccion;
            labelGenero.Text = person.Genero;

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
