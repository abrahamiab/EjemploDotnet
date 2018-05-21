using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;

namespace EjemploDotnet
{
    public class DBModel
    {
        static string Connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public static Ejemplo db = new Ejemplo(Connection);
    }

    public partial class Ejemplo : DataContext
    {
        public Table<DEPARTAMENTO> Dep;
        public Ejemplo(string connection) : base(connection) { }
    }

    [Table(Name = "HumanResources.Department")]
    public class DEPARTAMENTO
    {
        [Column(IsPrimaryKey = true, CanBeNull = false,DbType = "smallint")]
        public int DepartmentID { get; set; }
        [Column(DbType = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(DbType = "nvarchar(50)")]
        public string GroupName { get; set; }
        [Column]
        public DateTime ModifiedDate { get; set; }
    }

}