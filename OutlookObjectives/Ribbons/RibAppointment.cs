namespace OutlookObjectives
{
    using CommonObjectives;
    using Microsoft.Office.Tools.Ribbon;
    using Outlook = Microsoft.Office.Interop.Outlook;

    public partial class RibAppointment
    {
        private Outlook.Inspector inspector;
        IAppointment iAppointment;

        private void RibAppointment_Load(object sender, RibbonUIEventArgs e)
        {
            inspector = this.Context as Outlook.Inspector;

            if (Globals.ThisAddIn.IAppointments.TryGetValue(inspector, out iAppointment))
            {
                switch (iAppointment.AppointmentType)
                {
                    case AppointmentType.Standard:
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesDayReport");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesWeekReport");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesMonthReport");
                        break;

                    case AppointmentType.ObjectivesDayReport:
                        //inspector.HideFormPage("Appointment");
                        inspector.SetCurrentFormPage("InTouch-Objectives.FRObjectivesDayReport");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesWeekReport");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesMonthReport");

                        break;

                    case AppointmentType.ObjectivesWeekReport:
                        //inspector.HideFormPage("Appointment");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesDayReport");
                        inspector.SetCurrentFormPage("InTouch-Objectives.FRObjectivesWeekReport");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesMonthReport");

                        break;

                    case AppointmentType.ObjectivesMonthReport:
                        //inspector.HideFormPage("Appointment");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesDayReport");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesWeekReport");
                        inspector.SetCurrentFormPage("InTouch-Objectives.FRObjectivesMonthReport");

                        break;

                    default:
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesDayReport");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesWeekReport");
                        inspector.HideFormPage("InTouch-Objectives.FRObjectivesMonthReport");
                        break;
                }

                SetupRegion();
            }
        }

        private void SetupRegion()
        {

        }
    }
}