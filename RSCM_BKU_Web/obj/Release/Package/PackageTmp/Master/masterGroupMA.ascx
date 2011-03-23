<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="masterGroupMA.ascx.cs" Inherits="RSCM_BKU_Web.Master.masterGroupMA1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .style1
    {
        width: 136px;
    }
    .style2
    {
        width: 5px;
    }
    .style3
    {
        width: 178px;
    }
    .style4
    {
        width: 2px;
    }
</style>

<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Sunset" />

<table style="width: 52%;">
    <tr>
        <td class="style1">
            Kode Mata Anggaran</td>
        <td class="style2">
            :</td>
        <td>
            <telerik:RadTextBox ID="txtGroupMACode" Runat="server" 
                EmptyMessage="Kode Mata Anggaran" Width="230px" Skin="Sunset"
                Text='<%# DataBinder.Eval( Container, "DataItem.GtCode") %>'>
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            &nbsp;</td>
        <td>
            <telerik:RadTextBox ID="txtGroupMAId" Runat="server" Visible="False"
            Text='<%# DataBinder.Eval( Container, "DataItem.GtId") %>' >
            </telerik:RadTextBox>
        </td>
    </tr>    
</table>

<table style="width: 52%;">
    <tr>
        <td class="style3" align="right">
            <asp:Button ID="cmdSave" runat="server" Text='<%# ((bool)DataBinder.Eval(Container, "OwnerTableView.IsItemInserted")) ? "Insert" : "Update" %>' CommandName='<%# ((bool)DataBinder.Eval(Container, "OwnerTableView.IsItemInserted")) ? "PerformInsert" : "Update" %>' />
        </td>
        <td class="style4">
            &nbsp;</td>
        <td align="left">
            <asp:Button ID="cmdCancel" runat="server" Text="Cancel" causesvalidation="False" commandname="Cancel" />
        </td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style4">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>


