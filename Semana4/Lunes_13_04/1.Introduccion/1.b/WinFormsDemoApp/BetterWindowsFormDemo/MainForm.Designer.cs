namespace BetterWindowsFormDemo
{
    partial class MainForm
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
            firstNameText = new Label();
            firstNameTextBox = new TextBox();
            sayHelloButtom = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // firstNameText
            // 
            firstNameText.AutoSize = true;
            firstNameText.Location = new Point(158, 63);
            firstNameText.Name = "firstNameText";
            firstNameText.Size = new Size(129, 32);
            firstNameText.TabIndex = 0;
            firstNameText.Text = "First Name";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(305, 60);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(227, 39);
            firstNameTextBox.TabIndex = 1;
            // 
            // sayHelloButtom
            // 
            sayHelloButtom.Location = new Point(229, 151);
            sayHelloButtom.Name = "sayHelloButtom";
            sayHelloButtom.Size = new Size(192, 42);
            sayHelloButtom.TabIndex = 3;
            sayHelloButtom.Text = "say Hello";
            sayHelloButtom.UseVisualStyleBackColor = true;
            sayHelloButtom.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(305, 105);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(227, 39);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 108);
            label1.Name = "label1";
            label1.Size = new Size(129, 32);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 326);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(sayHelloButtom);
            Controls.Add(firstNameTextBox);
            Controls.Add(firstNameText);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6, 6, 6, 6);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label firstNameText;
        private TextBox firstNameTextBox;
        private Button sayHelloButtom;
        private TextBox textBox1;
        private Label label1;
    }
}
