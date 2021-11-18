
using System.Windows.Forms;

namespace ExpressionCalculation
{
    partial class ExpCalcForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpCalcForm));
            this.Formula = new System.Windows.Forms.TextBox();
            this.changeview = new System.Windows.Forms.Button();
            this.newtablebtn = new System.Windows.Forms.Button();
            this.open_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.DataGridView();
            this.edit_btn = new System.Windows.Forms.Button();
            this.dovidka_btn = new System.Windows.Forms.Button();
            this.file_btn = new System.Windows.Forms.Button();
            this.dovidka_panel = new System.Windows.Forms.Panel();
            this.dovidka = new System.Windows.Forms.TextBox();
            this.about_panel = new System.Windows.Forms.Panel();
            this.about = new System.Windows.Forms.TextBox();
            this.file_panel = new System.Windows.Forms.Panel();
            this.edit_panel = new System.Windows.Forms.Panel();
            this.removecol_btn = new System.Windows.Forms.Button();
            this.addcol_btn = new System.Windows.Forms.Button();
            this.removerow_btn = new System.Windows.Forms.Button();
            this.addrow_btn = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.Panel();
            this.about_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.dovidka_panel.SuspendLayout();
            this.about_panel.SuspendLayout();
            this.file_panel.SuspendLayout();
            this.edit_panel.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Formula
            // 
            this.Formula.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Formula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Formula.Location = new System.Drawing.Point(223, 11);
            this.Formula.Multiline = true;
            this.Formula.Name = "Formula";
            this.Formula.ReadOnly = true;
            this.Formula.Size = new System.Drawing.Size(441, 25);
            this.Formula.TabIndex = 7;
            // 
            // changeview
            // 
            this.changeview.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.changeview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.changeview.FlatAppearance.BorderSize = 0;
            this.changeview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeview.Location = new System.Drawing.Point(670, 0);
            this.changeview.Name = "changeview";
            this.changeview.Size = new System.Drawing.Size(142, 42);
            this.changeview.TabIndex = 6;
            this.changeview.Text = "вираз/значення";
            this.changeview.UseVisualStyleBackColor = false;
            this.changeview.Click += new System.EventHandler(this.formulaview_btn_Click);
            // 
            // newtablebtn
            // 
            this.newtablebtn.Location = new System.Drawing.Point(17, 7);
            this.newtablebtn.Name = "newtablebtn";
            this.newtablebtn.Size = new System.Drawing.Size(190, 29);
            this.newtablebtn.TabIndex = 2;
            this.newtablebtn.Text = "Нова таблиця";
            this.newtablebtn.UseVisualStyleBackColor = true;
            this.newtablebtn.Click += new System.EventHandler(this.newtablebtn_Click);
            // 
            // open_btn
            // 
            this.open_btn.Location = new System.Drawing.Point(17, 42);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(190, 29);
            this.open_btn.TabIndex = 1;
            this.open_btn.Text = "Відкрити";
            this.open_btn.UseVisualStyleBackColor = true;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(17, 77);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(190, 29);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "Зберегти";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_Click);
            // 
            // table
            // 
            this.table.AccessibleDescription = "table";
            this.table.AccessibleName = "table";
            this.table.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(-5, 42);
            this.table.Name = "table";
            this.table.RowHeadersWidth = 51;
            this.table.RowTemplate.Height = 29;
            this.table.Size = new System.Drawing.Size(1157, 734);
            this.table.TabIndex = 1;
            this.table.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellValueChanged);
            this.table.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellSelected);
            // 
            // edit_btn
            // 
            this.edit_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.edit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.edit_btn.FlatAppearance.BorderSize = 0;
            this.edit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_btn.Location = new System.Drawing.Point(105, 1);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(102, 42);
            this.edit_btn.TabIndex = 9;
            this.edit_btn.Text = "Редагувати";
            this.edit_btn.UseVisualStyleBackColor = false;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // dovidka_btn
            // 
            this.dovidka_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dovidka_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dovidka_btn.FlatAppearance.BorderSize = 0;
            this.dovidka_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dovidka_btn.Location = new System.Drawing.Point(818, 0);
            this.dovidka_btn.Name = "dovidka_btn";
            this.dovidka_btn.Size = new System.Drawing.Size(150, 42);
            this.dovidka_btn.TabIndex = 8;
            this.dovidka_btn.Text = "Довідка";
            this.dovidka_btn.UseVisualStyleBackColor = false;
            this.dovidka_btn.Click += new System.EventHandler(this.dovidka_btn_Click);
            // 
            // file_btn
            // 
            this.file_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.file_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.file_btn.FlatAppearance.BorderSize = 0;
            this.file_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file_btn.Location = new System.Drawing.Point(0, 1);
            this.file_btn.Name = "file_btn";
            this.file_btn.Size = new System.Drawing.Size(94, 42);
            this.file_btn.TabIndex = 0;
            this.file_btn.Text = "Файл";
            this.file_btn.UseVisualStyleBackColor = false;
            this.file_btn.Click += new System.EventHandler(this.file_btn_Click);
            // 
            // dovidka_panel
            // 
            this.dovidka_panel.Controls.Add(this.dovidka);
            this.dovidka_panel.Location = new System.Drawing.Point(813, 42);
            this.dovidka_panel.Name = "dovidka_panel";
            this.dovidka_panel.Size = new System.Drawing.Size(250, 250);
            this.dovidka_panel.TabIndex = 9;
            this.dovidka_panel.Visible = false;
            // 
            // dovidka
            // 
            this.dovidka.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dovidka.Location = new System.Drawing.Point(0, 0);
            this.dovidka.Multiline = true;
            this.dovidka.Name = "dovidka";
            this.dovidka.ReadOnly = true;
            this.dovidka.Size = new System.Drawing.Size(250, 234);
            this.dovidka.TabIndex = 0;
            this.dovidka.Text = resources.GetString("dovidka.Text");
            // 
            // about_panel
            // 
            this.about_panel.Controls.Add(this.about);
            this.about_panel.Location = new System.Drawing.Point(902, 42);
            this.about_panel.Name = "about_panel";
            this.about_panel.Size = new System.Drawing.Size(250, 152);
            this.about_panel.TabIndex = 10;
            this.about_panel.Visible = false;
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.WhiteSmoke;
            this.about.Location = new System.Drawing.Point(0, 0);
            this.about.Multiline = true;
            this.about.Name = "about";
            this.about.ReadOnly = true;
            this.about.Size = new System.Drawing.Size(250, 136);
            this.about.TabIndex = 0;
            this.about.Text = "Програма створена у листопаді 2021-ого року для лабораторної роботи 1 з об\'єктно-" +
    "орієнтованого програмування. При написанні використовувались json та antlr4.";
            // 
            // file_panel
            // 
            this.file_panel.Controls.Add(this.save_btn);
            this.file_panel.Controls.Add(this.newtablebtn);
            this.file_panel.Controls.Add(this.open_btn);
            this.file_panel.Location = new System.Drawing.Point(-5, 42);
            this.file_panel.Name = "file_panel";
            this.file_panel.Size = new System.Drawing.Size(230, 114);
            this.file_panel.TabIndex = 8;
            this.file_panel.Visible = false;
            // 
            // edit_panel
            // 
            this.edit_panel.Controls.Add(this.removecol_btn);
            this.edit_panel.Controls.Add(this.addcol_btn);
            this.edit_panel.Controls.Add(this.removerow_btn);
            this.edit_panel.Controls.Add(this.addrow_btn);
            this.edit_panel.Location = new System.Drawing.Point(-5, 42);
            this.edit_panel.Name = "edit_panel";
            this.edit_panel.Size = new System.Drawing.Size(250, 152);
            this.edit_panel.TabIndex = 10;
            // 
            // removecol_btn
            // 
            this.removecol_btn.BackColor = System.Drawing.Color.Transparent;
            this.removecol_btn.Location = new System.Drawing.Point(17, 113);
            this.removecol_btn.Name = "removecol_btn";
            this.removecol_btn.Size = new System.Drawing.Size(219, 29);
            this.removecol_btn.TabIndex = 3;
            this.removecol_btn.Text = "Видалити стовпчик";
            this.removecol_btn.UseVisualStyleBackColor = false;
            this.removecol_btn.Click += new System.EventHandler(this.removecol_btn_Click);
            // 
            // addcol_btn
            // 
            this.addcol_btn.BackColor = System.Drawing.Color.Transparent;
            this.addcol_btn.Location = new System.Drawing.Point(17, 78);
            this.addcol_btn.Name = "addcol_btn";
            this.addcol_btn.Size = new System.Drawing.Size(219, 29);
            this.addcol_btn.TabIndex = 2;
            this.addcol_btn.Text = "Додати стовпчик";
            this.addcol_btn.UseVisualStyleBackColor = false;
            this.addcol_btn.Click += new System.EventHandler(this.addcol_btn_Click);
            // 
            // removerow_btn
            // 
            this.removerow_btn.BackColor = System.Drawing.Color.Transparent;
            this.removerow_btn.Location = new System.Drawing.Point(17, 42);
            this.removerow_btn.Name = "removerow_btn";
            this.removerow_btn.Size = new System.Drawing.Size(219, 29);
            this.removerow_btn.TabIndex = 1;
            this.removerow_btn.Text = "Видалити рядок";
            this.removerow_btn.UseVisualStyleBackColor = false;
            this.removerow_btn.Click += new System.EventHandler(this.removerow_btn_Click);
            // 
            // addrow_btn
            // 
            this.addrow_btn.BackColor = System.Drawing.Color.Transparent;
            this.addrow_btn.Location = new System.Drawing.Point(17, 7);
            this.addrow_btn.Name = "addrow_btn";
            this.addrow_btn.Size = new System.Drawing.Size(219, 30);
            this.addrow_btn.TabIndex = 0;
            this.addrow_btn.Text = "Додати рядок";
            this.addrow_btn.UseVisualStyleBackColor = false;
            this.addrow_btn.Click += new System.EventHandler(this.addrow_btn_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu.Controls.Add(this.about_btn);
            this.menu.Controls.Add(this.dovidka_btn);
            this.menu.Controls.Add(this.file_btn);
            this.menu.Controls.Add(this.changeview);
            this.menu.Controls.Add(this.edit_btn);
            this.menu.Controls.Add(this.Formula);
            this.menu.Location = new System.Drawing.Point(-5, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1157, 43);
            this.menu.TabIndex = 7;
            // 
            // about_btn
            // 
            this.about_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.about_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.about_btn.FlatAppearance.BorderSize = 0;
            this.about_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.about_btn.Location = new System.Drawing.Point(965, 0);
            this.about_btn.Name = "about_btn";
            this.about_btn.Size = new System.Drawing.Size(192, 42);
            this.about_btn.TabIndex = 10;
            this.about_btn.Text = "Про програму";
            this.about_btn.UseVisualStyleBackColor = false;
            this.about_btn.Click += new System.EventHandler(this.about_btn_Click);
            // 
            // ExpCalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 600);
            this.Controls.Add(this.edit_panel);
            this.Controls.Add(this.dovidka_panel);
            this.Controls.Add(this.about_panel);
            this.Controls.Add(this.file_panel);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.table);
            this.Name = "ExpCalcForm";
            this.Text = "ExpCalcForm";
            this.Load += new System.EventHandler(this.ExpCalcForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.dovidka_panel.ResumeLayout(false);
            this.dovidka_panel.PerformLayout();
            this.about_panel.ResumeLayout(false);
            this.about_panel.PerformLayout();
            this.file_panel.ResumeLayout(false);
            this.edit_panel.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button newtablebtn;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.Button changeview;
        private System.Windows.Forms.TextBox Formula;
        private System.Windows.Forms.Button dovidka_btn;
        private Panel dovidka_panel;
        private TextBox dovidka;
        private Button edit_btn;
        private Panel edit_panel;
        private Button addcol_btn;
        private Button removerow_btn;
        private Button addrow_btn;
        private System.Windows.Forms.Button file_btn;
        private System.Windows.Forms.Panel file_panel;
        private Button removecol_btn;
        private Panel menu;
        private Button about_btn;
        private Panel about_panel;
        private TextBox about;
    }
}

