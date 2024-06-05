using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO.Compression;

namespace multi1
{
    public partial class reportform : Form
    {
        public reportform()
        {
            InitializeComponent();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt|PDF Files|*.pdf|All files|*.*";
            saveFileDialog.Title = "Save Text Inputs";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                string[] texts = new string[]
                {
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    textBox4.Text
                };

                if (extension == ".pdf")
                {
                    SaveAsPdf(filePath, texts);
                }
                else
                {
                    SaveAsText(filePath, texts);
                }

                MessageBox.Show("report saved successfully.");
            }
        }

        private void SaveAsText(string filePath, string[] texts)
        {
            File.WriteAllLines(filePath, texts);
        }

        private void SaveAsPdf(string filePath, string[] texts)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                foreach (string text in texts)
                {
                    document.Add(new Paragraph(text));
                }
                document.Close();
                writer.Close();
            }
        }

        private void CompressAndSaveButton_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ZIP Files|*.zip";
            saveFileDialog.Title = "Save Files as ZIP";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string zipFilePath = saveFileDialog.FileName;

                string[] texts = new string[]
                {
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    textBox4.Text
                };

                string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempDir);

                try
                {
                    string textFilePath = Path.Combine(tempDir, "report.txt");
                    File.WriteAllLines(textFilePath, texts);

                    string pdfFilePath = Path.Combine(tempDir, "report.pdf");
                    SaveAsPdf(pdfFilePath, texts);

                   
                    ZipFile.CreateFromDirectory(tempDir, zipFilePath);

                    MessageBox.Show("Files compressed and saved successfully.");
                }
                finally
                {
                    Directory.Delete(tempDir, true);
                }
            }
        }
    }
}
