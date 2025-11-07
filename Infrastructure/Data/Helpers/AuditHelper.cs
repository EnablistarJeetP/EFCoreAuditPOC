using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.EntityFramework;
using Infrastructure.Data.Entities.Common;


namespace Infrastructure.Data.Helpers
{
    public static class AuditHelper
    {
        public static List<AuditChangeModel> CreateAuditChangeObject(EventEntry eventEntry)
        {
            List<AuditChangeModel> auditChanges = new ();

            if (eventEntry.Action == "Update")
            {
                foreach(EventEntryChange field in eventEntry.Changes)
                {
                    if (!field.OriginalValue.Equals(field.NewValue))
                    {
                        auditChanges.Add(new AuditChangeModel(field.ColumnName, field.OriginalValue.ToString(), field.NewValue.ToString()));
                    }
                }
            }
            else
            {
                foreach (var field in eventEntry.ColumnValues)
                {
                    if (eventEntry.Action == "Insert")
                    {
                        auditChanges.Add(new AuditChangeModel(field.Key, null, field.Value.ToString()));
                    }
                    if (eventEntry.Action == "Delete")
                    {
                        auditChanges.Add(new AuditChangeModel(field.Key, field.Value.ToString(), null));
                    }

                }

            }

            return auditChanges;
        }
    }
}
