using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using AForge.Math;
using AForge.Imaging.Filters;
using Complex = AForge.Math.Complex;
using AForge.Imaging;
using NAudio.Wave;
using System.IO.Compression;
using System.Net.Http;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using iTextSharp.text.pdf.parser;





namespace multi1
{
    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private List<Point> curvePoints = new List<Point>();
        private bool isDrawingCurve = false; // متغير لتحديد ما إذا كان المستخدم يرسم منحنى حاليًا
        private Point startPoint;
        private Point endPoint;
        private bool selecting;
        long diff = 0;
        private Rectangle selection;
        private ShapeType currentShape = ShapeType.Rectangle;
        private bool select = false;
        private bool selectingtype = false;
        Rectangle rectCropArea = new Rectangle();
        private List<string> comments = new List<string>();
        private string audioFilePath;
        private string telegramBotToken = "6926994622:AAFZmKuTqR1wD-FDRKEadKH-ohJdrlEMRP8\r\n"; // Replace with your bot token
        private string telegramChatId = "@multimeadia_nour";
        private FourierType currentFourier = FourierType.magnitudeImage;
       

        //share
       
        private static readonly HttpClient httpClient = new HttpClient();


        public Form1()
        {
            InitializeComponent();
            orginalimage.MouseDown += pictureBox_MouseDown;
            orginalimage.MouseMove += pictureBox_MouseMove;
            orginalimage.MouseUp += pictureBox_MouseUp;
            orginalimage.Paint += pictureBox_Paint;
            comboBoxShapes.Items.Add(ShapeType.Rectangle);
            comboBoxShapes.Items.Add(ShapeType.Ellipse);
            comboBoxShapes.Items.Add(ShapeType.Triangle);
            comboBoxShapes.SelectedIndex = 0; // تعيين الشكل الافتراضي إلى Rectangle
            fouriercomboBox.SelectedIndexChanged += new EventHandler(fouriercomboBox_SelectedIndexChanged);
            InitializefourierComboBox();

        }

        private class Shape
        {
            public ShapeType ShapeType { get; set; }
            public Rectangle Rectangle { get; set; }
            public List<Point> CurvePoints { get; set; }

            public Shape(ShapeType shapeType, Rectangle rectangle)
            {
                ShapeType = shapeType;
                Rectangle = rectangle;
                CurvePoints = new List<Point>();
            }

            public Shape(List<Point> curvePoints)
            {
                ShapeType = ShapeType.Freehand;
                CurvePoints = new List<Point>(curvePoints);
            }
        }
        public enum ShapeType
        {
            Rectangle,
            Ellipse,
            Triangle,
            Freehand

        }
        public enum FourierType
        {
            magnitudeImage,
            logMagnitudeImage,
            LPF,
            HPF
        }
        private void comboBoxShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentShape = (ShapeType)comboBoxShapes.SelectedItem;
        }
        private void InitializefourierComboBox()
        {
            fouriercomboBox.Items.Clear(); // Clear existing items
            fouriercomboBox.Items.Add("magnitudeImage");
            fouriercomboBox.Items.Add("logMagnitudeImage");
            fouriercomboBox.Items.Add("LPF");
            fouriercomboBox.Items.Add("HPF");
        }

        public void AddImage(Bitmap image)
        {
            Bitmap pp = new Bitmap(image);
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(pp);
            
            orginalimage.Image = new Bitmap(grayImage);
            orginalimage.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        private void upload_Click(object sender, EventArgs e)
        {

            shapes.Clear();
            //home.BringToFront();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap originalBitmap = new Bitmap(openFileDialog1.FileName);
                Bitmap grayBitmap = ConvertToGrayscale(originalBitmap);

              
                orginalimage.Image = grayBitmap;
                orginalimage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            // Create a blank grayscale bitmap
            Bitmap grayscaleBitmap = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    // Get the pixel color from the original image
                    Color originalColor = original.GetPixel(x, y);

                    // Calculate the grayscale value
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);

                    // Set the pixel color in the grayscale bitmap
                    grayscaleBitmap.SetPixel(x, y, grayColor);
                }
            }

            return grayscaleBitmap;
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;

            if (currentShape == ShapeType.Freehand)
            {
                isDrawingCurve = true;
                curvePoints.Clear();
                curvePoints.Add(startPoint);
                orginalimage.Invalidate(); // تأكد من أن orginalimage هو اسم صحيح لكائن PictureBox
            }
            else
            {
                selecting = true;
                selection = new Rectangle(e.X, e.Y, 0, 0);
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawingCurve)
            {
                curvePoints.Add(e.Location);
                orginalimage.Invalidate();
            }
            else if (selecting)
            {
                endPoint = e.Location;
                selection.Width = e.X - selection.Left;
                selection.Height = e.Y - selection.Top;
                orginalimage.Invalidate();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawingCurve)
            {
                
                shapes.Add(new Shape(curvePoints));

            }
            else if (selecting)
            {
                shapes.Add(new Shape(currentShape, selection));
            }

            selecting = false;
            isDrawingCurve = false;
            rectCropArea = selection;
            orginalimage.Invalidate();
        }


        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {


            Graphics g = e.Graphics;
            

            Pen pen = new Pen(Color.Red, 2);

            foreach (var shape in shapes)
            {


                switch (currentShape)
                {
                    case ShapeType.Rectangle:
                        g.DrawRectangle(pen, selection);
                        break;
                    case ShapeType.Ellipse:
                        g.DrawEllipse(pen, selection);
                        break;
                    case ShapeType.Triangle:
                        Point p1 = new Point(startPoint.X + (selection.Width / 2), startPoint.Y);
                        Point p2 = new Point(startPoint.X, startPoint.Y + selection.Height);
                        Point p3 = new Point(startPoint.X + selection.Width, startPoint.Y + selection.Height);
                        g.DrawPolygon(pen, new Point[] { p1, p2, p3 });
                        break;
                }

            }

            

            

            if (isDrawingCurve && curvePoints.Count > 1)
            {
                g.DrawCurve(pen, curvePoints.ToArray());
            }
        }


        private void savebutton_Click(object sender, EventArgs e)
        {
            SaveImage();
        }
        private void SaveImage()
        {
            if (orginalimage.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
                saveFileDialog.Title = "Save Colored X-Ray Image";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string extension = System.IO.Path.GetExtension(filePath).ToLower();
                    ImageFormat format = ImageFormat.Jpeg; // افتراضي JPEG

                    if (extension == ".png")
                    {
                        format = ImageFormat.Png;
                    }

                    // نسخ الصورة الأصلية إلى صورة جديدة لإضافة النص عليها
                    Bitmap bitmapWithText = new Bitmap(orginalimage.Image);

                    using (Graphics graphics = Graphics.FromImage(bitmapWithText))
                    {
                        // إعدادات النص (يمكنك تعديل هذه الإعدادات حسب الحاجة)
                        string textToDraw = "اسم المريض: " + commenttextbox.Text;
                        Font drawFont = new Font("Arial", 30);
                        SolidBrush drawBrush = new SolidBrush(Color.Red);
                        PointF drawPoint = new PointF(10, 20); // موقع النص على الصورة

                        // رسم النص على الصورة
                        graphics.DrawString(textToDraw, drawFont, drawBrush, drawPoint);
                        result.Image = bitmapWithText;
                    }

                    // حفظ الصورة مع النص
                    bitmapWithText.Save(filePath, format);

                    string commentFilePath = System.IO.Path.ChangeExtension(filePath, ".txt");
                    File.WriteAllText(commentFilePath, commenttextbox.Text);

                    MessageBox.Show("Image saved successfully.");
                }
            }
            else
            {
                MessageBox.Show("No colored image to save.");
            }
        }
        private void applytext_Click(object sender, EventArgs e)
        {
            if (result.Image != null) 
            {

                Bitmap bitmapWithText = new Bitmap(result.Image);
                using (Graphics graphics = Graphics.FromImage(bitmapWithText))
                {
                    // إعدادات النص
                    string textToDraw = "اسم المريض: " + commenttextbox.Text;
                    Font drawFont = new Font("Arial", 20);
                    SolidBrush drawBrush = new SolidBrush(Color.Red);
                    PointF drawPoint = new PointF(10, 20);

                    // رسم النص على الصورة
                    graphics.DrawString(textToDraw, drawFont, drawBrush, drawPoint);
                }

                result.SizeMode = PictureBoxSizeMode.StretchImage;

                // عرض الصورة الأصلية مع النص في PictureBox الثاني (result)
                result.Image = bitmapWithText;
            }
            else if (orginalimage.Image != null)
            {
                Bitmap bitmapWithText = new Bitmap(orginalimage.Image);
                using (Graphics graphics = Graphics.FromImage(bitmapWithText))
                {
                    // إعدادات النص
                    string textToDraw = "اسم المريض: " + commenttextbox.Text;
                    Font drawFont = new Font("Arial", 20);
                    SolidBrush drawBrush = new SolidBrush(Color.Red);
                    PointF drawPoint = new PointF(10, 20);

                    // رسم النص على الصورة
                    graphics.DrawString(textToDraw, drawFont, drawBrush, drawPoint);
                }

                result.SizeMode = PictureBoxSizeMode.StretchImage;

                // عرض الصورة الأصلية مع النص في PictureBox الثاني (result)
                result.Image = bitmapWithText;
            }
            else
            {
                MessageBox.Show("No image available.");
            }
        }
        public void Cropping()
        {
            if (orginalimage.Image != null && rectCropArea.Width > 0 && rectCropArea.Height > 0)
            {
                Bitmap rgbIm = new Bitmap(orginalimage.Image, orginalimage.Width, orginalimage.Height);
                Bitmap croppedImage = new Bitmap(rectCropArea.Width, rectCropArea.Height);

                for (int y = 0; y < rectCropArea.Height; y++)
                {
                    for (int x = 0; x < rectCropArea.Width; x++)
                    {
                        // Get RGB color of current pixel within the selected rectangle
                        Color pixelColor = rgbIm.GetPixel(rectCropArea.X + x, rectCropArea.Y + y);
                        // Set the corresponding pixel in the cropped image
                        croppedImage.SetPixel(x, y, pixelColor);
                    }
                }

                // Display the cropped image in the second pictureBox
                result.Image = croppedImage;
            }
            else
            {
                MessageBox.Show("There is no image to crop.");
            }
        }
        private void applycoloring_Click(object sender, EventArgs e)
        {


            // Open a ColorDialog to allow the user to choose a color
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected color
                Color selectedColor = colorDialog.Color;

                // Apply the selected color to the image using the custom colormap
                ApplySequentialColormap(selectedColor);
            }


        }
        public void ApplySequentialColormap(Color selectedColor)
        {
            if (orginalimage.Image != null && rectCropArea.Width > 0 && rectCropArea.Height > 0)
            {
                Bitmap orginalBitmap = new Bitmap(orginalimage.Image, orginalimage.Width, orginalimage.Height);
                Bitmap resultimage = new Bitmap(orginalBitmap.Width, orginalBitmap.Height);
                Bitmap bitmapWithText = new Bitmap(orginalimage.Image);
                // Pre-calculate grayscale conversion factors
                const double redWeight = 0.3;
                const double greenWeight = 0.59;
                const double blueWeight = 0.11;

                // Generate sequential colormap based on selected color
                Color[] sequentialColors = GenerateSequentialColormap(selectedColor);

                for (int y = 0; y < orginalBitmap.Height; y++)
                {
                    for (int x = 0; x < orginalBitmap.Width; x++)
                    {
                        // Check if pixel is within crop area based on the shape
                        bool isWithinCropArea;

                        if (currentShape == ShapeType.Ellipse)
                        {
                            isWithinCropArea = IsWithinEllipseCropArea(x, y);
                        }
                        else if (currentShape == ShapeType.Triangle)
                        {
                            isWithinCropArea = IsWithinTriangleCropArea(x, y);
                        }
                        else
                        {
                            isWithinCropArea = IsWithinCropArea(x, y);
                        }


                        if (isWithinCropArea)
                        {
                            Color pixelColor = orginalBitmap.GetPixel(x, y);

                            // Calculate grayscale value efficiently
                            int grayscaleValue = (int)(pixelColor.R * redWeight + pixelColor.G * greenWeight + pixelColor.B * blueWeight);

                            // Map grayscale value to colormap using pre-calculated index
                            float value = (float)grayscaleValue / 255f;
                            Color newColor = Interpolate(sequentialColors[0], sequentialColors[1], value);

                            resultimage.SetPixel(x, y, newColor);
                        }
                        else
                        {
                            // Copy original pixel if outside crop area
                            resultimage.SetPixel(x, y, orginalBitmap.GetPixel(x, y));
                        }

                    }
                }
                orginalimage.Image = resultimage;
                result.Image = orginalimage.Image;


            }
            else
            {
                MessageBox.Show("Please select a valid crop area before applying the colormap.");
            }
        }
        private Color[] GenerateSequentialColormap(Color selectedColor)
        {

            // Calculate the complementary color
            Color complementaryColor = Color.FromArgb(255 - selectedColor.R, 255 - selectedColor.G, 255 - selectedColor.B);

            // Define the sequential colormap based on the selected color and its complementary color
            Color[] sequentialColors = new Color[]
            {

              Color.White,
              selectedColor,           // Selected color
         
             };

            return sequentialColors;
        }
        private Color Interpolate(Color color1, Color color2, float ratio)
        {
            int r = (int)(color1.R * (1 - ratio) + color2.R * ratio);
            int g = (int)(color1.G * (1 - ratio) + color2.G * ratio);
            int b = (int)(color1.B * (1 - ratio) + color2.B * ratio);
            return Color.FromArgb(r, g, b);
        }
        private bool IsWithinCropArea(int x, int y)
        {
            return x >= rectCropArea.Left && x < rectCropArea.Right &&
                   y >= rectCropArea.Top && y < rectCropArea.Bottom;
        }
        private bool IsWithinEllipseCropArea(int x, int y)
        {
            float centerX = rectCropArea.Left + rectCropArea.Width / 2f;
            float centerY = rectCropArea.Top + rectCropArea.Height / 2f;
            float radiusX = rectCropArea.Width / 2f;
            float radiusY = rectCropArea.Height / 2f;

            return Math.Pow((x - centerX) / radiusX, 2) + Math.Pow((y - centerY) / radiusY, 2) <= 1;
        }

        private bool IsWithinTriangleCropArea(int x,int y)
        {
            Point p1 = new Point(rectCropArea.Left + rectCropArea.Width / 2, rectCropArea.Top);
            Point p2 = new Point(rectCropArea.Left , rectCropArea.Bottom);
            Point p3 = new Point(rectCropArea.Right , rectCropArea.Bottom);
            return IsPointInTriangle(new Point(x,y), p1, p2,p3);
        }
     


        private bool IsPointInTriangle(Point pt, Point v1, Point v2, Point v3)
        {
            bool b1, b2, b3;

            b1 = Sign(pt, v1, v2) < 0.0f;
            b2 = Sign(pt, v2, v3) < 0.0f;
            b3 = Sign(pt, v3, v1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }



        private float Sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private void jetcolormap_Click(object sender, EventArgs e)
        {
            ApplyJetColormap();
        }
        private void terraincolor_Click(object sender, EventArgs e)
        {
            ApplyTerrainColormap();
        }
        private void gnuplotcolor_Click(object sender, EventArgs e)
        {
            ApplyGnuplotColormap();
        }

        public void ApplyJetColormap()
        {
            if (orginalimage.Image != null && rectCropArea.Width > 0 && rectCropArea.Height > 0)
            {
                Bitmap orginalBitmap = new Bitmap(orginalimage.Image, orginalimage.Width, orginalimage.Height);
                Bitmap resultimage = new Bitmap(orginalBitmap.Width, orginalBitmap.Height);

                // Pre-calculate grayscale conversion factors
                const double redWeight = 0.3;
                const double greenWeight = 0.59;
                const double blueWeight = 0.11;

                for (int y = 0; y < orginalBitmap.Height; y++)
                {
                    for (int x = 0; x < orginalBitmap.Width; x++)
                    {
                        bool isWithinCropArea;

                        if (currentShape == ShapeType.Ellipse)
                        {
                            isWithinCropArea = IsWithinEllipseCropArea(x, y);
                        }
                        else if (currentShape == ShapeType.Triangle)
                        {
                            isWithinCropArea = IsWithinTriangleCropArea(x, y);
                        }
                        else
                        {
                            isWithinCropArea = IsWithinCropArea(x, y);
                        }
                        // Check if pixel is within crop area based on the shape
                       

                        if (isWithinCropArea)
                        {
                            Color pixelColor = orginalBitmap.GetPixel(x, y);

                            // Calculate grayscale value efficiently
                            int grayscaleValue = (int)(pixelColor.R * redWeight + pixelColor.G * greenWeight + pixelColor.B * blueWeight);

                            // Map grayscale value to colormap using pre-calculated index
                            float value = (float)grayscaleValue / 255f;
                            Color newColor = GetJetColor(value);

                            resultimage.SetPixel(x, y, newColor);
                        }
                        else
                        {
                            // Copy original pixel if outside crop area
                            resultimage.SetPixel(x, y, orginalBitmap.GetPixel(x, y));
                        }
                    }
                }

                orginalimage.Image = resultimage;
                result.Image = orginalimage.Image;
            }
            else
            {
                MessageBox.Show("Please select a rectangle before applying the colormap.");
            }
        }
        public void ApplyTerrainColormap()
        {
            {
                if (orginalimage.Image != null && rectCropArea.Width > 0 && rectCropArea.Height > 0)
                {
                    Bitmap orginalBitmap = new Bitmap(orginalimage.Image, orginalimage.Width, orginalimage.Height);
                    Bitmap resultimage = new Bitmap(orginalBitmap.Width, orginalBitmap.Height);

                    // Pre-calculate grayscale conversion factors
                    const double redWeight = 0.3;
                    const double greenWeight = 0.59;
                    const double blueWeight = 0.11;

                    for (int y = 0; y < orginalBitmap.Height; y++)
                    {
                        for (int x = 0; x < orginalBitmap.Width; x++)
                        {
                            // Check if pixel is within crop area based on the shape
                            bool isWithinCropArea;

                            if (currentShape == ShapeType.Ellipse)
                            {
                                isWithinCropArea = IsWithinEllipseCropArea(x, y);
                            }
                            else if (currentShape == ShapeType.Triangle)
                            {
                                isWithinCropArea = IsWithinTriangleCropArea(x, y);
                            }
                            else
                            {
                                isWithinCropArea = IsWithinCropArea(x, y);
                            }


                            if (isWithinCropArea)
                            {
                                Color pixelColor = orginalBitmap.GetPixel(x, y);

                                // Calculate grayscale value efficiently
                                int grayscaleValue = (int)(pixelColor.R * redWeight + pixelColor.G * greenWeight + pixelColor.B * blueWeight);

                                // Map grayscale value to colormap using pre-calculated index
                                float value = (float)grayscaleValue / 255f;
                                Color newColor = GetTerrainColor(value);

                                resultimage.SetPixel(x, y, newColor);
                            }
                            else
                            {
                                // Copy original pixel if outside crop area
                                resultimage.SetPixel(x, y, orginalBitmap.GetPixel(x, y));
                            }
                        }
                    }

                    orginalimage.Image = resultimage;
                    result.Image = orginalimage.Image;
                }
                else
                {
                    MessageBox.Show("Please select a rectangle before applying the colormap.");
                }
            }
        }
        public void ApplyGnuplotColormap()
        {
            {
                if (orginalimage.Image != null && rectCropArea.Width > 0 && rectCropArea.Height > 0)
                {
                    Bitmap orginalBitmap = new Bitmap(orginalimage.Image, orginalimage.Width, orginalimage.Height);
                    Bitmap resultimage = new Bitmap(orginalBitmap.Width, orginalBitmap.Height);

                    // Pre-calculate grayscale conversion factors
                    const double redWeight = 0.3;
                    const double greenWeight = 0.59;
                    const double blueWeight = 0.11;

                    for (int y = 0; y < orginalBitmap.Height; y++)
                    {
                        for (int x = 0; x < orginalBitmap.Width; x++)
                        {
                            // Check if pixel is within crop area based on the shape
                            bool isWithinCropArea;

                            if (currentShape == ShapeType.Ellipse)
                            {
                                isWithinCropArea = IsWithinEllipseCropArea(x, y);
                            }
                            else if (currentShape == ShapeType.Triangle)
                            {
                                isWithinCropArea = IsWithinTriangleCropArea(x, y);
                            }
                            else
                            {
                                isWithinCropArea = IsWithinCropArea(x, y);
                            }


                            if (isWithinCropArea)
                            {
                                Color pixelColor = orginalBitmap.GetPixel(x, y);

                                // Calculate grayscale value efficiently
                                int grayscaleValue = (int)(pixelColor.R * redWeight + pixelColor.G * greenWeight + pixelColor.B * blueWeight);

                                // Map grayscale value to colormap using pre-calculated index
                                float value = (float)grayscaleValue / 255f;
                                Color newColor = GetGnuplotColor(value);

                                resultimage.SetPixel(x, y, newColor);
                            }
                            else
                            {
                                // Copy original pixel if outside crop area
                                resultimage.SetPixel(x, y, orginalBitmap.GetPixel(x, y));
                            }
                        }
                    }

                    orginalimage.Image = resultimage;
                    result.Image = orginalimage.Image;
                }
                else
                {
                    MessageBox.Show("Please select a rectangle before applying the colormap.");
                }
            }
        }
        private Color GetJetColor(float value)
        {
            // Ensure value is within [0, 1] range
            value = Math.Max(0, Math.Min(1, value));

            // Calculate Jet colormap components
            int r = (int)(255 * Math.Max(0, Math.Min(1, 1.5f - Math.Abs(4 * value - 3))));
            int g = (int)(255 * Math.Max(0, Math.Min(1, 1.5f - Math.Abs(4 * value - 2))));
            int b = (int)(255 * Math.Max(0, Math.Min(1, 1.5f - Math.Abs(4 * value - 1))));

            return Color.FromArgb(r, g, b);
        }
        private Color GetTerrainColor(float value)
        {
            // Ensure value is within [0, 1] range
            value = Math.Max(0, Math.Min(1, value));

            // Map grayscale value to terrain color
            if (value < 0.2)
            {
                // Deep blue for water bodies
                return Color.FromArgb(0, 0, 128);
            }
            else if (value < 0.4)
            {
                // Light green for lowlands
                return Color.FromArgb(144, 238, 144);
            }
            else if (value < 0.6)
            {
                // Green for plains
                return Color.FromArgb(0, 128, 0);
            }
            else if (value < 0.8)
            {
                // Brown for hills
                return Color.FromArgb(139, 69, 19);
            }
            else
            {
                // White for mountains
                return Color.Black;
            }
        }
        private Color GetGnuplotColor(float value)
        {
            // Ensure value is within [0, 1] range
            value = Math.Max(0, Math.Min(1, value));

            // Map grayscale value to Gnuplot color map
            double r = Math.Min(1, 2 * value);
            double g = Math.Min(1, 2 * Math.Max(0, value - 0.5));
            double b = Math.Min(1, 2 * Math.Max(0, 0.5 - value));

            // Scale to 0-255 range
            int red = (int)(255 * r);
            int green = (int)(255 * g);
            int blue = (int)(255 * b);

            return Color.FromArgb(red, green, blue);
        }
        private void comparing_Click(object sender, EventArgs e)
        {

            // MessageBox.Show("Button clicked!");
            Form2 form2 = new Form2();
            form2.Show();
        }
        // 2- تصنيف الصورة
        private void classify_Click(object sender, EventArgs e)
        {
            if (orginalimage.Image != null && rectCropArea.Width > 0 && rectCropArea.Height > 0)
            {
                Bitmap orginalBitmap = new Bitmap(orginalimage.Image, orginalimage.Width, orginalimage.Height);

                diff = 0; // Reset diff for new calculation
                using (Bitmap croppedBitmap = orginalBitmap.Clone(rectCropArea, orginalBitmap.PixelFormat))
                {
                    for (int y = 0; y < croppedBitmap.Height; y++)
                    {
                        for (int x = 0; x < croppedBitmap.Width; x++)
                        {
                            Color pixelColor = croppedBitmap.GetPixel(x, y);
                            int avgColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                            diff += avgColor;
                        }
                    }
                    double avgDiff = diff / (croppedBitmap.Width * croppedBitmap.Height);
                    if (avgDiff < 85)
                    {
                        MessageBox.Show("The condition is mild");
                    }
                    else if (avgDiff < 170)
                    {
                        MessageBox.Show("The condition is moderate.");
                    }
                    else
                    {
                        MessageBox.Show("The condition is severe.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please load an image and select an area before classifying.");
            }
        }
        private void cropbtn_Click(object sender, EventArgs e)
        {
            Cropping();
        }

       

        private void addAudioCommentButton_Click(object sender, EventArgs e)
        {
            if (orginalimage.Image != null)
            {
                RecordAudio();
            }
            else
            {
                MessageBox.Show("No image loaded.");
            }
        }
        private void RecordAudio()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Wave File (*.wav)|*.wav";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                audioFilePath = saveFileDialog.FileName;
                // تحديد مصدر الصوت كمايكروفون
                WaveIn waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new WaveFormat(44100, 1);

                // متغير مؤقت لحفظ بيانات الصوت
                MemoryStream recordedAudioStream = new MemoryStream();

                waveIn.DataAvailable += (s, e) =>
                {
                    // كتابة البيانات إلى المتغير المؤقت
                    recordedAudioStream.Write(e.Buffer, 0, e.BytesRecorded);
                };

                waveIn.RecordingStopped += (s, e) =>
                {
                    // بعد التوقف عن التسجيل، قم بفتح الملف الصوتي وكتابة البيانات إليه
                    using (WaveFileWriter writer = new WaveFileWriter(audioFilePath, waveIn.WaveFormat))
                    {
                        recordedAudioStream.Position = 0;
                        recordedAudioStream.CopyTo(writer);
                    }

                    // قم بتنظيف وإغلاق المتغير المؤقت
                    recordedAudioStream.Dispose();
                };

                waveIn.StartRecording();

                MessageBox.Show("قم بتسجيل وصف الحالة المرضية، اضغط على موافق عند الانتهاء.");
                waveIn.StopRecording();
                waveIn.Dispose();

                MessageBox.Show("تم تسجيل التعليق الصوتي بنجاح.");
            }
        }
        private void reportbutton_Click(object sender, EventArgs e)
        {
            reportform searchform = new reportform();
            searchform.ShowDialog();
        }
        private void CompressImage_Click(object sender, EventArgs e)
        {

            if (orginalimage.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "ZIP Archive|*.zip";
                saveFileDialog.Title = "Save All Files";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string zipFilePath = saveFileDialog.FileName;
                    string tempFolderPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString());
                    Directory.CreateDirectory(tempFolderPath);

                    try
                    {
                        // حفظ الصورة
                        string imageFilePath = System.IO.Path.Combine(tempFolderPath, "image.jpg");
                        string commentFilePath = System.IO.Path.Combine(tempFolderPath, "comment.txt");

                        Bitmap bitmapWithText = new Bitmap(orginalimage.Image);
                        using (Graphics graphics = Graphics.FromImage(bitmapWithText))
                        {
                            string textToDraw = "اسم المريض: " + commenttextbox.Text;
                            Font drawFont = new Font("Arial", 30);
                            SolidBrush drawBrush = new SolidBrush(Color.Red);
                            PointF drawPoint = new PointF(10, 20);

                            graphics.DrawString(textToDraw, drawFont, drawBrush, drawPoint);
                            //result.Image = bitmapWithText;
                        }
                        bitmapWithText.Save(imageFilePath, ImageFormat.Jpeg);

                        // حفظ التقرير
                        File.WriteAllText(commentFilePath, commenttextbox.Text);

                        // ضغط الملفات في ملف واحد
                        using (ZipArchive zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
                        {
                            zip.CreateEntryFromFile(imageFilePath, "image.jpg");
                            zip.CreateEntryFromFile(commentFilePath, "comment.txt");

                            if (!string.IsNullOrEmpty(audioFilePath) && File.Exists(audioFilePath))
                            {
                                zip.CreateEntryFromFile(audioFilePath, System.IO.Path.GetFileName(audioFilePath));
                            }
                        }

                        MessageBox.Show("Files saved successfully.");
                    }
                    finally
                    {
                        Directory.Delete(tempFolderPath, true);
                    }
                }
            }
            else
            {
                MessageBox.Show("No colored image to save.");
            }
        }
        private void ShareViaWhatsApp(string imagePath)
        {
            // Launch WhatsApp with the image attached
            Process.Start("whatsapp://send?text=Check%20out%20this%20color%20X-ray&attachment=" + imagePath);
        }
        private async void sharetele_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string orginalImagePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "shared_image.jpg");
            string resultImagePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "shared1_image.jpg");

            if (result.Image != null)
            { 
                result.Image.Save(resultImagePath, ImageFormat.Jpeg);
                filePath = resultImagePath;
            }
            else if (orginalimage.Image != null)
            {
                
                orginalimage.Image.Save(orginalImagePath, ImageFormat.Jpeg);
                filePath = orginalImagePath;

            }
            else
            {
                MessageBox.Show(" no image to share ");
                return;
            }

            try
            {
                await SendFile(filePath);
                MessageBox.Show("File sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"no internet connection");
            }
            
        }

        private async Task SendFile(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(stream), "document", System.IO.Path.GetFileName(filePath));

                var response = await httpClient.PostAsync($"https://api.telegram.org/bot{telegramBotToken}/sendDocument?chat_id=@multimeadia_nour", content);
                MessageBox.Show(response.StatusCode.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to send file: {response.ReasonPhrase}");
                }
                
                
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {

            // Create an instance of Form3
            Form4 searchForm = new Form4(this);

            // Show Form3
            searchForm.Show();
        }

        private void fouriercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = fouriercomboBox.SelectedItem.ToString();
            if (selectedType == "magnitudeImage")
            {
                currentFourier = FourierType.magnitudeImage;
                ApplyFourierTransformMagnitudeImage();

            }
            else if (selectedType == "logMagnitudeImage")
            {
                currentFourier = FourierType.logMagnitudeImage;
                ApplyFourierTransformlogMagnitudeImage();
            }
            else if (selectedType == "LPF")
            {
                currentFourier = FourierType.logMagnitudeImage;
                ApplyLowPassFilter();

            }
            else if (selectedType == "HPF")
            {
                currentFourier = FourierType.logMagnitudeImage;
                ApplyHighPassFilter();
            }
        }
        private int NearestPowerOf2(int n)
        {
            // Calculate the nearest power of 2 greater than or equal to n
            int powerOf2 = 1;
            while (powerOf2 < n)
            {
                powerOf2 *= 2;
            }
            return powerOf2;
        }

        private void ApplyFourierTransformMagnitudeImage()
        {
            int originalWidth = orginalimage.Width;
            int originalHeight = orginalimage.Height;
            if (result.Image != null)
            {

                originalWidth = result.Image.Width;
                originalHeight = result.Image.Height;
            }
            // Calculate the nearest power of 2 for width and height
            int paddedWidth = NearestPowerOf2(originalWidth);
            int paddedHeight = NearestPowerOf2(originalHeight);

            Bitmap image = new Bitmap(paddedWidth, paddedHeight);
            using (Graphics g = Graphics.FromImage(image))
            {
                // Set interpolation mode to high quality bicubic to ensure smooth resizing
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Draw the original image onto the new bitmap
                g.DrawImage(orginalimage.Image, 0, 0, paddedWidth, paddedHeight);
            }
            // Convert the image to grayscale
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(image);
            // Apply FFT to the grayscale image
            ComplexImage complexImage = ComplexImage.FromBitmap(grayImage);
            complexImage.ForwardFourierTransform();
            //Compute the magnitude spectrum for visualization
            Bitmap magnitudeImage = complexImage.ToBitmap();
            result.SizeMode = PictureBoxSizeMode.StretchImage;
            result.Image = magnitudeImage;

        }
        private static Bitmap LogTransform(ComplexImage complexImage)
        {
            int width = complexImage.Width;
            int height = complexImage.Height;

            Bitmap logMagnitudeImage = new Bitmap(width, height);

            // Compute the magnitude spectrum
            double maxMagnitude = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double magnitude = complexImage.Data[y, x].Magnitude;
                    if (magnitude > maxMagnitude)
                    {
                        maxMagnitude = magnitude;
                    }
                }
            }

            // Compute the scale factor for logarithmic transformation
            double scale = 255 / Math.Log(1 + maxMagnitude);

            // Apply logarithmic transformation and set pixel values
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double magnitude = complexImage.Data[y, x].Magnitude;
                    double logMagnitude = Math.Log(1 + magnitude) * scale;

                    // Map the logarithmic value to color intensity
                    byte colorIntensity = (byte)(logMagnitude / maxMagnitude * 255);

                    // Set the pixel color
                    logMagnitudeImage.SetPixel(x, y, Color.FromArgb(colorIntensity, colorIntensity, colorIntensity));
                }
            }

            return logMagnitudeImage;

        }
        private void ApplyFourierTransformlogMagnitudeImage()
        {
            int originalWidth = orginalimage.Width;
            int originalHeight = orginalimage.Height;

            if (result.Image != null)
            {
                originalWidth = result.Image.Width;
                originalHeight = result.Image.Height;
            }
            // Calculate the nearest power of 2 for width and height
            int paddedWidth = NearestPowerOf2(originalWidth);
            int paddedHeight = NearestPowerOf2(originalHeight);

            Bitmap image = new Bitmap(paddedWidth, paddedHeight);
            using (Graphics g = Graphics.FromImage(image))
            {
                // Set interpolation mode to high quality bicubic to ensure smooth resizing
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Draw the original image onto the new bitmap
                g.DrawImage(orginalimage.Image, 0, 0, paddedWidth, paddedHeight);
            }
            // Convert the image to grayscale
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(image);
            // Apply FFT to the grayscale image
            ComplexImage complexImage = ComplexImage.FromBitmap(grayImage);
            complexImage.ForwardFourierTransform();
            //Compute the magnitude spectrum for visualization
            Bitmap logMagnitudeImage = LogTransform(complexImage);
            result.SizeMode = PictureBoxSizeMode.StretchImage;
            result.Image = logMagnitudeImage;

        }
        private static Bitmap ApplyLowPassFilter(Bitmap image)
        {
            // Convert the grayscale image to complex image
            ComplexImage complexImage = ComplexImage.FromBitmap(image);

            // Apply Forward Fourier Transform
            complexImage.ForwardFourierTransform();

            // Get the dimensions of the image
            int width = complexImage.Width;
            int height = complexImage.Height;

            // Create a mask for low pass filtering
            AForge.Math.Complex[,] filterMask = new AForge.Math.Complex[height, width];
            double cutoffFrequency = 0.2; // تحديد تردد القطع (يمكن تعديله حسب الحاجة)
            int radius = (int)Math.Ceiling(cutoffFrequency * Math.Min(width, height));
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double distance = Math.Sqrt((x - width / 2) * (x - width / 2) + (y - height / 2) * (y - height / 2));
                    if (distance <= radius)
                    {
                        filterMask[y, x] = AForge.Math.Complex.One;

                    }
                    else
                    {
                        filterMask[y, x] = AForge.Math.Complex.Zero;
                    }
                }
            }
            // Apply the filter mask to the frequency domain image
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    complexImage.Data[y, x] *= filterMask[y, x];
                }
            }

            // Apply Inverse Fourier Transform
            complexImage.BackwardFourierTransform();

            // Get the filtered image from the real part of the complex image
            Bitmap filteredImage = complexImage.ToBitmap();

            return filteredImage;

        }
        private static Bitmap ApplyHighPassFilter(Bitmap image)
        {
            // Convert the grayscale image to a complex image
            ComplexImage complexImage = ComplexImage.FromBitmap(image);

            // Apply Forward Fourier Transform
            complexImage.ForwardFourierTransform();

            // Get the dimensions of the image
            int width = complexImage.Width;
            int height = complexImage.Height;

            // Create a mask for high-pass filtering
            AForge.Math.Complex[,] filterMask = new AForge.Math.Complex[height, width];
            double cutoffFrequency = 0.2; // Adjust as needed
            int radius = (int)Math.Ceiling(cutoffFrequency * Math.Min(width, height));
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double distance = Math.Sqrt((x - width / 2) * (x - width / 2) + (y - height / 2) * (y - height / 2));
                    if (distance > radius) // Invert the condition for high-pass
                    {
                        filterMask[y, x] = AForge.Math.Complex.One;
                    }
                    else
                    {
                        filterMask[y, x] = AForge.Math.Complex.Zero;
                    }
                }
            }

            // Apply the filter mask to the frequency domain image
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    complexImage.Data[y, x] *= filterMask[y, x];
                }
            }

            // Apply Inverse Fourier Transform
            complexImage.BackwardFourierTransform();

            // Get the filtered image from the real part of the complex image
            Bitmap filteredImage = complexImage.ToBitmap();

            return filteredImage;
        }
        private void ApplyLowPassFilter()
        {
            int originalWidth = orginalimage.Width;
            int originalHeight = orginalimage.Height;
            if (result.Image != null)
            {
                originalWidth = result.Image.Width;
                originalHeight = result.Image.Height;
            }
            // Calculate the nearest power of 2 for width and height
            int paddedWidth = NearestPowerOf2(originalWidth);
            int paddedHeight = NearestPowerOf2(originalHeight);
            Bitmap image = new Bitmap(paddedWidth, paddedHeight);
            using (Graphics g = Graphics.FromImage(image))
            {
                // Set interpolation mode to high quality bicubic to ensure smooth resizing
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Draw the original image onto the new bitmap
                g.DrawImage(orginalimage.Image, 0, 0, paddedWidth, paddedHeight);
            }
            // Convert the image to grayscale
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(image);
            Bitmap filteredImage = ApplyLowPassFilter(grayImage);
            result.SizeMode = PictureBoxSizeMode.StretchImage;
            result.Image = filteredImage;

        }
        private void ApplyHighPassFilter()
        {
            int originalWidth = orginalimage.Width;
            int originalHeight = orginalimage.Height;

            if (result.Image != null)
            {
                originalWidth = result.Image.Width;
                originalHeight = result.Image.Height;
            }

            // Calculate the nearest power of 2 for width and height
            int paddedWidth = NearestPowerOf2(originalWidth);
            int paddedHeight = NearestPowerOf2(originalHeight);
            Bitmap image = new Bitmap(paddedWidth, paddedHeight);
            using (Graphics g = Graphics.FromImage(image))
            {
                // Set interpolation mode to high quality bicubic to ensure smooth resizing
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Draw the original image onto the new bitmap
                g.DrawImage(orginalimage.Image, 0, 0, paddedWidth, paddedHeight);
            }
            // Convert the image to grayscale
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(image);

            Bitmap filteredImage = ApplyHighPassFilter(grayImage);
            result.SizeMode = PictureBoxSizeMode.StretchImage;
            result.Image = filteredImage;

        }
    }
 }
    




