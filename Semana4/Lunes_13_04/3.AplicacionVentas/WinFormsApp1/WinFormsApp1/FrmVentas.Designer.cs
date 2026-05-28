namespace WinFormsApp1
{
    partial class FrmVentas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            textBoxCliente = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            labelFecha = new Label();
            labelHora = new Label();
            groupBox2 = new GroupBox();
            textBoxCantidad = new TextBox();
            label10 = new Label();
            buttonRegistrar = new Button();
            buttonCancelar = new Button();
            labelPrecio = new Label();
            label6 = new Label();
            comboBoxProducto = new ComboBox();
            label5 = new Label();
            listViewRegistro = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            label8 = new Label();
            label9 = new Label();
            labelTotalNeto = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(236, 29);
            label1.Name = "label1";
            label1.Size = new Size(324, 30);
            label1.TabIndex = 0;
            label1.Text = "Control de Ventas de Productos";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxCliente);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(29, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(447, 114);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del cliente";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBoxCliente
            // 
            textBoxCliente.Location = new Point(6, 46);
            textBoxCliente.Name = "textBoxCliente";
            textBoxCliente.Size = new Size(428, 23);
            textBoxCliente.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 28);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 0;
            label2.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(529, 93);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 2;
            label3.Text = "FECHA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(627, 92);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 3;
            label4.Text = "HORA";
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFecha.Location = new Point(531, 138);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(39, 15);
            labelFecha.TabIndex = 4;
            labelFecha.Text = "Fecha";
            // 
            // labelHora
            // 
            labelHora.AutoSize = true;
            labelHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHora.Location = new Point(630, 138);
            labelHora.Name = "labelHora";
            labelHora.Size = new Size(34, 15);
            labelHora.TabIndex = 5;
            labelHora.Text = "Hora";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxCantidad);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(buttonRegistrar);
            groupBox2.Controls.Add(buttonCancelar);
            groupBox2.Controls.Add(labelPrecio);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(comboBoxProducto);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(29, 216);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(739, 108);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos de la Venta";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.Location = new Point(450, 61);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(77, 23);
            textBoxCantidad.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(462, 32);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 6;
            label10.Text = "Cantidad";
            // 
            // buttonRegistrar
            // 
            buttonRegistrar.BackColor = Color.Yellow;
            buttonRegistrar.Location = new Point(644, 61);
            buttonRegistrar.Name = "buttonRegistrar";
            buttonRegistrar.Size = new Size(75, 32);
            buttonRegistrar.TabIndex = 5;
            buttonRegistrar.Text = "Registrar";
            buttonRegistrar.UseVisualStyleBackColor = false;
            buttonRegistrar.Click += buttonRegistrar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.Gold;
            buttonCancelar.Location = new Point(642, 23);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(75, 32);
            buttonCancelar.TabIndex = 4;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrecio.Location = new Point(554, 68);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(42, 15);
            labelPrecio.TabIndex = 3;
            labelPrecio.Text = "Precio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(554, 32);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 2;
            label6.Text = "Precio";
            // 
            // comboBoxProducto
            // 
            comboBoxProducto.FormattingEnabled = true;
            comboBoxProducto.Location = new Point(12, 43);
            comboBoxProducto.Name = "comboBoxProducto";
            comboBoxProducto.Size = new Size(422, 23);
            comboBoxProducto.TabIndex = 1;
            comboBoxProducto.SelectedIndexChanged += comboBoxProducto_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 25);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 0;
            label5.Text = "Producto";
            // 
            // listViewRegistro
            // 
            listViewRegistro.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listViewRegistro.Location = new Point(29, 348);
            listViewRegistro.Name = "listViewRegistro";
            listViewRegistro.Size = new Size(739, 233);
            listViewRegistro.TabIndex = 7;
            listViewRegistro.UseCompatibleStateImageBehavior = false;
            listViewRegistro.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Producto";
            columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cantidad";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Precio";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Sub-Total";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Descuento";
            columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Neto";
            columnHeader6.Width = 100;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 330);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 8;
            label8.Text = "ListView";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(491, 610);
            label9.Name = "label9";
            label9.Size = new Size(101, 25);
            label9.TabIndex = 9;
            label9.Text = "Total Neto";
            // 
            // labelTotalNeto
            // 
            labelTotalNeto.AutoSize = true;
            labelTotalNeto.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalNeto.Location = new Point(611, 604);
            labelTotalNeto.Name = "labelTotalNeto";
            labelTotalNeto.Size = new Size(70, 32);
            labelTotalNeto.TabIndex = 10;
            labelTotalNeto.Text = "Total";
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(800, 671);
            Controls.Add(labelTotalNeto);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(listViewRegistro);
            Controls.Add(groupBox2);
            Controls.Add(labelHora);
            Controls.Add(labelFecha);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "FrmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aplicacion de Ventas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBoxCliente;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelFecha;
        private Label labelHora;
        private GroupBox groupBox2;
        private Button buttonRegistrar;
        private Button buttonCancelar;
        private Label labelPrecio;
        private Label label6;
        private ComboBox comboBoxProducto;
        private Label label5;
        private ListView listViewRegistro;
        private Label label8;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Label label9;
        private Label labelTotalNeto;
        private TextBox textBoxCantidad;
        private Label label10;
    }
}
