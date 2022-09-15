Imports DevExpress.Utils.Design
Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraForm1
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ComboBox1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ComboBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(61, 98)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(168, 20)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Properties.CycleOnDblClick = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(39, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "How would you like to identify these nodes?"
        '
        'XtraForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 194)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "XtraForm1"
        CType(Me.ComboBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
End Class
