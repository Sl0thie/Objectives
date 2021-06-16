namespace OutlookObjectives
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CommonObjectives;
    using LogNET;

    public partial class FormChangeWorkType : Form
    {
        private WorkType workType;

        public WorkType WorkType
        {
            get { return workType; }
            set
            {
                workType = value;
                SetupForm();
            }
        }

        public FormChangeWorkType()
        {
            InitializeComponent();
        }

        private void FormChangeWorkType_Load(object sender, EventArgs e)
        {
            ComboApplication.DataSource = Enum.GetValues(typeof(ApplicationType));
        }

        private void SetupForm()
        {
            TextName.Text = workType.Name;
            TextDescription.Text = workType.Description;
            NumCostPerHour.Value = workType.CostPerHour;
            NumMinMinutes.Value = workType.MinimumNoOfMinutes;
            NumMaxMinutes.Value = workType.MaximNoOfMinutes;
            ComboApplication.SelectedText = workType.Application.ToString();

            CheckActive.Checked = workType.Active;
        }

        private void TextName_TextChanged(object sender, EventArgs e)
        {
            workType.Name = TextName.Text;
        }

        private void TextDescription_TextChanged(object sender, EventArgs e)
        {
            workType.Description = TextDescription.Text;
        }

        private void NumCostPerHour_ValueChanged(object sender, EventArgs e)
        {
            workType.CostPerHour = NumCostPerHour.Value;
        }

        private void NumMinMinutes_ValueChanged(object sender, EventArgs e)
        {
            workType.MinimumNoOfMinutes = Convert.ToInt32(NumMinMinutes.Value);
        }

        private void NumMaxMinutes_ValueChanged(object sender, EventArgs e)
        {
            workType.MaximNoOfMinutes = Convert.ToInt32(NumMaxMinutes.Value);
        }

        private void ComboApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            workType.Application = (ApplicationType)ComboApplication.SelectedValue;
        }

        private void CheckActive_CheckedChanged(object sender, EventArgs e)
        {
            workType.Active = CheckActive.Checked;
        }
    }
}