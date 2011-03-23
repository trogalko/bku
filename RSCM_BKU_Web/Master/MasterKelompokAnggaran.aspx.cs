using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.Design;
using Telerik.Web.Dialogs;
using Telerik.Web.UI;
using RSCM_BKU_Web.BusinessObjects;
using EntitySpaces.DynamicQuery;
using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.SqlClientProvider;

using RSCM_BKU_Web.Linq;
using Telerik.WinControls.UI;

namespace RSCM_BKU_Web.Master
{
    public partial class MasterKelompokAnggaran : System.Web.UI.Page
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
            RscmBkuDataContext rscmdc = new RscmBkuDataContext();
            var kelAg = from k in rscmdc.Kel_anggarans
                        join p in rscmdc.ParentId_DataSource_ComboBoxes on k.PARENT_CODE equals p.KA_CODE
                        where (k.IS_KAS == false)
                        select new { KaId = k.KA_ID, KaCode = k.KA_CODE, KaName = k.KA_NAME, Parent = p.KA_NAME, GtCode = k.GT_CODE, Prefix = k.PREFIX, KaLevel=k.KA_LEVEL, Type=k.TYPE, IsDetail=k.IS_DETAIL, IsActive=k.IS_ACTIVE, IsKas=k.IS_KAS };


            KelAnggaranCollection kaColl = new KelAnggaranCollection();
            ParentIdDataSourceComboBoxQuery parentQ = new ParentIdDataSourceComboBoxQuery("a");
            KelAnggaranQuery kaQ = new KelAnggaranQuery("b");
            kaQ.Select(kaQ.KaId.As("KaId"), kaQ.KaCode.As("KaCode"), kaQ.KaName.As("KaName"), parentQ.KaName.As("Parent"), kaQ.GtCode.As("GtCode"), kaQ.Prefix.As("Prefix"), kaQ.KaLevel.As("KaLevel"), kaQ.Type.As("Type"), kaQ.IsDetail.As("IsDetail"), kaQ.IsActive.As("IsActive"), kaQ.IsKas.As("IsKas"));            
            kaQ.InnerJoin(parentQ).On(kaQ.ParentCode == parentQ.KaCode);
            kaColl.Load(kaQ);
            DataTable dtKA = kaQ.LoadDataTable();
            
            foreach (DataRow dr in dtKA.Rows)
            {
                for (int i = 0; i <= Convert.ToInt32(dr["KaLevel"]); i++)
                {
                    if (i != 0)
                    {
                        dr["KaName"] = "&nbsp;&nbsp;&nbsp;&nbsp;" + dr["KaName"];
                        dr.AcceptChanges();
                    }
                }
            }
            //this.RadGrid1.DataSource = kelAg;
            this.RadGrid1.DataSource = dtKA;
        }

        protected void RadGrid1_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            KelAnggaran ka = new KelAnggaran();
            try
            {                
                ka.KaCode = (userControl.FindControl("txtMACODE") as RadTextBox).Text.ToUpper();
                ka.KaName = (userControl.FindControl("txtMANAME") as RadTextBox).Text.ToUpper();
                ka.GtCode = (userControl.FindControl("cmbGROUP") as RadComboBox).Text.ToUpper();
                ka.Prefix = (userControl.FindControl("txtMAPREFIX") as RadTextBox).Text.ToUpper();
                ka.IsDetail = (userControl.FindControl("chkDETAIL") as CheckBox).Checked;
                ka.KaLevel = (userControl.FindControl("cmbLEVEL") as RadComboBox).Text.ToUpper();
                ka.ParentCode = (userControl.FindControl("cmbPARENT") as RadComboBox).Text.ToUpper();
                ka.Type = (userControl.FindControl("cmbTYPE") as RadComboBox).Text.ToUpper();
                ka.IsActive = (userControl.FindControl("chkACTIVE") as CheckBox).Checked;
                //ka.IsKas = (userControl.FindControl("chkKAS") as CheckBox).Checked;
                ka.IsKas = false;
                ka.UserInsert = "toro";
                ka.TglInsert = DateTime.Now;
                ka.Save();
            }
            catch (Exception ex)
            { string es = ex.Message; e.Canceled = true; }
            finally
            { RadGrid1.Rebind(); }
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

        protected void RadGrid1_UpdateCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            long kelAngId = Convert.ToInt32((userControl.FindControl("txtMAID") as RadTextBox).Text);
            KelAnggaran ka = new KelAnggaran();
            if (ka.LoadByPrimaryKey(kelAngId))
            {
                try
                {
                    //ka.KaCode = (userControl.FindControl("txtMACODE") as RadTextBox).Text.ToUpper();
                    ka.KaName = (userControl.FindControl("txtMANAME") as RadTextBox).Text.ToUpper();
                    ka.GtCode = (userControl.FindControl("cmbGROUP") as RadComboBox).Text.ToUpper();
                    ka.Prefix = (userControl.FindControl("txtMAPREFIX") as RadTextBox).Text.ToUpper();
                    ka.IsDetail = (userControl.FindControl("chkDETAIL") as CheckBox).Checked;
                    ka.KaLevel = (userControl.FindControl("cmbLEVEL") as RadComboBox).Text.ToUpper();
                    //ka.ParentCode = (userControl.FindControl("cmbPARENT") as RadComboBox).Text.ToUpper();
                    ka.Type = (userControl.FindControl("cmbTYPE") as RadComboBox).Text.ToUpper();
                    ka.IsActive = (userControl.FindControl("chkACTIVE") as CheckBox).Checked;
                    //ka.IsKas = (userControl.FindControl("chkKAS") as CheckBox).Checked;
                    ka.IsKas = false;
                    ka.UserUpdate = "toro";
                    ka.TglUpdate = DateTime.Now;
                    ka.Save();
                }
                catch (Exception ex)
                { string es = ex.Message; e.Canceled = true; }
                finally
                { RadGrid1.Rebind(); }
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