<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Test_Guid_no.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="http://localhost:1212/Scripts/jquery-1.7.min.js" type="text/javascript"></script>
    <script src="http://localhost:1212/Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <link href="http://localhost:1212/Content/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".display").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "pagingType": "full_numbers",
                "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]]
            });
        });
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBGrubbrrV2ConnectionString %>" SelectCommand="SELECT * FROM [ProductMaster]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" CssClass="display" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:CheckBoxField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
