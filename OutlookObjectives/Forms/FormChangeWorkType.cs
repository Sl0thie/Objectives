namespace OutlookObjectives
{
    using System;
    using System.Windows.Forms;
    using CommonObjectives;

    /// <summary>
    /// UI to review or make changes to the WorkTypes.
    /// </summary>
    public partial class FormChangeWorkType : Form
    {
        private WorkType workType;

        /// <summary>
        /// The WorkType to be review or modified.
        /// </summary>
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
        /// Initializes a new instance of the <see cref="FormChangeWorkType"/> class.
        /// </summary>
        public FormChangeWorkType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setup the UI.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
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

        /// <summary>
        /// Updates the WorkType Name.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void TextName_TextChanged(object sender, EventArgs e)
        {
            workType.Name = TextName.Text;
        }

        /// <summary>
        /// Updates the WorkType Description.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void TextDescription_TextChanged(object sender, EventArgs e)
        {
            workType.Description = TextDescription.Text;
        }

        /// <summary>
        /// Updates the WorkType Cost per Hour.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void NumCostPerHour_ValueChanged(object sender, EventArgs e)
        {
            workType.CostPerHour = NumCostPerHour.Value;
        }

        /// <summary>
        /// Updates the minimum number of minutes per day.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void NumMinMinutes_ValueChanged(object sender, EventArgs e)
        {
            workType.MinimumNoOfMinutes = Convert.ToInt32(NumMinMinutes.Value);
        }

        /// <summary>
        /// Updates the maximum number of minutes per day.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void NumMaxMinutes_ValueChanged(object sender, EventArgs e)
        {
            workType.MaximNoOfMinutes = Convert.ToInt32(NumMaxMinutes.Value);
        }

        /// <summary>
        /// Updates the application associated with the WorkType.
        /// </summary>
        /// <param name="sender">This parameter is unused.</param>
        /// <param name="e">This parameter is unused.</param>
        private void ComboApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            workType.Application = (ApplicationType)ComboApplication.SelectedValue;
        }
    }
}