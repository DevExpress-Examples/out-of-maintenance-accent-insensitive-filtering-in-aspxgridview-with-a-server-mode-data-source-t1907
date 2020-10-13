<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="XpoWebApplication._Default" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Xpo.v14.2.Web, Version=14.2.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Xpo" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
			DataSourceID="XpoDataSource1" KeyFieldName="Oid"
			OnProcessColumnAutoFilter="ASPxGridView1_ProcessColumnAutoFilter"
			OnAutoFilterCellEditorInitialize="ASPxGridView1_AutoFilterCellEditorInitialize"
			>
			<Settings ShowFilterRow="True" />
			<Columns>

				<dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ContactName" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Country" VisibleIndex="4">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="5">
				</dx:GridViewDataTextColumn>
			</Columns>
		</dx:ASPxGridView>
		<dx:XpoDataSource ID="XpoDataSource1" runat="server" TypeName="PersistentObjects.Customer" ServerMode="true">
		</dx:XpoDataSource>
	</form>
</body>
</html>