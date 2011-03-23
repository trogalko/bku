<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransaksiKasBendaharaPengguna.aspx.cs" Inherits="RSCM_BKU_Web.Transaksi.TransaksiKasBendaharaPengguna" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            oneditcommand="RadGrid1_EditCommand" 
            ShowStatusBar="True" onitemcommand="RadGrid1_ItemCommand">

            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>

            <MasterTableView 
                CommandItemDisplay="Top" 
                GridLines="None"
                 DataKeyNames="BKU_ID" >
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>

                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <CommandItemSettings AddNewRecordText="Add New Transaction" />

                <Columns>
                    <telerik:GridEditCommandColumn>                    
                    </telerik:GridEditCommandColumn>
                    <telerik:GridBoundColumn DataField="BKU_ID" 
                        HeaderText="Trans ID" 
                        ReadOnly="True" 
                        SortExpression="BKU_ID" 
                        UniqueName="BKU_ID">
                        <HeaderStyle Width="50px" />
                        <ItemStyle Width="50px" />
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="TRANS_NUMBER" 
                        HeaderText="Trans Number" ReadOnly="True" SortExpression="TRANS_NUMBER" 
                        UniqueName="TRANS_NUMBER">
                    </telerik:GridBoundColumn>

                    <telerik:GridDateTimeColumn DataField="TRANS_DATE" 
                        HeaderText="Trans Date" ReadOnly="True" SortExpression="TRANS_DATE" 
                        UniqueName="TRANS_DATE" DataFormatString="{0:d}">                        
                    </telerik:GridDateTimeColumn>

                    <telerik:GridBoundColumn DataField="KA_CODE" 
                        HeaderText="Trans. Code" ReadOnly="True" SortExpression="KA_CODE" 
                        UniqueName="KA_CODE">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="KA_NAME" 
                        HeaderText="Transaction Name" ReadOnly="True" SortExpression="KA_NAME" 
                        UniqueName="KA_NAME">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="CEK_BG_NUMBER" 
                        HeaderText="No. Cek/BG" ReadOnly="True" SortExpression="CEK_BG_NUMBER" 
                        UniqueName="CEK_BG_NUMBER">
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>

                    <telerik:GridNumericColumn DataField="DEBIT_AMOUNT" 
                        HeaderText="Debit Amount" ReadOnly="True" SortExpression="DEBIT_AMOUNT" 
                        UniqueName="DEBIT_AMOUNT" DataType="System.Decimal" NumericType="Currency">
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridNumericColumn>

                    <telerik:GridNumericColumn DataField="CREDIT_AMOUNT" 
                        HeaderText="Cedit Amount" ReadOnly="True" SortExpression="CREDIT_AMOUNT" 
                        UniqueName="CREDIT_AMOUNT" DataType="System.Decimal" NumericType="Currency">
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridNumericColumn>

                    <telerik:GridBoundColumn DataField="DESCRIPT"
                        HeaderText="Description" ReadOnly="true" SortExpression="DESCRIPT"
                        UniqueName="DESCRIPT">
                    </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn DataField="KAS_NAME"
                        HeaderText="KAS" ReadOnly="true" SortExpression="KAS_NAME"
                        UniqueName="KAS_NAME">
                    </telerik:GridBoundColumn>

                    <telerik:GridCheckBoxColumn DataField="ISVERIFIED"
                        HeaderText="Is Verifed?" ReadOnly="true" SortExpression="ISVERIFIED"
                        UniqueName="ISVERIFIED">
                    </telerik:GridCheckBoxColumn>

                    <telerik:GridCheckBoxColumn DataField="IS_CLOSED"
                        HeaderText="Is Closed?" ReadOnly="true" SortExpression="IS_CLOSED"
                        UniqueName="IS_CLOSED">
                    </telerik:GridCheckBoxColumn>

                </Columns>

                <EditFormSettings EditFormType="WebUserControl" 
                    UserControlName="TransaksiKasBendaharaPengguna.ascx"> 
                    <EditColumn UniqueName="EditCommandColumn1"></EditColumn>
                </EditFormSettings>
                <PagerStyle />
            </MasterTableView>        
            <PagerStyle AlwaysVisible="True"/>
        </telerik:RadGrid>

    </div>
    </form>
</body>
</html>
