Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form1
    'Our set variables
    Dim sqlConnectionStr As String = "Server=Asset3830;Database=lw7-prodcopy;User Id=sa;Password=LabWare123;TimeOut=1"
    Dim qryResults As New List(Of List(Of String))
    Dim qry As String
    Dim currUser As New User
    Dim workGroups As New Dictionary(Of Integer, String)
    Dim availWG As New Dictionary(Of Integer, String)


#Region "Main Functionality"
    Private Sub UpdateUser()
        'Query for the update button where we are using the class properties to update the
        'specific columns of the user with info that is entered manually
        qry = "UPDATE LIMS_USERS SET FULL_NAME='" & currUser.fullName & "', PHONE='" & currUser.phoneNum & "', EMAIL_ADDR= '" & currUser.email &
        "', t_job_title= '" & currUser.job & "', c_building= '" & currUser.building & "', c_lab_workgroup_owner= '" & currUser.wgpOwnerOfID & "', c_lab_workgroup_member= '" & currUser.wgpMemberOfID & "' WHERE USER_NAME ='" & cmbUsername.SelectedItem & "'"
        SQL_qry(qry)

        'Message box that asks for a confirmation from the user to update
        Dim answer As DialogResult
        answer = MessageBox.Show("Are you sure?", "Yes/no sample", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            MsgBox("Updated!")
        End If
    End Sub

    Private Sub ChangeUser()
        'Query to display the information from these columns of the user who is selected
        qry = "SELECT FULL_NAME, PHONE, EMAIL_ADDR, t_job_title, c_building, c_lab_workgroup_owner, c_lab_workgroup_member FROM LIMS_USERS WHERE USER_NAME = '" & cmbUsername.SelectedItem & "'"
        SQL_qry(qry)

        'Assigning the class properties with their specific column from the query
        currUser = New User
        With currUser
            .fullName = qryResults(0)(0)
            .phoneNum = qryResults(0)(1)
            .email = qryResults(0)(2)
            .job = qryResults(0)(3)
            .building = qryResults(0)(4)
            'If Else statements to allow for correct datatypes for the two dictionaries
            If qryResults(0)(5) = "" Then
                .wgpOwnerOfID = 0
            Else
                .wgpOwnerOfID = CInt(qryResults(0)(5))
            End If

            If qryResults(0)(6) = "" Then
                .wgpMemberOfID = 0
            Else
                .wgpMemberOfID = CInt(qryResults(0)(6))
            End If
            .username = cmbUsername.SelectedItem
        End With

        'Assigning the form property to the class property 
        txtFullName.Text = currUser.fullName
        PhoneNumberBox.Text = currUser.phoneNum
        EmailBox.Text = currUser.email
        JobBox.Text = currUser.job
        cmbBuilding.Text = currUser.building

        'MemberOf Query where the group ID is from LIMS_USERS and the description is concatenated from C_LAB_WORKGROUP_MEMBER
        qry = "SELECT WORKGROUP.NAME + ' - ' + WORKGROUP.DESCRIPTION  FROM LIMS_USERS USERS LEFT OUTER JOIN C_LAB_WORKGROUP WORKGROUP
		ON USERS.C_LAB_WORKGROUP_MEMBER = WORKGROUP.NAME WHERE USERS.USER_NAME = '" & currUser.username & "'"
        SQL_qry(qry)

        cmbMemberOf.Text = qryResults(0)(0)

        'Manager Query where the sub query is the group ID and the outside query is getting the "owner" of that group ID
        qry = "SELECT USER_NAME FROM LIMS_USERS WHERE C_LAB_WORKGROUP_OWNER = 
        (SELECT C_LAB_WORKGROUP_MEMBER FROM LIMS_USERS WHERE USER_NAME = '" & currUser.username & "')"
        SQL_qry(qry)

        'In case the data has not been updated for someone who left the company and so there are two managers present when we just need 1
        If qryResults.Count > 0 Then
            managerOfBox.Text = qryResults(0)(0)
        Else
            managerOfBox.Text = ""
        End If


        'Owner Of query that does a join with the two tables again and shows the name of each of the workgroup that the user owns
        qry = "SELECT WORKGROUP.NAME + ' - ' + WORKGROUP.DESCRIPTION  FROM LIMS_USERS USERS LEFT OUTER JOIN C_LAB_WORKGROUP WORKGROUP
		ON USERS.C_LAB_WORKGROUP_OWNER = WORKGROUP.NAME WHERE USERS.USER_NAME = '" & currUser.username & "'"
        SQL_qry(qry)
        'Will not be filled if the user is not an owner of a workgroup
        cmbOwnerOf.Text = qryResults(0)(0)

        'Direct Reports query that shows the members of the workgroup that the selected user owns 
        qry = "SELECT USER_NAME FROM ACTIVE_USERS WHERE C_LAB_WORKGROUP_MEMBER = 
		(SELECT C_LAB_WORKGROUP_OWNER FROM ACTIVE_USERS WHERE USER_NAME = '" & currUser.username & "')"
        SQL_qry(qry)
        'Need to clear the box each time for when we click on another person
        lb1.Items.Clear()
        'For loop to add each name to the box
        For i = 0 To qryResults.Count - 1
            lb1.Items.Add(qryResults(i)(0))
        Next
    End Sub


    Private Sub InitializeForm()
        'Query to select all usernames from the table
        qry = "SELECT USER_NAME FROM LIMS_USERS"
        SQL_qry(qry)
        'For loop to add each username to the combo box individually
        For i = 0 To qryResults.Count - 1
            cmbUsername.Items.Add(qryResults(i)(0))
        Next

        'Query to select all buildings from the table 
        qry = "SELECT NAME FROM STORAGE_LOCATION WHERE TEMPLATE = 'BUILDING'"
        SQL_qry(qry)
        'For loop to add each building to the combo box individually
        For i = 0 To qryResults.Count - 1
            cmbBuilding.Items.Add(qryResults(i)(0))
        Next

        'Member Of query that has two columns, one with the different owner/manager position IDs and the other with the concatenations. The union is so the field will be cleared
        'whenever we are first choosing from the Member Of field
        qry = "SELECT 0, '' FROM C_LAB_WORKGROUP UNION
                (SELECT 
	                 WORKGROUP.NAME, WORKGROUP.NAME + ' - ' + WORKGROUP.DESCRIPTION
                From ACTIVE_USERS USERS 
	                Left OUTER JOIN C_LAB_WORKGROUP WORKGROUP
                        On USERS.C_LAB_WORKGROUP_OWNER = WORKGROUP.NAME 
                WHERE USERS.C_LAB_WORKGROUP_OWNER Is Not NULL AND WORKGROUP.NAME IS NOT NULL And USERS.C_LAB_WORKGROUP_OWNER <> 800)"
        SQL_qry(qry)
        'Adds the query results to the workGroups dictionary
        For i = 0 To qryResults.Count - 1
            workGroups.Add(qryResults(i)(0), qryResults(i)(1))
        Next
        'Confirms which item in the dictionary is going to be displayed in the drop down
        cmbMemberOf.DisplayMember = "Value"
        cmbMemberOf.ValueMember = "Key"
        cmbMemberOf.DataSource = New BindingSource(workGroups, Nothing)

        'Same exact idea as the Member Of query, but this time with the different workgroup IDs. 
        qry = "SELECT 0, '' FROM C_LAB_WORKGROUP CLWG UNION 
                    (SELECT 
	                    CLWG.NAME, CLWG.NAME + ' - ' + CLWG.DESCRIPTION
                    FROM	
	                    C_LAB_WORKGROUP CLWG
		                    LEFT OUTER JOIN ACTIVE_USERS LU
			                    ON LU.C_LAB_WORKGROUP_OWNER = CLWG.NAME
                    WHERE 
	                    LU.C_LAB_WORKGROUP_OWNER IS NULL AND NAME <> 800)"
        SQL_qry(qry)
        'Adds the query results to the availWG dictionary
        For i = 0 To qryResults.Count - 1
            availWG.Add(qryResults(i)(0), qryResults(i)(1))
        Next
        'Confirms which item in the dictionary is going to be displayed in the drop down
        cmbOwnerOf.DisplayMember = "Value"
        cmbOwnerOf.ValueMember = "Key"
        cmbOwnerOf.DataSource = New BindingSource(availWG, Nothing)
    End Sub
#End Region

#Region "Helper Functions"
    'Function to execute the SQL command we need
    Private Sub SQL_execute(QRY As String)

        'The Using keyword handles correctly opening the sql connection and closing it when we're done with it
        Using SQL As New SqlConnection(sqlConnectionStr)
            Using CMD As New SqlCommand()
                'The Try/Catch statement handles if an error is encountered so the application doesn't crash
                Try
                    'Set properties of the SQLCommand
                    With CMD
                        .Connection = SQL
                        .CommandType = CommandType.Text
                        .CommandText = QRY
                    End With

                    'Open the SQL connection and execute the command
                    SQL.Open()
                    CMD.ExecuteNonQuery()
                Catch ex As Exception
                    'If error encountered, show exception message and qry
                    MsgBox(ex.Message & Chr(10) & Chr(10) & QRY)
                End Try
            End Using
        End Using
    End Sub

    'Function to execute SQL query and fill qryResults global variable with the return
    Private Sub SQL_qry(QRY As String)

        'The Using keyword handles correctly opening the sql connection and closing it when we're done with it
        Using SQL As New SqlConnection(sqlConnectionStr)
            Using ADP As New SqlDataAdapter()

                'Creating and emptying a DataTable where the SQL query results will be stored
                Dim TBL As DataTable = New DataTable
                TBL.Clear()
                TBL.Columns.Clear()

                'Open SQL connection
                ADP.SelectCommand = New SqlCommand(QRY, SQL)
                SQL.Open()

                'The Try/Catch statement handles if an error is encountered so the application doesn't crash
                Try
                    'Fill DataTable with query results
                    ADP.Fill(TBL)
                Catch ex As Exception
                    'If error encountered, show exception message and qry
                    MsgBox(ex.Message & Chr(10) & Chr(10) & QRY)
                End Try

                'Put query results into qryResults global variable
                build_2D_List(TBL, qryResults)
            End Using
        End Using
    End Sub

    'Take in a DataTable object and fill a 2D List with the results
    Private Function build_2D_List(dataTbl As DataTable, list_2D As List(Of List(Of String)))

        Dim rowList As New List(Of String)

        'Makes sure passed in 2D list is empty
        For i = 0 To list_2D.Count - 1
            list_2D.RemoveAt(0)
        Next

        'Initialize row list and makes sure it has the correct number of fields/columns to match our data table
        While rowList.Count > dataTbl.Columns.Count
            rowList.RemoveAt(rowList.Count - 1)
        End While

        While rowList.Count < dataTbl.Columns.Count
            rowList.Add("")
        End While

        'For each row: 
        For i = 0 To dataTbl.Rows.Count - 1
            'For each column:
            For j = 0 To dataTbl.Columns.Count - 1
                'Add value of column to rowList
                rowList(j) = dataTbl.Rows(i).Item(j).ToString
            Next
            'Add rowList to table list (list_2D)
            list_2D.Add(New List(Of String)(rowList))
        Next

        Return list_2D
    End Function
#End Region

#Region "Form Functions"

    ' ======================================================================
    ' Form Load
    ' ======================================================================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
    End Sub



    ' ======================================================================
    ' User Interaction
    ' ======================================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClickMe.Click
        UpdateUser()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsername.SelectedIndexChanged
        ChangeUser()
    End Sub



    ' ======================================================================
    ' Setting class prperties to values in form objects, as they get updated
    ' ======================================================================

    Private Sub txtFullName_TextChanged(sender As Object, e As EventArgs) Handles txtFullName.TextChanged
        currUser.fullName = txtFullName.Text
    End Sub

    Private Sub PhoneNumberBox_TextChanged(sender As Object, e As EventArgs) Handles PhoneNumberBox.TextChanged
        currUser.phoneNum = PhoneNumberBox.Text
    End Sub

    Private Sub EmailBox_TextChanged(sender As Object, e As EventArgs) Handles EmailBox.TextChanged
        currUser.email = EmailBox.Text
    End Sub

    Private Sub JobBox_TextChanged(sender As Object, e As EventArgs) Handles JobBox.TextChanged
        currUser.job = JobBox.Text
    End Sub

    Private Sub cmbMemberOf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMemberOf.SelectedIndexChanged
        currUser.wgpMemberOfID = cmbMemberOf.SelectedValue

    End Sub

    Private Sub cmbOwnerOf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOwnerOf.SelectedIndexChanged
        currUser.wgpOwnerOfID = cmbOwnerOf.SelectedValue
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbBuilding.SelectedIndexChanged
        currUser.building = cmbBuilding.SelectedItem
    End Sub

#End Region

End Class