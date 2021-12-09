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
            var facs = linq.GetFacultiesNames();
            foreach (var fac in facs)
            {
                facultiesComboBox.Items.Add(fac);
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
            if (method == null)
            {
                output_textbox.Text = "Виберіть спосіб пошуку";
                return;
            }
            dynamic list = null;
            if (Changes_radiobtn.Checked)   //вивести усі зміни людини
            {
                if (namesComboBox.Text != "")
                {
                    list = method.GetChanges(namesComboBox.Text);
                }
            }
            if (changes_on_dep_radiobtn.Checked)  //вивести усі зміни складу кафедри
            {
                if (departmentsComboBox.Text != "")
                {
                    Search search = new Search { Department = departmentsComboBox.Text };
                    list = method.GetStaffChanges(search);
                }
            }
            if (changes_on_faculty_radiobtn.Checked)    //вивести усі зміни складу факультету
            {
                if (facultiesComboBox.Text != "")
                {
                    Search search = new Search { Faculty = facultiesComboBox.Text };
                    list = method.GetStaffChanges(search);
                }
            }

            if (depNow_radiobtn.Checked)     //вивести науковців на кафедрі
            {
                if (departmentsComboBox.Text != "")
                {
                    Search search = new Search { Department = departmentsComboBox.Text };
                    list = method.GetScientistsNow(search, "now" , "now");
                }
            }
            if (facultyNow_radiobtn.Checked)     //вивести науковців на факультеті
            {
                if (facultiesComboBox.Text != "")
                {
                    Search search = new Search { Faculty = facultiesComboBox.Text };
                    list = method.GetScientistsNow(search, "now", "now");
                }
            }

            if (list == null) return;
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
                    output_textbox.Text += change.JoinTime + "-" + change.TillTime + "\nкафедра " +  change.Department + "\nфакультет " + change.Faculty + "\n" + change.Position + "\n-----------------\n";
            }
            if (list is List<StaffChange>)
            {
                foreach (var change in list)
                {
                    output_textbox.Text += change.StartTime + " - " + change.FinishTime + "\n\n";
                    foreach (var scientist in change.Scientists)
                    {
                        output_textbox.Text += scientist.Name + "\n";
                        if (scientist.Faculty != null) output_textbox.Text += "факультет " + scientist.Faculty + "\n";
                        if (scientist.Department != null) output_textbox.Text += "кафедра " + scientist.Department + "\n";
                        if (scientist.Position != null) output_textbox.Text += "посада " + scientist.Position + "\n";
                        output_textbox.Text += "\n";
                    }
                    if (change.Scientists.Count == 0) output_textbox.Text += "Жодного науковця!\n";
                    output_textbox.Text += "-----------------------------\n";
                }
            }
            if (list is List<ScientistNow>)
            {
                foreach (var scientist in list)
                {
                    output_textbox.Text += scientist.Name + "\n";
                    if (scientist.Faculty != null) output_textbox.Text += "факультет " + scientist.Faculty + "\n";
                    if (scientist.Department != null) output_textbox.Text += "кафедра " + scientist.Department + "\n";
                    if (scientist.Position != null) output_textbox.Text += "посада " + scientist.Position + "\n";
                    output_textbox.Text += "\n";
                }
                if (list.Count == 0) output_textbox.Text += "Жодного науковця!\n";
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
            Changes_radiobtn.Checked = false;
            changes_on_dep_radiobtn.Checked = false;
            LINQ.Checked = false;
            DOM.Checked = false;
            SAX.Checked = false;
            output_textbox.Text = "";
            namesComboBox.SelectedIndex = -1;
            departmentsComboBox.SelectedIndex = -1;
            facultiesComboBox.SelectedIndex = -1;
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
