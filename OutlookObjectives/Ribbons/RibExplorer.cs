namespace OutlookObjectives
{
    using Microsoft.Office.Tools.Ribbon;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using Microsoft.Office.Tools;
    using System;
    using LogNET;

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
        /// <param name="e">Unused.</param>
        private void RibExplorer_Load(object sender, RibbonUIEventArgs e)
        {
            // Get the explorer object.
            explorer = (Outlook.Explorer)Globals.ThisAddIn.Application.ActiveExplorer();
            // Subscribe to the folder switch event.
            explorer.FolderSwitch += Explorer_FolderSwitch;

            // Create the Objectives task pane for the side of the canendar.
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
            string FolderLocation = parentFolder.FolderPath.Substring(2);
            FolderLocation = FolderLocation.Substring(FolderLocation.IndexOf("\\") + 1);

            // Show or hide the objective task pane based on the folder.
            switch (FolderLocation)
            {
                case "Calendar":
                    try
                    {
                        taskPaneObjectives.Visible = true;
                    }
                    catch (Exception ex) { Log.Error(ex); }
                    break;

                case "Calendar\\Objectives":
                    try
                    {
                        taskPaneObjectives.Visible = true;
                    }
                    catch (Exception ex) { Log.Error(ex); }
                    break;

                case "Calendar\\System":
                    try
                    {
                        taskPaneObjectives.Visible = true;
                    }
                    catch (Exception ex) { Log.Error(ex); }
                    break;

                default:
                    try
                    {
                        Log.Info("FolderLocation: " + FolderLocation);
                        taskPaneObjectives.Visible = false;
                    }
                    catch (Exception ex) { Log.Error(ex); }
                    break;
            }
        }

        /// <summary>
        /// Event for the New Objective button.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void ButtonNewObjective_Click(object sender, RibbonControlEventArgs e)
        {
            // Create and display a form to create a new Objective.
            FormCreateObjective createObjectiveForm = new FormCreateObjective();
            createObjectiveForm.ShowDialog();
        }
    }
}