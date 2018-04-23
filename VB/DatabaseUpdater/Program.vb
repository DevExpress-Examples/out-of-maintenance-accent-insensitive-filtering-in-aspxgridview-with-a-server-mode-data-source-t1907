' Developer Express Code Central Example:
' How to display and edit XPO in the ASPxGridView
' 
' This is a simple example of how to bind the grid to an XpoDataSource (eXpress
' Persistent Objects) for data displaying and editing. It's implemented according
' to the http://www.devexpress.com/scid=K18061 article.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E320

Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace DatabaseUpdater
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace