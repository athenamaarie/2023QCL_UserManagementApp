<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        txtFullName = New TextBox()
        cmbUsername = New ComboBox()
        btnClickMe = New Button()
        Label1 = New Label()
        Label2 = New Label()
        PhoneNumberBox = New TextBox()
        PhoneTxT = New Label()
        EmailBox = New TextBox()
        Label4 = New Label()
        JobBox = New TextBox()
        Label5 = New Label()
        Label6 = New Label()
        managerBox = New Label()
        managerOfBox = New TextBox()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        Label8 = New Label()
        Label9 = New Label()
        lb1 = New ListBox()
        GroupBox1 = New GroupBox()
        cmbOwnerOf = New ComboBox()
        cmbMemberOf = New ComboBox()
        directReportsBox = New Label()
        cmbBuilding = New ComboBox()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtFullName
        ' 
        txtFullName.Anchor = AnchorStyles.Top
        txtFullName.Location = New Point(501, 81)
        txtFullName.MaxLength = 50
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(491, 27)
        txtFullName.TabIndex = 0
        ' 
        ' cmbUsername
        ' 
        cmbUsername.Anchor = AnchorStyles.Top
        cmbUsername.AutoCompleteMode = AutoCompleteMode.Append
        cmbUsername.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbUsername.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUsername.FormattingEnabled = True
        cmbUsername.Location = New Point(146, 50)
        cmbUsername.Name = "cmbUsername"
        cmbUsername.Size = New Size(265, 28)
        cmbUsername.TabIndex = 1
        ' 
        ' btnClickMe
        ' 
        btnClickMe.Anchor = AnchorStyles.Top
        btnClickMe.Location = New Point(998, 12)
        btnClickMe.Name = "btnClickMe"
        btnClickMe.Size = New Size(242, 76)
        btnClickMe.TabIndex = 2
        btnClickMe.Text = "Update"
        btnClickMe.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.AutoSize = True
        Label1.Location = New Point(62, 58)
        Label1.Name = "Label1"
        Label1.Size = New Size(78, 20)
        Label1.TabIndex = 3
        Label1.Text = "Username:"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top
        Label2.AutoSize = True
        Label2.Location = New Point(416, 88)
        Label2.Name = "Label2"
        Label2.Size = New Size(79, 20)
        Label2.TabIndex = 4
        Label2.Text = "Full Name:"
        ' 
        ' PhoneNumberBox
        ' 
        PhoneNumberBox.Anchor = AnchorStyles.Top
        PhoneNumberBox.Location = New Point(502, 123)
        PhoneNumberBox.MaxLength = 15
        PhoneNumberBox.Name = "PhoneNumberBox"
        PhoneNumberBox.Size = New Size(490, 27)
        PhoneNumberBox.TabIndex = 5
        ' 
        ' PhoneTxT
        ' 
        PhoneTxT.Anchor = AnchorStyles.Top
        PhoneTxT.AutoSize = True
        PhoneTxT.Location = New Point(384, 130)
        PhoneTxT.Name = "PhoneTxT"
        PhoneTxT.Size = New Size(111, 20)
        PhoneTxT.TabIndex = 6
        PhoneTxT.Text = "Phone Number:"
        ' 
        ' EmailBox
        ' 
        EmailBox.Anchor = AnchorStyles.Top
        EmailBox.Location = New Point(502, 170)
        EmailBox.MaxLength = 254
        EmailBox.Name = "EmailBox"
        EmailBox.Size = New Size(490, 27)
        EmailBox.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top
        Label4.AutoSize = True
        Label4.Location = New Point(446, 177)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 20)
        Label4.TabIndex = 8
        Label4.Text = "Email:"
        ' 
        ' JobBox
        ' 
        JobBox.Anchor = AnchorStyles.Top
        JobBox.Location = New Point(502, 217)
        JobBox.MaxLength = 200
        JobBox.Name = "JobBox"
        JobBox.Size = New Size(490, 27)
        JobBox.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top
        Label5.AutoSize = True
        Label5.Location = New Point(427, 224)
        Label5.Name = "Label5"
        Label5.Size = New Size(68, 20)
        Label5.TabIndex = 10
        Label5.Text = "Job Title:"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top
        Label6.AutoSize = True
        Label6.Location = New Point(428, 272)
        Label6.Name = "Label6"
        Label6.Size = New Size(67, 20)
        Label6.TabIndex = 12
        Label6.Text = "Building:"
        ' 
        ' managerBox
        ' 
        managerBox.AutoSize = True
        managerBox.Location = New Point(49, 66)
        managerBox.Name = "managerBox"
        managerBox.Size = New Size(71, 20)
        managerBox.TabIndex = 14
        managerBox.Text = "Manager:"
        ' 
        ' managerOfBox
        ' 
        managerOfBox.Location = New Point(123, 59)
        managerOfBox.Name = "managerOfBox"
        managerOfBox.ReadOnly = True
        managerOfBox.Size = New Size(491, 27)
        managerOfBox.TabIndex = 13
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(32, 33)
        Label8.Name = "Label8"
        Label8.Size = New Size(88, 20)
        Label8.TabIndex = 16
        Label8.Text = "Member Of:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(41, 121)
        Label9.Name = "Label9"
        Label9.Size = New Size(75, 20)
        Label9.TabIndex = 18
        Label9.Text = "Owner Of:"
        ' 
        ' lb1
        ' 
        lb1.FormattingEnabled = True
        lb1.ItemHeight = 20
        lb1.Location = New Point(123, 147)
        lb1.Name = "lb1"
        lb1.SelectionMode = SelectionMode.None
        lb1.Size = New Size(491, 184)
        lb1.Sorted = True
        lb1.TabIndex = 19
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Top
        GroupBox1.Controls.Add(cmbOwnerOf)
        GroupBox1.Controls.Add(cmbMemberOf)
        GroupBox1.Controls.Add(directReportsBox)
        GroupBox1.Controls.Add(lb1)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(managerOfBox)
        GroupBox1.Controls.Add(managerBox)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Location = New Point(378, 318)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(635, 349)
        GroupBox1.TabIndex = 20
        GroupBox1.TabStop = False
        GroupBox1.Text = "Work Group Info"
        ' 
        ' cmbOwnerOf
        ' 
        cmbOwnerOf.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOwnerOf.FormattingEnabled = True
        cmbOwnerOf.Location = New Point(122, 113)
        cmbOwnerOf.Name = "cmbOwnerOf"
        cmbOwnerOf.Size = New Size(492, 28)
        cmbOwnerOf.TabIndex = 21
        ' 
        ' cmbMemberOf
        ' 
        cmbMemberOf.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMemberOf.FormattingEnabled = True
        cmbMemberOf.Location = New Point(123, 26)
        cmbMemberOf.Name = "cmbMemberOf"
        cmbMemberOf.Size = New Size(491, 28)
        cmbMemberOf.TabIndex = 21
        ' 
        ' directReportsBox
        ' 
        directReportsBox.AutoSize = True
        directReportsBox.Location = New Point(9, 147)
        directReportsBox.Name = "directReportsBox"
        directReportsBox.Size = New Size(107, 20)
        directReportsBox.TabIndex = 20
        directReportsBox.Text = "Direct Reports:"
        ' 
        ' cmbBuilding
        ' 
        cmbBuilding.Anchor = AnchorStyles.Top
        cmbBuilding.DropDownStyle = ComboBoxStyle.DropDownList
        cmbBuilding.FormattingEnabled = True
        cmbBuilding.Location = New Point(501, 272)
        cmbBuilding.Name = "cmbBuilding"
        cmbBuilding.Size = New Size(491, 28)
        cmbBuilding.TabIndex = 21
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1404, 683)
        Controls.Add(cmbBuilding)
        Controls.Add(GroupBox1)
        Controls.Add(Label2)
        Controls.Add(txtFullName)
        Controls.Add(btnClickMe)
        Controls.Add(Label6)
        Controls.Add(Label1)
        Controls.Add(PhoneNumberBox)
        Controls.Add(cmbUsername)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(PhoneTxT)
        Controls.Add(EmailBox)
        Controls.Add(JobBox)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(1422, 730)
        Name = "Form1"
        Text = "User Management Tool"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtFullName As TextBox
    Friend WithEvents cmbUsername As ComboBox
    Friend WithEvents btnClickMe As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PhoneNumberBox As TextBox
    Friend WithEvents PhoneTxT As Label
    Friend WithEvents EmailBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents JobBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents managerBox As Label
    Friend WithEvents managerOfBox As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents directReportsBox As Label
    Friend WithEvents cmbMemberOf As ComboBox
    Friend WithEvents cmbOwnerOf As ComboBox
    Friend WithEvents lb1 As ListBox
    Friend WithEvents cmbBuilding As ComboBox
End Class
