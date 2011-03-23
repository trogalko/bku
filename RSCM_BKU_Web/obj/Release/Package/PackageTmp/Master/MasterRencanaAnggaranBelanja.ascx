<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MasterRencanaAnggaranBelanja.ascx.cs" Inherits="RSCM_BKU_Web.Master.MasterRencanaAnggaranBelanja1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
    .style1
    {
        width: 166px;
    }
    .style2
    {
        width: 6px;
    }
</style>
<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" 
    Skin="Office2007" />
<table style="width:100%;">
    <tr>
        <td class="style1">
            ID</td>
        <td class="style2">
            :</td>
        <td>
            <telerik:RadTextBox ID="txtId" 
                Runat="server" 
                Text='<%# DataBinder.Eval(Container,"DataItem.id") %>' 
                ReadOnly="True" Skin="Office2007">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Kelompok Anggaran</td>
        <td class="style2">
            :</td>
        <td>
            <telerik:RadTextBox ID="txtKaCode" 
                Runat="server" 
                ReadOnly="True" 
                Visible="False" 
                Width="300px" 
                Text='<%# DataBinder.Eval(Container,"DataItem.KA_NAME") %>' 
                Skin="Office2007">
            </telerik:RadTextBox>
            <telerik:RadComboBox ID="cmbKaCode" Runat="server" Width="300px" 
                Skin="Office2007" AllowCustomText="True" Filter="Contains" 
                MarkFirstMatch="True">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Rencana Anggaran Belanja</td>
        <td class="style2">
            :</td>
        <td>
            <telerik:RadNumericTextBox ID="txtRab" 
                Runat="server" Type="Currency"
                Text='<%# DataBinder.Eval(Container,"DataItem.RAB1") %>' 
                Width="300px" Skin="Office2007">
                <NumberFormat AllowRounding="False" 
                    DecimalDigits="2" 
                    KeepNotRoundedValue="True" 
                    NegativePattern="(Rp n)" 
                    PositivePattern="Rp n" />
            </telerik:RadNumericTextBox>
        </td>
    </tr>
</table>
<table style="width:100%;">
    <tr>
        <td style="width:50%" align="right">
            <asp:Button ID="cmdSave" runat="server" Text='<%# ((bool)DataBinder.Eval(Container, "OwnerTableView.IsItemInserted")) ? "Insert" : "Update" %>' CommandName='<%# ((bool)DataBinder.Eval(Container, "OwnerTableView.IsItemInserted")) ? "PerformInsert" : "Update" %>' />
        </td>
        <td style="width:50%" align="left">
            <asp:Button ID="cmdCancel" runat="server" Text="Cancel" causesvalidation="False" commandname="Cancel" />
        </td>        
    </tr>

</table>

