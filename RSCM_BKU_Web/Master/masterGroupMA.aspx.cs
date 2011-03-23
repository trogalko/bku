using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;
using Telerik.Web.Design;
using Telerik.Web.Dialogs;
using RSCM_BKU_Web.BusinessObjects;
using EntitySpaces.DynamicQuery;
using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.SqlClientProvider;

using RSCM_BKU_Web.Linq;

namespace RSCM_BKU_Web.Master
{
    public partial class masterGroupMA : System.Web.UI.Page
    {
        private RscmBkuDataContext rscm = new RscmBkuDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            var per = from p in rscm.PeriodeAnggarans
                      where p.Is_Closed == false
                      select p;
            foreach (RSCM_BKU_Web.Linq.PeriodeAnggaran pp in per)
            {
                HttpContext.Current.Session["_periodeId"] = (Int32)pp.id;
            }
        }
        
        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var groupMAQuery = new GroupMAQuery();
            groupMAQuery.Select(groupMAQuery.GtId, groupMAQuery.GtCode);
            GroupMACollection gMAColl = new GroupMACollection();
            gMAColl.Load(groupMAQuery);
            this.RadGrid1.DataSource = gMAColl;
        }

        protected void RadGrid1_UpdateCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            long GroupMAId = Convert.ToInt32( (userControl.FindControl("txtGroupMAId") as RadTextBox).Text.Trim());
            GroupMA gma = new GroupMA();
            if (gma.LoadByPrimaryKey(GroupMAId))
            {
                try
                {
                    gma.GtCode = (userControl.FindControl("txtGroupMACode") as RadTextBox).Text.ToUpper();
                    gma.UserUpdate = "toro";
                    gma.TglUpdate = DateTime.Now;
                    gma.Save();
                }
                catch (Exception ex)
                {
                    string es = ex.Message;
                    e.Canceled = true;
                }
                finally
                {
                    RadGrid1.Rebind();
                }
            }
        }

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            if (RadGrid1.EditItems.Count > 0)
            {
                foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
                {
                    if (item != RadGrid1.EditItems[0])
                    {
                        item.Visible = false;
                    }
                }
            }
            if (RadGrid1.MasterTableView.IsItemInserted)
            {
                foreach (GridItem item in RadGrid1.Items)
                {
                    item.Visible = false;
                }
            }
            if (!IsPostBack)
            {
                this.RadGrid1.MasterTableView.Rebind();
            }
        }

        protected void RadGrid1_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            GroupMA gma = new GroupMA();
            try
            {
                gma.GtCode = (userControl.FindControl("txtGroupMACode") as RadTextBox).Text.ToUpper();
                gma.UserInsert = "toro";
                gma.TglInsert = DateTime.Now;
                gma.Save();
            }
            catch (Exception ex)
            {
                string es = ex.Message;
                e.Canceled = true;
            }
            finally
            {
                RadGrid1.Rebind();
            }            
        }
    }
}