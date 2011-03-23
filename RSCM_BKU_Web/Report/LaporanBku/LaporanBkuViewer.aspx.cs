using System;
using System.Collections.Generic;
using System.Data;
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

using Telerik.Reporting;
using Telerik.ReportViewer;
using RSCM_BKU_web.Report;

namespace RSCM_BKU_Web.Report.LaporanBku
{
    public partial class LaporanBkuViewer : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        decimal SaldoAwal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.SelectedDate > DateTime.Now)
                return;
            if (dtpStartDate.SelectedDate > dtpEndDate.SelectedDate)
                return;
            if (dtpStartDate.SelectedDate.ToString().Trim() == string.Empty || dtpEndDate.SelectedDate.ToString().Trim() == string.Empty)
                return;
            
            TransaksiBKUQuery transBkuQ = new TransaksiBKUQuery();
            SaldoAwalCollection saCol = new SaldoAwalCollection();
            saCol.LoadAll();

            transBkuQ.SelectAll();           
            transBkuQ.Where(transBkuQ.TransDate >= dtpStartDate.SelectedDate, transBkuQ.TransDate <= dtpEndDate.SelectedDate);

            TransaksiBKUCollection transBkuCol = new TransaksiBKUCollection();
            transBkuCol.Load(transBkuQ);
            
            if (transBkuCol.Count > 0)
            {
                dt = transBkuQ.LoadDataTable();
                dt.Columns.Add("Saldo", typeof(decimal));
                DataTable dtCopy = dt.Clone();

                foreach (RSCM_BKU_Web.BusinessObjects.SaldoAwal sa in saCol)
                {
                    dt.Rows.Add("", null, "", "", "", "", 0, 0, false, false, true, sa.SaldoAwal);
                    dtCopy.Rows.Add("", null, "", "", "", "", 0, 0, false, false, true, sa.SaldoAwal);
                    SaldoAwal = Convert.ToDecimal((sa.SaldoAwal));
                }

                foreach (DataColumn dc in dt.Columns)
                {
                    this.Title = this.Title + " - " + dc.ColumnName;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    
                    SaldoAwal = SaldoAwal + (Convert.ToDecimal(dr["DEBIT_AMOUNT"]) - Convert.ToDecimal(dr["CREDIT_AMOUNT"]));
                    dr["Saldo"] = SaldoAwal;
                    dt.AcceptChanges();
                    dtCopy.Rows.Add(dr["TRANS_NUMBER"],dr["TRANS_DATE"],dr["DESCRIPT"],dr["KA_CODE"],dr["KA_NAME"],dr["GT_CODE"],dr["DEBIT_AMOUNT"],dr["CREDIT_AMOUNT"],dr["IS_CLOSED"],dr["ISVERIFIED"],dr["IS_ACTIVE"],dr["Saldo"]);
                }
                
                RSCM_BKU_web.Report.LaporanBKU report1 = new LaporanBKU();
                report1.ReportParameters[0].Value = dtpStartDate.SelectedDate;
                report1.ReportParameters[1].Value = dtpEndDate.SelectedDate;
                report1.DataSource = dtCopy;
                ReportViewer1.Report = report1;
                ReportViewer1.RefreshReport();
            }
            else
                return;
        }
    }
}