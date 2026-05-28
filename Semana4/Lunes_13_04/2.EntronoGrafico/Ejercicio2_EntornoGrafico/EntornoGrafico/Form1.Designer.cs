namespace EntornoGrafico
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            nombreTextBox = new TextBox();
            direccionTextBox = new TextBox();
            edadTextBox = new TextBox();
            apellidoTextBox = new TextBox();
            comboBoxGenero = new ComboBox();
            buttonInsertar = new Button();
            buttonSalir = new Button();
            buttonLimpiar = new Button();
            buttonPantallaDos = new Button();
            buttonPantallaTres = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(29, 82);
            label1.Name = "label1";
            label1.Size = new Size(93, 27);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(29, 140);
            label2.Name = "label2";
            label2.Size = new Size(95, 27);
            label2.TabIndex = 1;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(29, 203);
            label3.Name = "label3";
            label3.Size = new Size(58, 27);
            label3.TabIndex = 2;
            label3.Text = "Edad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(29, 258);
            label4.Name = "label4";
            label4.Size = new Size(104, 27);
            label4.TabIndex = 3;
            label4.Text = "Direccion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tempus Sans ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(29, 312);
            label5.Name = "label5";
            label5.Size = new Size(84, 27);
            label5.TabIndex = 4;
            label5.Text = "Genero";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(174, 87);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(218, 23);
            nombreTextBox.TabIndex = 5;
            // 
            // direccionTextBox
            // 
            direccionTextBox.Location = new Point(174, 263);
            direccionTextBox.Name = "direccionTextBox";
            direccionTextBox.Size = new Size(218, 23);
            direccionTextBox.TabIndex = 7;
            // 
            // edadTextBox
            // 
            edadTextBox.Location = new Point(174, 208);
            edadTextBox.Name = "edadTextBox";
            edadTextBox.Size = new Size(218, 23);
            edadTextBox.TabIndex = 8;
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(174, 145);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(218, 23);
            apellidoTextBox.TabIndex = 9;
            // 
            // comboBoxGenero
            // 
            comboBoxGenero.FormattingEnabled = true;
            comboBoxGenero.Items.AddRange(new object[] { "Masculino", "Femenino" });
            comboBoxGenero.Location = new Point(174, 312);
            comboBoxGenero.Name = "comboBoxGenero";
            comboBoxGenero.Size = new Size(218, 23);
            comboBoxGenero.TabIndex = 10;
            // 
            // buttonInsertar
            // 
            buttonInsertar.BackColor = Color.Navy;
            buttonInsertar.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonInsertar.ForeColor = SystemColors.ButtonHighlight;
            buttonInsertar.Location = new Point(17, 365);
            buttonInsertar.Margin = new Padding(0);
            buttonInsertar.Name = "buttonInsertar";
            buttonInsertar.Size = new Size(119, 43);
            buttonInsertar.TabIndex = 11;
            buttonInsertar.Text = "Insertar";
            buttonInsertar.UseVisualStyleBackColor = false;
            buttonInsertar.Click += buttonInsertar_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.Navy;
            buttonSalir.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSalir.ForeColor = SystemColors.ButtonHighlight;
            buttonSalir.Location = new Point(322, 365);
            buttonSalir.Margin = new Padding(0);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(119, 43);
            buttonSalir.TabIndex = 12;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // buttonLimpiar
            // 
            buttonLimpiar.BackColor = Color.Navy;
            buttonLimpiar.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLimpiar.ForeColor = SystemColors.ButtonHighlight;
            buttonLimpiar.Location = new Point(174, 365);
            buttonLimpiar.Margin = new Padding(0);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new Size(119, 43);
            buttonLimpiar.TabIndex = 13;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.UseVisualStyleBackColor = false;
            buttonLimpiar.Click += buttonLimpiar_Click;
            // 
            // buttonPantallaDos
            // 
            buttonPantallaDos.BackColor = Color.Navy;
            buttonPantallaDos.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPantallaDos.ForeColor = SystemColors.ButtonHighlight;
            buttonPantallaDos.Location = new Point(436, 87);
            buttonPantallaDos.Margin = new Padding(0);
            buttonPantallaDos.Name = "buttonPantallaDos";
            buttonPantallaDos.Size = new Size(119, 81);
            buttonPantallaDos.TabIndex = 14;
            buttonPantallaDos.Text = "Pantalla Dos";
            buttonPantallaDos.UseVisualStyleBackColor = false;
            buttonPantallaDos.Click += buttonPantallaDos_Click;
            // 
            // buttonPantallaTres
            // 
            buttonPantallaTres.BackColor = Color.Navy;
            buttonPantallaTres.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPantallaTres.ForeColor = SystemColors.ButtonHighlight;
            buttonPantallaTres.Location = new Point(436, 248);
            buttonPantallaTres.Margin = new Padding(0);
            buttonPantallaTres.Name = "buttonPantallaTres";
            buttonPantallaTres.Size = new Size(119, 87);
            buttonPantallaTres.TabIndex = 15;
            buttonPantallaTres.Text = "Pantalla Tres";
            buttonPantallaTres.UseVisualStyleBackColor = false;
            buttonPantallaTres.Click += buttonPantallaTres_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(576, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 248);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(buttonPantallaTres);
            Controls.Add(buttonPantallaDos);
            Controls.Add(buttonLimpiar);
            Controls.Add(buttonSalir);
            Controls.Add(buttonInsertar);
            Controls.Add(comboBoxGenero);
            Controls.Add(apellidoTextBox);
            Controls.Add(edadTextBox);
            Controls.Add(direccionTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormPrincipal";
            Text = "Formulario de Entrada";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox nombreTextBox;
        private TextBox direccionTextBox;
        private TextBox edadTextBox;
        private TextBox apellidoTextBox;
        private ComboBox comboBoxGenero;
        private Button buttonInsertar;
        private Button buttonSalir;
        private Button buttonLimpiar;
        private Button buttonPantallaDos;
        private Button buttonPantallaTres;
        private PictureBox pictureBox1;
    }
}
