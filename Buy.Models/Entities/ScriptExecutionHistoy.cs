using System;
using System.Collections.Generic;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class ScriptExecutionHistoy
    {
        public Guid ScriptId { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}
