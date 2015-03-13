Imports Microsoft.Win32
Imports System.IO
Imports System.Runtime.InteropServices




Public Class Form1
    Const FEATURE_DISABLE_NAVIGATION_SOUNDS As Integer = 21
    Const SET_FEATURE_ON_THREAD As Integer = &H1
    Const SET_FEATURE_ON_PROCESS As Integer = &H2
    Const SET_FEATURE_IN_REGISTRY As Integer = &H4
    Const SET_FEATURE_ON_THREAD_LOCALMACHINE As Integer = &H8
    Const SET_FEATURE_ON_THREAD_INTRANET As Integer = &H10
    Const SET_FEATURE_ON_THREAD_TRUSTED As Integer = &H20
    Const SET_FEATURE_ON_THREAD_INTERNET As Integer = &H40
    Const SET_FEATURE_ON_THREAD_RESTRICTED As Integer = &H80

    <DllImport("urlmon.dll")> _
    <PreserveSig> _
    Private Shared Function CoInternetSetFeatureEnabled(FeatureEntry As Integer, <MarshalAs(UnmanagedType.U4)> dwFlags As Integer, fEnable As Boolean) As <MarshalAs(UnmanagedType.[Error])> Integer
    End Function

    Dim Votes As Integer = 0
    Dim StartTime, EndTime As DateTime
    Dim ElapsedTime As TimeSpan
    Dim GoBack As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, True)
        Browser.Navigate(New Uri("http://www.surveygizmo.com/s3/1844796/Week-8-Voting-MSA-Sports-Friday-Night-Spotlight-Game-of-the-Week"))
        Browser.ScriptErrorsSuppressed = True
        Me.Text = "Loading WebPage"
        StartTime = Now
    End Sub


    Private Sub AutoClick_Tick(sender As Object, e As EventArgs) Handles AutoClick.Tick
        EndTime = Now
        Dim Elem As HtmlElement
        Dim Doc As HtmlDocument
        Doc = Browser.Document

        'Make sure document is valid
        If (Doc IsNot Nothing) Then
            'Get the radio button for norwin
            Elem = Doc.GetElementById("sgE-1844796-1-2-10038")
            If (Elem IsNot Nothing) Then
                Elem.InvokeMember("Click") 'click button
                Me.Text = "Found Option"
            End If

            'Get the vote button
            Dim Button As HtmlElement
            Button = Doc.GetElementById("sg_SubmitButton")
            If (Button IsNot Nothing) Then
                Button.InvokeMember("Click") 'click vote
                StartTime = Now
                GoBack = True
                Me.Text = "Voted"

                Me.Text = "Voted For Norwin " + Votes.ToString() + " Times, Elapsed Time: " + ElapsedTime.TotalSeconds.ToString() + " seconds"
            End If

            'Hyperlinks are a little different they dont have an ID, so get all elements with tags
            'the tag for the text return to poll is A

            'Grab all elements with 'A' tag name
            'Dim Elems As HtmlElementCollection
            'Elems = Doc.GetElementsByTagName("A")
            'For Each El As HtmlElement In Elems 'loop all the elements
            '    If El.OuterText = "Return To Poll" Then   'check if the text is the link we want
            '        Votes += 1
            '        Me.Text = "Voted For Steel Valley " + Votes.ToString() + " Times, Elapsed Time: " + ElapsedTime.TotalSeconds.ToString() + " seconds"
            '        El.InvokeMember("Click")   'click it
            '    End If
            'Next


            ElapsedTime = EndTime.Subtract(StartTime)
        End If
    End Sub

    Private Sub Browser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles Browser.DocumentCompleted
        'Callback for when browser loads page
        If (GoBack = True) Then
            Votes += 1
            Browser.GoBack()
            GoBack = False
            Me.Text = "Reloaded Poll"
            EndTime = Now
        End If
    End Sub
End Class
