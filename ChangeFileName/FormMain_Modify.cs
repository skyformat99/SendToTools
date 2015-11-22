using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;


namespace ChangeFileName
{
    public partial class FormMain : Form
    {
       

        delegate string Converter(string s);
        void ChangeSelectionCommon(Converter converter)
        {
            if (textName.SelectionLength == 0)
                return;
            
            int start = textName.SelectionStart;

            string s = textName.SelectedText;
            s = converter.Invoke(s);
            textName.SelectedText = s;

            textName.Select(start, s.Length);
            textName.Focus();
        }

        
        string NameFileNamable(string fn)
        {
            fn = fn.Replace("<", "");
            fn = fn.Replace(">", "");
            fn = fn.Replace(":", "");
            fn = fn.Replace("\"", "");
            fn = fn.Replace("/", "");
            fn = fn.Replace("\\", "");
            fn = fn.Replace("|", "");
            fn = fn.Replace("?", "");
            fn = fn.Replace("*", "");
            fn = fn.Replace(",", "");
            return fn;
        }
        private void ToFileNamable_Click(object sender, EventArgs e)
        {
            textName.Text = NameFileNamable(textName.Text);
        }
        private void ToMakeFileNamableSel_Click(object sender, EventArgs e)
        {
            ChangeSelectionCommon(NameFileNamable);
        }


        string tolower(string s)
        {
            return s.ToLower();
        }
        private void ToLower_Click(object sender, EventArgs e)
        {
            textName.Text = tolower(textName.Text);
        }
        private void ToLowerSel_Click(object sender, EventArgs e)
        {
            ChangeSelectionCommon(tolower);
        }


        string toupper(string s)
        {
            return s.ToUpper();
        }
        private void ToUpper_Click(object sender, EventArgs e)
        {
            textName.Text = toupper(textName.Text);
        }
        private void ToUpperSel_Click(object sender, EventArgs e)
        {
            ChangeSelectionCommon(toupper);
        }


        string trim(string s)
        {
            return s.Trim();
        }
        private void Trim_Click(object sender, EventArgs e)
        {
            textName.Text = trim(textName.Text);
        }
        private void TrimSel_Click(object sender, EventArgs e)
        {
            ChangeSelectionCommon(trim);
        }


        private string RemoveSpace(string s)
        {
            s = s.Replace(" ", "");
            s = s.Replace("�@", "");
            return s;
        }
        private void ToRemoveSpace_Click(object sender, EventArgs e)
        {
            textName.Text = RemoveSpace(textName.Text);
        }
        private void ToRemoveSpaceSel_Click(object sender, EventArgs e)
        {
            ChangeSelectionCommon(RemoveSpace);
        }

    }
}