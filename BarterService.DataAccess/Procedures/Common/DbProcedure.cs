using System;

namespace BarterService.DataAccess.Procedures.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DbProcedure : Attribute
    {
        public string ProcName { get; set; }

        public DbProcedure(string procName)
        {
            ProcName = procName;
        }
    }
}
