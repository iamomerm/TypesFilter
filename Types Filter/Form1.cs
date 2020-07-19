using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Types_Filter
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//Threads
		Thread ActionThread; /* 1 */

		private void ButtonBrowseClick(object sender, EventArgs e)
		{

			bool CheckAdmin = IsAdministrator();

			if (CheckAdmin == false)
			{

				MessageBox.Show
					(
					"This program must be executed as local admin!"
					+ Environment.NewLine + 
					"Right click - Run as administrator"
					, "Types Filter"
					);
			}

			else
			{
				//Set Flag
				RecursiveFlag = false;

				//Init Labels
				Label_Folder_Files.Text = "Files ";
				Label_Extensions.Text = "Extensions ";
				Label_Folders.Text = "Folders ";
				Label_Selection_Extensions.Text = "Extensions ";
				Label_Selection_Files.Text = "Files ";
				Label_Mode.Text = "Mode ";

				//Clear CheckList
				Checklist_Types.Items.Clear();

				using (var folderBrowserDialog = new FolderBrowserDialog())
				{
					//SelectedFolder is the selected folder variable

					folderBrowserDialog.ShowNewFolderButton = false;

					DialogResult result = folderBrowserDialog.ShowDialog();

					string SelectedFolder = folderBrowserDialog.SelectedPath;

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
					{
						//Folder Path Text set to Selected Folder
						this.Label_Directory.Text = SelectedFolder;

						//Global Variable Modification
						SelectedFolderPath = SelectedFolder;

						//Enable Scan Button 
						this.Button_Scan.Enabled = true;

						//Enable Select All Button 
						this.Button_Select.Enabled = true;

						//Enable Clear Selection Button 
						this.Button_Clear.Enabled = true;

						//Enable Recutsive Scan Button 
						this.Button_RecScan.Enabled = true;
					}

					else
					{
						//Folder Path Text is Null
						this.Label_Directory.Text = null;

						//Global Variable Modification
						SelectedFolderPath = null;

						//Disable Scan Button 
						this.Button_Scan.Enabled = false;

						//Disable Select All Button 
						this.Button_Select.Enabled = false;

						//Disable Clear Selection Button 
						this.Button_Clear.Enabled = false;

						//Disable Recutsive Scan Button 
						this.Button_RecScan.Enabled = false;

						//Disable Analyze Button 
						this.Button_Analyze.Enabled = false;

						//Disable Remove Button 
						this.Label_Remove.Enabled = false;
					}
				}
			}
		}

		//Exit Application Method
		private void ExitApp() { Application.Exit(); }

		//Scan Method
		private void Scan()
		{
			//Enable Analyze Button 
			this.Button_Analyze.Enabled = true;

			//Clear Global Files List
			GlobalFilesList.Clear();

			//Set Flag
			RecursiveFlag = false;

			//Init Labels
			this.Label_Selection_Extensions.Text = "Extensions ";
			this.Label_Selection_Files.Text = "Files ";

			//Scanning
			this.Label_Folder_Files.Text = "Files Scanning...";
			this.Label_Extensions.Text = "Extensions Scanning...";
			this.Label_Folders.Text = "Folders 1";
			this.Label_Mode.Text = "Mode: Scan";

			//Clear CheckList
			this.Checklist_Types.Items.Clear();
			ExtensionList.Clear();

			//Scan
			string[] Files = Directory.GetFiles(SelectedFolderPath);

			//Unique Extensions Added to Extenstion List
			try
			{
				foreach (string File in Files)
				{
					GlobalFilesList.Add(File);
					string FileExtension = Path.GetExtension(File);
					if (ExtensionList.Contains(FileExtension) == false) { ExtensionList.Add(FileExtension); }
				}
			}

			catch { }

			//Add to CheckList
			foreach (string Extension in ExtensionList) { this.Checklist_Types.Items.Add(Extension); }

			//Set Folder Information
			Label_Folder_Files.Text = "Files " + (Files.Count()).ToString();
			Label_Extensions.Text = "Extensions " + (ExtensionList.Count()).ToString();
			if (RecursiveFlag == false) { this.Label_Mode.Text = "Mode Non Recursive"; }
			else { this.Label_Mode.Text = "Mode Recursive"; }

			//Enable Remove Button 
			this.Label_Remove.Enabled = true;

			//Init Mode
			this.Label_Mode.Text = "Mode ";
		}

		//Remove Method
		private void Remove()
		{
			//Date
			DateTime RawDate = DateTime.Today;
			string DateDay = (RawDate.Day).ToString();
			string DateMonth = (RawDate.Month).ToString();
			string DateYear = (RawDate.Year).ToString();
			string Date = DateMonth + "-" + DateDay + "-" + DateYear;
			string LogPath = "C:\\Temp\\TypesFilter " + Date + ".log";

			if (File.Exists(LogPath)) { File.Delete(LogPath); }

			//Count Selected Items
			foreach (Object SelectedItem in this.Checklist_Types.CheckedItems)
			{
				//Search & Remove Files By Selected Types
				foreach (string GlobalFile in GlobalFilesList)
				{
					string PowerShellCMD = "Write-Host 'Removing file: '" + GlobalFile + "; Remove-Item -Path '" + GlobalFile + "' -Force";
					string RemoveFileExtension = Path.GetExtension(GlobalFile);

					if (RemoveFileExtension == SelectedItem.ToString())
					{
						if (GlobalFile != LogPath)
						{
							using (StreamWriter LogFile = File.AppendText(LogPath)) { LogFile.WriteLine(GlobalFile); }
							System.Diagnostics.Process.Start("powershell.exe", PowerShellCMD);
						}
					}
				}
			}

			//Clear CheckList
			this.Checklist_Types.Items.Clear();
			RecExtensionList.Clear();
			ExtensionList.Clear();
			GlobalFilesList.Clear();
			RecursiveFlag = false;

			//Init Labels
			this.Label_Selection_Extensions.Text = "Extensions ";
			this.Label_Selection_Files.Text = "Files ";
			this.Label_Mode.Text = "Mode ";

			//Scanning
			this.Label_Folder_Files.Text = "Files ";
			this.Label_Extensions.Text = "Extensions ";
			this.Label_Folders.Text = "Folders ";
			this.Label_Mode.Text = "Mode ";

			//Folder Path Text is Null
			this.Label_Directory.Text = null;

			//Global Variable Modification
			SelectedFolderPath = null;

			//Disable Scan Button 
			this.Button_Scan.Enabled = false;

			//Disable Select All Button 
			this.Button_Select.Enabled = false;

			//Disable Clear Selection Button 
			this.Button_Clear.Enabled = false;

			//Disable Recutsive Scan Button 
			this.Button_RecScan.Enabled = false;

			//Disable Analyze Button 
			this.Button_Analyze.Enabled = false;

			//Disable Remove Button 
			this.Label_Remove.Enabled = false;

			//LOG MSG
			if (File.Exists(LogPath)) { MessageBox.Show("Log file path: " + LogPath); }
		}

		//Analyze Method
		private void Analyze()
		{
			//Init Labels
			this.Label_Selection_Extensions.Text = "Extensions Scanning...";
			this.Label_Selection_Files.Text = "Files Scanning...";
			this.Label_Mode.Text = "Mode Analyze";

			//Count Selected Items
			int SelectedItemsCount = 0;
			int AnalyzeFilesByType = 0;

			foreach (Object SelectedItem in this.Checklist_Types.CheckedItems)
			{
				SelectedItemsCount++;

				//Count Files By Selected Types
				foreach (string GlobalFile in GlobalFilesList)
				{
					string AnalyzeFileExtension = Path.GetExtension(GlobalFile);
					if (AnalyzeFileExtension == SelectedItem.ToString()) { AnalyzeFilesByType++; }
				}
			}

			this.Label_Selection_Extensions.Text = "Extensions " + (SelectedItemsCount).ToString();
			this.Label_Selection_Files.Text = "Files " + (AnalyzeFilesByType).ToString();

			//Init Mode
			this.Label_Mode.Text = "Mode ";
		}

		//Recursive Scan Method
		private void RecScan()
		{
			//Enable Analyze Button 
			this.Button_Analyze.Enabled = true;

			//Enable Remove Button 
			this.Label_Remove.Enabled = true;

			//Clear Global Files List
			GlobalFilesList.Clear();

			//Set Flag
			RecursiveFlag = true;

			//Init Labels
			this.Label_Selection_Extensions.Text = "Extensions ";
			this.Label_Selection_Files.Text = "Files ";
			this.Label_Mode.Text = "Mode ";

			//Scanning
			this.Label_Folder_Files.Text = "Files Scanning...";
			this.Label_Extensions.Text = "Extensions Scanning...";
			this.Label_Folders.Text = "Folders Scanning...";
			this.Label_Mode.Text = "Mode Recursive Scan";

			//Clear CheckList
			this.Checklist_Types.Items.Clear();
			RecExtensionList.Clear();

			int RecFilesCount = 0;

			//Recursive Scan
			try
			{
				string[] Files = Directory.GetFiles(SelectedFolderPath, "*", SearchOption.AllDirectories);

				foreach (string File in Files)
				{
					GlobalFilesList.Add(File);
					RecFilesCount++;
					string FileExtension = Path.GetExtension(File);
					if (RecExtensionList.Contains(FileExtension) == false) { RecExtensionList.Add(FileExtension); }
				}
			}

			catch
			{
				MessageBox.Show
					(
						"Exception:"
						+ Environment.NewLine +
						"- - - - - - -"
						+ Environment.NewLine +
						"Types Filter encountered access violation."
						+ Environment.NewLine +
						"To avoid this problem, narrow down the search to a specific directory."
						,
						"Types Filter"
					);
			}

			//Scan Folders
			int FoldersCount = 0;

			try
			{
				string[] Folders = Directory.GetDirectories(SelectedFolderPath, "*", SearchOption.AllDirectories);

				foreach (string Folder in Folders) { FoldersCount++; }
			}

			catch { /* Pass */ }

			//Add to CheckList
			int RecItemsCount = 0;

			foreach (string RecItem in RecExtensionList) { this.Checklist_Types.Items.Insert(RecItemsCount, RecItem); RecItemsCount++; }

			//Set Folder Information
			Label_Folders.Text = "Folders " + (FoldersCount).ToString();
			Label_Folder_Files.Text = "Files " + (RecFilesCount).ToString();
			Label_Extensions.Text = "Extensions " + (RecExtensionList.Count()).ToString();
			if (RecursiveFlag == false) { this.Label_Mode.Text = "Mode Non Recursive"; }
			else { this.Label_Mode.Text = "Mode Recursive"; }

			//Enable Remove Button 
			this.Label_Remove.Enabled = true;

			//Init Mode
			this.Label_Mode.Text = "Mode ";
		}

		private void ButtonCancelClick(object sender, EventArgs e) { ExitApp(); }
		
		private void ButtonSelectAllClick(object sender, EventArgs e)
		{
			for (int Index = 0; Index < Checklist_Types.Items.Count; Index++)
			{
				Checklist_Types.SetItemChecked(Index, true);
			}
		}

		private void ButtonRecursiveScanClick(object sender, EventArgs e)
		{
			ActionThread = new Thread(new ThreadStart(RecScan));

			ActionThread.IsBackground = true;

			ActionThread.Start();		   
		}

		private void ButtonAnalyzeClick(object sender, EventArgs e)
		{
			ActionThread = new Thread(new ThreadStart(Analyze));

			ActionThread.IsBackground = true;

			ActionThread.Start();
		}

		private void Label_Remove_Click(object sender, EventArgs e)
		{
			ActionThread = new Thread(new ThreadStart(Remove));

			ActionThread.IsBackground = true;

			ActionThread.Start();
		}

		private void ButtonScanClick(object sender, EventArgs e)
		{
			ActionThread = new Thread(new ThreadStart(Scan));

			ActionThread.IsBackground = true;

			ActionThread.Start();
		}

		private void ButtonClearSelectionClick(object sender, EventArgs e)
		{
			for (int Index = 0; Index < Checklist_Types.Items.Count; Index++) { Checklist_Types.SetItemChecked(Index, false);}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//Check Multiple Instances
			bool SingleInstance;

			Mutex Mutex = new Mutex(true, "Application", out SingleInstance);

			if (!SingleInstance)
			{
				MessageBox.Show("Instance of 'Types Filter' Is Already Running !", "Types Filter");

				//Exit Application
				System.Windows.Forms.Application.Exit();
			}
		}
	}
}
