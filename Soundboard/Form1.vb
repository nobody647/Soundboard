Imports WMPLib

Public Class Form1
    Private Sub startup() Handles MyBase.Load
        OpenFolderToolStripMenuItem_Click()

        RefreshList()
    End Sub

    Private Sub Chooser_SelectedValueChanged(sender As Object, e As EventArgs) Handles Chooser.SelectedValueChanged
        AxWindowsMediaPlayer1.URL = My.Settings.SoundFolder + Chooser.SelectedItem
    End Sub
    Private Sub RefreshList()
        Chooser.Items.Clear()
        Dim soundFiles = My.Computer.FileSystem.GetFiles(My.Settings.SoundFolder.ToString, FileIO.SearchOption.SearchTopLevelOnly)

        For Each soundFile As String In soundFiles
            Dim parts As Array = soundFile.Split("\")
            Dim length As Integer = parts.Length
            soundFile = parts.GetValue(parts.Length - 1)

            Chooser.Items.Add(soundFile)
        Next
    End Sub

    Private Sub OpenFolderToolStripMenuItem_Click() Handles OpenFolderToolStripMenuItem.Click
        FolderBrowserDialog1.ShowDialog()
        My.Settings.SoundFolder = FolderBrowserDialog1.SelectedPath + "\"
        RefreshList()
    End Sub

End Class
