using System.Collections;

namespace WinFormsApp1
{
    public partial class FrmVentas : Form
    {
        //Inicializar arreglo de producto
        static string[] produtos = { "Celular", "Laptop", "Monitor", "Televisor", "Lavadora" };

        //Objecto de la clase ArrayList
        //listProducts es ahora una colección (tipo lista dinámica) que contiene los productos
        //y que puede crecer o cambiar en tiempo de ejecución, a diferencia de un arreglo fijo.
        ArrayList listProducts = new ArrayList(produtos);

        //Objeto de la clase ventas
        Ventas ventas = new Ventas();

        double total;
        public FrmVentas()
        {
            InitializeComponent();
            MostrarFecha();
            MostrarHora();
            LimpiarCampos();
            LLenarProducto();
        }


        private void MostrarFecha()
        {
            labelFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void MostrarHora()
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void LimpiarCampos()
        {
            textBoxCliente.Clear();
            comboBoxProducto.Text = "Selecccione un producto";
            textBoxCantidad.Clear();
            labelPrecio.Text = "0.00";
            textBoxCliente.Focus();
        }

        private void LLenarProducto()
        {
            foreach (var item in listProducts)
            {
                comboBoxProducto.Items.Add(item);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea salir..?", "Ventas", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void comboBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ventas.Producto = comboBoxProducto.Text;
            labelPrecio.Text = ventas.AsignarPrecio().ToString("C");
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            //Enviar datos a la clase ventas
            ventas.Producto = comboBoxProducto.Text;
            ventas.Cantidad = int.Parse(textBoxCantidad.Text);

            //Imprimir resultados
            //Crea una fila de datos que se va a mostrar en un control visual
            //llamado ListView (un tipo de tabla en Windows Forms).

            //Crea una nueva fila (fila) para la tabla ListView.

            //Columnna principal -> Producto
            ListViewItem fila = new ListViewItem(ventas.Producto);

            //SubItems representa las columnas adicionales de una fila (ListViewItem) en un ListView.
            fila.SubItems.Add(ventas.Cantidad.ToString());
            fila.SubItems.Add(ventas.AsignarPrecio().ToString("C"));
            fila.SubItems.Add(ventas.CalcularSubTotal().ToString("C"));
            fila.SubItems.Add(ventas.CalcularDescuento().ToString("C"));
            fila.SubItems.Add(ventas.CalcularNeto().ToString("C"));

            listViewRegistro.Items.Add(fila);

            // Suma de producto
            total += ventas.CalcularNeto();

            //Imprimir totales
            labelTotalNeto.Text = total.ToString("C");


            //Limpiar campos
            LimpiarCampos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
