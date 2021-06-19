namespace OutlookObjectives
{
    using CommonObjectives;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// UI to review or make changes to the WorkTypes.
    /// </summary>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        public FormChangeWorkType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setup the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormChangeWorkType_Load(object sender, EventArgs e)
        {
            ComboApplication.DataSource = Enum.GetValues(typeof(ApplicationType));
        }

        /// <summary>
        /// Load the data from the WorkType to the UI.
        /// </summary>
        private void SetupForm()
        {
            TextName.Text = workType.Name;
            TextDescription.Text = workType.Description;
            NumCostPerHour.Value = workType.CostPerHour;
            NumMinMinutes.Value = workType.MinimumNoOfMinutes;
            NumMaxMinutes.Value = workType.MaximNoOfMinutes;
            ComboApplication.SelectedText = workType.Application.ToString();
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
    }
}