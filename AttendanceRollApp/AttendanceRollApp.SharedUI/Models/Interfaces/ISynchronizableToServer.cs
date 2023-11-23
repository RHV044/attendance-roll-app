using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceRollApp.SharedUI.Models.Interfaces
{
    public interface ISynchronizableToServer
    {
        public DateTime? LastTimeSynced { get; set; }
        public bool IsSynced { get; set; }
    }
}