namespace OutlookObjectives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using CommonObjectives;

    class IWAppointment : IAppointment
    {
        private Outlook.Inspector inspector;
        public Outlook.Inspector Inspector
        {
            get
            {
                return inspector;
            }
        }

        private Outlook.AppointmentItem appointment;
        public Outlook.AppointmentItem Appointment
        {
            get { return appointment; }
        }

        private string folderPath;
        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        public AppointmentType AppointmentType { get; set; }


        public IWAppointment(Outlook.Inspector Inspector, string folderPath,AppointmentType appointmentType)
        {
            this.inspector = Inspector;
            this.folderPath = folderPath;
            appointment = (Outlook.AppointmentItem)inspector.CurrentItem;
            AppointmentType = appointmentType;

            ((Outlook.ItemEvents_10_Event)appointment).Close += Appointment_Close;
            ((Outlook.InspectorEvents_Event)inspector).Close += new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
        }

        void InspectorWrapper_Close()
        {
            //exAppointment.Close();
            //exAppointment = null;

            Globals.ThisAddIn.IAppointments.Remove(inspector);
            ((Outlook.InspectorEvents_Event)inspector).Close -=
                new Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);
            inspector = null;
        }

        private void Appointment_Close(ref bool cancel)
        {
            ((Outlook.ItemEvents_10_Event)appointment).Close -= Appointment_Close;
            appointment.Save();
        }
    }
}
