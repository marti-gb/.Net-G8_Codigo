namespace EntornoGrafico
{
    partial class Pantalla3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Apellidos = new DataGridViewTextBoxColumn();
            Edad = new DataGridViewTextBoxColumn();
            Direccion = new DataGridViewTextBoxColumn();
            Genero = new DataGridViewTextBoxColumn();
            buttonSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nombre, Apellidos, Edad, Direccion, Genero });
            dataGridView1.Location = new Point(31, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(568, 228);
            dataGridView1.TabIndex = 0;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Apellidos
            // 
            Apellidos.HeaderText = "Apellidos";
            Apellidos.Name = "Apellidos";
            // 
            // Edad
            // 
            Edad.HeaderText = "Edad";
            Edad.Name = "Edad";
            // 
            // Direccion
            // 
            Direccion.HeaderText = "Direccion";
            Direccion.Name = "Direccion";
            // 
            // Genero
            // 
            Genero.HeaderText = "Genero";
            Genero.Name = "Genero";
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.Navy;
            buttonSalir.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSalir.ForeColor = SystemColors.ButtonHighlight;
            buttonSalir.Location = new Point(480, 282);
            buttonSalir.Margin = new Padding(0);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(119, 43);
            buttonSalir.TabIndex = 16;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // Pantalla3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(628, 334);
            Controls.Add(buttonSalir);
            Controls.Add(dataGridView1);
            Name = "Pantalla3";
            Text = "Pantalla3";
            Load += Pantalla3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellidos;
        private DataGridViewTextBoxColumn Edad;
        private DataGridViewTextBoxColumn Direccion;
        private DataGridViewTextBoxColumn Genero;
        private Button buttonSalir;
    }
}