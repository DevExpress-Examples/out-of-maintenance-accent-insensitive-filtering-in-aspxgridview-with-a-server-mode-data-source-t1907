<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128532475/18.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T190796)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [AccentInsensitiveFilterOperator.cs](./CS/XpoWebApplication/AccentInsensitiveFilterOperator.cs) (VB: [AccentInsensitiveFilterOperator.vb](./VB/XpoWebApplication/AccentInsensitiveFilterOperator.vb))
* [Default.aspx](./CS/XpoWebApplication/Default.aspx) (VB: [Default.aspx](./VB/XpoWebApplication/Default.aspx))
* [Default.aspx.cs](./CS/XpoWebApplication/Default.aspx.cs) (VB: [Default.aspx](./VB/XpoWebApplication/Default.aspx))
<!-- default file list end -->
# Accent-insensitive filtering in ASPxGridView with a Server Mode data source


When ASPxGridView is bound to a server mode data source, all data operations are performed on the database server:[Binding to Large Data (Database Server Mode)][1]. Thus, results depend on database settings. For instance, filtering data with diacritic signs depends on the default collation of your data server:
- [CodeProject.com - Configuring SQL Server Accent-Insensitivity][2]
- [Stackoverflow.com - Questions about accent insensitivity in SQL Server (Latin1_General_CI_AS)][3]

In other words, the first solution to achieve accent-insensitive filtering when the grid is bound to the server mode datasource is to change collation on the server. <br>Another solution is to create a custom filter operator by implementing **ICustomFunctionOperator** and  **ICustomFunctionOperatorFormattable** interfaces. The approach is described in detail in the [
How to register a custom filter function and use it in ASPxGridView][4] example. The main difference is that you need to modify a filtering request to the database in the [ICustomFunctionOperatorFormattable.Format][5] method as follows:

```cs
string ICustomFunctionOperatorFormattable.Format(Type providerType, params String[] operands) {
    var operand = string.Format("N'%{0}%'", operands[0].Split('\'')[1]);
    return string.Format("{0} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE {1} ", operands[1], operand);
}
```

```vb
Private Function ICustomFunctionOperatorFormattable_Format(ByVal providerType As Type, ParamArray ByVal operands() As String) As String Implements ICustomFunctionOperatorFormattable.Format
    Dim operand = String.Format("N'%{0}%'", operands(0).Split("'"c)(1))
    Return String.Format("{0} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE {1} ", operands(1), operand)
End Function
```
This code sets an accent-insensitive collation for filtering requests.

**Note that this approach is not supported by LINQ-based ORMs**. This example demonstrates how to implement accent-insensitive filtering in Auto Filter Row when ASPxGridView is bound to XpoDataSource with Server Mode enabled. To test the example, download the solution to your local machine.
**See Also:**

- [KB Article: How to make the Grid's filter to be a case- and accent-insensitive in Server Mode][6]
- [ASPxGridView - How to create Accent Insensitive filter][7]


### Steps to setup:

1) Run the **DatabaseUpdater** project
2) Generate sample data
3) Run **XpoWebApplication** project.


[1]: https://documentation.devexpress.com/#AspNet/CustomDocument14781
[2]: http://www.codeproject.com/Articles/310510/Configuring-SQL-Server-Accent-Insensitivity
[3]: http://stackoverflow.com/questions/14525981/questions-about-accent-insensitivity-in-sql-server-latin1-general-ci-as
[4]: https://www.devexpress.com/Support/Center/Example/Details/E4099/how-to-register-a-custom-filter-function-and-use-it-in-aspxgridview
[5]: https://documentation.devexpress.com/CoreLibraries/DevExpress.Data.Filtering.ICustomFunctionOperatorFormattable.Format.method
[6]: https://www.devexpress.com/Support/Center/p/T385990
[7]: https://github.com/DevExpress-Examples/aspxgridview-how-to-create-accent-insensitive-filter-t547083
