Class Example

	Private Shared Sub Main()
		Dim TBN As New API()
		Dim username As String = TBN.getUsername()
		Console.WriteLine("Welcome, " & username)

		If Not TBN.isMemberOf("Old School") Then
			Console.WriteLine("Sorry, you must be an Old School member to use this bot.")
			Return
		End If

		'Do stuff here

	End Sub
End Class
