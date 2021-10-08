namespace OutlookObjectives
{
    using System;
    using LogNET;
    using Microsoft.Office.Tools;
    using Microsoft.Office.Tools.Ribbon;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Ribbon for the Explorer.
    /// </summary>
    public partial class RibExplorer
    {
        private Outlook.Explorer explorer;
        private CustomTaskPane taskPaneObjectives;

        /// <summary>
        /// Load event for the ribbon.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void RibExplorer_Load(object sender, RibbonUIEventArgs e)
        {
            // Get the explorer object.
            explorer = (Outlook.Explorer)Globals.ThisAddIn.Application.ActiveExplorer();

            // Subscribe to the folder switch event.
            explorer.FolderSwitch += Explorer_FolderSwitch;

            // Create the Objectives task pane for the side of the calendar.
            taskPaneObjectives = Globals.ThisAddIn.CustomTaskPanes.Add(new UCObjectives(), "Objectives", explorer);
            taskPaneObjectives.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
            taskPaneObjectives.Width = (int)(250 * InTouch.DpiX);
            taskPaneObjectives.Visible = true;
        }

        /// <summary>
        /// Manage the folder switch event.
        /// </summary>
        private void Explorer_FolderSwitch()
        {
            Outlook.MAPIFolder parentFolder = explorer.CurrentFolder as Outlook.MAPIFolder;
            string folderLocation = parentFolder.FolderPath.Substring(2);
            folderLocation = folderLocation.Substring(folderLocation.IndexOf("\\") + 1);

            // Show or hide the objective task pane based on the folder.
            switch (folderLocation)
            {
                case "Calendar":
                    try
                    {
                        taskPaneObjectives.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }

                    break;

                case "Calendar\\Objectives":
                    try
                    {
                        taskPaneObjectives.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }

                    break;

                case "Calendar\\System":
                    try
                    {
                        taskPaneObjectives.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }

                    break;

                default:
                    try
                    {
                        Log.Info("FolderLocation: " + folderLocation);
                        taskPaneObjectives.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }

                    break;
            }
        }

        /// <summary>
        /// Event for the New Objective button.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void ButtonNewObjective_Click(object sender, RibbonControlEventArgs e)
        {
            // Create and display a form to create a new Objective.
            FormCreateObjective createObjectiveForm = new FormCreateObjective();
            _ = createObjectiveForm.ShowDialog();
        }
    }
}