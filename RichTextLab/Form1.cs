using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RichTextLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBold_MouseClick(object sender, MouseEventArgs e)
        {
            if (rtbDoc.SelectedText != null)
            {
                if (((Button)sender).Text == "Жирный")
                {
                    rtbDoc.SelectionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                }
                else
                {
                    if (((Button)sender).Text == "Курсив")
                    {
                        rtbDoc.SelectionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Italic);
                    }
                    else
                    {
                        rtbDoc.SelectionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                    }
                }
                
            }
        }

        private void btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            DocumentForm documentForm = (DocumentForm)this.ParentForm;
            if (documentForm != null && !string.IsNullOrEmpty(documentForm.FilePath))
            {
                documentForm.RichTextBox.SaveFile(documentForm.FilePath, RichTextBoxStreamType.RichText);
            }
        }

        private void btnNewDocument_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "RTF Files|*.rtf";
            saveFileDialog.Title = "Создать новый документ RTF";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                DocumentForm documentForm = new DocumentForm(filePath);
                documentForm.Show();
            }
        }

        private void rtbDoc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
