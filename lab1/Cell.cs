using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExpressionCalculation
{
    struct Index
    {
        public int row;
        public int col;
        public Index(int row, int col) { 
            this.row = row; //this values are from 0
            this.col = col;
        }
    }
    class Cell
    {
        public DataGridViewCell Parent { get; set; }    //the datagridview (table) cell
        public string Formula { get; set; }
        public static List<Cell> Cells { get; set; } = new List<Cell>();
        public static Dictionary<string, string> GetDictionary()
        {
            var data = new Dictionary<string, string>();
            foreach (Cell cell in Cells)
            {
                data.Add(cell.GetName(), cell.Formula);
            }
            return data;
        }

        private string GetName()
        {
            return ((Parent.RowIndex + 1).ToString() + IndexToLetter(Parent.ColumnIndex));
        }
        public static Cell GetCell(string name)
        {
            Index index = ParseName(name);
            int row = index.row;
            int col = index.col;
            foreach (Cell cell in Cells)
            {
                if (cell.Parent.RowIndex == row && cell.Parent.ColumnIndex == col)
                {
                    return cell;
                }
            }
            return null;
        }

        public static Cell GetCell(int row, int col)
        {
            foreach (Cell cell in Cells)
            {
                if (cell.Parent.RowIndex == row && cell.Parent.ColumnIndex == col)
                {
                    return cell;
                }
            }
            return null;
        }

        public static Index ParseName(string name)
        {
            string row_str = "";
            string col_letter = "";
            foreach (char charofstring in name)
            {
                if (Char.IsDigit(charofstring))
                {
                    row_str += charofstring;
                }
                else
                {
                    col_letter += charofstring;
                }
            }
            Index index = new Index(Convert.ToInt32(row_str) - 1, LetterToIndex(col_letter));
            Debug.WriteLine(index.col + " " + index.row);
            return index;
        }
        public static int LetterToIndex(string letter)
        {
            letter = letter.ToUpper();
            int sum = 0;
            foreach (char c in letter)
            {
                sum = sum * 26 + c - 'A' + 1;
            }
            return sum - 1;

        }

        public Cell(DataGridViewCell parent)
        {
            Parent = parent;
            Cells.Add(this);
        }

        public static string IndexToLetter(int index)       //A to 0, B to 1
        {

            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var value = "";
            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];
            value += letters[index % letters.Length];
            return value;
        }

        public static void ChangeToFormula()
        {
            foreach (Cell cell in Cells)
            {
                cell.Parent.Value = cell.Formula;
            }
        }

        public static void Recalculate()
        {
            foreach (Cell cell in Cells)
            {
                try
                {
                    double result = Calculator.Evaluate(cell.Formula);
                    cell.Parent.Value = result.ToString();
                    string name = IndexToLetter(cell.Parent.ColumnIndex) + (cell.Parent.RowIndex + 1).ToString();
                }
                catch (ArgumentException ex)
                {
                    Debug.WriteLine(ex.Message);
                    cell.Parent.Value = "error";
                }
                catch (FormatException ex)
                {
                    Debug.WriteLine(ex.Message);
                    cell.Parent.Value = "error";
                }
                catch (DivideByZeroException  ex)
                {
                    Debug.WriteLine(ex.Message);
                    cell.Parent.Value = "error";
                }
            }
        }
    }
}
