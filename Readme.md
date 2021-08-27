<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128532475/14.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T190796)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [AccentInsensitiveFilterOperator.cs](./CS/XpoWebApplication/AccentInsensitiveFilterOperator.cs) (VB: [AccentInsensitiveFilterOperator.vb](./VB/XpoWebApplication/AccentInsensitiveFilterOperator.vb))
* [Default.aspx](./CS/XpoWebApplication/Default.aspx) (VB: [Default.aspx](./VB/XpoWebApplication/Default.aspx))
* [Default.aspx.cs](./CS/XpoWebApplication/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/XpoWebApplication/Default.aspx.vb))
<!-- default file list end -->
# Accent-insensitive filtering in ASPxGridView with a Server Mode data source


<p>When ASPxGridView is bound to a server mode data source, all data operations are performed on the database server: <a href="https://documentation.devexpress.com/#AspNet/CustomDocument14781">Binding to Large Data (Database Server Mode)</a>?. Thus, results depend on database settings. For instance, filtering data with diacritic signs depends on the default collation of your data server:<br><a href="http://www.codeproject.com/Articles/310510/Configuring-SQL-Server-Accent-Insensitivity">[CodeProject.com] Configuring SQL Server Accent-Insensitivity</a><br><a href="http://stackoverflow.com/questions/14525981/questions-about-accent-insensitivity-in-sql-server-latin1-general-ci-as">[Stackoverflow.com] Questions about accent insensitivity in SQL Server (Latin1_General_CI_AS)</a>?<br><br>In other words, the first solution to achieve accent-insensitive filtering when the grid is bound to the server mode datasource is to change collation on the server. <br>Another solution is to create a custom filter operator by implementing ICustomFunctionOperator and  ICustomFunctionOperatorFormattable interfaces and modify a filtering request to the database in the ICustomFunctionOperatorFormattable.Format method:</p>


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


<p> </p>
<p>In this case, the accent-insensitive collation is applied only for filtering. <strong>Note that this approach is not supported by LINQ-based ORMs.<br><br></strong>This example demonstrates how to implement accent-insensitive filtering in Auto Filter Row when ASPxGridView is bound to XpoDataSource with Server Mode enabled. To test the example, download the solution to your local machine.<br><br><strong>See Also:<br><a href="https://www.devexpress.com/Support/Center/p/T385990">How to make the Grid's filter to be a case- and accent-insensitive in Server Mode</a><br><a href="https://www.devexpress.com/Support/Center/p/E4836">E4836: How to create a custom ASPxGridView's filter insensitive to the number of spaces and punctuation</a></strong></p>


<h3>Description</h3>

1) Run the "DatabaseUpdater" project;<br />2) Generate sample data;<br />3) Run XpoWebApplication project.

<br/>


