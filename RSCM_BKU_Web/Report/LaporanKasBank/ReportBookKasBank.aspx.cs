using System;

using RSCM_BKU_Web.BusinessObjects;
using Telerik.Reporting;
using Telerik.ReportViewer;

namespace RSCM_BKU_Web.Report.LaporanKasBank
{
    public partial class ReportBookKasBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.SelectedDate > dtpEndDate.SelectedDate || dtpStartDate.SelectedDate > DateTime.Now)
                return;
            if (dtpEndDate.SelectedDate.ToString().Trim() == string.Empty)
                return;
            if ((dtpStartDate.SelectedDate.ToString().Trim() == string.Empty))
                dtpStartDate.SelectedDate = dtpStartDate.MinDate;

            //Load All Valid Kas
            KasQuery kasQ = new KasQuery("a");
            PeriodeAnggaranQuery paQ = new PeriodeAnggaranQuery("b");
            kasQ.InnerJoin(paQ).On(kasQ.PeriodeId == paQ.Id);
            kasQ.Select(kasQ.KaCode, kasQ.KaName);
            paQ.Where(paQ.IsClosed == false);

            KasCollection kasC = new KasCollection();
            kasC.Load(kasQ);
            ReportBook rb = new ReportBook();
            
            foreach (Kas k in kasC)
            {
                TransQuery tQ = new TransQuery("c");
                tQ.Select(tQ.TransNumber, tQ.TransDate, tQ.Descript, tQ.DebitAmount, tQ.CreditAmount);
                tQ.Where(tQ.TransDate >= dtpStartDate.SelectedDate, tQ.TransDate <= dtpEndDate.SelectedDate,tQ.KasId == k.KaCode);
                TransCollection tColl = new TransCollection();
                tColl.Load(tQ);
                if (tColl.Count > 0)
                {                    
                    RSCM_BKU_web.Report.LaporanKasBank report1 = new RSCM_BKU_web.Report.LaporanKasBank();
                    report1.ReportParameters[0].Value = k.KaName;
                    report1.ReportParameters[1].Value = dtpStartDate.SelectedDate;
                    report1.ReportParameters[2].Value = dtpEndDate.SelectedDate;
                    report1.DataSource = tColl;
                    rb.Reports.Add(report1);                                       
                }                
            }
            
            //ReportViewer1.Report = rb;
            //ReportViewer1.RefreshReport();            
        }
    }
}