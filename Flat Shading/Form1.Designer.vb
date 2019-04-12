<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.drawBtn = New System.Windows.Forms.Button()
        Me.TranslateRadio = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RotateRadio = New System.Windows.Forms.RadioButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.zSource2 = New System.Windows.Forms.TextBox()
        Me.ySource2 = New System.Windows.Forms.TextBox()
        Me.xSource2 = New System.Windows.Forms.TextBox()
        Me.greenClr = New System.Windows.Forms.RadioButton()
        Me.blueClr = New System.Windows.Forms.RadioButton()
        Me.allClr = New System.Windows.Forms.RadioButton()
        Me.redClr = New System.Windows.Forms.RadioButton()
        Me.zSource = New System.Windows.Forms.TextBox()
        Me.ySource = New System.Windows.Forms.TextBox()
        Me.xSource = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.configureBtn = New System.Windows.Forms.Button()
        Me.diffuseBox = New System.Windows.Forms.TextBox()
        Me.ambientBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(39, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(500, 400)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'drawBtn
        '
        Me.drawBtn.Location = New System.Drawing.Point(559, 219)
        Me.drawBtn.Name = "drawBtn"
        Me.drawBtn.Size = New System.Drawing.Size(75, 23)
        Me.drawBtn.TabIndex = 19
        Me.drawBtn.Text = "Draw"
        Me.drawBtn.UseVisualStyleBackColor = True
        '
        'TranslateRadio
        '
        Me.TranslateRadio.AutoSize = True
        Me.TranslateRadio.Checked = True
        Me.TranslateRadio.Location = New System.Drawing.Point(9, 19)
        Me.TranslateRadio.Name = "TranslateRadio"
        Me.TranslateRadio.Size = New System.Drawing.Size(69, 17)
        Me.TranslateRadio.TabIndex = 20
        Me.TranslateRadio.TabStop = True
        Me.TranslateRadio.Text = "Translate"
        Me.TranslateRadio.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.RotateRadio)
        Me.GroupBox3.Controls.Add(Me.TranslateRadio)
        Me.GroupBox3.Location = New System.Drawing.Point(559, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 183)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Command"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(188, 132)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controls"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(120, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Z = Z+ Axis"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(120, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "E = Z- Axis"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "D = X+ Axis"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "A = X- Axis"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "S = Y- Axis"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "W = Y+ Axis"
        '
        'RotateRadio
        '
        Me.RotateRadio.AutoSize = True
        Me.RotateRadio.Location = New System.Drawing.Point(137, 19)
        Me.RotateRadio.Name = "RotateRadio"
        Me.RotateRadio.Size = New System.Drawing.Size(57, 17)
        Me.RotateRadio.TabIndex = 21
        Me.RotateRadio.TabStop = True
        Me.RotateRadio.Text = "Rotate"
        Me.RotateRadio.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.zSource2)
        Me.GroupBox1.Controls.Add(Me.ySource2)
        Me.GroupBox1.Controls.Add(Me.xSource2)
        Me.GroupBox1.Controls.Add(Me.greenClr)
        Me.GroupBox1.Controls.Add(Me.blueClr)
        Me.GroupBox1.Controls.Add(Me.allClr)
        Me.GroupBox1.Controls.Add(Me.redClr)
        Me.GroupBox1.Controls.Add(Me.zSource)
        Me.GroupBox1.Controls.Add(Me.ySource)
        Me.GroupBox1.Controls.Add(Me.xSource)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.configureBtn)
        Me.GroupBox1.Controls.Add(Me.diffuseBox)
        Me.GroupBox1.Controls.Add(Me.ambientBox)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(559, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 183)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuration"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(34, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 13)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "*Light source 2 can be left blank"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Light Source 2:"
        '
        'zSource2
        '
        Me.zSource2.Location = New System.Drawing.Point(160, 101)
        Me.zSource2.Name = "zSource2"
        Me.zSource2.Size = New System.Drawing.Size(34, 20)
        Me.zSource2.TabIndex = 38
        '
        'ySource2
        '
        Me.ySource2.Location = New System.Drawing.Point(122, 101)
        Me.ySource2.Name = "ySource2"
        Me.ySource2.Size = New System.Drawing.Size(34, 20)
        Me.ySource2.TabIndex = 37
        '
        'xSource2
        '
        Me.xSource2.Location = New System.Drawing.Point(82, 101)
        Me.xSource2.Name = "xSource2"
        Me.xSource2.Size = New System.Drawing.Size(34, 20)
        Me.xSource2.TabIndex = 36
        '
        'greenClr
        '
        Me.greenClr.AutoSize = True
        Me.greenClr.Location = New System.Drawing.Point(57, 151)
        Me.greenClr.Name = "greenClr"
        Me.greenClr.Size = New System.Drawing.Size(54, 17)
        Me.greenClr.TabIndex = 35
        Me.greenClr.TabStop = True
        Me.greenClr.Text = "Green"
        Me.greenClr.UseVisualStyleBackColor = True
        '
        'blueClr
        '
        Me.blueClr.AutoSize = True
        Me.blueClr.Location = New System.Drawing.Point(110, 151)
        Me.blueClr.Name = "blueClr"
        Me.blueClr.Size = New System.Drawing.Size(46, 17)
        Me.blueClr.TabIndex = 34
        Me.blueClr.TabStop = True
        Me.blueClr.Text = "Blue"
        Me.blueClr.UseVisualStyleBackColor = True
        '
        'allClr
        '
        Me.allClr.AutoSize = True
        Me.allClr.Checked = True
        Me.allClr.Location = New System.Drawing.Point(158, 151)
        Me.allClr.Name = "allClr"
        Me.allClr.Size = New System.Drawing.Size(36, 17)
        Me.allClr.TabIndex = 33
        Me.allClr.TabStop = True
        Me.allClr.Text = "All"
        Me.allClr.UseVisualStyleBackColor = True
        '
        'redClr
        '
        Me.redClr.AutoSize = True
        Me.redClr.Location = New System.Drawing.Point(6, 151)
        Me.redClr.Name = "redClr"
        Me.redClr.Size = New System.Drawing.Size(45, 17)
        Me.redClr.TabIndex = 32
        Me.redClr.TabStop = True
        Me.redClr.Text = "Red"
        Me.redClr.UseVisualStyleBackColor = True
        '
        'zSource
        '
        Me.zSource.Location = New System.Drawing.Point(160, 75)
        Me.zSource.Name = "zSource"
        Me.zSource.Size = New System.Drawing.Size(34, 20)
        Me.zSource.TabIndex = 31
        Me.zSource.Text = "10"
        '
        'ySource
        '
        Me.ySource.Location = New System.Drawing.Point(122, 75)
        Me.ySource.Name = "ySource"
        Me.ySource.Size = New System.Drawing.Size(34, 20)
        Me.ySource.TabIndex = 30
        Me.ySource.Text = "10"
        '
        'xSource
        '
        Me.xSource.Location = New System.Drawing.Point(82, 75)
        Me.xSource.Name = "xSource"
        Me.xSource.Size = New System.Drawing.Size(34, 20)
        Me.xSource.TabIndex = 29
        Me.xSource.Text = "-10"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Light Source 1:"
        '
        'configureBtn
        '
        Me.configureBtn.Location = New System.Drawing.Point(109, 13)
        Me.configureBtn.Name = "configureBtn"
        Me.configureBtn.Size = New System.Drawing.Size(75, 46)
        Me.configureBtn.TabIndex = 27
        Me.configureBtn.Text = "Configure"
        Me.configureBtn.UseVisualStyleBackColor = True
        '
        'diffuseBox
        '
        Me.diffuseBox.Location = New System.Drawing.Point(52, 39)
        Me.diffuseBox.Name = "diffuseBox"
        Me.diffuseBox.Size = New System.Drawing.Size(34, 20)
        Me.diffuseBox.TabIndex = 26
        Me.diffuseBox.Text = "0.7"
        '
        'ambientBox
        '
        Me.ambientBox.Location = New System.Drawing.Point(52, 13)
        Me.ambientBox.Name = "ambientBox"
        Me.ambientBox.Size = New System.Drawing.Size(34, 20)
        Me.ambientBox.TabIndex = 24
        Me.ambientBox.Text = "0.2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Diffuse:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Ambient:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.drawBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents drawBtn As Button
    Friend WithEvents TranslateRadio As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RotateRadio As RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents diffuseBox As System.Windows.Forms.TextBox
    Friend WithEvents ambientBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents zSource As System.Windows.Forms.TextBox
    Friend WithEvents ySource As System.Windows.Forms.TextBox
    Friend WithEvents xSource As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents configureBtn As System.Windows.Forms.Button
    Friend WithEvents greenClr As System.Windows.Forms.RadioButton
    Friend WithEvents blueClr As System.Windows.Forms.RadioButton
    Friend WithEvents allClr As System.Windows.Forms.RadioButton
    Friend WithEvents redClr As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents zSource2 As TextBox
    Friend WithEvents ySource2 As TextBox
    Friend WithEvents xSource2 As TextBox
    Friend WithEvents Label10 As Label
End Class
