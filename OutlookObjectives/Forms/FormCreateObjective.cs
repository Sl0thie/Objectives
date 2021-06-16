namespace OutlookObjectives
{
    using System;
    using System.Windows.Forms;
    using System.IO;

    public partial class FormCreateObjective : Form
    {
        public FormCreateObjective()
        {
            InitializeComponent();
        }

        private void ButtonCreateObjective_Click(object sender, EventArgs e)
        {
            // Check if the new objective name is valid first.
            if(TextBoxObjective.Text.Length > 0)
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