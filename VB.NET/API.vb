Imports System.Text.RegularExpressions
Imports System.Collections.Generic


Public Class API
	Private username As String
	Private usergroups As String()
	Private posts As Integer, reputation As Integer, thanks As Integer, userID As Integer = 0
	Private subscriber As Boolean = False

	Public Sub New()
		Dim input As String = New System.Net.WebClient().DownloadString("http://thebot.net/api/post.php?legacy=0")
		If input.Contains("log in on TBN and try again") Then
			Return
		End If

		Dim pattern As String = ": (.*?)<br>"
		Dim returnValue As New List(Of String)()

		For Each m As Match In Regex.Matches(input, pattern)
			returnValue.Add(m.Groups(1).Value)
		Next

		Me.username = returnValue(0)
		Me.posts = Convert.ToInt32(returnValue(1))
		Me.reputation = 9001
		Me.subscriber = returnValue(3).Equals("Yes")
		Me.usergroups = returnValue(4).Split(New String() {", "}, StringSplitOptions.None)
		Me.thanks = Convert.ToInt32(returnValue(5))

		Me.userID = Convert.ToInt32(returnValue(6))
	End Sub

	Public Function getReputation() As Integer
		Return reputation
	End Function

	Public Function getPosts() As Integer
		Return posts
	End Function

	Public Function getThanks() As Integer
		Return thanks
	End Function

	Public Function getUserID() As Integer
		Return userID
	End Function

	Public Function getUsername() As [String]
		Return username
	End Function

	Public Function isSubscriber() As Boolean
		Return subscriber
	End Function

	Public Function getUsergroups() As String()
		Return usergroups
	End Function

	Public Function isMemberOf(group As String) As Boolean
		Dim pos As Integer = Array.IndexOf(usergroups, group)
		If pos > -1 Then
			Return True
		End If
		Return False
	End Function
End Class
