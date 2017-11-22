using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DataValidation
{
    public partial class dataValidationForm : Form
    {
        Dictionary<string, string> elements = new Dictionary<string, string>();

        public dataValidationForm()
        {
            InitializeComponent();
            elements.Add("nameBox", "name");
            elements.Add("phoneBox", "phone number");
            elements.Add("emailBox", "e-mail address");
            nameBox.TextChanged += new EventHandler(TextBox_TextChanged);
            phoneBox.TextChanged += new EventHandler(TextBox_TextChanged);
            emailBox.TextChanged += new EventHandler(TextBox_TextChanged);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            List<TextBox> invalidInputs = GetInvalidInputs(new List<TextBox> { nameBox, phoneBox, emailBox });
            foreach (TextBox item in invalidInputs)
            {
                errorMessage += (errorMessage.Length > 0) ? "\n" : "";
                errorMessage += $"Please enter a valid {elements[item.Name]}.";
            }
            if (errorMessage.Length > 0)
            {
                foreach (TextBox item in invalidInputs)
                {
                    item.BackColor = Color.LightCoral;
                }
                DialogResult dialogResult = MessageBox.Show(errorMessage);
                if (dialogResult == DialogResult.OK)
                {
                    invalidInputs[0].Focus();
                }
            }
            else
                MessageBox.Show("Data saved successfully.");
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<TextBox> GetInvalidInputs(List<TextBox> inputs)
        {
            InputValidator validator = new InputValidator();
            List<TextBox> invalidInputs = new List<TextBox>();
            if (!validator.ValidName(inputs[0].Text))
            {
                invalidInputs.Add(inputs[0]);
            }
            if (!validator.ValidPhone(inputs[1].Text))
            {
                invalidInputs.Add(inputs[1]);
            }
            if (!validator.ValidEmail(inputs[2].Text))
            {
                invalidInputs.Add(inputs[2]);
            }
            return invalidInputs;
        }
    }
}
