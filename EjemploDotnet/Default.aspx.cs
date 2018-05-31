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
                FillGridview();
            }
        }

        protected void id_run_Click(object sender, EventArgs e)
        {
            FillGridview();
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
            FillGridview();
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

            items = (dynamic)null;

            items = (from a in DBModel.db.Dep.ToList()
                     select new ListItem() { Text = a.GroupName, Value = a.GroupName }).Distinct();

            ddl_grp.Items.AddRange(items.ToArray());
            ddl_grp.DataBind();
        }

        void FillGridview()
        {
            GridView1.DataSource = from a in DBModel.db.Dep
                                   where a.GroupName == DropDownList1.SelectedItem.Text
                                   select a;
            GridView1.DataBind();

            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            id_gvreg.DataSource = from a in DBModel.db.Dep
                                  where a.GroupName == ddl_grp.SelectedItem.Text
                                  select a;
            id_gvreg.DataBind();

            id_gvreg.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            DEPARTAMENTO item = new DEPARTAMENTO()
            {
                Name = txb_name.Text.Trim(),
                GroupName = ddl_grp.SelectedItem.Value,
                ModifiedDate = DateTime.Now
            };

            DBModel.db.Dep.InsertOnSubmit(item);

            DBModel.db.SubmitChanges();

            FillGridview();
        }

        protected void lbtn_refresh_Click(object sender, EventArgs e)
        {
            FillGridview();
        }

        protected void lbtn_save_Click(object sender, EventArgs e)
        {
            var update = (from a in DBModel.db.Dep.ToList()
                          where a.DepartmentID == int.Parse(txb_name.Attributes["aria-label"])
                          select a).Select(a => { a.Name = txb_name.Text.Trim(); a.GroupName = ddl_grp.SelectedItem.Value; return true; }).ToList();

            DBModel.db.SubmitChanges();

            txb_name.Text = "";
            txb_name.Attributes.Remove("aria-label");

            FillGridview();

        }


        protected void lbtn_edit_Click(object sender, EventArgs e)
        {
            id_gvreg.AutoGenerateSelectButton = true;

            FillGridview();
        }

        protected void id_gvreg_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            GridViewRow row = gv.SelectedRow;

            txb_name.Text = row.Cells[2].Text.Trim();
            txb_name.Attributes.Add("aria-label", row.Cells[1].Text);

            gv.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        void Uniones(int dato)
        {

            var join = (dynamic)null;

            int v1;             
            DateTime v2;

            switch (dato)
            {
                case 1:

                    join = from a in DBModel.db.Dep
                           join b in DBModel.db.TABL_DEPHISTORY on a.DepartmentID equals b.DepartmentID
                           select new
                           {
                               a.DepartmentID,
                               a.Name,
                               a.GroupName,
                               b.StartDate,
                               b.ModifiedDate,
                               b.EndDate
                           };

                    break;
                case 2:

                    join = from a in DBModel.db.Dep
                           join tb in DBModel.db.TABL_DEPHISTORY on a.DepartmentID equals tb.DepartmentID into jb
                           from b in jb.DefaultIfEmpty()
                           where b == null
                           select new
                           {
                               DepartmentID = int.TryParse(a.DepartmentID.ToString(), out v1) ? v1 : (int?)null,
                               a.Name,
                               a.GroupName,
                               StartDate = DateTime.TryParse(b.StartDate.ToString(), out v2) ? v2 : (DateTime?)null,
                               ModifiedDate = DateTime.TryParse(b.ModifiedDate.ToString(), out v2) ? v2 : (DateTime?)null,
                               b.EndDate
                           };

                    break;
                case 3:

                    join = from a in DBModel.db.TABL_DEPHISTORY
                           join tb in DBModel.db.Dep on a.DepartmentID equals tb.DepartmentID into jb
                           from b in jb.DefaultIfEmpty()
                           where b == null
                           select new
                           {
                               DepartmentID = int.TryParse(b.DepartmentID.ToString(), out v1) ? v1 : (int?)null,
                               b.Name,
                               b.GroupName,
                               StartDate = DateTime.TryParse(a.StartDate.ToString(), out v2) ? v2 : (DateTime?)null,
                               ModifiedDate = DateTime.TryParse(a.ModifiedDate.ToString(), out v2) ? v2 : (DateTime?)null,
                               a.EndDate
                           };

                    break;

            }

            gv_joins.DataSource = join;
            gv_joins.DataBind();

            if (gv_joins.Rows.Count != 0)
                gv_joins.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void lbtn_join_run_Click(object sender, EventArgs e)
        {
            Uniones(int.Parse(ddl_select_join.SelectedItem.Value));
        }

    }

    class Items
    {
        public string grp { get; set; }
        public string atributte { get; set; }
    }

}