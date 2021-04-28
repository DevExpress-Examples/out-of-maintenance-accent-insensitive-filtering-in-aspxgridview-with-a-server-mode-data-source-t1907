<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XpoWebApplication._Default" %>
<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v18.2, Version=18.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Xpo" TagPrefix="dx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Accent-insensitive filtering in ASPxGridView with a Server Mode data source</title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Filter by CompanyName, ContactName or Country</h3>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="XpoDataSource1" KeyFieldName="Oid"
            OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter"
            OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize">
            <Settings ShowFilterRow="True" />
            <Columns>
                <dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" />
                <dx:GridViewDataTextColumn FieldName="CompanyName" />
                <dx:GridViewDataTextColumn FieldName="ContactName" />
                <dx:GridViewDataTextColumn FieldName="Country" />
                <dx:GridViewDataTextColumn FieldName="Phone" />
            </Columns>
        </dx:ASPxGridView>
        <dx:XpoDataSource ID="XpoDataSource1" runat="server" TypeName="PersistentObjects.Customer" ServerMode="true"/>
    </form>
</body>
</html>
