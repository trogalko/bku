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
    public partial class MasterKelompokAnggaran1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((bool)HttpContext.Current.Session["_isEdit"] == false) // Add
                {
                    //Controls Visibility                    
                    cmbPARENT.Visible = true;
                    txtParent.Visible = false;
                    txtMACODE.ReadOnly = false;
                    
                    ParentIdDataSourceComboBoxCollection parent = new ParentIdDataSourceComboBoxCollection();
                    parent.LoadAll();
                    //Parent
                    cmbPARENT.Items.Clear();
                    cmbPARENT.SelectedValue = null;
                    cmbPARENT.DataSource = parent;
                    cmbPARENT.DataTextField = "KaCode";
                    cmbPARENT.DataValueField = "KaName";
                    //Group MA
                    GroupMACollection gm = new GroupMACollection();
                    gm.LoadAll();
                    cmbGROUP.DataSource = gm;
                    cmbGROUP.DataTextField = "GtCode";
                    cmbGROUP.DataValueField = "GtCode";
                    //Level
                    LevelMACollection lma = new LevelMACollection();
                    lma.LoadAll();
                    cmbLEVEL.DataSource = lma;
                    cmbLEVEL.DataTextField = "Level";
                    cmbLEVEL.DataValueField = "Id";
                    //Type            
                    DebitKreditCollection dK = new DebitKreditCollection();
                    dK.LoadAll();
                    cmbTYPE.DataSource = dK;
                    cmbTYPE.DataTextField = "Type";
                    cmbTYPE.DataValueField = "Type";
                }
                else // Edit
                {
                    //Controls Visibility                    
                    cmbPARENT.Visible = false;
                    txtParent.Visible = true;
                    txtMACODE.ReadOnly = true;
                    //Group MA
                    GroupMACollection gm = new GroupMACollection();
                    gm.LoadAll();
                    cmbGROUP.DataSource = gm;
                    cmbGROUP.DataTextField = "GtCode";
                    cmbGROUP.DataValueField = "GtCode";
                    //Level
                    LevelMACollection lma = new LevelMACollection();
                    lma.LoadAll();
                    cmbLEVEL.DataSource = lma;
                    cmbLEVEL.DataTextField = "Level";
                    cmbLEVEL.DataValueField = "Id";
                    //Type            
                    DebitKreditCollection dK = new DebitKreditCollection();
                    dK.LoadAll();
                    cmbTYPE.DataSource = dK;
                    cmbTYPE.DataTextField = "Type";
                    cmbTYPE.DataValueField = "Type";
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        protected bool FormatCheckBox(object container,string expression)
        {
            bool ret = false;
            
            // if column is null set checkbox.checked = false

            if ((DataBinder.Eval(container, expression)).ToString() == "")
                ret = false;
            else // set checkbox.checked to boolean value in Status column
                ret = (bool)DataBinder.Eval(container, expression);

            return ret;
        }
    }
}