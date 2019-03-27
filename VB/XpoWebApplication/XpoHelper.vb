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
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata

''' <summary>
''' Summary description for XpoHelper
''' </summary>
Public Module XpoHelper
	Public Function GetNewSession() As Session
		Return New Session(DataLayer)
	End Function

	Public Function GetNewUnitOfWork() As UnitOfWork
		Return New UnitOfWork(DataLayer)
	End Function

	Private ReadOnly lockObject As New Object()

'INSTANT VB TODO TASK: There is no VB equivalent to 'volatile':
'ORIGINAL LINE: static volatile IDataLayer fDataLayer;
	Private fDataLayer As IDataLayer
	Private ReadOnly Property DataLayer() As IDataLayer
		Get
			If fDataLayer Is Nothing Then
				SyncLock lockObject
					If fDataLayer Is Nothing Then
						fDataLayer = GetDataLayer()
					End If
				End SyncLock
			End If
			Return fDataLayer
		End Get
	End Property

	Private Function GetDataLayer() As IDataLayer
		' set XpoDefault.Session to null to prevent accidental use of XPO default session
		XpoDefault.Session = Nothing

		Dim conn As String = MSSqlConnectionProvider.GetConnectionString("(local)", "XpoWebTest")
		Dim dict As XPDictionary = New ReflectionDictionary()

'         Note: The database schema must exactly match your persistent classes' definition. ASP.NET applications
'         * should not update the database schema themselves; moreover, they often don't have enough permission
'         * to read the database schema.  You may need to create a separate tool which manages your database.
'         * On the one hand, we recommend using AutoCreateOption.SchemaAlreadyExists for the XPO data layer of your
'         * Web site.  On the other hand, the ThreadSafeDataLayer intensively uses data which is stored in the XPO's
'         * XPObjectType service table.  This sample project maps to the XpoWebTest database on your MS SQL Server.
'         * This database is created via the DatabaseUpdater project, which must be launched before this Site is 
'         * published. 

		Dim store As IDataStore = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists)

		' initialize the XPO dictionary
		dict.GetDataStoreSchema(GetType(PersistentObjects.Customer).Assembly)

		' create a ThreadSafeDataLayer
		Dim dl As IDataLayer = New ThreadSafeDataLayer(dict, store)

		Return dl
	End Function
End Module
