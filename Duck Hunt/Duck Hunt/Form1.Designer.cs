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
using System.Drawing.Imaging;
using System.Threading;


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
            this.components = new System.ComponentModel.Container();
            //this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            //this.timer1.Interval = 20;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Duck Hunt";
            this.ResumeLayout(false);

            
            this.TopMost = true;
            this.Paint += Form1_Paint1;
            this.MouseMove += Form1_MouseMove1;
            this.Click += Form1_Click;
            this.duck_image = Image.FromFile("Duck1.png");

            duck_position.X = 350;
            duck_position.Y = 350;
            duck_position.Width = 50;
            duck_position.Height = 50;

            this.check.Size = new Size(50, 50);
            this.check.Location = new Point(50, 50);
            this.Controls.Add(check);
            this.Cursor.Dispose();



        }
        private void Form1_Click(object sender, EventArgs e)
        {
            cord_point.Add(new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10));
            duck_colection.Add(new Duck(duck_image, 1, rand_duck.Next(0, 500), rand_duck.Next(0, 500)));

        }

        Random rand_duck = new Random();
        Point elipse_location = new Point();
        Rectangle duck_position = new Rectangle();
        Rectangle shut_position = new Rectangle();
        //bool isAlive = true;
        Image duck_image;

        private void Form1_Paint1(object sender, PaintEventArgs e)
        {
            e.Graphics.Flush();
            GC.Collect();
            DrawImage2FloatRectF(e);
            Pen pen = new Pen(Color.Red);
            

            e.Graphics.DrawLine(pen, elipse_location.X + 30, elipse_location.Y + 20, elipse_location.X + 60, elipse_location.Y + 20);
            e.Graphics.DrawLine(pen, elipse_location.X + 10, elipse_location.Y + 20, elipse_location.X - 20, elipse_location.Y + 20);
            e.Graphics.DrawLine(pen, elipse_location.X + 20, elipse_location.Y + 30, elipse_location.X + 20, elipse_location.Y + 60);
            e.Graphics.DrawLine(pen, elipse_location.X + 20, elipse_location.Y + 10, elipse_location.X + 20, elipse_location.Y - 20);
            e.Graphics.DrawEllipse(Pens.Red,
                elipse_location.X, elipse_location.Y, 40, 40);

            foreach (Point point in cord_point)
            {
                //this.check.Text = point.X.ToString();
                e.Graphics.FillEllipse(Brushes.Red,
                point.X, point.Y, 20, 20);
                shut_position.X = point.X;
                shut_position.Y = point.Y;
                shut_position.Width = 20;
                shut_position.Height = 20;
            }


        }

        private void Form1_MouseMove1(object sender, MouseEventArgs e)
        {
            elipse_location.X = e.Location.X;
            elipse_location.Y = e.Location.Y;

            this.Invalidate();
        }

        public void DrawImage2FloatRectF(PaintEventArgs e)
        {

            foreach (Duck duck in duck_colection)
            {
                if (check_kill(duck) == true)
                {
                    duck_colection.Remove(duck);
                    break;
                }
                e.Graphics.DrawImage(duck.duck_img, duck.cords);
            }
            if (duck_colection.Count >= MAX_DUCK)
            {
                MakeScreenshot();
                MessageBox.Show("END GAME");
                this.Close();
            }
            GC.Collect();
        }
        public void MakeScreenshot()
        {
            string names = DateTime.Now.ToString().Replace(".", "_").Replace(":", "_");
            names += ".jpg";
            // получаем размеры окна рабочего стола
            Rectangle bounds = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);


            // создаем пустое изображения размером с экран устройства
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                // создаем объект на котором можно рисовать
                using (var g = Graphics.FromImage(bitmap))
                {
                    // перерисовываем экран на наш графический объект
                    //g.CopyFromScreen(100,100,300,300, bounds.Size);
                    g.CopyFromScreen(this.Location, Point.Empty, bounds.Size);
                }

                // сохраняем в файл с форматом JPG
                bitmap.Save(names, ImageFormat.Jpeg);
            }
        }
        void new_duck()
        {
            this.duck_position.X = duck_position.X + 100;
            this.duck_position.Y = duck_position.Y + 100;
            //isAlive = true;

        }

        bool check_kill(Duck duck)
        {

            if (shut_position.IntersectsWith(duck.cords))
            {
                MessageBox.Show("Kill duck!");
                GC.Collect(GC.GetGeneration(duck));
                return true;
            }
            return false;
        }
        readonly int MAX_DUCK = 10;
        List<Point> cord_point = new List<Point>();
        List<Duck> duck_colection = new List<Duck>();
        Label check = new Label();

        #endregion
        //private Timer timer1;
    }
}

