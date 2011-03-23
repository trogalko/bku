using System;

using RSCM_BKU_Web.BusinessObjects;



namespace RSCM_BKU_Web.Report.LaporanKasBank
{
    public partial class LaporanKasBankViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TransQuery tQ = new TransQuery();
            //tQ.Select(tQ.BkuId, tQ.TransDate, tQ.Descript, tQ.DebitAmount, tQ.CreditAmount);

            //RSCM_BKU_web.Report.LaporanKasBank report1 = new RSCM_BKU_web.Report.LaporanKasBank();
            //report1.ReportParameters[0].Value = "toro";
            //LaporanKasBankWebViewer.Report = report1;
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.SelectedDate > dtpEndDate.SelectedDate || dtpStartDate.SelectedDate > DateTime.Now)
                return;
            if (dtpEndDate.SelectedDate.ToString().Trim() == string.Empty)
                return;
            if ((dtpStartDate.SelectedDate.ToString().Trim() == string.Empty))
                dtpStartDate.SelectedDate = dtpStartDate.MinDate;
            TransQuery tQ = new TransQuery();
            tQ.Select(tQ.TransNumber, tQ.TransDate, tQ.Descript, tQ.DebitAmount, tQ.CreditAmount);
            tQ.Where(tQ.TransDate >= dtpStartDate.SelectedDate, tQ.TransDate <= dtpEndDate.SelectedDate);
            TransCollection tColl = new TransCollection();
            tColl.Load(tQ);
            if (tColl.Count > 0)
            {
                RSCM_BKU_web.Report.LaporanKasBank report1 = new RSCM_BKU_web.Report.LaporanKasBank();
                report1.ReportParameters[0].Value = "Toro";
                report1.ReportParameters[1].Value = dtpStartDate.SelectedDate;
                report1.ReportParameters[2].Value = dtpEndDate.SelectedDate;
                report1.DataSource = tColl;
                LaporanKasBankWebViewer.Report = report1;
                LaporanKasBankWebViewer.RefreshReport();
            }
            else
                return;
        }
    }
}