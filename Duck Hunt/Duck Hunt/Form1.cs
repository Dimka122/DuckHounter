using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Duck_Hunt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (pictureBox_Duck.Left < 720) pictureBox_Duck.Left += 4;
            //else pictureBox_Duck.Left = 8;
            if (duck_position.X < 720) duck_position.X += 4;
            else duck_position.X = 8;
        }
    }
}
