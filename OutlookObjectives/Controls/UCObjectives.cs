﻿namespace OutlookObjectives
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using CommonObjectives;
    using LogNET;

    /// <summary>
    /// A User Control to be used as the UI for the Objectives Pane.
    /// </summary>
    public partial class UCObjectives : UserControl
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public UCObjectives()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fills the UI with Objectives.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCObjectives_Load(object sender, EventArgs e)
        {
            foreach (var path in Directory.EnumerateDirectories(InTouch.ObjectivesRootFolder, "*", SearchOption.TopDirectoryOnly))
            {
                Objective objective = InTouch.GetObjective(path);
                ListViewItem nextItem = new ListViewItem(objective.ObjectiveName)
                {
                    ImageIndex = 0,
                    Tag = objective.Path,
                };
                ListObjectives.Items.Add(nextItem);
            }

            foreach (var path in Directory.EnumerateDirectories(InTouch.ObjectivesArchiveFolder, "*", SearchOption.TopDirectoryOnly))
            {
                Objective objective = InTouch.GetObjective(path);
                ListViewItem nextItem = new ListViewItem(objective.ObjectiveName)
                {
                    ImageIndex = 1,
                    Tag = objective.Path,
                };
                ListObjectives.Items.Add(nextItem);
            }
        }

        /// <summary>
        /// Manage the control being resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCObjectives_Resize(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
            panel1.Height = this.Height;

            ListObjectives.Width = this.Width + 100;
            ListObjectives.Height = this.Height;
        }

        /// <summary>
        /// Mange the change of selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListObjectives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListObjectives.SelectedItems.Count > 0)
            {
                if (ListObjectives.SelectedItems[0] is object)
                {
                    if (ListObjectives.SelectedItems[0].ImageIndex == 0)
                    {
                        MenuObjective.Items["MenuArchive"].Visible = true;
                        MenuObjective.Items["MenuActivate"].Visible = false;
                    }
                    else
                    {
                        MenuObjective.Items["MenuArchive"].Visible = false;
                        MenuObjective.Items["MenuActivate"].Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Archive the Objective.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuArchive_Click(object sender, EventArgs e)
        {
            string pathto = InTouch.ObjectivesArchiveFolder + "\\" + ListObjectives.SelectedItems[0].Text;
            string pathfrom = InTouch.ObjectivesRootFolder + "\\" + ListObjectives.SelectedItems[0].Text;

            Log.Info("To  : " + pathto);
            Log.Info("From: " + pathfrom);
        }

        /// <summary>
        /// Re-activate the Objective from archive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuActivate_Click(object sender, EventArgs e)
        {
            string pathfrom = InTouch.ObjectivesArchiveFolder + "\\" + ListObjectives.SelectedItems[0].Text;
            string pathto = InTouch.ObjectivesRootFolder + "\\" + ListObjectives.SelectedItems[0].Text;

            Log.Info("To  : " + pathto);
            Log.Info("From: " + pathfrom);
        }

        /// <summary>
        /// Display the Rates and Costs for the Objective.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRates_Click(object sender, EventArgs e)
        {
            if (ListObjectives.SelectedItems[0] is object)
            {
                FormObjectiveRates ratesForm = new FormObjectiveRates
                {
                    Objective = InTouch.GetObjective(ListObjectives.SelectedItems[0].Tag.ToString()),
                };
                ratesForm.ShowDialog();
                ratesForm.Dispose();
            }
        }
    }
}