using System.Collections.Generic;
using System.Security.Principal;
using System.Drawing;

namespace Types_Filter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        //Global Variables
        string SelectedFolderPath;
        IList<string> GlobalFilesList = new List<string>();
        IList<string> ExtensionList = new List<string>();
        IList<string> RecExtensionList = new List<string>();
        bool RecursiveFlag;
       

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Button_Scan = new System.Windows.Forms.Button();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.Label_Directory = new System.Windows.Forms.Label();
            this.Checklist_Types = new System.Windows.Forms.CheckedListBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Button_Select = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.Button_Clear = new System.Windows.Forms.Button();
            this.Label_Folder_Files = new System.Windows.Forms.Label();
            this.Label_Extensions = new System.Windows.Forms.Label();
            this.Label_Folder_Info = new System.Windows.Forms.Label();
            this.Button_RecScan = new System.Windows.Forms.Button();
            this.Label_Folders = new System.Windows.Forms.Label();
            this.Label_Selection_Info = new System.Windows.Forms.Label();
            this.Label_Selection_Files = new System.Windows.Forms.Label();
            this.Button_Analyze = new System.Windows.Forms.Button();
            this.Label_Selection_Extensions = new System.Windows.Forms.Label();
            this.Label_Mode = new System.Windows.Forms.Label();
            this.Space_White = new System.Windows.Forms.Label();
            this.Space_LightBlue = new System.Windows.Forms.Label();
            this.Picture_Seperator = new System.Windows.Forms.PictureBox();
            this.Label_Remove = new System.Windows.Forms.Label();
            this.Picture_Remove = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Seperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Remove)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Scan
            // 
            this.Button_Scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(142)))), ((int)(((byte)(168)))));
            this.Button_Scan.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button_Scan.Enabled = false;
            this.Button_Scan.FlatAppearance.BorderSize = 0;
            this.Button_Scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Scan.ForeColor = System.Drawing.Color.White;
            this.Button_Scan.Location = new System.Drawing.Point(387, 175);
            this.Button_Scan.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Scan.Name = "Button_Scan";
            this.Button_Scan.Size = new System.Drawing.Size(98, 24);
            this.Button_Scan.TabIndex = 0;
            this.Button_Scan.Text = "Scan";
            this.Button_Scan.UseVisualStyleBackColor = false;
            this.Button_Scan.Click += new System.EventHandler(this.ButtonScanClick);
            // 
            // Button_Browse
            // 
            this.Button_Browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(142)))), ((int)(((byte)(168)))));
            this.Button_Browse.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button_Browse.FlatAppearance.BorderSize = 0;
            this.Button_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Browse.ForeColor = System.Drawing.Color.White;
            this.Button_Browse.Location = new System.Drawing.Point(387, 26);
            this.Button_Browse.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(98, 24);
            this.Button_Browse.TabIndex = 1;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.UseVisualStyleBackColor = false;
            this.Button_Browse.Click += new System.EventHandler(this.ButtonBrowseClick);
            // 
            // Label_Directory
            // 
            this.Label_Directory.BackColor = System.Drawing.Color.White;
            this.Label_Directory.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Label_Directory.Location = new System.Drawing.Point(14, 26);
            this.Label_Directory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Directory.Name = "Label_Directory";
            this.Label_Directory.Size = new System.Drawing.Size(367, 24);
            this.Label_Directory.TabIndex = 2;
            this.Label_Directory.Text = "Select a directory";
            this.Label_Directory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Checklist_Types
            // 
            this.Checklist_Types.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Checklist_Types.CheckOnClick = true;
            this.Checklist_Types.FormattingEnabled = true;
            this.Checklist_Types.Location = new System.Drawing.Point(13, 79);
            this.Checklist_Types.Margin = new System.Windows.Forms.Padding(2);
            this.Checklist_Types.MultiColumn = true;
            this.Checklist_Types.Name = "Checklist_Types";
            this.Checklist_Types.Size = new System.Drawing.Size(472, 90);
            this.Checklist_Types.TabIndex = 5;
            // 
            // Button_Select
            // 
            this.Button_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(142)))), ((int)(((byte)(168)))));
            this.Button_Select.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button_Select.Enabled = false;
            this.Button_Select.FlatAppearance.BorderSize = 0;
            this.Button_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Select.ForeColor = System.Drawing.Color.White;
            this.Button_Select.Location = new System.Drawing.Point(75, 175);
            this.Button_Select.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Select.Name = "Button_Select";
            this.Button_Select.Size = new System.Drawing.Size(98, 24);
            this.Button_Select.TabIndex = 6;
            this.Button_Select.Text = "Select All";
            this.Button_Select.UseVisualStyleBackColor = false;
            this.Button_Select.Click += new System.EventHandler(this.ButtonSelectAllClick);
            // 
            // Button_Exit
            // 
            this.Button_Exit.BackColor = System.Drawing.Color.White;
            this.Button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(78)))), ((int)(((byte)(109)))));
            this.Button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(78)))), ((int)(((byte)(109)))));
            this.Button_Exit.Location = new System.Drawing.Point(351, 426);
            this.Button_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(134, 30);
            this.Button_Exit.TabIndex = 7;
            this.Button_Exit.Text = "Exit";
            this.Button_Exit.UseVisualStyleBackColor = false;
            this.Button_Exit.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // Button_Clear
            // 
            this.Button_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(142)))), ((int)(((byte)(168)))));
            this.Button_Clear.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button_Clear.Enabled = false;
            this.Button_Clear.FlatAppearance.BorderSize = 0;
            this.Button_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Clear.ForeColor = System.Drawing.Color.White;
            this.Button_Clear.Location = new System.Drawing.Point(283, 175);
            this.Button_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Clear.Name = "Button_Clear";
            this.Button_Clear.Size = new System.Drawing.Size(98, 24);
            this.Button_Clear.TabIndex = 8;
            this.Button_Clear.Text = "Clear";
            this.Button_Clear.UseVisualStyleBackColor = false;
            this.Button_Clear.Click += new System.EventHandler(this.ButtonClearSelectionClick);
            // 
            // Label_Folder_Files
            // 
            this.Label_Folder_Files.AutoSize = true;
            this.Label_Folder_Files.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Label_Folder_Files.Location = new System.Drawing.Point(14, 250);
            this.Label_Folder_Files.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Folder_Files.Name = "Label_Folder_Files";
            this.Label_Folder_Files.Size = new System.Drawing.Size(33, 15);
            this.Label_Folder_Files.TabIndex = 9;
            this.Label_Folder_Files.Text = "Files";
            // 
            // Label_Extensions
            // 
            this.Label_Extensions.AutoSize = true;
            this.Label_Extensions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Label_Extensions.Location = new System.Drawing.Point(14, 270);
            this.Label_Extensions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Extensions.Name = "Label_Extensions";
            this.Label_Extensions.Size = new System.Drawing.Size(66, 15);
            this.Label_Extensions.TabIndex = 10;
            this.Label_Extensions.Text = "Extensions";
            // 
            // Label_Folder_Info
            // 
            this.Label_Folder_Info.AutoSize = true;
            this.Label_Folder_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Label_Folder_Info.Location = new System.Drawing.Point(14, 230);
            this.Label_Folder_Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Folder_Info.Name = "Label_Folder_Info";
            this.Label_Folder_Info.Size = new System.Drawing.Size(110, 15);
            this.Label_Folder_Info.TabIndex = 11;
            this.Label_Folder_Info.Text = "Folder Information";
            // 
            // Button_RecScan
            // 
            this.Button_RecScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(142)))), ((int)(((byte)(168)))));
            this.Button_RecScan.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button_RecScan.Enabled = false;
            this.Button_RecScan.FlatAppearance.BorderSize = 0;
            this.Button_RecScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_RecScan.ForeColor = System.Drawing.Color.White;
            this.Button_RecScan.Location = new System.Drawing.Point(179, 175);
            this.Button_RecScan.Margin = new System.Windows.Forms.Padding(2);
            this.Button_RecScan.Name = "Button_RecScan";
            this.Button_RecScan.Size = new System.Drawing.Size(98, 24);
            this.Button_RecScan.TabIndex = 13;
            this.Button_RecScan.Text = "Recursive Scan";
            this.Button_RecScan.UseVisualStyleBackColor = false;
            this.Button_RecScan.Click += new System.EventHandler(this.ButtonRecursiveScanClick);
            // 
            // Label_Folders
            // 
            this.Label_Folders.AutoSize = true;
            this.Label_Folders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Label_Folders.Location = new System.Drawing.Point(280, 290);
            this.Label_Folders.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Folders.Name = "Label_Folders";
            this.Label_Folders.Size = new System.Drawing.Size(48, 15);
            this.Label_Folders.TabIndex = 14;
            this.Label_Folders.Text = "Folders";
            // 
            // Label_Selection_Info
            // 
            this.Label_Selection_Info.AutoSize = true;
            this.Label_Selection_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Label_Selection_Info.Location = new System.Drawing.Point(280, 230);
            this.Label_Selection_Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Selection_Info.Name = "Label_Selection_Info";
            this.Label_Selection_Info.Size = new System.Drawing.Size(124, 15);
            this.Label_Selection_Info.TabIndex = 15;
            this.Label_Selection_Info.Text = "Selection Information";
            // 
            // Label_Selection_Files
            // 
            this.Label_Selection_Files.AutoSize = true;
            this.Label_Selection_Files.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Label_Selection_Files.Location = new System.Drawing.Point(280, 250);
            this.Label_Selection_Files.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Selection_Files.Name = "Label_Selection_Files";
            this.Label_Selection_Files.Size = new System.Drawing.Size(33, 15);
            this.Label_Selection_Files.TabIndex = 17;
            this.Label_Selection_Files.Text = "Files";
            // 
            // Button_Analyze
            // 
            this.Button_Analyze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(78)))), ((int)(((byte)(109)))));
            this.Button_Analyze.Enabled = false;
            this.Button_Analyze.FlatAppearance.BorderSize = 0;
            this.Button_Analyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Analyze.ForeColor = System.Drawing.Color.White;
            this.Button_Analyze.Location = new System.Drawing.Point(210, 426);
            this.Button_Analyze.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Analyze.Name = "Button_Analyze";
            this.Button_Analyze.Size = new System.Drawing.Size(134, 30);
            this.Button_Analyze.TabIndex = 18;
            this.Button_Analyze.Text = "Analyze";
            this.Button_Analyze.UseVisualStyleBackColor = false;
            this.Button_Analyze.Click += new System.EventHandler(this.ButtonAnalyzeClick);
            // 
            // Label_Selection_Extensions
            // 
            this.Label_Selection_Extensions.AutoSize = true;
            this.Label_Selection_Extensions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Label_Selection_Extensions.Location = new System.Drawing.Point(280, 270);
            this.Label_Selection_Extensions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Selection_Extensions.Name = "Label_Selection_Extensions";
            this.Label_Selection_Extensions.Size = new System.Drawing.Size(66, 15);
            this.Label_Selection_Extensions.TabIndex = 19;
            this.Label_Selection_Extensions.Text = "Extensions";
            // 
            // Label_Mode
            // 
            this.Label_Mode.AutoSize = true;
            this.Label_Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Label_Mode.Location = new System.Drawing.Point(14, 290);
            this.Label_Mode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(38, 15);
            this.Label_Mode.TabIndex = 20;
            this.Label_Mode.Text = "Mode";
            // 
            // Space_White
            // 
            this.Space_White.BackColor = System.Drawing.Color.White;
            this.Space_White.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Space_White.Location = new System.Drawing.Point(-1, 71);
            this.Space_White.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Space_White.Name = "Space_White";
            this.Space_White.Size = new System.Drawing.Size(502, 134);
            this.Space_White.TabIndex = 2;
            this.Space_White.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Space_LightBlue
            // 
            this.Space_LightBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.Space_LightBlue.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Space_LightBlue.Location = new System.Drawing.Point(-1, 202);
            this.Space_LightBlue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Space_LightBlue.Name = "Space_LightBlue";
            this.Space_LightBlue.Size = new System.Drawing.Size(502, 205);
            this.Space_LightBlue.TabIndex = 2;
            this.Space_LightBlue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Picture_Seperator
            // 
            this.Picture_Seperator.Image = ((System.Drawing.Image)(resources.GetObject("Picture_Seperator.Image")));
            this.Picture_Seperator.Location = new System.Drawing.Point(-7, 204);
            this.Picture_Seperator.Name = "Picture_Seperator";
            this.Picture_Seperator.Size = new System.Drawing.Size(508, 13);
            this.Picture_Seperator.TabIndex = 22;
            this.Picture_Seperator.TabStop = false;
            // 
            // Label_Remove
            // 
            this.Label_Remove.AutoSize = true;
            this.Label_Remove.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Label_Remove.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Remove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(78)))), ((int)(((byte)(109)))));
            this.Label_Remove.Location = new System.Drawing.Point(42, 432);
            this.Label_Remove.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Remove.Name = "Label_Remove";
            this.Label_Remove.Size = new System.Drawing.Size(79, 18);
            this.Label_Remove.TabIndex = 23;
            this.Label_Remove.Text = "Remove All";
            this.Label_Remove.Click += new System.EventHandler(this.Label_Remove_Click);
            // 
            // Picture_Remove
            // 
            this.Picture_Remove.Image = ((System.Drawing.Image)(resources.GetObject("Picture_Remove.Image")));
            this.Picture_Remove.Location = new System.Drawing.Point(23, 432);
            this.Picture_Remove.Name = "Picture_Remove";
            this.Picture_Remove.Size = new System.Drawing.Size(17, 20);
            this.Picture_Remove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture_Remove.TabIndex = 24;
            this.Picture_Remove.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.Button_Exit;
            this.ClientSize = new System.Drawing.Size(496, 467);
            this.Controls.Add(this.Picture_Remove);
            this.Controls.Add(this.Label_Remove);
            this.Controls.Add(this.Picture_Seperator);
            this.Controls.Add(this.Button_Scan);
            this.Controls.Add(this.Button_RecScan);
            this.Controls.Add(this.Button_Clear);
            this.Controls.Add(this.Checklist_Types);
            this.Controls.Add(this.Label_Mode);
            this.Controls.Add(this.Label_Selection_Extensions);
            this.Controls.Add(this.Button_Analyze);
            this.Controls.Add(this.Label_Selection_Files);
            this.Controls.Add(this.Label_Selection_Info);
            this.Controls.Add(this.Label_Folders);
            this.Controls.Add(this.Label_Folder_Info);
            this.Controls.Add(this.Label_Extensions);
            this.Controls.Add(this.Label_Folder_Files);
            this.Controls.Add(this.Button_Exit);
            this.Controls.Add(this.Button_Select);
            this.Controls.Add(this.Label_Directory);
            this.Controls.Add(this.Button_Browse);
            this.Controls.Add(this.Space_LightBlue);
            this.Controls.Add(this.Space_White);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Types Filter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Seperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Remove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Scan;
        private System.Windows.Forms.Button Button_Browse;
        private System.Windows.Forms.Label Label_Directory;
        private System.Windows.Forms.CheckedListBox Checklist_Types;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button Button_Select;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.Button Button_Clear;
        private System.Windows.Forms.Label Label_Folder_Files;
        private System.Windows.Forms.Label Label_Extensions;
        private System.Windows.Forms.Label Label_Folder_Info;
        private System.Windows.Forms.Button Button_RecScan;
        private System.Windows.Forms.Label Label_Folders;
        private System.Windows.Forms.Label Label_Selection_Info;
        private System.Windows.Forms.Label Label_Selection_Files;
        private System.Windows.Forms.Button Button_Analyze;
        private System.Windows.Forms.Label Label_Selection_Extensions;
        private System.Windows.Forms.Label Label_Mode;
        private System.Windows.Forms.Label Space_White;
        private System.Windows.Forms.Label Space_LightBlue;
        private System.Windows.Forms.PictureBox Picture_Seperator;
        private System.Windows.Forms.Label Label_Remove;
        private System.Windows.Forms.PictureBox Picture_Remove;
    }
}

