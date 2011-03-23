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
    public partial class MasterKas : System.Web.UI.Page
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

        protected void RadGrid1_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            Kas kas = new Kas();
            kas.KaCode = (userControl.FindControl("txtKasCode") as RadTextBox).Text.Trim().ToUpper();
            kas.KaName = (userControl.FindControl("txtKaName") as RadTextBox).Text.Trim().ToUpper();
            kas.SaldoAwal = Convert.ToDecimal((userControl.FindControl("txtSaldo") as RadTextBox).Text.Trim());
            kas.PeriodeId = Convert.ToInt32(HttpContext.Current.Session["_periodeId"]);
            kas.Save();
        }

        protected void RadGrid1_UpdateCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            Int32 KasId = 0;
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            Kas kas = new Kas();
            KasId = Convert.ToInt32((userControl.FindControl("txtBkuId") as RadTextBox).Text.Trim());
            if (kas.LoadByPrimaryKey(KasId))
            {                
                kas.KaName = (userControl.FindControl("txtKaName") as RadTextBox).Text.Trim().ToUpper();
                kas.SaldoAwal = Convert.ToDecimal((userControl.FindControl("txtSaldo") as RadTextBox).Text.Trim());                
                kas.Save();
            }
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            var mKas = from mK in rscm.KAs
                       join P in rscm.PeriodeAnggarans on mK.PERIODE_ID equals P.id
                       select new { mK.id, mK.KA_CODE, mK.KA_NAME, mK.SALDO_AWAL, mK.PERIODE_ID, P.Start_Period, P.End_Period, P.Is_Closed };
            RadGrid1.DataSource = mKas;
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

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.EditCommandName)
            {
                HttpContext.Current.Session["_isEdit"] = true;
            }

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                HttpContext.Current.Session["_isEdit"] = false;
            }
        }
    }
}