Partial Public Class Form1
    Inherits DevExpress.XtraEditors.XtraForm

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.barManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.bar1 = New DevExpress.XtraBars.Bar()
        Me.bar2 = New DevExpress.XtraBars.Bar()
        Me.btnTestRecognize = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCameraTo90 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTestPhotoToBytes = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTestRecognizeFromImg = New DevExpress.XtraBars.BarButtonItem()
        Me.toggleStartCamera = New DevExpress.XtraBars.BarToggleSwitchItem()
        Me.btnMakeScreenshot = New DevExpress.XtraBars.BarButtonItem()
        Me.bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.CameraControl1 = New DevExpress.XtraEditors.Camera.CameraControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.barManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barManager1
        '
        Me.barManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.bar1, Me.bar2, Me.bar3})
        Me.barManager1.DockControls.Add(Me.barDockControlTop)
        Me.barManager1.DockControls.Add(Me.barDockControlBottom)
        Me.barManager1.DockControls.Add(Me.barDockControlLeft)
        Me.barManager1.DockControls.Add(Me.barDockControlRight)
        Me.barManager1.Form = Me
        Me.barManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnTestRecognize, Me.btnCameraTo90, Me.btnTestPhotoToBytes, Me.btnTestRecognizeFromImg, Me.toggleStartCamera, Me.btnMakeScreenshot})
        Me.barManager1.MainMenu = Me.bar2
        Me.barManager1.MaxItemId = 6
        Me.barManager1.StatusBar = Me.bar3
        '
        'bar1
        '
        Me.bar1.BarName = "Tools"
        Me.bar1.DockCol = 0
        Me.bar1.DockRow = 1
        Me.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.bar1.Text = "Tools"
        '
        'bar2
        '
        Me.bar2.BarName = "Main menu"
        Me.bar2.DockCol = 0
        Me.bar2.DockRow = 0
        Me.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnTestRecognize), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCameraTo90), New DevExpress.XtraBars.LinkPersistInfo(Me.btnTestPhotoToBytes), New DevExpress.XtraBars.LinkPersistInfo(Me.btnTestRecognizeFromImg), New DevExpress.XtraBars.LinkPersistInfo(Me.toggleStartCamera), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMakeScreenshot)})
        Me.bar2.OptionsBar.MultiLine = True
        Me.bar2.OptionsBar.UseWholeRow = True
        Me.bar2.Text = "Main menu"
        '
        'btnTestRecognize
        '
        Me.btnTestRecognize.Caption = "Распознать"
        Me.btnTestRecognize.Enabled = False
        Me.btnTestRecognize.Id = 0
        Me.btnTestRecognize.Name = "btnTestRecognize"
        '
        'btnCameraTo90
        '
        Me.btnCameraTo90.Caption = "Повернуть камеру"
        Me.btnCameraTo90.Id = 1
        Me.btnCameraTo90.Name = "btnCameraTo90"
        '
        'btnTestPhotoToBytes
        '
        Me.btnTestPhotoToBytes.Caption = "Фото в байты"
        Me.btnTestPhotoToBytes.Enabled = False
        Me.btnTestPhotoToBytes.Id = 2
        Me.btnTestPhotoToBytes.Name = "btnTestPhotoToBytes"
        '
        'btnTestRecognizeFromImg
        '
        Me.btnTestRecognizeFromImg.Caption = "Распознать с картинки"
        Me.btnTestRecognizeFromImg.Enabled = False
        Me.btnTestRecognizeFromImg.Id = 3
        Me.btnTestRecognizeFromImg.Name = "btnTestRecognizeFromImg"
        '
        'toggleStartCamera
        '
        Me.toggleStartCamera.Caption = "Захватывать изображение:"
        Me.toggleStartCamera.Id = 4
        Me.toggleStartCamera.Name = "toggleStartCamera"
        '
        'btnMakeScreenshot
        '
        Me.btnMakeScreenshot.Caption = "Скриншот"
        Me.btnMakeScreenshot.Id = 5
        Me.btnMakeScreenshot.Name = "btnMakeScreenshot"
        '
        'bar3
        '
        Me.bar3.BarName = "Status bar"
        Me.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.bar3.DockCol = 0
        Me.bar3.DockRow = 0
        Me.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.bar3.OptionsBar.AllowQuickCustomization = False
        Me.bar3.OptionsBar.DrawDragBorder = False
        Me.bar3.OptionsBar.UseWholeRow = True
        Me.bar3.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.barManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1116, 41)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 783)
        Me.barDockControlBottom.Manager = Me.barManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1116, 20)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 41)
        Me.barDockControlLeft.Manager = Me.barManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 742)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1116, 41)
        Me.barDockControlRight.Manager = Me.barManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 742)
        '
        'CameraControl1
        '
        Me.CameraControl1.Location = New System.Drawing.Point(4, 4)
        Me.CameraControl1.Name = "CameraControl1"
        Me.CameraControl1.Padding = New System.Windows.Forms.Padding(13)
        Me.CameraControl1.Size = New System.Drawing.Size(1084, 630)
        Me.CameraControl1.StyleController = Me.LayoutControl1
        Me.CameraControl1.TabIndex = 4
        Me.CameraControl1.Text = "CameraControl1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControl1.Controls.Add(Me.CameraControl1)
        Me.LayoutControl1.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1092, 638)
        Me.LayoutControl1.TabIndex = 14
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.Root.Size = New System.Drawing.Size(1092, 638)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CameraControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1088, 634)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.LayoutControl1)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 41)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(1116, 742)
        Me.LayoutControl2.TabIndex = 15
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1116, 742)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.LayoutControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1096, 642)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 642)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1096, 80)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1116, 803)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "Form1"
        Me.Text = "Тестирование работы с камерой"
        CType(Me.barManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents barManager1 As DevExpress.XtraBars.BarManager
    Private WithEvents bar1 As DevExpress.XtraBars.Bar
    Private WithEvents bar2 As DevExpress.XtraBars.Bar
    Private WithEvents bar3 As DevExpress.XtraBars.Bar
    Private WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Private WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Private WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Private WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents CameraControl1 As DevExpress.XtraEditors.Camera.CameraControl
    Friend WithEvents btnTestRecognize As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCameraTo90 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTestPhotoToBytes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTestRecognizeFromImg As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents toggleStartCamera As DevExpress.XtraBars.BarToggleSwitchItem
    Friend WithEvents btnMakeScreenshot As DevExpress.XtraBars.BarButtonItem
End Class
