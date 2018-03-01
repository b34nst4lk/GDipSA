using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TextBoxesAndInputs
{
    public partial class TextBoxesAndInputs : Form
    {
        public TextBoxesAndInputs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AllScrollTextBox.Text);
            MessageBox.Show(AllScrollTextBox.Text.Length + " characters");
        }

        private void RadioButtonButton_Click(object sender, EventArgs e)
        {
            string output = String.Format("Radio button values:\nInner1: {0}\nInner2: {1}\nOuter1: {2}\nOuter2: {3}",
                                          InnerRadio1.Checked, InnerRadio2.Checked, OuterRadio1.Checked, OuterRadio2.Checked);

            MessageBox.Show(output);
        }

        private void MixedRadioButtonButton_Click(object sender, EventArgs e)
        {
            string output = String.Format("Radio button values:\nMultiLine Radio: {0}\nSingle Line Radio: {1}\nMultiLine Button: {2}\nSingle Line: {3}",
                                          MultiLineRadioRadioButton.Checked, 
                                          SingleLineRadioRadioButton.Checked, 
                                          MultiLineButtonRadioButton.Checked, 
                                          SingleLineButtonRadioButton.Checked);

            MessageBox.Show(output);
        }

        private void ClearRadioButton_Click(object sender, EventArgs e)
        {
            var controls = GetAll(this, typeof(RadioButton));

            foreach (Control control in controls)
            {
                RadioButton rb = (RadioButton)control;
                if(rb.Checked)
                {
                    rb.Checked = false;
                }
            }
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrls => GetAll(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        private void CheckBoxGroupingButton_Click(object sender, EventArgs e)
        {
            string output = String.Format("Checkbox values:\nSingle Line Checkbox Button: {0}\nMultiLine Checkbox Button: {1}\nSingle Line Checkbox: {2}\nMultiLine Checkbox: {3}",
                                          SingleLineCheckBoxButton.Checked,
                                          MultiLineCheckBoxButton.Checked,
                                          SingleLineCheckBox.Checked,
                                          MultiLineCheckBox.Checked);

            MessageBox.Show(output);
        }



        private void ComboBoxGroupingButton_Click(object sender, EventArgs e)
        {
            string output = String.Format("ComboBox values:\nSimple ComboBox: {0}\nDropdown ComboBox: {1}\nDropdown List ComboBox: {2}",
                                          SimpleComboBox.Text,
                                          DropDownComboBox.Text,
                                          DropDownListComboBox.Text);

            MessageBox.Show(output);
        }

        private void ListBoxGroupingButton_Click(object sender, EventArgs e)
        {
            var controls = GetAll(this, typeof(ListBox));

            string output = "ListBox values:\n";

            foreach (Control control in controls)
            {
                ListBox rb = (ListBox)control;
                if (rb.SelectedItems.Count > 0)
                {
                    List<String> subList = new List<String>();
                    foreach (String item in rb.SelectedItems)
                    {
                        subList.Add(item);
                    }

                    output += rb.Name + ": " + String.Join(", ", subList) + "\n";
                }
            }

            MessageBox.Show(output);
        }
    }
}
