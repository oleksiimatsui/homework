
namespace StaffGetter
{
    partial class StaffGetterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.output_textbox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LINQ = new System.Windows.Forms.RadioButton();
            this.SAX = new System.Windows.Forms.RadioButton();
            this.DOM = new System.Windows.Forms.RadioButton();
            this.erase_btn = new System.Windows.Forms.Button();
            this.changes_on_dep_radiobtn = new System.Windows.Forms.RadioButton();
            this.Changes_radiobtn = new System.Windows.Forms.RadioButton();
            this.namesComboBox = new System.Windows.Forms.ComboBox();
            this.departmentsComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.facultyNow_radiobtn = new System.Windows.Forms.RadioButton();
            this.depNow_radiobtn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.facultiesComboBox = new System.Windows.Forms.ComboBox();
            this.changes_on_faculty_radiobtn = new System.Windows.Forms.RadioButton();
            this.transform_btn = new System.Windows.Forms.Button();
            this.openxml_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // output_textbox
            // 
            this.output_textbox.BackColor = System.Drawing.Color.White;
            this.output_textbox.Location = new System.Drawing.Point(348, 37);
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.ReadOnly = true;
            this.output_textbox.Size = new System.Drawing.Size(440, 370);
            this.output_textbox.TabIndex = 4;
            this.output_textbox.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(806, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Відкрити";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LINQ
            // 
            this.LINQ.AutoSize = true;
            this.LINQ.Location = new System.Drawing.Point(806, 40);
            this.LINQ.Name = "LINQ";
            this.LINQ.Size = new System.Drawing.Size(114, 24);
            this.LINQ.TabIndex = 10;
            this.LINQ.TabStop = true;
            this.LINQ.Text = "LINQ to XML";
            this.LINQ.UseVisualStyleBackColor = true;
            // 
            // SAX
            // 
            this.SAX.AutoSize = true;
            this.SAX.Location = new System.Drawing.Point(806, 68);
            this.SAX.Name = "SAX";
            this.SAX.Size = new System.Drawing.Size(57, 24);
            this.SAX.TabIndex = 11;
            this.SAX.TabStop = true;
            this.SAX.Text = "SAX";
            this.SAX.UseVisualStyleBackColor = true;
            // 
            // DOM
            // 
            this.DOM.AutoSize = true;
            this.DOM.Location = new System.Drawing.Point(806, 98);
            this.DOM.Name = "DOM";
            this.DOM.Size = new System.Drawing.Size(65, 24);
            this.DOM.TabIndex = 12;
            this.DOM.TabStop = true;
            this.DOM.Text = "DOM";
            this.DOM.UseVisualStyleBackColor = true;
            // 
            // erase_btn
            // 
            this.erase_btn.BackColor = System.Drawing.Color.White;
            this.erase_btn.Location = new System.Drawing.Point(9, 335);
            this.erase_btn.Name = "erase_btn";
            this.erase_btn.Size = new System.Drawing.Size(88, 33);
            this.erase_btn.TabIndex = 13;
            this.erase_btn.Text = "Очистити";
            this.erase_btn.UseVisualStyleBackColor = false;
            this.erase_btn.Click += new System.EventHandler(this.erase_btn_Click);
            // 
            // changes_on_dep_radiobtn
            // 
            this.changes_on_dep_radiobtn.AutoSize = true;
            this.changes_on_dep_radiobtn.Location = new System.Drawing.Point(9, 42);
            this.changes_on_dep_radiobtn.Name = "changes_on_dep_radiobtn";
            this.changes_on_dep_radiobtn.Size = new System.Drawing.Size(183, 24);
            this.changes_on_dep_radiobtn.TabIndex = 15;
            this.changes_on_dep_radiobtn.TabStop = true;
            this.changes_on_dep_radiobtn.Text = "Зміни складу кафедри";
            this.changes_on_dep_radiobtn.UseVisualStyleBackColor = true;
            // 
            // Changes_radiobtn
            // 
            this.Changes_radiobtn.AutoSize = true;
            this.Changes_radiobtn.Location = new System.Drawing.Point(9, 268);
            this.Changes_radiobtn.Name = "Changes_radiobtn";
            this.Changes_radiobtn.Size = new System.Drawing.Size(196, 24);
            this.Changes_radiobtn.TabIndex = 16;
            this.Changes_radiobtn.TabStop = true;
            this.Changes_radiobtn.Text = "Переміщення науковця";
            this.Changes_radiobtn.UseVisualStyleBackColor = true;
            this.Changes_radiobtn.CheckedChanged += new System.EventHandler(this.posChanges_radiobtn_CheckedChanged);
            // 
            // namesComboBox
            // 
            this.namesComboBox.FormattingEnabled = true;
            this.namesComboBox.Location = new System.Drawing.Point(87, 234);
            this.namesComboBox.Name = "namesComboBox";
            this.namesComboBox.Size = new System.Drawing.Size(226, 28);
            this.namesComboBox.TabIndex = 17;
            // 
            // departmentsComboBox
            // 
            this.departmentsComboBox.FormattingEnabled = true;
            this.departmentsComboBox.Location = new System.Drawing.Point(85, 16);
            this.departmentsComboBox.Name = "departmentsComboBox";
            this.departmentsComboBox.Size = new System.Drawing.Size(228, 28);
            this.departmentsComboBox.TabIndex = 18;
            this.departmentsComboBox.SelectedIndexChanged += new System.EventHandler(this.departmentsComboBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.facultyNow_radiobtn);
            this.panel1.Controls.Add(this.depNow_radiobtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.erase_btn);
            this.panel1.Controls.Add(this.facultiesComboBox);
            this.panel1.Controls.Add(this.changes_on_faculty_radiobtn);
            this.panel1.Controls.Add(this.Changes_radiobtn);
            this.panel1.Controls.Add(this.departmentsComboBox);
            this.panel1.Controls.Add(this.namesComboBox);
            this.panel1.Controls.Add(this.changes_on_dep_radiobtn);
            this.panel1.Location = new System.Drawing.Point(4, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 446);
            this.panel1.TabIndex = 19;
            // 
            // facultyNow_radiobtn
            // 
            this.facultyNow_radiobtn.AutoSize = true;
            this.facultyNow_radiobtn.Location = new System.Drawing.Point(9, 183);
            this.facultyNow_radiobtn.Name = "facultyNow_radiobtn";
            this.facultyNow_radiobtn.Size = new System.Drawing.Size(192, 24);
            this.facultyNow_radiobtn.TabIndex = 27;
            this.facultyNow_radiobtn.TabStop = true;
            this.facultyNow_radiobtn.Text = "Склад факультету зараз";
            this.facultyNow_radiobtn.UseVisualStyleBackColor = true;
            // 
            // depNow_radiobtn
            // 
            this.depNow_radiobtn.AutoSize = true;
            this.depNow_radiobtn.Location = new System.Drawing.Point(9, 72);
            this.depNow_radiobtn.Name = "depNow_radiobtn";
            this.depNow_radiobtn.Size = new System.Drawing.Size(176, 24);
            this.depNow_radiobtn.TabIndex = 25;
            this.depNow_radiobtn.TabStop = true;
            this.depNow_radiobtn.Text = "Склад кафедри зараз";
            this.depNow_radiobtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Науковці";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Факультети";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Кафедри";
            // 
            // facultiesComboBox
            // 
            this.facultiesComboBox.FormattingEnabled = true;
            this.facultiesComboBox.Location = new System.Drawing.Point(102, 119);
            this.facultiesComboBox.Name = "facultiesComboBox";
            this.facultiesComboBox.Size = new System.Drawing.Size(211, 28);
            this.facultiesComboBox.TabIndex = 20;
            // 
            // changes_on_faculty_radiobtn
            // 
            this.changes_on_faculty_radiobtn.AutoSize = true;
            this.changes_on_faculty_radiobtn.Location = new System.Drawing.Point(9, 153);
            this.changes_on_faculty_radiobtn.Name = "changes_on_faculty_radiobtn";
            this.changes_on_faculty_radiobtn.Size = new System.Drawing.Size(199, 24);
            this.changes_on_faculty_radiobtn.TabIndex = 19;
            this.changes_on_faculty_radiobtn.TabStop = true;
            this.changes_on_faculty_radiobtn.Text = "Зміни складу факультету";
            this.changes_on_faculty_radiobtn.UseVisualStyleBackColor = true;
            // 
            // transform_btn
            // 
            this.transform_btn.BackColor = System.Drawing.Color.White;
            this.transform_btn.Location = new System.Drawing.Point(133, 0);
            this.transform_btn.Name = "transform_btn";
            this.transform_btn.Size = new System.Drawing.Size(201, 34);
            this.transform_btn.TabIndex = 20;
            this.transform_btn.Text = "Трансформувати в html";
            this.transform_btn.UseVisualStyleBackColor = false;
            this.transform_btn.Click += new System.EventHandler(this.transform_btn_Click);
            // 
            // openxml_btn
            // 
            this.openxml_btn.BackColor = System.Drawing.Color.White;
            this.openxml_btn.Location = new System.Drawing.Point(-8, 0);
            this.openxml_btn.Name = "openxml_btn";
            this.openxml_btn.Size = new System.Drawing.Size(135, 33);
            this.openxml_btn.TabIndex = 19;
            this.openxml_btn.Text = "відкрити xml";
            this.openxml_btn.UseVisualStyleBackColor = false;
            this.openxml_btn.Click += new System.EventHandler(this.openxml_btn_Click);
            // 
            // StaffGetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(952, 455);
            this.Controls.Add(this.openxml_btn);
            this.Controls.Add(this.transform_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DOM);
            this.Controls.Add(this.SAX);
            this.Controls.Add(this.LINQ);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output_textbox);
            this.Name = "StaffGetterForm";
            this.Text = "StaffGetter";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox output_textbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton LINQ;
        private System.Windows.Forms.RadioButton SAX;
        private System.Windows.Forms.RadioButton DOM;
        private System.Windows.Forms.Button erase_btn;
        private System.Windows.Forms.RadioButton changes_on_dep_radiobtn;
        private System.Windows.Forms.RadioButton Changes_radiobtn;
        private System.Windows.Forms.ComboBox namesComboBox;
        private System.Windows.Forms.ComboBox departmentsComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button transform_btn;
        private System.Windows.Forms.Button openxml_btn;
        private System.Windows.Forms.ComboBox facultiesComboBox;
        private System.Windows.Forms.RadioButton changes_on_faculty_radiobtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton depNow_radiobtn;
        private System.Windows.Forms.RadioButton facultyNow_radiobtn;
    }
}

