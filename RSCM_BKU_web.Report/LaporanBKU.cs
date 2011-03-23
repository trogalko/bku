namespace RSCM_BKU_web.Report
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for LaporanBKU.
    /// </summary>
    public partial class LaporanBKU : Telerik.Reporting.Report
    {
        public LaporanBKU()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //string startDate = "";
            //string endDate = "";
            //startDate = DateTime.Now.ToShortDateString();
            //endDate = DateTime.Now.ToShortDateString();
            //this.ReportParameters[0].Value = startDate;
            //this.ReportParameters[1].Value = endDate;
            
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}