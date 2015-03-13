<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Browser = New System.Windows.Forms.WebBrowser()
        Me.AutoClick = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Browser
        '
        resources.ApplyResources(Me.Browser, "Browser")
        Me.Browser.Name = "Browser"
        '
        'AutoClick
        '
        Me.AutoClick.Enabled = True
        Me.AutoClick.Interval = 1000
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Browser)
        Me.Name = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Browser As System.Windows.Forms.WebBrowser
    Friend WithEvents AutoClick As System.Windows.Forms.Timer

End Class
