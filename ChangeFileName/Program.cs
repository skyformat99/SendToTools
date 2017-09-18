﻿using Ambiesoft;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChangeFileName
{
    static class Program
    {
        static internal bool SafeProcessStart(string s, bool showerrorbox)
        {
            try
            {
                System.Diagnostics.Process.Start(s);
                return true;
            }
            catch (System.Exception e)
            {
                if (showerrorbox)
                {
                    MessageBox.Show(e.Message,
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            return false;
        }

      

        static readonly internal string damemoji = "\\/:;*?\"<>|";
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                MessageBox.Show(Properties.Resources.NO_ARGUMENTS,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }
            if (args.Length > 1)
            {
                StringBuilder sbNotFounds = new StringBuilder();
                for (int i = 0; i < args.Length; ++i)
                {
                    try
                    {
                        if(File.Exists(args[i]) || Directory.Exists(args[i]))
                            System.Diagnostics.Process.Start(Application.ExecutablePath, "\""+args[i]+"\"");
                        else
                        {
                            sbNotFounds.AppendLine(args[i]);
                        }
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.Message,
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                }

                if (sbNotFounds.Length != 0)
                {
                    MessageBox.Show(Properties.Resources.FOLLOWING_DOESNOT_EXIST + "\r\n\r\n" + sbNotFounds.ToString(),
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                }
                return;
            }
            
            string theFileName = args[0];
            // theFileName = @"C:\Documents and Settings\tt\My Documents\Productivity Distribution, Firm Heterogeneity, and Agglomeration.pdf";
            if (!File.Exists(theFileName) && !Directory.Exists(theFileName) )
            {
                MessageBox.Show(string.Format(Properties.Resources.FILE_NOT_FOUND, theFileName),
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }

            System.IO.FileInfo fi = new System.IO.FileInfo(theFileName.Trim());

            string oldname = fi.Name;
            string oldext = fi.Extension;
            string newName = fi.Name;
            if (!string.IsNullOrEmpty(oldext))
            {
                newName = newName.Replace(oldext, "");
            }
            do
            {
                try
                {
                    FormMain fm = new FormMain();
                    AmbLib.SetFontAll(fm);

                    fm.textName.Text = newName;
                    fm.textName.Tag = theFileName;
                    if (DialogResult.OK != fm.ShowDialog())
                        return;

                    newName = fm.textName.Text;

                    if (oldname == (newName + oldext))
                    {
                        return;
                    }

                    if ( string.IsNullOrEmpty(oldext ) )
                    {
                        newName = newName.TrimEnd(' ');
                    }

                    if (string.IsNullOrEmpty(newName))
                    {
                        MessageBox.Show(Properties.Resources.ENTER_FILENAME,
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);

                        continue;
                    }

                    if ( -1 != newName.IndexOfAny(damemoji.ToCharArray()))
                    {
                        MessageBox.Show(Properties.Resources.FOLLOWING_UNABLE_FILENAME + Environment.NewLine + Environment.NewLine  + damemoji,
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);

                        continue;
                    }

                    string dir = fi.Directory.FullName;
                    fi.MoveTo(dir + @"\" + newName + oldext);
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message,
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            } while (true);
        }
    }
}