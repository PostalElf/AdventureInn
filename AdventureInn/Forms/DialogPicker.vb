Public Class DialogPicker
    Inherits Form
    Public Result As Object
    Public MainList

    Private Sub DialogPicker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each i In MainList
            cmbSelect.Items.Add(i)
        Next
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If cmbSelect.SelectedIndex = -1 Then Exit Sub

        Result = cmbSelect.SelectedItem
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class