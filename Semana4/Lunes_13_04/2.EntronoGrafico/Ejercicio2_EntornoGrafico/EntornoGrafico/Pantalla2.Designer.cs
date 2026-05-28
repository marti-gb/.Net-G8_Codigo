namespace EntornoGrafico
{
    partial class Pantalla2
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            labelNombre = new Label();
            labelDireccion = new Label();
            labelEdad = new Label();
            labelApellido = new Label();
            labelGenero = new Label();
            buttonSalir = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(40, 264);
            label5.Name = "label5";
            label5.Size = new Size(84, 27);
            label5.TabIndex = 9;
            label5.Text = "Genero";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(40, 210);
            label4.Name = "label4";
            label4.Size = new Size(104, 27);
            label4.TabIndex = 8;
            label4.Text = "Direccion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(40, 155);
            label3.Name = "label3";
            label3.Size = new Size(58, 27);
            label3.TabIndex = 7;
            label3.Text = "Edad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(40, 92);
            label2.Name = "label2";
            label2.Size = new Size(95, 27);
            label2.TabIndex = 6;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(40, 34);
            label1.Name = "label1";
            label1.Size = new Size(93, 27);
            label1.TabIndex = 5;
            label1.Text = "Nombre";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNombre.ForeColor = Color.Navy;
            labelNombre.Location = new Point(179, 22);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(131, 40);
            labelNombre.TabIndex = 10;
            labelNombre.Text = "Nombre";
            // 
            // labelDireccion
            // 
            labelDireccion.AutoSize = true;
            labelDireccion.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDireccion.ForeColor = Color.Navy;
            labelDireccion.Location = new Point(179, 198);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(146, 40);
            labelDireccion.TabIndex = 11;
            labelDireccion.Text = "Direccion";
            // 
            // labelEdad
            // 
            labelEdad.AutoSize = true;
            labelEdad.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEdad.ForeColor = Color.Navy;
            labelEdad.Location = new Point(179, 143);
            labelEdad.Name = "labelEdad";
            labelEdad.Size = new Size(84, 40);
            labelEdad.TabIndex = 12;
            labelEdad.Text = "Edad";
            // 
            // labelApellido
            // 
            labelApellido.AutoSize = true;
            labelApellido.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelApellido.ForeColor = Color.Navy;
            labelApellido.Location = new Point(179, 80);
            labelApellido.Name = "labelApellido";
            labelApellido.Size = new Size(131, 40);
            labelApellido.TabIndex = 13;
            labelApellido.Text = "Apellido";
            // 
            // labelGenero
            // 
            labelGenero.AutoSize = true;
            labelGenero.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelGenero.ForeColor = Color.Navy;
            labelGenero.Location = new Point(179, 252);
            labelGenero.Name = "labelGenero";
            labelGenero.Size = new Size(118, 40);
            labelGenero.TabIndex = 14;
            labelGenero.Text = "Genero";
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.Navy;
            buttonSalir.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSalir.ForeColor = SystemColors.ButtonHighlight;
            buttonSalir.Location = new Point(401, 307);
            buttonSalir.Margin = new Padding(0);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(119, 43);
            buttonSalir.TabIndex = 15;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // Pantalla2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(546, 365);
            Controls.Add(buttonSalir);
            Controls.Add(labelGenero);
            Controls.Add(labelApellido);
            Controls.Add(labelEdad);
            Controls.Add(labelDireccion);
            Controls.Add(labelNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Pantalla2";
            Text = "Pantalla2";
            Load += Pantalla2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label labelNombre;
        private Label labelDireccion;
        private Label labelEdad;
        private Label labelApellido;
        private Label labelGenero;
        private Button buttonSalir;
    }
}