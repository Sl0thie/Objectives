namespace OutlookObjectives
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// UI form to provide an interface for the user to create a new Objective.</br>
    /// </summary>
    public partial class FormCreateObjective : Form
    {
        /// <summary>
        /// Constructor.</br>
        /// </summary>
        public FormCreateObjective()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks is the Objective is correct and if so then creates a new Objective.</be>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        this.Close();
                        return;
                    }
                    else
                    {
                        this.Text = "Objective already exists. (Archived)";
                    }
                }
                else
                {
                    this.Text = "Objective already exists.";
                }
            }
            else
            {
                this.Text = "Enter a name for the Objective.";
            }
        }
    }
}