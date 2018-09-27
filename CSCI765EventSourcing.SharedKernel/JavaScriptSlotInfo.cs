using System;
using System.Collections.Generic;
using System.Text;

namespace CSCI765EventSourcing.SharedKernel
{
    public class JavaScriptSlotInfo
    {
        public string Action { get; set; }
        public string When { get; set; }
        public string RoomId { get; set; }
        public string StartingAt { get; set; }
        public string Name { get; set; }
        public string Length { get; set; }
    }
}
