using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
 
namespace ExpressionCalculation
{
    public partial class ExpCalcForm : Form
    {
        bool formulaView = false;

        public ExpCalcForm()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
                table, new object[] { true });
            table.AllowUserToAddRows = false;

            NewTable(3, 3);
            
        }

        private void table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            var table_cell = table[col, row];

            Cell cell = null;
            if (table_cell == null) return;
            if (table_cell.Tag != null)
            {
                cell = (Cell)table_cell.Tag;
            }
            else if(table_cell.Value != null)
            {
                cell = new Cell(table_cell);
                table_cell.Tag = cell;
            }else return;
            
            cell.Formula = table_cell.Value.ToString();
            
            if (formulaView == false)
            {
                Cell.Recalculate();
            }

        }
        private void table_CellSelected(object sender, DataGridViewCellEventArgs e)
        {
            hide_panels(); //close all panels with buttons from the menu
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            try
            {
                var table_cell = table[col, row];
                Cell cell = (Cell)table[col, row].Tag;
                if (cell != null)
                {
                    Formula.Text = cell.Formula;
                }
                else
                {
                    Formula.Text = "";
                }
            }
            catch //if we selected an invalid cell
            {
                return;
            }
         
        }

        private void formulaview_btn_Click(object sender, EventArgs e)
        {
            if(formulaView == false)
            {
                Cell.ChangeToFormula();                
                formulaView = true;
            }
            else
            {
                Cell.Recalculate();
                formulaView = false;
            }
        }

        private void NewTable(int columns, int rows)
        {
            table.Rows.Clear();

            table.ColumnCount = columns;
            table.RowCount = rows;

            foreach (DataGridViewColumn column in table.Columns)
            {
                column.HeaderText = Cell.IndexToLetter(column.Index);
                column.MinimumWidth = 100;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in table.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void file_btn_Click(object sender, EventArgs e)
        {
            hide_about();
            hide_edit();
            if (file_panel.Visible == false)
            {
                file_panel.Visible = true;
                file_btn.BackColor = SystemColors.Control;
            }
            else
            {
                file_panel.Visible = false;
                file_btn.BackColor = SystemColors.ActiveCaption;
            }
        }
        private void about_btn_Click(object sender, EventArgs e)
        {
            hide_file();
            hide_edit();
            if (about_panel.Visible == false)
            {
                about_panel.Visible = true;
                about_btn.BackColor = SystemColors.Control;
            }
            else
            {
                about_panel.Visible = false;
                about_btn.BackColor = SystemColors.ActiveCaption;
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            hide_file();
            hide_about();
            if (edit_panel.Visible == false)
            {
                edit_panel.Visible = true;
                edit_btn.BackColor = SystemColors.Control;
            }
            else
            {
                edit_panel.Visible = false;
                edit_btn.BackColor = SystemColors.ActiveCaption;
            }
        }

        private void hide_panels()
        {
            hide_file();
            hide_about();
            hide_edit();
        }
        private void hide_file()
        {
            file_panel.Visible = false;
            file_btn.BackColor = SystemColors.ActiveCaption;
        }
        private void hide_about()
        {
            about_panel.Visible = false;
            about_btn.BackColor = SystemColors.ActiveCaption;
        }
        private void hide_edit()
        {
            edit_panel.Visible = false;
            edit_btn.BackColor = SystemColors.ActiveCaption;
        }

        private void newtablebtn_Click(object sender, EventArgs e)
        {
            NewTable(3, 3);
        }

        private void addrow_btn_Click(object sender, EventArgs e)
        {
            table.RowCount = table.RowCount + 1;
            var row = table.Rows[table.RowCount-1];
            row.HeaderCell.Value = (row.Index + 1).ToString();
        }
        private void addcol_btn_Click(object sender, EventArgs e)
        {
            table.ColumnCount = table.ColumnCount + 1;
            var col = table.Columns[table.ColumnCount - 1];
            col.HeaderCell.Value = Cell.IndexToLetter(col.Index);
        }
        private void removerow_btn_Click(object sender, EventArgs e)
        {
            if (table.RowCount == 1) return;
            table.RowCount = table.RowCount - 1;
            Cell.Recalculate();
        }
        private void removecol_btn_Click(object sender, EventArgs e)
        {
            if (table.ColumnCount == 1) return;
            table.ColumnCount = table.ColumnCount - 1;
            edit_btn_Click(null, null);
            Cell.Recalculate();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save your table";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            
            var data = Cell.GetDictionary();
            data.Add("_length", (table.RowCount+1)  + Cell.IndexToLetter(table.ColumnCount));

            string json = JsonConvert.SerializeObject(data);
            System.Diagnostics.Debug.WriteLine(json);
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter file = File.CreateText(@saveFileDialog.FileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, data);
                }
            }
            hide_panels();
        }

        private void open_btn_Click(object sender, EventArgs e)
        {
            hide_panels();  //close all menu panels that are shown

            //read file from fileinput
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open a table";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                using (StreamReader r = new StreamReader(openFileDialog.FileName))
                {
                    string json = r.ReadToEnd();
                    Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    Index max = Cell.ParseName(dict["_length"]);

                    NewTable(max.col, max.row);

                    foreach (KeyValuePair<string, string> pair in dict)   
                    {
                        if (pair.Key != "_length")
                        {
                            Debug.WriteLine(pair.Key + " " + pair.Value);
                            Index index = Cell.ParseName(pair.Key);
                            Debug.WriteLine(index.col + " " + index.row);
                            var table_cell = table[index.col, index.row];
                            if (table_cell.Tag == null)
                            {
                                Cell cell = new Cell(table_cell);
                                table_cell.Tag = cell;
                                table_cell.Value = pair.Value;
                                cell.Formula = pair.Value;
                            }
                            else
                            {
                                Cell cell = (Cell)table_cell.Tag;
                                cell.Formula = pair.Value;
                            }
                            
                        }
                    }
                    formulaView = false;
                    Cell.Recalculate();
                }
            }
        }

        private void ExpCalcForm_Load(object sender, EventArgs e)
        {

        }
    }
}
