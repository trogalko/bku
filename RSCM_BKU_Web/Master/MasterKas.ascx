<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MasterKas.ascx.cs" Inherits="RSCM_BKU_Web.Master.MasterKas1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<style type="text/css">
    .style1
    {
        width: 149px;
    }
    .style2
    {
        width: 2px;
    }
    .style3
    {
        width: 50%;
    }
</style>

<telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" 
    Skin="Office2007" />

<table style="width:100%;" width="100%">
    <tr>
        <td class="style1">
            ID</td>
        <td class="style2">
            :</td>
        <td>
            <telerik:RadTextBox ID="txtBkuId" 
                Runat="server" 
                Width="30%"
                Text='<%# DataBinder.Eval(Container,"DataItem.id") %>' 
                ReadOnly="True" Skin="Office2007">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Kode Kas</td>
        <td class="style2">
            :</td>
        <td>
            <telerik:RadTextBox ID="txtKasCode" 
                Runat="server" 
                Width="30%"
                Text='<%# DataBinder.Eval(Container,"DataItem.KA_CODE") %>' 
                ReadOnly="True" Skin="Office2007" >
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Nama</td>
        <td class="style2">
            :</td>
        <td>
            <telerik:RadTextBox ID="txtKaName" 
                Runat="server" 
                Width="500px" 
                Text='<%# DataBinder.Eval(Container,"DataItem.KA_NAME") %>' 
                ReadOnly="True" Skin="Office2007">
            </telerik:RadTextBox>
        </td>
    </tr>
    
    <tr>
        <td class="style1">
            Saldo</td>
        <td class="style2">
            :</td>
        <td>
            <telerik:RadTextBox ID="txtSaldo" 
                Runat="server" 
                Width="30%"
                Text='<%# DataBinder.Eval(Container,"DataItem.SALDO_AWAL") %>' 
                Skin="Office2007">
            </telerik:RadTextBox>
        </td>
    </tr>    
    </tr>

    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>


<table style="width:100%;">
    <tr>
        <td align="right" class="style3">
            <asp:Button ID="cmdSave" runat="server" Text='<%# ((bool)DataBinder.Eval(Container, "OwnerTableView.IsItemInserted")) ? "Insert" : "Update" %>' CommandName='<%# ((bool)DataBinder.Eval(Container, "OwnerTableView.IsItemInserted")) ? "PerformInsert" : "Update" %>' />
        </td>
        <td align="left" class="style3">
            <asp:Button ID="cmdCancel" runat="server" Text="Cancel" causesvalidation="False" commandname="Cancel" />
        </td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>



