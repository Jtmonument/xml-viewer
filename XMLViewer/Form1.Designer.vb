<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.FluentDesignFormContainer1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.FluentDesignFormControl1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl()
        Me.FluentFormDefaultManager1 = New DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(Me.components)
        Me.FluentDesignFormContainer1.SuspendLayout()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FluentFormDefaultManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FluentDesignFormContainer1
        '
        Me.FluentDesignFormContainer1.Controls.Add(Me.Button1)
        Me.FluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FluentDesignFormContainer1.Location = New System.Drawing.Point(48, 31)
        Me.FluentDesignFormContainer1.Name = "FluentDesignFormContainer1"
        Me.FluentDesignFormContainer1.Size = New System.Drawing.Size(643, 442)
        Me.FluentDesignFormContainer1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Button1.Location = New System.Drawing.Point(246, 181)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 34)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Choose XML file"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 31)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.Size = New System.Drawing.Size(48, 442)
        Me.AccordionControl1.TabIndex = 1
        Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        '
        'FluentDesignFormControl1
        '
        Me.FluentDesignFormControl1.FluentDesignForm = Me
        Me.FluentDesignFormControl1.Location = New System.Drawing.Point(0, 0)
        Me.FluentDesignFormControl1.Manager = Me.FluentFormDefaultManager1
        Me.FluentDesignFormControl1.Name = "FluentDesignFormControl1"
        Me.FluentDesignFormControl1.Size = New System.Drawing.Size(691, 31)
        Me.FluentDesignFormControl1.TabIndex = 2
        Me.FluentDesignFormControl1.TabStop = False
        '
        'FluentFormDefaultManager1
        '
        Me.FluentFormDefaultManager1.Form = Me
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 473)
        Me.ControlContainer = Me.FluentDesignFormContainer1
        Me.Controls.Add(Me.FluentDesignFormContainer1)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Controls.Add(Me.FluentDesignFormControl1)
        Me.FluentDesignFormControl = Me.FluentDesignFormControl1
        Me.Name = "Form1"
        Me.NavigationControl = Me.AccordionControl1
        Me.Text = "Form1"
        Me.FluentDesignFormContainer1.ResumeLayout(False)
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FluentFormDefaultManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FluentDesignFormContainer1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents FluentDesignFormControl1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl
    Friend WithEvents FluentFormDefaultManager1 As DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager
    Friend WithEvents Button1 As Button
End Class
