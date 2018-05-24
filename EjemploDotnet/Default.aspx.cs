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
            if (!IsPostBack)
            {
                FillDddl();
            }
        }

        protected void id_run_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = from a in DBModel.db.Dep
                                   where a.GroupName == DropDownList1.SelectedItem.Value
                                   select a;
            GridView1.DataBind();

            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = from a in DBModel.db.Dep
                                   where a.GroupName == DropDownList1.SelectedItem.Text
                                   select a;
            GridView1.DataBind();

            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        void FillDddl()
        {
            List<Items> animate = new List<Items>();

            animate.Add(new Items { atributte = "jello", grp = "Executive General and Administration" });
            animate.Add(new Items { atributte = "rollIn", grp = "Inventory Management" });
            animate.Add(new Items { atributte = "rotateIn", grp = "Manufacturing" });
            animate.Add(new Items { atributte = "slideOutDown", grp = "Quality Assurance" });
            animate.Add(new Items { atributte = "flipInX", grp = "Research and Development" });
            animate.Add(new Items { atributte = "slideInUp", grp = "Sales and Marketing" });

            var items = (from a in DBModel.db.Dep.ToList()
                         join b in animate on a.GroupName equals b.grp
                         select new ListItem() { Text = a.GroupName, Value = b.atributte }).Distinct();

            DropDownList1.Items.AddRange(items.ToArray());
            DropDownList1.DataBind();

        }

    }

    class Items
    {
        public string grp { get; set; }
        public string atributte { get; set; }
    }

}