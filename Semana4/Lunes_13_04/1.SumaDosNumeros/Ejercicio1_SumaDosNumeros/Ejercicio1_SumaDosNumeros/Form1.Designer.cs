namespace Ejercicio1_SumaDosNumeros
{
    partial class Form1
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            resultadoLabel = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            primerNumeroText = new TextBox();
            segundoNumeroText = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(266, 57);
            label1.Name = "label1";
            label1.Size = new Size(268, 27);
            label1.TabIndex = 0;
            label1.Text = "Suma de dos Numeros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(181, 150);
            label2.Name = "label2";
            label2.Size = new Size(151, 25);
            label2.TabIndex = 1;
            label2.Text = "Primer Numero";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(160, 196);
            label3.Name = "label3";
            label3.Size = new Size(172, 25);
            label3.TabIndex = 2;
            label3.Text = "Segundo Numero";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(245, 264);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 3;
            label4.Text = "Resultado";
            // 
            // resultadoLabel
            // 
            resultadoLabel.AutoSize = true;
            resultadoLabel.Font = new Font("Tempus Sans ITC", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resultadoLabel.Location = new Point(366, 261);
            resultadoLabel.Name = "resultadoLabel";
            resultadoLabel.Size = new Size(0, 31);
            resultadoLabel.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(124, 354);
            button1.Name = "button1";
            button1.Size = new Size(100, 33);
            button1.TabIndex = 5;
            button1.Text = "Limpiar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 192, 255);
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(287, 356);
            button2.Name = "button2";
            button2.Size = new Size(122, 28);
            button2.TabIndex = 6;
            button2.Text = "Calcular";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 192, 128);
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(484, 354);
            button3.Name = "button3";
            button3.Size = new Size(111, 32);
            button3.TabIndex = 7;
            button3.Text = "Salir";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // primerNumeroText
            // 
            primerNumeroText.Location = new Point(366, 155);
            primerNumeroText.Name = "primerNumeroText";
            primerNumeroText.Size = new Size(168, 23);
            primerNumeroText.TabIndex = 8;
            // 
            // segundoNumeroText
            // 
            segundoNumeroText.Location = new Point(366, 200);
            segundoNumeroText.Name = "segundoNumeroText";
            segundoNumeroText.Size = new Size(168, 23);
            segundoNumeroText.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(segundoNumeroText);
            Controls.Add(primerNumeroText);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(resultadoLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label resultadoLabel;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox primerNumeroText;
        private TextBox segundoNumeroText;
    }
}
