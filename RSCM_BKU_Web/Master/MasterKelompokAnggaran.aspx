<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterKelompokAnggaran.aspx.cs" Inherits="RSCM_BKU_Web.Master.MasterKelompokAnggaran" %>

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
            ShowStatusBar="True" onitemcommand="RadGrid1_ItemCommand" PageSize="100">

            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>

            <MasterTableView 
                CommandItemDisplay="Top" 
                GridLines="None"
                 DataKeyNames="KaId" >
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>

                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <CommandItemSettings AddNewRecordText="Add New Kelompok Anggaran" />

                <Columns>
                    <telerik:GridEditCommandColumn>
                    </telerik:GridEditCommandColumn>
                    <telerik:GridBoundColumn DataField="KaId" 
                        HeaderText="Kel. Anggaran ID" 
                        ReadOnly="True" 
                        SortExpression="KaId" 
                        UniqueName="KaId">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="KaCode" 
                        HeaderText="Kel. Anggaran Code" ReadOnly="True" SortExpression="KaCode" 
                        UniqueName="KaCode">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="KaName" 
                        HeaderText="Kel. Anggaran" ReadOnly="True" SortExpression="KaName" 
                        UniqueName="KaName">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Parent" 
                        HeaderText="Parent" ReadOnly="True" SortExpression="Parent" 
                        UniqueName="Parent">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="GtCode" 
                        HeaderText="Group MA" ReadOnly="True" SortExpression="GtCode" 
                        UniqueName="GtCode">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Prefix" 
                        HeaderText="Prefix" ReadOnly="True" SortExpression="Prefix" 
                        UniqueName="Prefix">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="KaLevel" 
                        HeaderText="Level MA" ReadOnly="True" SortExpression="KaLevel" 
                        UniqueName="KaLevel">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="Type" 
                        HeaderText="Type MA" ReadOnly="True" SortExpression="Type" 
                        UniqueName="Type">
                    </telerik:GridBoundColumn>

                    <telerik:GridCheckBoxColumn DataField="IsDetail" 
                        HeaderText="Is Detail?" ReadOnly="True" SortExpression="IsDetail" 
                        UniqueName="IsDetail">
                    </telerik:GridCheckBoxColumn>

                    <telerik:GridCheckBoxColumn DataField="IsActive" 
                        HeaderText="Is Active?" ReadOnly="True" SortExpression="IsActive" 
                        UniqueName="IsActive">
                    </telerik:GridCheckBoxColumn>
                    
                </Columns>

                <EditFormSettings EditFormType="WebUserControl" 
                    UserControlName="MasterKelompokAnggaran.ascx">
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
