namespace OutlookObjectives
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// UI form to provide an interface for the user to create a new Objective.
    /// </summary>
    public partial class FormCreateObjective : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormCreateObjective"/> class.
        /// </summary>
        public FormCreateObjective()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks is the Objective is correct and if so then creates a new Objective.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void ButtonCreateObjective_Click(object sender, EventArgs e)
        {
            // Check if the new objective name is valid first.
            if (TextBoxObjective.Text.Length > 0)
            {
                if (!Directory.Exists(InTouch.ObjectivesRootFolder + @"\" + TextBoxObjective.Text))
                {
                    if (!Directory.Exists(InTouch.ObjectivesArchiveFolder + @"\" + TextBoxObjective.Text))
                    {
                        // If valid then create objective and close the form.
                        InTouch.CreateObjective(TextBoxObjective.Text);
                        Close();
                        return;
                    }
                    else
                    {
                        Text = "Objective already exists. (Archived)";
                    }
                }
                else
                {
                    Text = "Objective already exists.";
                }
            }
            else
            {
                Text = "Enter a name for the Objective.";
            }
        }
    }
}