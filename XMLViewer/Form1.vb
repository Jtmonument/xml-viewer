Imports System.IO
Imports System.Xml
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting.Native.Extensions
Imports DevExpress.XtraSplashScreen

Public Class Form1

    Private XmlDoc As New XmlDocument
    Private Identifiers As New Hashtable

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

        ''' Add children nodes if they haven't already been added '''
        If Not Element.Expanded AndAlso Element.Elements.Count() = 0 Then
            If Element.Node.Attributes IsNot Nothing AndAlso Element.Node.Attributes.Count() > 0 Then
                For Each Attribute As XmlAttribute In Element.Node.Attributes()
                    Dim Contents As New Label()
                    Contents.Text = Attribute.InnerText
                    Me.FluentDesignFormContainer1.Controls.Clear()
                    Me.FluentDesignFormContainer1.Controls.Add(Contents)
                Next
            End If
            ''' Ask the user how to identify the children nodes (by attribute or by child inner text) '''
            ' If the level has been established, no need to repeat
            Dim Identifier As String
            If Element.Node.FirstChild IsNot Nothing Then
                If Not Identifiers.ContainsKey(Element.Node.FirstChild.Name) Then
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
            ''' Add children nodes and expand '''
            For Each Child As XmlNode In Element.Node.ChildNodes()
                If Not Child.Name = "#text" Then ' Should only execute once per first expanse
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
                    Dim Contents As New Label()
                    Contents.Text = Child.InnerText
                    Me.FluentDesignFormContainer1.Controls.Clear()
                    Me.FluentDesignFormContainer1.Controls.Add(Contents)
                End If
            Next
        Else
            Me.FluentDesignFormContainer1.Controls.Clear()
            If Element.Node.ParentNode IsNot Nothing AndAlso Element.Node.ParentNode.Attributes() IsNot Nothing Then
                If Element.Node.ParentNode.Attributes.Count() > 0 Then
                    For Each Attribute As XmlAttribute In Element.Node.ParentNode.Attributes()
                        Dim Contents As New Label()
                        Contents.Text = Attribute.InnerText
                        Me.FluentDesignFormContainer1.Controls.Add(Contents)
                    Next
                End If
            End If
        End If
    End Sub
End Class
