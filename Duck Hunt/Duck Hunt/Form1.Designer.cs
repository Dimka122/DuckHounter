using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Duck_Hunt
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Duck Hunt";
            this.ResumeLayout(false);

            duck_position.X = 350;
            duck_position.Y = 350;
            duck_position.Width = 50;
            duck_position.Height = 50;

            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.Cursor.Dispose();
            

        }

        Point mouse_location = new Point();
        Rectangle duck_position = new Rectangle();
        bool isAlive = true;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_location.X = e.Location.X;
            mouse_location.Y = e.Location.Y;

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Flush();
            GC.Collect();
            if (isAlive)
            {
                e.Graphics.DrawImage(Image.FromFile("Duck1.png"), duck_position);
            }
            else
            {
                e.Graphics.DrawImage(Image.FromFile("Duck.png"), duck_position);
            }
            if(duck_position.IntersectsWith(new Rectangle(mouse_location,new Size(50,50))))
            {
                MessageBox.Show("Kill duck");
                isAlive = false;
            }

            e.Graphics.DrawEllipse(Pens.Black, new RectangleF(mouse_location, new SizeF(30, 30)));
            
        }

        #endregion
    }
}

