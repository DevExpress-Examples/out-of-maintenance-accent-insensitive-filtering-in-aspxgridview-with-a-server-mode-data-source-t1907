Imports DevExpress.Data.Filtering
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace XpoWebApplication
	Public Module AccentInsensitiveFilterStatic
		Public ReadOnly Property Name() As String
			Get
				Return "AccentInsensitive"
			End Get
		End Property
	End Module
	Public Class AccentInsensitiveFilterOperator
		Implements ICustomFunctionOperator, ICustomFunctionOperatorFormattable

		Public ReadOnly Property Name() As String Implements ICustomFunctionOperator.Name
			Get
				Return AccentInsensitiveFilterStatic.Name
			End Get
		End Property
		Private Function ICustomFunctionOperatorFormattable_Format(ByVal providerType As Type, ParamArray ByVal operands() As String) As String Implements ICustomFunctionOperatorFormattable.Format
			Dim operand = String.Format("N'%{0}%'", operands(0).Split("'"c)(1))
			Return String.Format("{0} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE {1} ", operands(1), operand)
		End Function
		Public Function ResultType(ParamArray ByVal operands() As Type) As Type Implements ICustomFunctionOperator.ResultType
			Return GetType(Boolean)
		End Function
		Public Function Evaluate(ParamArray ByVal operands() As Object) As Object Implements ICustomFunctionOperator.Evaluate
			Return Nothing
		End Function
	End Class
End Namespace