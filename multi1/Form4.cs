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
using static multi1.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;


namespace multi1
{
    public partial class Form4 : Form
    {

        private SearchType currentType = SearchType.Size;
        private Label labelSizeUnit;
        private ImageList imageList;
        private ListView listView;
        private List<Bitmap> searchResults;
        private Form1 form1;
        public Form4(Form1 form1)
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeSizeUnitLabel();
            InitializeListView();
            textBox1.Visible = false; // Ensure sizeTextBox is initially hidden
            dateTimePicker1.Visible = false;
            labelSizeUnit.Visible = false;
            this.form1 = form1;


            // SelectedIndexChanged
            //comboBox2.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);
        }


        private void InitializeComboBox()
        {
            comboBox2.Items.Clear(); // Clear existing items
            comboBox2.Items.Add("Size");
            comboBox2.Items.Add("Date");
        }

        private void InitializeSizeUnitLabel()
        {
            labelSizeUnit = new Label
            {
                Location = new Point(textBox1.Right + 5, textBox1.Top),
                Text = "KB",
                AutoSize = true
            };
            this.Controls.Add(labelSizeUnit);
        }

        private void InitializeListView()
        {
            imageList = new ImageList
            {
                ImageSize = new Size(64, 64),
                ColorDepth = ColorDepth.Depth32Bit
            };

            listView = new ListView
            {
                View = View.LargeIcon,
                LargeImageList = imageList,
                Location = new Point(10, 100),
                Size = new Size(600, 400)
            };
            listView.ItemActivate += ListView_ItemActivate; // Add event handler for image click
            this.Controls.Add(listView);
            this.Controls.Add(listView);
        }

        public enum SearchType
        {
            Size,
            Date
        }



       

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedType = comboBox2.SelectedItem.ToString();
            if (selectedType == "Date")
            {
                currentType = SearchType.Date;
                dateTimePicker1.Visible = true;
                textBox1.Visible = false;
                labelSizeUnit.Visible = false;
            }
            else if (selectedType == "Size")
            {
                currentType = SearchType.Size;
                textBox1.Visible = true;
                dateTimePicker1.Visible = false;
                labelSizeUnit.Visible = true;
            }
            else
            {
                // Hide both controls initially
                textBox1.Visible = false;
                dateTimePicker1.Visible = false;
                labelSizeUnit.Visible = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchPath = @"C:\Users\ASUS\OneDrive\Pictures\Screenshots"; // Update this to your actual search path
            searchResults = new List<Bitmap>();

            if (currentType == SearchType.Size)
            {
                if (int.TryParse(textBox1.Text, out int sizeInKB))
                {
                    int sizeInBytes = sizeInKB * 1024; // Convert KB to bytes
                    searchResults = SearchBySize(searchPath, sizeInBytes, 1024);

                }
                else
                {
                    MessageBox.Show("Please enter a valid size in kilobytes (KB).");
                    return;
                }

            }
            else if (currentType == SearchType.Date)
            {
                DateTime selectedDate = dateTimePicker1.Value;
                searchResults = SearchByDate(searchPath, selectedDate);
            }



            listView.Items.Clear();
            imageList.Images.Clear();

            foreach (var file in searchResults)
            {
                imageList.Images.Add(file);

                listView.Items.Add(new ListViewItem { ImageIndex = imageList.Images.Count - 1 });
            }
        }

        private List<Bitmap> SearchBySize(string searchPath, int exactSize, int tolerance)
        {
            List<Bitmap> resultFiles = new List<Bitmap>();
            var files = Directory.GetFiles(searchPath, "*.*", SearchOption.AllDirectories);


            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                if (Math.Abs(fileInfo.Length - exactSize) <= tolerance)
                {
                    resultFiles.Add(new Bitmap(file));
                }
            }

            return resultFiles;


        }

        private List<Bitmap> SearchByDate(string searchPath, DateTime date)
        {
            List<Bitmap> resultFiles = new List<Bitmap>();
            var files = Directory.GetFiles(searchPath, "*.*", SearchOption.AllDirectories)
                                 .Where(file => File.GetLastWriteTime(file).Date == date.Date);


            foreach (var item in files)
            {
                resultFiles.Add(new Bitmap(item));
            }

            //resultFiles.AddRange(files);
            return resultFiles;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void ListView_ItemActivate(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int selectedIndex = listView.SelectedItems[0].Index;
                Bitmap selectedImage = searchResults[selectedIndex];


                this.form1.AddImage(selectedImage); // Call method in Form1
                this.Close();
            }
        }
    }
}
