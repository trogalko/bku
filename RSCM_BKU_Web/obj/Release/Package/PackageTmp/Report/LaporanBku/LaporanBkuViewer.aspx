<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LaporanBkuViewer.aspx.cs" Inherits="RSCM_BKU_Web.Report.LaporanBku.LaporanBkuViewer" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=4.1.10.921, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            width: 77px;
        }
        .style4
        {
            width: 6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="btnPreview">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="btnPreview" />
                        <telerik:AjaxUpdatedControl ControlID="ReportViewer1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" 
            Skin="Office2007" />
        <telerik:RadMenu ID="RadMenu1" Runat="server" Skin="Office2007" Width="100%">
            <Items>
                <telerik:RadMenuItem runat="server" Text="MASTER">
                    <Items>
                        <telerik:RadMenuItem runat="server" NavigateUrl="~/Master/masterGroupMA.aspx" 
                            Text="Master Group Anggaran">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" 
                            NavigateUrl="~/Master/MasterKelompokAnggaran.aspx" 
                            Text="Master Kelompok Anggaran">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" 
                            NavigateUrl="~/Master/MasterKas.aspx" 
                            Text="Master Kas">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" 
                            NavigateUrl="~/Master/MasterRencanaAnggaranBelanja.aspx" 
                            Text="Master Rencana Anggaran Belanja">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="TRANSACTION">
                    <Items>
                        <telerik:RadMenuItem runat="server" 
                            NavigateUrl="~/Transaksi/TransaksiKasBendaharaPengguna.aspx" 
                            Text="Transaksi Kas Bendahara Pengguna">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="REPORTS">
                    <Items>
                        <telerik:RadMenuItem runat="server" 
                            NavigateUrl="~/Report/LaporanKasBank/LaporanKasBankViewer.aspx" 
                            Text="Laporan Kas dan Bank">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" 
                            NavigateUrl="~/Report/LaporanBku/LaporanBkuViewer.aspx" 
                            Text="Laporan BKU">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenu>
        <table style="width: 100%;">
            <tr>
                <td class="style3">
                    &nbsp;
                    Start Date</td>
                <td class="style4">
                    :</td>
                <td >
                    <telerik:RadDatePicker ID="dtpStartDate" Runat="server" Skin="Office2007" 
                        Width="200px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" 
                            Skin="Office2007"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                    End Date</td>
                <td class="style4" >
                    :</td>
                <td >                    
                    <telerik:RadDatePicker ID="dtpEndDate" Runat="server" Skin="Office2007" 
                        Width="199px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" 
                            Skin="Office2007"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
            </tr>            
        </table>
        <table style="width: 100%;">
            <tr>
                <td align="center" width="100%">
                    <asp:Button ID="btnPreview" runat="server" Text="PREVIEW" 
                        onclick="btnPreview_Click" />                    
                </td>                
            </tr>            
        </table>
    </div>
    <div>
        <telerik:ReportViewer ID="ReportViewer1" runat="server" Skin="Office2007" 
            Width="100%" Height="500px">
        </telerik:ReportViewer>
    </div>
    </form>
</body>
</html>
