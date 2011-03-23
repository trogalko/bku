<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MasterKelompokAnggaran.ascx.cs" Inherits="RSCM_BKU_Web.Master.MasterKelompokAnggaran1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
    .style1
    {
        width: 101px;
    }
    .style2
    {
        width: 10px;
    }
    .style3
    {
        width: 294px;
    }
    .style4
    {
        width: 82px;
    }
    .style5
    {
        width: 4px;
    }
    .style6
    {
        width: 304px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            Kel. MA ID</td>
        <td class="style2">
            :</td>
        <td class="style3">
            <telerik:RadTextBox ID="txtMAID" 
                Runat="server"
                Text='<%# DataBinder.Eval( Container, "DataItem.KaId") %>' 
                ReadOnly="True" 
                Skin="Office2007">
            </telerik:RadTextBox>
        </td>
        <td class="style4">
            Level</td>
        <td class="style5">
            :</td>
        <td>
            <telerik:RadComboBox ID="cmbLEVEL" 
                Runat="server"
                SelectedValue='<%# DataBinder.Eval( Container, "DataItem.KaLevel") %>' 
                Skin="Office2007">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Kel. MA Code</td>
        <td class="style2">
            :</td>
        <td class="style3">
            <telerik:RadTextBox ID="txtMACODE" 
                Runat="server"
                Text='<%# DataBinder.Eval( Container, "DataItem.KaCode") %>' 
                Skin="Office2007">
            </telerik:RadTextBox>
        </td>
        <td class="style4">
            Type</td>
        <td class="style5">
            :</td>
        <td>
            <telerik:RadComboBox ID="cmbTYPE" Runat="server"
                SelectedValue='<%# DataBinder.Eval( Container, "DataItem.Type") %>' 
                Skin="Office2007">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Kel. MA Name</td>
        <td class="style2">
            :</td>
        <td class="style3">
            <telerik:RadTextBox ID="txtMANAME" 
                Runat="server" 
                Width="285px"
                Text='<%# DataBinder.Eval( Container, "DataItem.KaName") %>' 
                Skin="Office2007">
            </telerik:RadTextBox>
        </td>
        <td class="style4">
            &nbsp;</td>
        <td class="style5">
            :</td>
        <td>
            <asp:CheckBox ID="chkDETAIL" runat="server" Text="Is Detail" Checked='<%# FormatCheckBox( Container, "DataItem.IsDetail") %>' />
        </td>
    </tr>
    <tr>
        <td class="style1">
            Kel. MA Parent</td>
        <td class="style2">
            :</td>
        <td class="style3">
            <telerik:RadComboBox ID="cmbPARENT" 
                Runat="server"            
                Skin="Office2007" 
                Width="285px">
            </telerik:RadComboBox>
            <telerik:RadTextBox ID="txtParent" 
                Runat="server"                 
                Visible="False" 
                Width="285px"
                Text='<%# DataBinder.Eval( Container, "DataItem.Parent") %>' 
                Skin="Office2007" ReadOnly="True">
            </telerik:RadTextBox>
        </td>
        <td class="style4">
            &nbsp;</td>
        <td class="style5">
            :</td>
        <td>
            <asp:CheckBox ID="chkACTIVE" runat="server" Text="Is Active" Checked='<%# FormatCheckBox( Container, "DataItem.IsActive") %>' />
        </td>
    </tr>
    <tr>
        <td class="style1">
            Group MA</td>
        <td class="style2">
            :</td>
        <td class="style3">
            <telerik:RadComboBox ID="cmbGROUP" 
                Runat="server"
                SelectedValue='<%# DataBinder.Eval( Container, "DataItem.GtCode") %>' 
                Skin="Office2007">
            </telerik:RadComboBox>
        </td>
        <td class="style4">
            &nbsp;</td>
        <td class="style5">
            :</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Prefix</td>
        <td class="style2">
            :</td>
        <td class="style3">
            <telerik:RadTextBox ID="txtMAPREFIX" 
                Runat="server"
                Text='<%# DataBinder.Eval( Container, "DataItem.Prefix") %>' 
                Skin="Office2007">
            </telerik:RadTextBox>
        </td>
        <td class="style4">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <table style="width: 100%;">
            <tr>
                <td align="right" class="style6">
                    <asp:Button ID="btnSAVE" runat="server" Height="26px" Text='<%# ((bool)DataBinder.Eval(Container, "OwnerTableView.IsItemInserted")) ? "Insert" : "Update" %>' CommandName='<%# ((bool)DataBinder.Eval(Container, "OwnerTableView.IsItemInserted")) ? "PerformInsert" : "Update" %>' />
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                    <asp:Button ID="btnCANCEL" runat="server" Text="Cancel" causesvalidation="False" commandname="Cancel" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>

</table>

