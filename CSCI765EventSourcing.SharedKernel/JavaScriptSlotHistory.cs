using System;
using System.Collections.Generic;
using System.Text;

namespace CSCI765EventSourcing.SharedKernel
{
    public class JavaScriptSlotHistory
    {
        public int AppointmentId { get; set; }
        public IList<JavaScriptSlotInfo> ChangeList { get; set; }
    }
}
