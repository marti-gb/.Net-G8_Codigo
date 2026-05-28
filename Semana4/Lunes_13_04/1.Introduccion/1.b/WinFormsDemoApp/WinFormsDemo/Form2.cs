using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class Form2 : Form
    {
        private string _message;
        public Form2(string message)
        {
            InitializeComponent();
            _message = message;
            label1.Text = _message;
        }
    }
}
