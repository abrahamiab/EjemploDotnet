using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploDotnet
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void id_run_Click(object sender, EventArgs e)
        {
            var items = (from a in DBModel.db.Dep
                        select new ListItem() { Text = a.GroupName, Value = a.GroupName }).Distinct();

            DropDownList1.Items.AddRange(items.ToArray());
            DropDownList1.DataBind();

            GridView1.DataSource =  DBModel.db.Dep;
            GridView1.DataBind();
        }

        public DEPARTAMENTO[] Grupo()
        {
            DEPARTAMENTO[] data = DBModel.db.Dep.ToArray();
            
            return data;
        }

        protected void lbtn_animate_Click(object sender, EventArgs e)
        {
            lb_title.Text = txb_dato.Text;
            lb_title.Attributes.Add("class", "animated infinite fadeOutDown");

        }
    }
}