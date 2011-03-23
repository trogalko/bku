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
    public partial class MasterRencanaAnggaranBelanja1 : System.Web.UI.UserControl
    {
        private RscmBkuDataContext rscm = new RscmBkuDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if ((bool)HttpContext.Current.Session["_isEdit"] == false)
            {
                txtKaCode.Visible = false;
                cmbKaCode.Visible = true;

                //combo kode anggaran datasource
                var kaQ = from k in rscm.Kel_anggarans
                          where k.IS_ACTIVE == true &&
                          k.IS_DETAIL == true &&
                          k.IS_KAS == false
                          select new { k.KA_CODE, complete = k.KA_CODE + " - " + k.KA_NAME };

                //KelAnggaranQuery kelAngQ = new KelAnggaranQuery();
                //kelAngQ.Where(kelAngQ.IsActive == true, kelAngQ.IsDetail == true, kelAngQ.IsKas == false);
                //kelAngQ.Select(kelAngQ.KaCode, (kelAngQ.KaCode + " - " + kelAngQ.KaName).As("complete"));

                //KelAnggaranCollection kaC = new KelAnggaranCollection();
                //kaC.Load(kelAngQ);                
                cmbKaCode.DataSource = kaQ;
                cmbKaCode.DataTextField = "complete";
                cmbKaCode.DataValueField = "KA_CODE";                
            }
            else
            {
                txtKaCode.Visible = true;
                cmbKaCode.Visible = false;
            }
        }
    }
}