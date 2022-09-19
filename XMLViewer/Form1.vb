Imports System.IO
Imports System.Xml
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors

Public Class Form1

    Private XmlDoc As New XmlDocument
    Private Identifiers As New Hashtable
    Private LabelFont As New Font(New FontFamily("Arial Narrow"), 16, FontStyle.Regular, GraphicsUnit.Pixel)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With New OpenFileDialog()
            .Filter = "XML files (*.xml) | *.xml"
            .FilterIndex = 1
            If .ShowDialog() = DialogResult.OK Then
                Try
                    XmlDoc.Load(.OpenFile())
                Catch ex As Exception
                    MessageBox.Show("Cannot parse XML file", "", MessageBoxButtons.OK)
                    Return
                End Try
            Else
                Return
            End If
        End With
        Me.AccordionControl1.Clear()
        Dim Root As New XmlAccordionElement
        Root.Text = XmlDoc.LastChild.Name
        Root.Node = XmlDoc.LastChild
        For Each Node As XmlNode In XmlDoc.ChildNodes()
            If Not Node.Name.ToLower().Contains("xml") Then
                Dim Element As New XmlAccordionElement()
                Element.Text = Node.Name
                Element.Node = Node
            End If
        Next
        Me.AccordionControl1.Elements.Add(Root)
    End Sub

    Private Sub AccordionControl1_ElementClick(sender As Object, e As ElementClickEventArgs) Handles AccordionControl1.ElementClick
        Dim Element = CType(e.Element, XmlAccordionElement)
        If e.MouseButton = MouseButtons.Right Then
            Dim Identifier = IdentifyElements(Element, e.MouseButton)
            Element.Elements.Clear()
            For Each Child As XmlNode In Element.Node.ChildNodes()
                If Not Child.Name = "#text" AndAlso Child.FirstChild IsNot Nothing AndAlso Not Child.FirstChild.Name = "#text" Then
                    Dim NextElement As New XmlAccordionElement()
                    NextElement.Node = Child
                    ' Identify from the choice from before
                    If Identifier.EndsWith(" (attribute)") Then
                        Dim AttributeContent = Child.Attributes.GetNamedItem(Identifier.Substring(0, Identifier.LastIndexOf(" (attribute)"))).InnerText
                        NextElement.Text = AttributeContent
                    ElseIf Identifier.EndsWith(" (tag)") Then
                        For Each PossibleIdenifiter As XmlNode In Child.ChildNodes()
                            If PossibleIdenifiter.Name = Identifier.Substring(0, Identifier.LastIndexOf(" (tag)")) Then
                                If PossibleIdenifiter.FirstChild IsNot Nothing Then
                                    Dim InnerText = PossibleIdenifiter.FirstChild.InnerText
                                    NextElement.Text = If(String.IsNullOrWhiteSpace(InnerText), "NULL", InnerText)
                                End If
                            End If
                        Next
                    Else
                        NextElement.Text = Child.Name
                    End If
                    Element.Elements.Add(NextElement)
                End If
            Next
            Element.Expanded = False
        End If
        ''' Add children nodes if they haven't already been added '''
        If Not Element.Expanded AndAlso Element.Elements.Count() = 0 Then
            If Element.Node.Attributes IsNot Nothing AndAlso Element.Node.Attributes.Count() > 0 Then
                For Each Attribute As XmlAttribute In Element.Node.Attributes()
                    Dim Contents As New Label()
                    Contents.Text = String.Format("{9}", Attribute.Name, Attribute.InnerText)
                    Me.FluentDesignFormContainer1.Controls.Clear()
                    Me.FluentDesignFormContainer1.Controls.Add(Contents)
                Next
            End If
            ''' Ask the user how to identify the children nodes (by attribute or by child inner text) '''
            ' If the level has been established, no need to repeat
            Dim Identifier As String = IdentifyElements(Element, MouseButtons.None)
            ''' Add children nodes and expand '''
            Me.FluentDesignFormContainer1.Controls.Clear()
            Dim Line As Integer = 0
            For Each Child As XmlNode In Element.Node.ChildNodes()
                ' Should only execute once per first expanse
                If Not Child.Name = "#text" AndAlso Child.FirstChild IsNot Nothing AndAlso Not Child.FirstChild.Name = "#text" Then
                    Dim NextElement As New XmlAccordionElement()
                    NextElement.Node = Child
                    ' Identify from the choice from before
                    If Identifier.EndsWith(" (attribute)") Then
                        Dim AttributeContent = Child.Attributes.GetNamedItem(Identifier.Substring(0, Identifier.LastIndexOf(" (attribute)"))).InnerText
                        NextElement.Text = AttributeContent
                    ElseIf Identifier.EndsWith(" (tag)") Then
                        For Each PossibleIdenifiter As XmlNode In Child.ChildNodes()
                            If PossibleIdenifiter.Name = Identifier.Substring(0, Identifier.LastIndexOf(" (tag)")) Then
                                If PossibleIdenifiter.FirstChild IsNot Nothing Then
                                    Dim InnerText = PossibleIdenifiter.FirstChild.InnerText
                                    NextElement.Text = If(String.IsNullOrWhiteSpace(InnerText), "NULL", InnerText)
                                End If
                            End If
                        Next
                    Else
                        NextElement.Text = Child.Name
                    End If
                    Element.Elements.Add(NextElement)
                Else
                    Dim Contents As New LabelControl()
                    Contents.Font = LabelFont
                    Contents.Location = New Point((Me.FluentDesignFormContainer1.Width - Contents.Width) / 2, Line)
                    If Child.FirstChild IsNot Nothing AndAlso Child.FirstChild.Name = "#text" Then
                        Contents.Text = Child.FirstChild.InnerText
                    Else
                        Contents.Text = Child.InnerText
                    End If
                    Me.FluentDesignFormContainer1.Controls.Add(Contents)
                    Line += 25
                End If
            Next
        ElseIf Not Element.Expanded Then
            Me.FluentDesignFormContainer1.Controls.Clear()
            Dim Line As Integer = 0
            For Each Child As XmlNode In Element.Node.ChildNodes()
                If Child.FirstChild IsNot Nothing AndAlso Child.FirstChild.Name = "#text" Then
                    Dim Contents As New LabelControl()
                    Contents.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Coffee)
                    Dim X = 0
                    Dim Y = Me.FluentDesignFormContainer1.Height / 2 + Line
                    Contents.Font = LabelFont
                    Contents.Location = New Point(X, Y)
                    Contents.Text = Child.FirstChild.InnerText
                    Me.FluentDesignFormContainer1.Controls.Add(Contents)
                    Line += 25
                End If
            Next
        Else
            Me.FluentDesignFormContainer1.Controls.Clear()
            Dim ParentNode = Element.Node.ParentNode
            Dim Line As Integer = 0
            If ParentNode IsNot Nothing AndAlso ParentNode.Attributes() IsNot Nothing Then
                For Each Attribute As XmlAttribute In ParentNode.Attributes()
                    Dim Contents As New LabelControl()
                    Contents.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Coffee)
                    Dim X = Me.FluentDesignFormContainer1.Width / 5
                    Dim Y = Me.FluentDesignFormContainer1.Height / 2 + Line
                    Contents.Font = LabelFont
                    Contents.Location = New Point(X, Y)
                    Contents.Text = Attribute.InnerText
                    Me.FluentDesignFormContainer1.Controls.Add(Contents)
                    Line += 25
                Next
                For Each Child As XmlNode In ParentNode.ChildNodes()
                    If Child.FirstChild IsNot Nothing AndAlso Child.FirstChild.Name = "#text" Then
                        Dim Contents As New LabelControl()
                        Contents.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Coffee)
                        Dim X = 0
                        Dim Y = Me.FluentDesignFormContainer1.Height / 2 + Line
                        Contents.Font = LabelFont
                        Contents.Location = New Point(X, Y)
                        Contents.Text = Child.FirstChild.InnerText
                        Me.FluentDesignFormContainer1.Controls.Add(Contents)
                        Line += 25
                    End If
                Next
            End If
        End If
    End Sub

    Private Function IdentifyElements(ByRef Element As XmlAccordionElement, MouseButton As MouseButtons) As String
        Dim Identifier As String
        If Element.Node.FirstChild IsNot Nothing Then
            If Not Identifiers.ContainsKey(Element.Node.FirstChild.Name) OrElse MouseButton = MouseButtons.Right Then
                Dim Prompt As New XtraForm1()
                ' Add attributes to options
                If Element.Node.FirstChild IsNot Nothing AndAlso Element.Node.FirstChild.Attributes() IsNot Nothing Then
                    For Each Attribute As XmlAttribute In Element.Node.FirstChild.Attributes()
                        Prompt.ComboBox1.Properties.Items.Add(Attribute.Name & " (attribute)")
                    Next
                End If
                ' Add child nodes to options only if the inner text does not contain more children
                For Each Child As XmlNode In Element.Node.FirstChild.ChildNodes()
                    If Child.FirstChild IsNot Nothing AndAlso Child.FirstChild.Name = "#text" Then
                        Prompt.ComboBox1.Properties.Items.Add(Child.Name & " (tag)")
                    End If
                Next
                If Prompt.ComboBox1.Properties.Items.Count() > 0 Then
                    Prompt.ComboBox1.Properties.Items.Add("None")
                    Prompt.ShowDialog()
                    Identifier = CType(Prompt.ComboBox1.SelectedItem, String)
                    If Identifiers.ContainsKey(Element.Node.FirstChild.Name) Then
                        Identifiers.Remove(Element.Node.FirstChild.Name)
                    End If
                    Identifiers.Add(Element.Node.FirstChild.Name, Identifier)
                Else
                    Identifier = ""
                End If
            Else
                Identifier = Identifiers.Item(Element.Node.FirstChild.Name)
            End If
        Else
            Identifier = ""
        End If
        Return Identifier
    End Function

    Private Sub FluentDesignFormContainer1_Click(sender As Object, e As EventArgs) Handles FluentDesignFormContainer1.SizeChanged
        For Each Item As Control In Me.FluentDesignFormContainer1.Controls
            Dim Y = Item.Location.Y - Me.FluentDesignFormContainer1.Height / 2
            Item.Location = New Point(0, Item.Location.Y)
        Next
    End Sub
End Class
