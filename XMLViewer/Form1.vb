Imports System.IO
Imports System.Xml
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraPrinting.Native.Extensions
Imports DevExpress.XtraSplashScreen

Public Class Form1

    Private XmlDoc As New XmlDocument
    Private XmlTreePath As New List(Of String)
    Private CurrentNode As XmlNode

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        Me.AccordionControl1.Elements.Add(Root)
        SplashScreenManager.ShowForm(GetType(SplashScreen1))
        Await SearchXmlTree(Root.Node, Root)
        SplashScreenManager.CloseForm()
    End Sub

    Private Async Function SearchXmlTree(Node As XmlNode, Element As XmlAccordionElement) As Task
        For Each Child As XmlNode In Node.ChildNodes()
            Dim NextElement As New XmlAccordionElement()
            NextElement.Node = Child
            NextElement.Text = Child.Name
            Element.Elements.Add(NextElement)
            Await SearchXmlTree(NextElement.Node, NextElement)
        Next
    End Function

End Class
