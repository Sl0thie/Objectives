namespace OutlookObjectives
{
    using System;
    using System.Windows.Forms;
    using System.IO;
    using CommonObjectives;

    public partial class UCObjectives : UserControl
    {
        public UCObjectives()
        {
            InitializeComponent();
        }

        private void UCObjectives_Load(object sender, EventArgs e)
        {

            foreach (var path in Directory.EnumerateDirectories(InTouch.ObjectivesRootFolder, "*", SearchOption.TopDirectoryOnly))
            {
                Objective objective = InTouch.GetObjective(path);
                ListViewItem nextItem = new ListViewItem(objective.ObjectiveName)
                {
                    ImageIndex = 0,
                    Tag = objective.Path
                };
                ListObjectives.Items.Add(nextItem);
            }

            foreach (var path in Directory.EnumerateDirectories(InTouch.ObjectivesArchiveFolder, "*", SearchOption.TopDirectoryOnly))
            {
                Objective objective = InTouch.GetObjective(path);
                ListViewItem nextItem = new ListViewItem(objective.ObjectiveName)
                {
                    ImageIndex = 1,
                    Tag = objective.Path
                };
                ListObjectives.Items.Add(nextItem);
            }
        }

        private void UCObjectives_Resize(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
            panel1.Height = this.Height;

            ListObjectives.Width = this.Width + 100;
            ListObjectives.Height = this.Height;
        }

        private void ListObjectives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ListObjectives.SelectedItems.Count > 0)
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

        private void MenuArchive_Click(object sender, EventArgs e)
        {

        }

        private void MenuActivate_Click(object sender, EventArgs e)
        {

        }

        private void MenuRates_Click(object sender, EventArgs e)
        {
            if (ListObjectives.SelectedItems[0] is object)
            {
                FormObjectiveRates ratesForm = new FormObjectiveRates();
                ratesForm.Objective = InTouch.GetObjective(ListObjectives.SelectedItems[0].Tag.ToString());
                ratesForm.ShowDialog();
            }
        }
    }
}