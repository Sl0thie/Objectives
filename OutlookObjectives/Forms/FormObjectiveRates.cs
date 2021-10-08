namespace OutlookObjectives
{
    using System;
    using System.Windows.Forms;
    using CommonObjectives;
    using LogNET;

    /// <summary>
    /// Form to manage the Objectives Rates and Costs.
    /// </summary>
    public partial class FormObjectiveRates : Form
    {
        private Objective objective;

        /// <summary>
        /// Gets or sets the objective to manage.
        /// </summary>
        public Objective Objective
        {
            get
            {
                return objective;
            }

            set
            {
                objective = value;
                if (objective is object)
                {
                    SetupControl();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormObjectiveRates"/> class.
        /// </summary>
        public FormObjectiveRates()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setup the form to suit the supplied objective.
        /// </summary>
        private void SetupControl()
        {
            ListWorkTypes.Items.Clear();

            foreach (var next in InTouch.WorkTypes)
            {
                ListViewItem nextItem = new ListViewItem(next.Value.Index.ToString("000"))
                {
                    Tag = next.Value.Index,
                };
                _ = nextItem.SubItems.Add(next.Value.Name);
                _ = nextItem.SubItems.Add(next.Value.Description);
                _ = nextItem.SubItems.Add(next.Value.CostPerHour.ToString());
                _ = nextItem.SubItems.Add(next.Value.MinimumNoOfMinutes.ToString());
                _ = nextItem.SubItems.Add(next.Value.MaximNoOfMinutes.ToString());
                _ = nextItem.SubItems.Add(next.Value.Application.ToString());
                _ = ListWorkTypes.Items.Add(nextItem);
            }

            labelObjectiveName.Text = objective.ObjectiveName;
            labelDateCreated.Text = objective.Created.ToString("d/MM/yyyy");

            foreach (var next in objective.WorkTypes)
            {
                bool same = true;
                ListViewItem nextItem = ListWorkTypes.Items[next.Key];

                if (next.Value.Index.ToString("000") != nextItem.Text)
                {
                    same = false;
                    nextItem.Text = next.Value.Index.ToString("000");
                }

                if (next.Value.Name != nextItem.SubItems[1].Text)
                {
                    same = false;
                    nextItem.SubItems[1].Text = next.Value.Name;
                }

                if (next.Value.Description != nextItem.SubItems[2].Text)
                {
                    same = false;
                    nextItem.SubItems[2].Text = next.Value.Description;
                }

                if (next.Value.CostPerHour.ToString() != nextItem.SubItems[3].Text)
                {
                    same = false;
                    nextItem.SubItems[3].Text = next.Value.CostPerHour.ToString();
                }

                if (next.Value.MinimumNoOfMinutes.ToString() != nextItem.SubItems[4].Text)
                {
                    same = false;
                    nextItem.SubItems[4].Text = next.Value.MinimumNoOfMinutes.ToString();
                }

                if (next.Value.MaximNoOfMinutes.ToString() != nextItem.SubItems[5].Text)
                {
                    same = false;
                    nextItem.SubItems[5].Text = next.Value.MaximNoOfMinutes.ToString();
                }

                if (next.Value.Application.ToString() != nextItem.SubItems[6].Text)
                {
                    same = false;
                    nextItem.SubItems[6].Text = next.Value.Application.ToString();
                }

                if (!same)
                {
                    Log.Info("Not the same");
                }
            }
        }

        /// <summary>
        /// Show the Change WorkType form when an item is double clicked.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void ListWorkTypes_DoubleClick(object sender, EventArgs e)
        {
            if (ListWorkTypes.SelectedItems.Count > 0)
            {
                if (ListWorkTypes.SelectedItems[0] is object)
                {
                    if (objective.WorkTypes.ContainsKey((int)ListWorkTypes.SelectedItems[0].Tag))
                    {
                        FormChangeWorkType newForm = new FormChangeWorkType
                        {
                            WorkType = objective.WorkTypes[(int)ListWorkTypes.SelectedItems[0].Tag],
                        };

                        _ = newForm.ShowDialog();
                        objective.WorkTypes[(int)ListWorkTypes.SelectedItems[0].Tag] = newForm.WorkType;
                    }
                    else if (InTouch.WorkTypes.ContainsKey((int)ListWorkTypes.SelectedItems[0].Tag))
                    {
                        FormChangeWorkType newForm = new FormChangeWorkType
                        {
                            WorkType = InTouch.WorkTypes[(int)ListWorkTypes.SelectedItems[0].Tag],
                        };

                        _ = newForm.ShowDialog();

                        if (objective.WorkTypes.ContainsKey((int)ListWorkTypes.SelectedItems[0].Tag))
                        {
                            objective.WorkTypes[(int)ListWorkTypes.SelectedItems[0].Tag] = newForm.WorkType;
                        }
                        else
                        {
                            objective.WorkTypes.Add(newForm.WorkType.Index, newForm.WorkType);
                        }
                    }

                    SetupControl();
                }
            }
        }

        /// <summary>
        /// Save the objective when the form closes.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void FormObjectiveRates_FormClosing(object sender, FormClosingEventArgs e)
        {
            InTouch.SaveObjective(objective);
        }
    }
}