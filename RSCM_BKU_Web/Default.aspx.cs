using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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

namespace RSCM_BKU_Web
{
    public partial class _Default : System.Web.UI.Page
    {
        private RscmBkuDataContext rscm = new RscmBkuDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            var per = from p in rscm.PeriodeAnggarans
                      where p.Is_Closed == false
                      select p;
            foreach ( RSCM_BKU_Web.Linq.PeriodeAnggaran pp in per)
            {
                HttpContext.Current.Session["_periodeId"] = (Int32)pp.id;
            }            
            //RSCM_BKU_Service.RSCM_BKUSoapClient service = new RSCM_BKU_Service.RSCM_BKUSoapClient();
            //TransCollection transColl = new TransCollection();
            //service.GetAllTransactionCompleted += new EventHandler<RSCM_BKU_Service.GetAllTransactionCompletedEventArgs>(service_GetAllTransactionCompleted);
            //service.GetAllTransactionAsync();
        }
    }
}