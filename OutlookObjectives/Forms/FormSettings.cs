﻿namespace OutlookObjectives
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Serilog;
    using Microsoft.Win32;

    /// <summary>
    /// Form to manage Objectives Settings.
    /// </summary>
    public partial class FormSettings : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormSettings"/> class.
        /// </summary>
        public FormSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populate the form with the original details.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void FormSettings_Load(object sender, EventArgs e)
        {
            RegistryKey objectiveKey;

            // Check if the registry keys exist.
            try
            {
                objectiveKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\InTouch\\Objectives");
                if (objectiveKey == null)
                {
                    _ = Registry.CurrentUser.CreateSubKey("SOFTWARE\\InTouch\\Objectives");
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return;
            }

            // Check if the registry Objectives path value exist.
            try
            {
                InTouch.ObjectivesRootFolder = (string)objectiveKey.GetValue("RootFolder");
                if (InTouch.ObjectivesRootFolder is object)
                {
                    TextBoxObjectivesRootFolder.Text = InTouch.ObjectivesRootFolder;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            try
            {
                InTouch.ObjectivesArchiveFolder = (string)objectiveKey.GetValue("ArchiveFolder");
                if (InTouch.ObjectivesRootFolder is object)
                {
                    TextBoxArchiveFolder.Text = InTouch.ObjectivesArchiveFolder;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            try
            {
                InTouch.ObjectivesStorageFolder = (string)objectiveKey.GetValue("StorageFolder");
                if (InTouch.ObjectivesStorageFolder is object)
                {
                    TextBoxAddinStorageFolder.Text = InTouch.ObjectivesStorageFolder;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Update the root folder.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void TextBoxObjectivesRootFolder_TextChanged(object sender, EventArgs e)
        {
            InTouch.ObjectivesRootFolder = TextBoxObjectivesRootFolder.Text;

            // Check if the Objectives Path exists.
            try
            {
                if (!Directory.Exists(InTouch.ObjectivesRootFolder))
                {
                    LabelErrorObjectivesRootFolder.Text = "Path does not exist.";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Update the archive folder.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void TextBoxArchiveFolder_TextChanged(object sender, EventArgs e)
        {
            InTouch.ObjectivesArchiveFolder = TextBoxObjectivesRootFolder.Text;

            // Check if the Objectives Path exists.
            try
            {
                if (!Directory.Exists(InTouch.ObjectivesRootFolder))
                {
                    LabelErrorArchiveFolder.Text = "Path does not exist.";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        private void TextBoxAddinStorageFolder_TextChanged(object sender, EventArgs e)
        {
            InTouch.ObjectivesStorageFolder = TextBoxAddinStorageFolder.Text;

            // Check if the Objectives Path exists.
            try
            {
                if (!Directory.Exists(InTouch.ObjectivesStorageFolder))
                {
                    LabelErrorAddinStorageFolder.Text = "Path does not exist.";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        private void ButtonObjectivesRootFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TextBoxObjectivesRootFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonArchiveFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TextBoxArchiveFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonAddinStorageFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TextBoxAddinStorageFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            RegistryKey objectiveKey;

            // Check if the registry keys exist.
            try
            {
                objectiveKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\InTouch\Objectives", true);
                if (objectiveKey == null)
                {
                    _ = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\InTouch\Objectives");
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return;
            }

            try
            {
                objectiveKey.SetValue("ArchiveFolder", TextBoxArchiveFolder.Text, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            try
            {
                objectiveKey.SetValue("RootFolder", TextBoxObjectivesRootFolder.Text, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            try
            {
                objectiveKey.SetValue("StorageFolder", TextBoxAddinStorageFolder.Text, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            Close();
        }
    }
}