using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RichTextLab
{
    public partial class DocumentForm : Form
    {

        private string filePath;

        public DocumentForm(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
        }
      public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        public RichTextBox RichTextBox {
            get { return richTextBox; } 
        }

        private void DocumentForm_Load(object sender, EventArgs e)
        {
            AddFontButtons();
            AddColorButton();
            AddFontSizeButtons();
            AddBackgroundColorButton();

            if (File.Exists(filePath))
            {
                richTextBox.LoadFile(filePath, RichTextBoxStreamType.RichText);
            }
        }
       
        private void AddFontButtons()
        {
            // Создаем кнопки для изменения шрифта
            Button btnBold = new Button();
            btnBold.Text = "Жирный";
            btnBold.Click += (sender, e) =>
            {
                richTextBox.SelectionFont = new Font(richTextBox.Font, richTextBox.SelectionFont.Style ^ FontStyle.Bold);
            };

            Button btnItalic = new Button();
            btnItalic.Text = "Курсив";
            btnItalic.Click += (sender, e) =>
            {
                richTextBox.SelectionFont = new Font(richTextBox.Font, richTextBox.SelectionFont.Style ^ FontStyle.Italic);
            };

            
            Button btnRegular = new Button();
            btnRegular.Text = "Обычный";
            btnRegular.Click += (sender, e) =>
            {
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
            };

            // Добавляем кнопки на форму
            flowLayoutPanel.Controls.Add(btnBold);
            flowLayoutPanel.Controls.Add(btnItalic);
            flowLayoutPanel.Controls.Add(btnRegular);
        }
       
           
        
            private void AddColorButton()
        {
            // Создаем кнопку для выбора цвета шрифта
            Button btnColor = new Button();
            btnColor.Text = "Цвет";
            btnColor.Click += (sender, e) =>
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SelectionColor = colorDialog.Color;
                }
            };

            // Добавляем кнопку на форму
            flowLayoutPanel.Controls.Add(btnColor);
        }


        
            private void AddFontSizeButtons()
        {
            // Создаем кнопки для выбора размера шрифта
            int[] fontSizes = { 8, 10, 12, 14, 16, 18, 20 };
            foreach (int fontSize in fontSizes)
            {
                Button btnFontSize = new Button();
                btnFontSize.Text = fontSize.ToString();
                btnFontSize.Tag = fontSize;
                btnFontSize.Click += (sender, e) =>
                {
                    Button button = (Button)sender;
                    int selectedFontSize = (int)button.Tag;
                    richTextBox.SelectionFont = new Font(richTextBox.SelectionFont.FontFamily, selectedFontSize, richTextBox.SelectionFont.Style);
                };

                // на форму
            flowLayoutPanel.Controls.Add(btnFontSize);
            }
        }
        
        private void AddBackgroundColorButton()
        {
            // Создаем кнопку для выбора цвета фона документа
            Button btnBackgroundColor = new Button();
            btnBackgroundColor.Text = "Фон";
            btnBackgroundColor.Click += (sender, e) =>
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.BackColor = colorDialog.Color;
                }
            };

            //  на форму
            flowLayoutPanel.Controls.Add(btnBackgroundColor);
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                richTextBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
                this.Close();
            }
        }
    }
}
