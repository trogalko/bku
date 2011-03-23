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
    public partial class MasterKas1 : System.Web.UI.UserControl
    {
        private RscmBkuDataContext rscm = new RscmBkuDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)HttpContext.Current.Session["_isEdit"] == false)
            {
                txtKasCode.ReadOnly = false;
                txtKaName.ReadOnly = false;
                // Nama Kas enable && End period input disabled                
                // Datasource combo period Anggaran
                //var period = from p in rscm.PeriodeAnggarans
                //             where p.Is_Closed == false
                //             select new { p.id,p.Start_Period,p.End_Period, text = p.id + " - " + p.Start_Period.ToShortDateString() };

            }
            else
            {
                txtKasCode.ReadOnly = true;
                txtKaName.ReadOnly = false;
            }
        }
    }
}