using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities.Common
{
    public class AuditChangeModel
    {
        public AuditChangeModel(
            string? FeildName,
            string? OriginalValue,
            string? NewValue)
        {
            this.FieldName = FeildName;
            this.OriginalValue = OriginalValue; 
            this.NewValue = NewValue;
        }
        public string? FieldName { get; set; }

        public string? OriginalValue { get; set; }

        public string? NewValue { get; set; }
    }
}
