Public Class DialogAdventure
    Private Loot As List(Of LootItem)
    Private Results As List(Of String)

    Public Sub New(ByVal _results As List(Of String), ByVal _loot As List(Of LootItem))
        InitializeComponent()

        Results = _results
        Loot = _loot
    End Sub
    Private Sub DialogAdventure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each r In Results
            lblResults.Text &= r & vbCrLf
        Next
        For Each l In Loot
            lstLoot.Items.Add(l)
        Next
    End Sub

    Private Sub lstLoot_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLoot.SelectedIndexChanged
        Dim l As LootItem = lstLoot.SelectedItem
        If l Is Nothing Then Exit Sub

        lblLootDescription.Text = l.AttributesDescription
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class