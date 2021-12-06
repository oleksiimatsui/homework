
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
            this.staffChanges_radiobtn = new System.Windows.Forms.RadioButton();
            this.posChanges_radiobtn = new System.Windows.Forms.RadioButton();
            this.namesComboBox = new System.Windows.Forms.ComboBox();
            this.departmentsComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.transform_btn = new System.Windows.Forms.Button();
            this.openxml_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // output_textbox
            // 
            this.output_textbox.BackColor = System.Drawing.Color.White;
            this.output_textbox.Location = new System.Drawing.Point(333, 37);
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.ReadOnly = true;
            this.output_textbox.Size = new System.Drawing.Size(422, 326);
            this.output_textbox.TabIndex = 4;
            this.output_textbox.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(333, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(422, 72);
            this.button1.TabIndex = 5;
            this.button1.Text = "Відкрити";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LINQ
            // 
            this.LINQ.AutoSize = true;
            this.LINQ.Location = new System.Drawing.Point(21, 370);
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
            this.SAX.Location = new System.Drawing.Point(21, 400);
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
            this.DOM.Location = new System.Drawing.Point(21, 430);
            this.DOM.Name = "DOM";
            this.DOM.Size = new System.Drawing.Size(65, 24);
            this.DOM.TabIndex = 12;
            this.DOM.TabStop = true;
            this.DOM.Text = "DOM";
            this.DOM.UseVisualStyleBackColor = true;
            // 
            // erase_btn
            // 
            this.erase_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.erase_btn.Location = new System.Drawing.Point(219, 376);
            this.erase_btn.Name = "erase_btn";
            this.erase_btn.Size = new System.Drawing.Size(88, 29);
            this.erase_btn.TabIndex = 13;
            this.erase_btn.Text = "Очистити";
            this.erase_btn.UseVisualStyleBackColor = false;
            this.erase_btn.Click += new System.EventHandler(this.erase_btn_Click);
            // 
            // staffChanges_radiobtn
            // 
            this.staffChanges_radiobtn.AutoSize = true;
            this.staffChanges_radiobtn.Location = new System.Drawing.Point(9, 64);
            this.staffChanges_radiobtn.Name = "staffChanges_radiobtn";
            this.staffChanges_radiobtn.Size = new System.Drawing.Size(183, 24);
            this.staffChanges_radiobtn.TabIndex = 15;
            this.staffChanges_radiobtn.TabStop = true;
            this.staffChanges_radiobtn.Text = "Зміни складу кафедри";
            this.staffChanges_radiobtn.UseVisualStyleBackColor = true;
            // 
            // posChanges_radiobtn
            // 
            this.posChanges_radiobtn.AutoSize = true;
            this.posChanges_radiobtn.Location = new System.Drawing.Point(8, 0);
            this.posChanges_radiobtn.Name = "posChanges_radiobtn";
            this.posChanges_radiobtn.Size = new System.Drawing.Size(252, 24);
            this.posChanges_radiobtn.TabIndex = 16;
            this.posChanges_radiobtn.TabStop = true;
            this.posChanges_radiobtn.Text = "Переміщення з посад науковця";
            this.posChanges_radiobtn.UseVisualStyleBackColor = true;
            this.posChanges_radiobtn.CheckedChanged += new System.EventHandler(this.posChanges_radiobtn_CheckedChanged);
            // 
            // namesComboBox
            // 
            this.namesComboBox.FormattingEnabled = true;
            this.namesComboBox.Location = new System.Drawing.Point(25, 30);
            this.namesComboBox.Name = "namesComboBox";
            this.namesComboBox.Size = new System.Drawing.Size(227, 28);
            this.namesComboBox.TabIndex = 17;
            // 
            // departmentsComboBox
            // 
            this.departmentsComboBox.FormattingEnabled = true;
            this.departmentsComboBox.Location = new System.Drawing.Point(25, 94);
            this.departmentsComboBox.Name = "departmentsComboBox";
            this.departmentsComboBox.Size = new System.Drawing.Size(227, 28);
            this.departmentsComboBox.TabIndex = 18;
            this.departmentsComboBox.SelectedIndexChanged += new System.EventHandler(this.departmentsComboBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.posChanges_radiobtn);
            this.panel1.Controls.Add(this.departmentsComboBox);
            this.panel1.Controls.Add(this.namesComboBox);
            this.panel1.Controls.Add(this.staffChanges_radiobtn);
            this.panel1.Location = new System.Drawing.Point(4, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 326);
            this.panel1.TabIndex = 19;
            // 
            // transform_btn
            // 
            this.transform_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.transform_btn.Location = new System.Drawing.Point(172, 411);
            this.transform_btn.Name = "transform_btn";
            this.transform_btn.Size = new System.Drawing.Size(135, 37);
            this.transform_btn.TabIndex = 20;
            this.transform_btn.Text = "Трансформувати";
            this.transform_btn.UseVisualStyleBackColor = false;
            this.transform_btn.Click += new System.EventHandler(this.transform_btn_Click);
            // 
            // openxml_btn
            // 
            this.openxml_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.openxml_btn.Location = new System.Drawing.Point(4, 2);
            this.openxml_btn.Name = "openxml_btn";
            this.openxml_btn.Size = new System.Drawing.Size(94, 29);
            this.openxml_btn.TabIndex = 19;
            this.openxml_btn.Text = "open_xml";
            this.openxml_btn.UseVisualStyleBackColor = false;
            this.openxml_btn.Click += new System.EventHandler(this.openxml_btn_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(771, 495);
            this.Controls.Add(this.openxml_btn);
            this.Controls.Add(this.transform_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.erase_btn);
            this.Controls.Add(this.DOM);
            this.Controls.Add(this.SAX);
            this.Controls.Add(this.LINQ);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output_textbox);
            this.Name = "Form";
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
        private System.Windows.Forms.RadioButton staffChanges_radiobtn;
        private System.Windows.Forms.RadioButton posChanges_radiobtn;
        private System.Windows.Forms.ComboBox namesComboBox;
        private System.Windows.Forms.ComboBox departmentsComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button transform_btn;
        private System.Windows.Forms.Button openxml_btn;
    }
}

