using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StaffGetter
{
    public partial class StaffGetterForm : System.Windows.Forms.Form
    {
        public StaffGetterForm()
        {
            InitializeComponent();
            fillComboBoxes();
        }

        private void fillComboBoxes()
        {
            LINQ linq = new LINQ();
            var names = linq.GetScientistsNames();
            foreach (var name in names)
            {
                namesComboBox.Items.Add(name);
            }

            var deps = linq.GetDepartmentsNames();
            foreach (var dep in deps)
            {
                departmentsComboBox.Items.Add(dep);
            }
        }

        public void Open()
        {
            Analizer_IStrategy method = null;
            if (DOM.Checked)
            {
                method = new DOM();
            }
            if (LINQ.Checked)
            {
                method = new LINQ();
            }
            if (SAX.Checked)
            {
                method = new SAX();
            }
            dynamic list = null;
            if (posChanges_radiobtn.Checked)
            {
                if (namesComboBox.Text != "")
                {
                    list = method.GetPosChanges(namesComboBox.Text);
                }
            }
            if (staffChanges_radiobtn.Checked)
            {
                if (departmentsComboBox.Text != "")
                {
                    list = method.GetStaffChangesOfDep(departmentsComboBox.Text);
                }
            }
           // if (list == null) return;
            Output(list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Output(dynamic list)
        {
           output_textbox.Text = "";
            
            if (list is List<PositionChange>)
            {
                foreach (var change in list)
                    output_textbox.Text += change.JoinTime + "\nкафедра " +  change.Department + "\nфакультет " + change.Faculty + "\n" + change.Position + "\n-----------------\n";
            }
            if (list is List<StaffChange>)
            {
                foreach (var change in list)
                {
                    foreach (var scientist in change.Scientists)
                    {
                        output_textbox.Text += scientist.Name + "\n" +
                            "факультет " + scientist.Faculty + "\n" +
                            "посада " + scientist.Position + "\n\n";

                    }
                    output_textbox.Text += " " + change.StartTime + "-" + change.FinishTime + "\n-----------------------------\n";
                }
            }
        }


        public void OpenXML()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open an xml";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                Links.Xml = @openFileDialog.FileName;
            }
        }

        public void Erase()
        {
            posChanges_radiobtn.Checked = false;
            staffChanges_radiobtn.Checked = false;
            LINQ.Checked = false;
            DOM.Checked = false;
            SAX.Checked = false;
        }

        private void erase_btn_Click(object sender, EventArgs e)
        {
            Erase();
        }

        private void transform_btn_Click(object sender, EventArgs e)
        {
            Transformator.Transform();
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem .Name == "open_xml") {
                output_textbox.Text = ("First toolbar button clicked");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Name == "open_xml")
            {
                output_textbox.Text = "First toolbar button clicked";
            }
            else
            {
                output_textbox.Text = "hoh";
            }
        }

        private void openxml_btn_Click(object sender, EventArgs e)
        {
            OpenXML();
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_2(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void departmentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void posChanges_radiobtn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
