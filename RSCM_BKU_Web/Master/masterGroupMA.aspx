<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="masterGroupMA.aspx.cs" Inherits="RSCM_BKU_Web.Master.masterGroupMA" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    <div>
    
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

        <telerik:RadGrid ID="RadGrid1" 
            runat="server" 
            AllowPaging="True" 
            AllowSorting="True" GridLines="None" 
            oninsertcommand="RadGrid1_InsertCommand" 
            OnUpdateCommand="RadGrid1_UpdateCommand"
            onneeddatasource="RadGrid1_NeedDataSource" 
            onprerender="RadGrid1_PreRender" 
            Skin="Office2007" 
            AutoGenerateColumns="False"             
            ShowStatusBar="True">

            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>

            <MasterTableView 
                CommandItemDisplay="Top"                 
                GridLines="None"                 
                DataKeyNames="GtId" >
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>

                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <CommandItemSettings AddNewRecordText="Add New Group MA" />

                <Columns>
                    <telerik:GridEditCommandColumn HeaderStyle-Width="10%">                       
                    </telerik:GridEditCommandColumn>
                    <telerik:GridBoundColumn DataField="GtId" 
                        HeaderText="Group MA ID" 
                        ReadOnly="True" 
                        SortExpression="GtId" 
                        UniqueName="GtId"
                        ItemStyle-Wrap="false" 
                        HeaderStyle-Width="10%">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="GtCode" 
                        HeaderText="Group MA Code" 
                        ReadOnly="True" 
                        SortExpression="GtCode" 
                        UniqueName="GtCode"
                        ItemStyle-Wrap="false" 
                        HeaderStyle-Width="10%">
                    </telerik:GridBoundColumn>
                </Columns>

                <EditFormSettings EditFormType="WebUserControl" 
                    UserControlName="masterGroupMA.ascx">
                    <EditColumn UniqueName="EditCommandColumn1"></EditColumn>
                </EditFormSettings>
                <PagerStyle />
            </MasterTableView>            
            <PagerStyle AlwaysVisible="True" />
        </telerik:RadGrid>
    </div>
    </form>
</body>
</html>
