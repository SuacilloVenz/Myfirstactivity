Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 🔹 Populate ComboBox with courses
        ComboBox1.Items.AddRange({"BSIT", "BSHRM", "BSA", "BEED", "BSED", "BSBA", "BSMT", "BSCE"})

        ' 🔹 Set default labels
        Label1.Text = "Course: "
        Label2.Text = "Hobbies: "
        Label3.Text = "Gender: "

        ' 🔹 Setup DataGridView columns (only once)
        With DataGridView1
            .Columns.Clear()
            .Columns.Add("colCourse", "COURSE")
            .Columns.Add("colHobbies", "HOBBIES")
            .Columns.Add("colGender", "GENDER")
            .AllowUserToAddRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 🔹 Get selected course
        Dim selectedCourse As String = If(ComboBox1.SelectedIndex <> -1, ComboBox1.SelectedItem.ToString(), "No course selected")

        ' 🔹 Get selected hobbies
        Dim hobbies As New List(Of String)
        If CheckBox1.Checked Then hobbies.Add(CheckBox1.Text)
        If CheckBox2.Checked Then hobbies.Add(CheckBox2.Text)
        If CheckBox3.Checked Then hobbies.Add(CheckBox3.Text)
        Dim selectedHobbies As String = If(hobbies.Count > 0, String.Join(", ", hobbies), "No hobbies selected")

        ' 🔹 Get selected gender
        Dim selectedGender As String
        If RadioButton1.Checked Then
            selectedGender = RadioButton1.Text
        ElseIf RadioButton2.Checked Then
            selectedGender = RadioButton2.Text
        Else
            selectedGender = "No gender selected"
        End If

        ' 🔹 Display results in Labels
        Label1.Text = "Course: " & selectedCourse
        Label2.Text = "Hobbies: " & selectedHobbies
        Label3.Text = "Gender: " & selectedGender

        ' 🔹 Insert results into DataGridView
        DataGridView1.Rows.Add(selectedCourse, selectedHobbies, selectedGender)
    End Sub

    Private Sub DELETE_Click(sender As Object, e As EventArgs) Handles DELETE.Click
        ' 🔹 Delete selected row
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.Rows.RemoveAt(DataGridView1.SelectedRows(0).Index)
        Else
            MessageBox.Show("Please select a row to delete.", "Delete Row", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
