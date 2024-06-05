using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace multi1
{
    public partial class Form2 : Form
    {
        private Rectangle firstSelection = new Rectangle();
        private Rectangle secondSelection = new Rectangle();
        private bool firstSelecting = false;
        private bool secondSelecting = false;
        public Form2()
        {
            InitializeComponent();
            first_image.MouseDown += firstImage_MouseDown;
            first_image.MouseMove += firstImage_MouseMove;
            first_image.MouseUp += firstImage_MouseUp;
            first_image.Paint += firstImage_Paint;
          /*  second_image.MouseDown += secondImage_MouseDown;
            second_image.MouseMove += secondImage_MouseMove;
            second_image.MouseUp += secondImage_MouseUp;
            second_image.Paint += secondImage_Paint;*/
        }

        // Event handlers for the first image
        private void firstImage_MouseDown(object sender, MouseEventArgs e)
        {
            firstSelection = new Rectangle(e.X, e.Y, 0, 0);
            firstSelecting = true;
        }
        private void firstImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (firstSelecting)
            {
                firstSelection.Width = e.X - firstSelection.Left;
                firstSelection.Height = e.Y - firstSelection.Top;
                first_image.Invalidate();
            }
        }
        private void firstImage_MouseUp(object sender, MouseEventArgs e)
        {
            firstSelecting = false;
        }
        private void firstImage_Paint(object sender, PaintEventArgs e)
        {
            if (firstSelecting)
            {
                e.Graphics.DrawRectangle(Pens.Red, firstSelection);
            }
        }

        // Event handlers for the second image
       /* private void secondImage_MouseDown(object sender, MouseEventArgs e)
        {
            secondSelection = new Rectangle(e.X, e.Y, 0, 0);
            secondSelecting = true;
        }
        private void secondImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (secondSelecting)
            {
                secondSelection.Width = e.X - secondSelection.Left;
                secondSelection.Height = e.Y - secondSelection.Top;
                second_image.Invalidate();
            }
        }
        private void secondImage_MouseUp(object sender, MouseEventArgs e)
        {
            secondSelecting = false;
        }
        private void secondImage_Paint(object sender, PaintEventArgs e)
        {
            if (secondSelecting)
            {
                e.Graphics.DrawRectangle(Pens.Red, secondSelection);
            }
        }*/
        private void firstimage_Click(object sender, EventArgs e)
        {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    first_image.Image = new Bitmap(openFileDialog1.FileName);
                    first_image.SizeMode = PictureBoxSizeMode.StretchImage;
                }
        }
        private void secondimage_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                second_image.Image = new Bitmap(openFileDialog2.FileName);
                second_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        //1- المقارنة بين صورتين 
        private void compare_Click(object sender, EventArgs e)
        {
            if (first_image.Image != null && second_image.Image != null)
            {
                using (Bitmap bmp1 = new Bitmap((Bitmap)first_image.Image))
                using (Bitmap bmp2 = new Bitmap((Bitmap)second_image.Image))
                {
                    string comparisonResult = CompareImages(bmp1, bmp2);
                    resultLabel.Text = comparisonResult;
                }
            }
            else
            {
                MessageBox.Show("Please load both images before comparing.");
            }
        }
        private string CompareImages(Bitmap bmp1, Bitmap bmp2)
        {
            // تغيير حجم الصورة الثانية لتتطابق مع حجم الصورة الأولى
            Bitmap resizedBmp2 = new Bitmap(bmp1.Width, bmp1.Height);

            using (Graphics g = Graphics.FromImage(resizedBmp2))
            {
                g.DrawImage(bmp2, 0, 0, bmp1.Width, bmp1.Height);
            }

            int width = bmp1.Width;
            int height = bmp1.Height;
            long diff = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel1 = bmp1.GetPixel(x, y);
                    Color pixel2 = resizedBmp2.GetPixel(x, y);

                    int rDiff = Math.Abs(pixel1.R - pixel2.R);
                    int gDiff = Math.Abs(pixel1.G - pixel2.G);
                    int bDiff = Math.Abs(pixel1.B - pixel2.B);

                    diff += rDiff + gDiff + bDiff;
                }
            }

            double avgDiff = diff / (width * height * 3.0);

            if (avgDiff < 10)
            {
                return "There is significant improvement or stability in the treatment.";
            }
            else
            {
                return "There is no significant improvement, or the condition may have worsened.";
            }
        }
       

        

    }
}
