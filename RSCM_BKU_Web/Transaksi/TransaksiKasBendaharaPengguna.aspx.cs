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

namespace RSCM_BKU_Web.Transaksi
{
    public partial class TransaksiKasBendaharaPengguna : System.Web.UI.Page
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

        protected void RadGrid1_UpdateCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            Trans Trans = new Trans();
            if (Trans.LoadByPrimaryKey(Convert.ToInt32((userControl.FindControl("txtTransID") as RadTextBox).Text)))
            {
                try
                {
                    //Trans.Amount = Convert.ToDecimal((userControl.FindControl("txtAMOUNT") as RadTextBox).Text.ToUpper());
                    Trans.CekBgNumber = (userControl.FindControl("txtCek") as RadTextBox).Text.ToUpper();
                    Trans.DebitAmount = Convert.ToDecimal((userControl.FindControl("txtDebitAmount") as RadNumericTextBox).Value);
                    Trans.CreditAmount = Convert.ToDecimal((userControl.FindControl("txtCreditAmount") as RadNumericTextBox).Value);
                    Trans.Descript = (userControl.FindControl("txtDESC") as RadTextBox).Text.ToUpper();
                    //Trans.KasId = (userControl.FindControl("cmbKasID") as RadComboBox).SelectedValue.ToUpper();                   
                    Trans.UserUpdate = "toro";
                    Trans.TglUpdate = DateTime.Now;
                    Trans.Isverified = false;
                    Trans.IsClosed = false;
                    Trans.Save();
                }
                catch (Exception ex)
                {
                    string es = ex.Message;
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

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            var TransQ = from t in rscm.Trans
                         join kA in rscm.Kel_anggarans on t.KA_CODE equals kA.KA_CODE                         
                         join kas in rscm.KAs on t.KAS_ID equals kas.KA_CODE
                         where kA.IS_DETAIL == true &&
                         kA.IS_ACTIVE == true &&
                         kA.KA_LEVEL == "3"
                         select new { t.BKU_ID,t.TRANS_NUMBER,t.TRANS_DATE,t.CEK_BG_NUMBER,t.DEBIT_AMOUNT,t.CREDIT_AMOUNT,t.KA_CODE,kA.KA_NAME,t.DESCRIPT,KAS_NAME=kas.KA_NAME, t.ISVERIFIED,t.IS_CLOSED };
            RadGrid1.DataSource = TransQ;
        }

        protected void RadGrid1_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            string month = DateTime.Now.Month.ToString().Trim();
            string autonumber = "";
            if (month.Length == 1)
                month = ('0' + month).Trim();

            Trans Trans = new Trans();
            //Auto Number
            AutoNumberingQuery anQ = new AutoNumberingQuery();
                anQ.SelectAll();
                anQ.Where(anQ.KaMonth == month, anQ.KaYear == DateTime.Now.Year.ToString().Trim());
                AutoNumberingCollection anColl = new AutoNumberingCollection();
                
                    anColl.Load(anQ);
                    KelAnggaranQuery kaQ = new KelAnggaranQuery();
                    kaQ.SelectAll();
                    kaQ.Where(kaQ.KaCode == (userControl.FindControl("cmbTransCODE") as RadComboBox).SelectedValue.Trim());
                    KelAnggaranCollection kaColl = new KelAnggaranCollection();
                    
                        kaColl.Load(kaQ);
                        if (kaColl.Count > 0)
                            foreach (KelAnggaran kkk in kaColl)
                                autonumber = kkk.Prefix.Trim();
                        else
                            return;
                    
                    if (anColl.Count == 0)
                    {
                        AutoNumbering an = new AutoNumbering { KaYear = DateTime.Now.Year.ToString().Trim(), KaMonth = month, LastNumber = 1, PrefixNumber = "000" };
                        autonumber = String.Format("{0}{1}{2}-0001", autonumber, DateTime.Now.Year.ToString().Trim(), month);
                        an.Save();
                    }
                    else
                        foreach (AutoNumbering aa in anColl)
                        {
                            string i = (aa.LastNumber + 1).ToString().Trim();
                            if (i.Length == 1)
                                autonumber = String.Format("{0}{1}{2}-000{3}", autonumber, aa.KaYear, aa.KaMonth, i);
                            if (i.Length == 2)
                                autonumber = String.Format("{0}{1}{2}-00{3}", autonumber, aa.KaYear, aa.KaMonth, i);
                            if (i.Length == 3)
                                autonumber = String.Format("{0}{1}{2}-0{3}", autonumber, aa.KaYear, aa.KaMonth, i);
                            if (i.Length == 4)
                                autonumber = String.Format("{0}{1}{2}-{3}", autonumber, aa.KaYear, aa.KaMonth, i);
                            AutoNumbering anb = new AutoNumbering();
                            if (anb.LoadByPrimaryKey((long)aa.Id))
                            {
                                anb.LastNumber = aa.LastNumber + 1;
                                anb.Save();
                            }
                        }
                
            try
            {
                Trans.KaCode = (userControl.FindControl("cmbTransCODE") as RadComboBox).SelectedValue.ToUpper();
                Trans.TransNumber = autonumber.ToUpper();
                Trans.CekBgNumber = (userControl.FindControl("txtCek") as RadTextBox).Text.ToUpper();
                //Trans.Amount = Convert.ToDecimal((userControl.FindControl("txtDebitAmount") as RadNumericTextBox).Value - (userControl.FindControl("txtCreditAmount") as RadNumericTextBox).Value);
                Trans.DebitAmount = Convert.ToDecimal((userControl.FindControl("txtDebitAmount") as RadNumericTextBox).Value);
                Trans.CreditAmount = Convert.ToDecimal((userControl.FindControl("txtCreditAmount") as RadNumericTextBox).Value);
                Trans.Descript = (userControl.FindControl("txtDESC") as RadTextBox).Text.ToUpper();
                Trans.KasId = (userControl.FindControl("cmbKasID") as RadComboBox).SelectedValue.ToUpper();
                Trans.TransDate = DateTime.Now;
                Trans.UserInsert = "toro";
                Trans.TglInsert = DateTime.Now;
                Trans.PeriodId = (long)HttpContext.Current.Session["_periodeId"];
                Trans.Isverified = false;
                Trans.IsClosed = false;
                Trans.Save();
            }
            catch (Exception ex)
            {
                string es = ex.Message;
            }
            finally
            {
                RadGrid1.Rebind();
            }
        }

        protected void RadGrid1_EditCommand(object source, GridCommandEventArgs e)
        {
            Session["isEdit"] = true;
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {                
                HttpContext.Current.Session["_isEdit"] = false;
            }
            if (e.CommandName == RadGrid.EditCommandName)
            {                
                HttpContext.Current.Session["_isEdit"] = true;
            }
        }
    }
}