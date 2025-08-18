VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "tabctl32.ocx"
Begin VB.Form DPOPOSDemo 
   Caption         =   "U.are.U SDK Sample Application for OPOS"
   ClientHeight    =   8025
   ClientLeft      =   60
   ClientTop       =   570
   ClientWidth     =   11775
   LinkTopic       =   "Form1"
   ScaleHeight     =   8025
   ScaleWidth      =   11775
   StartUpPosition =   2  'CenterScreen
   Begin VB.PictureBox Picture1 
      Height          =   1095
      Left            =   10440
      ScaleHeight     =   1035
      ScaleWidth      =   1155
      TabIndex        =   158
      Top             =   6840
      Width           =   1215
   End
   Begin VB.TextBox txtstatus 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   1560
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   155
      Text            =   "DPOPOSDemo.frx":0000
      Top             =   1080
      Visible         =   0   'False
      Width           =   10215
   End
   Begin TabDlg.SSTab SSTabSpecificProperties 
      Height          =   4935
      Left            =   1560
      TabIndex        =   10
      Top             =   1800
      Width           =   10125
      _ExtentX        =   17859
      _ExtentY        =   8705
      _Version        =   393216
      Tabs            =   2
      TabHeight       =   520
      Enabled         =   0   'False
      TabCaption(0)   =   "Common Properties"
      TabPicture(0)   =   "DPOPOSDemo.frx":0006
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "Label15"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Label14"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "Label5"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "Label3"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "Label7"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "Label6"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "Label1"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "Label8"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "Label9"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "Label2"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "Label18"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).Control(11)=   "Label19"
      Tab(0).Control(11).Enabled=   0   'False
      Tab(0).Control(12)=   "Label20"
      Tab(0).Control(12).Enabled=   0   'False
      Tab(0).Control(13)=   "Label21"
      Tab(0).Control(13).Enabled=   0   'False
      Tab(0).Control(14)=   "Label16"
      Tab(0).Control(14).Enabled=   0   'False
      Tab(0).Control(15)=   "Label11"
      Tab(0).Control(15).Enabled=   0   'False
      Tab(0).Control(16)=   "Label12"
      Tab(0).Control(16).Enabled=   0   'False
      Tab(0).Control(17)=   "Label13"
      Tab(0).Control(17).Enabled=   0   'False
      Tab(0).Control(18)=   "Label17"
      Tab(0).Control(18).Enabled=   0   'False
      Tab(0).Control(19)=   "Label39"
      Tab(0).Control(19).Enabled=   0   'False
      Tab(0).Control(20)=   "Frame9"
      Tab(0).Control(20).Enabled=   0   'False
      Tab(0).Control(21)=   "Frame8"
      Tab(0).Control(21).Enabled=   0   'False
      Tab(0).Control(22)=   "Frame6"
      Tab(0).Control(22).Enabled=   0   'False
      Tab(0).Control(23)=   "Frame5"
      Tab(0).Control(23).Enabled=   0   'False
      Tab(0).Control(24)=   "Frame7"
      Tab(0).Control(24).Enabled=   0   'False
      Tab(0).Control(25)=   "Frame4"
      Tab(0).Control(25).Enabled=   0   'False
      Tab(0).Control(26)=   "Frame3"
      Tab(0).Control(26).Enabled=   0   'False
      Tab(0).Control(27)=   "txtCheckHealthText"
      Tab(0).Control(27).Enabled=   0   'False
      Tab(0).Control(28)=   "txtDeviceControlVersion"
      Tab(0).Control(28).Enabled=   0   'False
      Tab(0).Control(29)=   "txtDeviceServiceDescription"
      Tab(0).Control(29).Enabled=   0   'False
      Tab(0).Control(30)=   "Frame11"
      Tab(0).Control(30).Enabled=   0   'False
      Tab(0).Control(31)=   "txtDeviceServiceVersion"
      Tab(0).Control(31).Enabled=   0   'False
      Tab(0).Control(32)=   "txtPhysicalDeviceDescription"
      Tab(0).Control(32).Enabled=   0   'False
      Tab(0).Control(33)=   "txtPhysicalDeviceName"
      Tab(0).Control(33).Enabled=   0   'False
      Tab(0).Control(34)=   "Frame10"
      Tab(0).Control(34).Enabled=   0   'False
      Tab(0).Control(35)=   "Frame14"
      Tab(0).Control(35).Enabled=   0   'False
      Tab(0).Control(36)=   "Frame13"
      Tab(0).Control(36).Enabled=   0   'False
      Tab(0).Control(37)=   "Frame12"
      Tab(0).Control(37).Enabled=   0   'False
      Tab(0).Control(38)=   "txtDeviceControlDescription"
      Tab(0).Control(38).Enabled=   0   'False
      Tab(0).Control(39)=   "Frame1"
      Tab(0).Control(39).Enabled=   0   'False
      Tab(0).ControlCount=   40
      TabCaption(1)   =   "Specific Properties"
      TabPicture(1)   =   "DPOPOSDemo.frx":0022
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "Label4"
      Tab(1).Control(1)=   "Label22"
      Tab(1).Control(2)=   "Label23"
      Tab(1).Control(3)=   "Label24"
      Tab(1).Control(4)=   "Label25"
      Tab(1).Control(5)=   "Label26"
      Tab(1).Control(6)=   "Label27"
      Tab(1).Control(7)=   "Label28"
      Tab(1).Control(8)=   "Label29"
      Tab(1).Control(9)=   "Label30"
      Tab(1).Control(10)=   "Label31"
      Tab(1).Control(11)=   "Label32"
      Tab(1).Control(12)=   "Label33"
      Tab(1).Control(13)=   "Label34"
      Tab(1).Control(14)=   "Label35"
      Tab(1).Control(15)=   "Label36"
      Tab(1).Control(16)=   "Label37"
      Tab(1).Control(17)=   "Label38"
      Tab(1).Control(18)=   "Label10"
      Tab(1).Control(19)=   "txtAlgorithm"
      Tab(1).Control(20)=   "txtAlgorithmList"
      Tab(1).Control(21)=   "txtBir"
      Tab(1).Control(22)=   "Frame15"
      Tab(1).Control(23)=   "Frame16"
      Tab(1).Control(24)=   "Frame17"
      Tab(1).Control(25)=   "Frame18"
      Tab(1).Control(26)=   "Frame19"
      Tab(1).Control(27)=   "comboCapSensorType"
      Tab(1).Control(28)=   "Frame20"
      Tab(1).Control(29)=   "txtRawSensorData"
      Tab(1).Control(30)=   "Frame21"
      Tab(1).Control(31)=   "txtSensorBpp"
      Tab(1).Control(32)=   "Frame22"
      Tab(1).Control(33)=   "txtSensorHeight"
      Tab(1).Control(34)=   "Frame23"
      Tab(1).Control(35)=   "comboSensorType"
      Tab(1).Control(36)=   "txtSensorWidth"
      Tab(1).Control(37)=   "txtSensorWidth1"
      Tab(1).ControlCount=   38
      Begin VB.TextBox txtSensorWidth1 
         Enabled         =   0   'False
         Height          =   285
         Left            =   -67320
         TabIndex        =   157
         Top             =   1080
         Width           =   1639
      End
      Begin VB.Frame Frame1 
         Height          =   495
         Left            =   1200
         TabIndex        =   144
         Top             =   3720
         Width           =   5055
         Begin VB.OptionButton rdoCapPowerReportingPR_ADVANCED 
            Caption         =   "PR_ADVANCED"
            Enabled         =   0   'False
            Height          =   195
            Left            =   3120
            TabIndex        =   147
            Top             =   240
            Width           =   1575
         End
         Begin VB.OptionButton rdoCapPowerReportingPR_NONE 
            Caption         =   "PR_NONE"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   146
            Top             =   240
            Value           =   -1  'True
            Width           =   1335
         End
         Begin VB.OptionButton rdoCapPowerReportingPR_STANDARD 
            Caption         =   "PR_STANDARD"
            Enabled         =   0   'False
            Height          =   195
            Left            =   1440
            TabIndex        =   145
            Top             =   240
            Width           =   1815
         End
      End
      Begin VB.TextBox txtSensorWidth 
         Enabled         =   0   'False
         Height          =   375
         Left            =   -66750
         Locked          =   -1  'True
         TabIndex        =   91
         Top             =   5880
         Width           =   1815
      End
      Begin VB.ComboBox comboSensorType 
         Enabled         =   0   'False
         Height          =   315
         ItemData        =   "DPOPOSDemo.frx":003E
         Left            =   -67230
         List            =   "DPOPOSDemo.frx":0069
         TabIndex        =   90
         Text            =   "Iris"
         Top             =   4320
         Width           =   1215
      End
      Begin VB.Frame Frame23 
         Height          =   615
         Left            =   -67320
         TabIndex        =   142
         Top             =   3360
         Width           =   1485
         Begin VB.OptionButton rdoSensorOrientation_270 
            Caption         =   "270"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   89
            Top             =   360
            Width           =   615
         End
         Begin VB.OptionButton rdoSensorOrientation_180 
            Caption         =   "180"
            Enabled         =   0   'False
            Height          =   255
            Left            =   840
            TabIndex        =   86
            Top             =   120
            Width           =   615
         End
         Begin VB.OptionButton rdoSensorOrientation_90 
            Caption         =   "90"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   88
            Top             =   360
            Width           =   615
         End
         Begin VB.OptionButton rdoSensorOrientation_0 
            Caption         =   "0"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   87
            Top             =   120
            Value           =   -1  'True
            Width           =   615
         End
      End
      Begin VB.TextBox txtSensorHeight 
         Enabled         =   0   'False
         Height          =   285
         Left            =   -67320
         Locked          =   -1  'True
         TabIndex        =   85
         Top             =   2700
         Width           =   1639
      End
      Begin VB.Frame Frame22 
         Height          =   855
         Left            =   -67350
         TabIndex        =   141
         Top             =   1600
         Width           =   2175
         Begin VB.OptionButton rdoSensorColorBW 
            Caption         =   "(B/W)"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   81
            Top             =   120
            Width           =   735
         End
         Begin VB.OptionButton rdoSensorColor16Color 
            Caption         =   "16Color"
            Enabled         =   0   'False
            Height          =   255
            Left            =   120
            TabIndex        =   82
            Top             =   360
            Width           =   855
         End
         Begin VB.OptionButton rdoSensorColorGrayScale 
            Caption         =   "GrayScale"
            Enabled         =   0   'False
            Height          =   255
            Left            =   960
            TabIndex        =   80
            Top             =   120
            Value           =   -1  'True
            Width           =   1095
         End
         Begin VB.OptionButton rdoSensorColor256Color 
            Caption         =   "256Color"
            Enabled         =   0   'False
            Height          =   255
            Left            =   960
            TabIndex        =   83
            Top             =   360
            Width           =   975
         End
         Begin VB.OptionButton rdoSensorColorFullColor 
            Caption         =   "FullColor"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   84
            Top             =   600
            Width           =   975
         End
      End
      Begin VB.TextBox txtSensorBpp 
         Enabled         =   0   'False
         Height          =   285
         Left            =   -67320
         Locked          =   -1  'True
         TabIndex        =   79
         Top             =   600
         Width           =   1639
      End
      Begin VB.Frame Frame21 
         Height          =   615
         Left            =   -70320
         TabIndex        =   134
         Top             =   5880
         Width           =   1695
         Begin VB.OptionButton rdoRealTimeDataEnabledFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   77
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
         Begin VB.OptionButton rdoRealTimeDataEnabledTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   78
            Top             =   240
            Width           =   735
         End
      End
      Begin VB.TextBox txtRawSensorData 
         Enabled         =   0   'False
         Height          =   285
         Left            =   -70800
         Locked          =   -1  'True
         TabIndex        =   76
         Top             =   4320
         Width           =   1639
      End
      Begin VB.Frame Frame20 
         Height          =   495
         Left            =   -70800
         TabIndex        =   133
         Top             =   3360
         Width           =   1695
         Begin VB.OptionButton rdoCapTemplateAdaptationFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   75
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
         Begin VB.OptionButton rdoCapTemplateAdaptationTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   74
            Top             =   240
            Width           =   735
         End
      End
      Begin VB.ComboBox comboCapSensorType 
         Enabled         =   0   'False
         Height          =   315
         ItemData        =   "DPOPOSDemo.frx":011B
         Left            =   -70800
         List            =   "DPOPOSDemo.frx":0146
         TabIndex        =   73
         Text            =   "Iris"
         Top             =   2700
         Width           =   1575
      End
      Begin VB.Frame Frame19 
         Height          =   615
         Left            =   -70800
         TabIndex        =   132
         Top             =   1560
         Width           =   1485
         Begin VB.OptionButton rdoCapSensorOrientation_0 
            Caption         =   "0"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   70
            Top             =   120
            Value           =   -1  'True
            Width           =   495
         End
         Begin VB.OptionButton rdoCapSensorOrientation_90 
            Caption         =   "90"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   71
            Top             =   360
            Width           =   495
         End
         Begin VB.OptionButton rdoCapSensorOrientation_180 
            Caption         =   "180"
            Enabled         =   0   'False
            Height          =   255
            Left            =   840
            TabIndex        =   69
            Top             =   120
            Width           =   615
         End
         Begin VB.OptionButton rdoCapSensorOrientation_270 
            Caption         =   "270"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   72
            Top             =   360
            Width           =   615
         End
      End
      Begin VB.Frame Frame18 
         Height          =   855
         Left            =   -70800
         TabIndex        =   131
         Top             =   480
         Width           =   2175
         Begin VB.OptionButton rdoCapSensorColorFulColor 
            Caption         =   "FullColor"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   67
            Top             =   600
            Width           =   975
         End
         Begin VB.OptionButton rdoCapSensorColor256Color 
            Caption         =   "256Color"
            Enabled         =   0   'False
            Height          =   255
            Left            =   960
            TabIndex        =   68
            Top             =   360
            Width           =   975
         End
         Begin VB.OptionButton rdoCapSensorColorGrayScale 
            Caption         =   "GrayScale"
            Enabled         =   0   'False
            Height          =   255
            Left            =   960
            TabIndex        =   64
            Top             =   120
            Width           =   1095
         End
         Begin VB.OptionButton rdoCapSensorColor16Color 
            Caption         =   "16Color"
            Enabled         =   0   'False
            Height          =   255
            Left            =   120
            TabIndex        =   66
            Top             =   360
            Width           =   855
         End
         Begin VB.OptionButton rdoCapSensorColorBW 
            Caption         =   "(B/W)"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   65
            Top             =   120
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.Frame Frame17 
         Height          =   615
         Left            =   -73680
         TabIndex        =   124
         Top             =   5880
         Width           =   1695
         Begin VB.OptionButton rdoCapRealTimeDataTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   63
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdoCapRealTimeDataFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   62
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.Frame Frame16 
         Height          =   495
         Left            =   -73800
         TabIndex        =   123
         Top             =   4200
         Width           =   1695
         Begin VB.OptionButton rdoCapRawSensorDataTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   58
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdoCapRawSensorDataFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   60
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.Frame Frame15 
         Height          =   495
         Left            =   -73800
         TabIndex        =   122
         Top             =   3240
         Width           =   1695
         Begin VB.OptionButton rdoCapPrematchDataTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   56
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdoCapPrematchDataFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   54
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.TextBox txtBir 
         Enabled         =   0   'False
         Height          =   285
         Left            =   -73800
         Locked          =   -1  'True
         TabIndex        =   52
         Top             =   2700
         Width           =   1639
      End
      Begin VB.TextBox txtAlgorithmList 
         Enabled         =   0   'False
         Height          =   285
         Left            =   -73800
         Locked          =   -1  'True
         TabIndex        =   50
         Top             =   1680
         Width           =   1639
      End
      Begin VB.TextBox txtAlgorithm 
         Enabled         =   0   'False
         Height          =   285
         Left            =   -73800
         Locked          =   -1  'True
         TabIndex        =   47
         Top             =   720
         Width           =   495
      End
      Begin VB.TextBox txtDeviceControlDescription 
         Enabled         =   0   'False
         Height          =   285
         Left            =   7800
         Locked          =   -1  'True
         TabIndex        =   40
         Top             =   480
         Width           =   1875
      End
      Begin VB.Frame Frame12 
         Height          =   495
         Left            =   7800
         TabIndex        =   115
         Top             =   840
         Width           =   1695
         Begin VB.OptionButton rdoFreezeEventsFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   41
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
         Begin VB.OptionButton rdoFreezeEventsTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   42
            Top             =   240
            Width           =   735
         End
      End
      Begin VB.Frame Frame13 
         Height          =   495
         Left            =   7800
         TabIndex        =   114
         Top             =   1440
         Width           =   1695
         Begin VB.OptionButton rdoDeviceEnabledTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   43
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdoDeviceEnabledFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   44
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.Frame Frame14 
         Height          =   495
         Left            =   7800
         TabIndex        =   113
         Top             =   2040
         Width           =   1695
         Begin VB.OptionButton rdoDataEventEnabledFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   45
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
         Begin VB.OptionButton rdoDataEventEnabledTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   46
            Top             =   240
            Width           =   735
         End
      End
      Begin VB.Frame Frame10 
         Height          =   615
         Left            =   4155
         TabIndex        =   108
         Top             =   360
         Width           =   2415
         Begin VB.OptionButton rdoStateS_Closed 
            Caption         =   "S_CLOSED"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   28
            Top             =   360
            Value           =   -1  'True
            Width           =   1215
         End
         Begin VB.OptionButton rdoStateS_Idle 
            Caption         =   "S_IDLE"
            Enabled         =   0   'False
            Height          =   195
            Left            =   1320
            TabIndex        =   31
            Top             =   360
            Width           =   975
         End
         Begin VB.OptionButton rdoStateS_Busy 
            Caption         =   "S_BUSY"
            Enabled         =   0   'False
            Height          =   195
            Left            =   1320
            TabIndex        =   30
            Top             =   120
            Width           =   975
         End
         Begin VB.OptionButton rdoStateS_Error 
            Caption         =   "S_ERROR"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   29
            Top             =   120
            Width           =   1215
         End
      End
      Begin VB.TextBox txtPhysicalDeviceName 
         Enabled         =   0   'False
         Height          =   285
         Left            =   4155
         Locked          =   -1  'True
         TabIndex        =   32
         Top             =   1080
         Width           =   2175
      End
      Begin VB.TextBox txtPhysicalDeviceDescription 
         Enabled         =   0   'False
         Height          =   285
         Left            =   4155
         Locked          =   -1  'True
         TabIndex        =   33
         Top             =   1560
         Width           =   2175
      End
      Begin VB.TextBox txtDeviceServiceVersion 
         Enabled         =   0   'False
         Height          =   285
         Left            =   4155
         Locked          =   -1  'True
         TabIndex        =   34
         Top             =   2160
         Width           =   2175
      End
      Begin VB.Frame Frame11 
         Height          =   495
         Left            =   4155
         TabIndex        =   107
         Top             =   2520
         Width           =   1695
         Begin VB.OptionButton rdoClaimedTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   36
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdoClaimedFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   35
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.TextBox txtDeviceServiceDescription 
         Enabled         =   0   'False
         Height          =   285
         Left            =   7800
         Locked          =   -1  'True
         TabIndex        =   38
         Top             =   3240
         Width           =   1935
      End
      Begin VB.TextBox txtDeviceControlVersion 
         Enabled         =   0   'False
         Height          =   285
         Left            =   7800
         Locked          =   -1  'True
         TabIndex        =   39
         Top             =   2640
         Width           =   1935
      End
      Begin VB.TextBox txtCheckHealthText 
         Enabled         =   0   'False
         Height          =   285
         Left            =   4155
         Locked          =   -1  'True
         TabIndex        =   37
         Top             =   3240
         Width           =   1935
      End
      Begin VB.Frame Frame3 
         Height          =   495
         Left            =   1240
         TabIndex        =   11
         Top             =   360
         Width           =   1695
         Begin VB.OptionButton rdoAutoDisableTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   12
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdoAutoDisableFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   13
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.Frame Frame4 
         Height          =   495
         Left            =   1240
         TabIndex        =   14
         Top             =   840
         Width           =   1695
         Begin VB.OptionButton rdoCapCompareFirmwareVirsionFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   15
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
         Begin VB.OptionButton rdoCapCompareFirmwareVirsionTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   16
            Top             =   240
            Width           =   735
         End
      End
      Begin VB.Frame Frame7 
         Height          =   495
         Left            =   1240
         TabIndex        =   97
         Top             =   1440
         Width           =   1695
         Begin VB.OptionButton rdoCapStatisticsReportingTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   98
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdoCapStatisticsReportingFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   17
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.Frame Frame5 
         Height          =   495
         Left            =   1240
         TabIndex        =   95
         Top             =   2040
         Width           =   1695
         Begin VB.OptionButton rdocapUpdateFirmwareTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   18
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdocapUpdateFirmwareFalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   96
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.Frame Frame6 
         Height          =   495
         Left            =   1240
         TabIndex        =   94
         Top             =   2640
         Width           =   1695
         Begin VB.OptionButton rdoCapUpdateStatisticsTrue 
            Caption         =   "True"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   20
            Top             =   240
            Width           =   735
         End
         Begin VB.OptionButton rdoCapUpdateStatisticsfalse 
            Caption         =   "False"
            Enabled         =   0   'False
            Height          =   195
            Left            =   840
            TabIndex        =   19
            Top             =   240
            Value           =   -1  'True
            Width           =   735
         End
      End
      Begin VB.Frame Frame8 
         Height          =   615
         Left            =   1240
         TabIndex        =   93
         Top             =   3120
         Width           =   1695
         Begin VB.OptionButton rdoPowerNotifyPN_Enable 
            Caption         =   "PN_ENABLED"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   22
            Top             =   120
            Width           =   1455
         End
         Begin VB.OptionButton rdoPowerNotifyPN_Disabled 
            Caption         =   "PN_DISABLED"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   21
            Top             =   360
            Value           =   -1  'True
            Width           =   1455
         End
      End
      Begin VB.Frame Frame9 
         Height          =   495
         Left            =   1200
         TabIndex        =   92
         Top             =   4320
         Width           =   7935
         Begin VB.OptionButton rdoPowerStatePS_Unknown 
            Caption         =   "PS_UNKNOWN"
            Enabled         =   0   'False
            Height          =   195
            Left            =   1440
            TabIndex        =   24
            Top             =   240
            Value           =   -1  'True
            Width           =   1575
         End
         Begin VB.OptionButton rdoPowerStatePS_Online 
            Caption         =   "PS_ONLINE"
            Enabled         =   0   'False
            Height          =   195
            Left            =   120
            TabIndex        =   23
            Top             =   240
            Width           =   1335
         End
         Begin VB.OptionButton rdoPowerStatePS_Off 
            Caption         =   "PS_OFF"
            Enabled         =   0   'False
            Height          =   195
            Left            =   3120
            TabIndex        =   25
            Top             =   240
            Width           =   975
         End
         Begin VB.OptionButton rdoPowerStatePS_Off_Offline 
            Caption         =   "PS_OFF_OFFLINE"
            Enabled         =   0   'False
            Height          =   195
            Left            =   6120
            TabIndex        =   27
            Top             =   240
            Width           =   1695
         End
         Begin VB.OptionButton rdoPowerStatePS_Offline 
            Caption         =   "PS_OFFLINE"
            Enabled         =   0   'False
            Height          =   195
            Left            =   4560
            TabIndex        =   26
            Top             =   240
            Width           =   1335
         End
      End
      Begin VB.Label Label10 
         Caption         =   "SensorWidth"
         Height          =   255
         Left            =   -68475
         TabIndex        =   156
         Top             =   1080
         Width           =   975
      End
      Begin VB.Label Label39 
         Caption         =   "CapPower Reporting"
         Height          =   495
         Left            =   120
         TabIndex        =   143
         Top             =   3840
         Width           =   975
      End
      Begin VB.Label Label38 
         Caption         =   "SensorWidth"
         Height          =   375
         Left            =   -67995
         TabIndex        =   140
         Top             =   5880
         Width           =   975
      End
      Begin VB.Label Label37 
         Caption         =   "Sensor Orientation"
         Height          =   495
         Left            =   -68475
         TabIndex        =   139
         Top             =   3360
         Width           =   1080
      End
      Begin VB.Label Label36 
         Caption         =   "SensorHeight"
         Height          =   375
         Left            =   -68475
         TabIndex        =   138
         Top             =   2700
         Width           =   1095
      End
      Begin VB.Label Label35 
         Caption         =   "SensorColor"
         Height          =   255
         Left            =   -68475
         TabIndex        =   137
         Top             =   1605
         Width           =   960
      End
      Begin VB.Label Label34 
         Caption         =   "SensorType"
         Height          =   375
         Left            =   -68475
         TabIndex        =   136
         Top             =   4320
         Width           =   975
      End
      Begin VB.Label Label33 
         Caption         =   "SensorBPP"
         Height          =   255
         Left            =   -68475
         TabIndex        =   135
         Top             =   600
         Width           =   960
      End
      Begin VB.Label Label32 
         Caption         =   "CapSensorColor"
         Height          =   375
         Left            =   -72000
         TabIndex        =   130
         Top             =   600
         Width           =   1215
      End
      Begin VB.Label Label31 
         Caption         =   "CapSensorType"
         Height          =   375
         Left            =   -72000
         TabIndex        =   129
         Top             =   2700
         Width           =   1215
      End
      Begin VB.Label Label30 
         Caption         =   "CapTemplate Adaptation"
         Height          =   525
         Left            =   -72000
         TabIndex        =   128
         Top             =   3360
         Width           =   975
      End
      Begin VB.Label Label29 
         Caption         =   "CapSensor Orientation"
         Height          =   495
         Left            =   -72000
         TabIndex        =   127
         Top             =   1605
         Width           =   855
      End
      Begin VB.Label Label28 
         Caption         =   "RawSensorData"
         Height          =   255
         Left            =   -72000
         TabIndex        =   126
         Top             =   4320
         Width           =   1215
      End
      Begin VB.Label Label27 
         Caption         =   "RealTimeData Enabled"
         Height          =   495
         Left            =   -71640
         TabIndex        =   125
         Top             =   5880
         Width           =   1095
      End
      Begin VB.Label Label26 
         Caption         =   "Algorithm"
         Height          =   255
         Left            =   -74880
         TabIndex        =   121
         Top             =   600
         Width           =   735
      End
      Begin VB.Label Label25 
         Caption         =   "CapPrematch Data"
         Height          =   405
         Left            =   -74880
         TabIndex        =   120
         Top             =   3360
         Width           =   1095
      End
      Begin VB.Label Label24 
         Caption         =   "CapRawSensor Data"
         Height          =   495
         Left            =   -74880
         TabIndex        =   119
         Top             =   4320
         Width           =   1215
      End
      Begin VB.Label Label23 
         Caption         =   "AlgorithmList"
         Height          =   255
         Left            =   -74880
         TabIndex        =   118
         Top             =   1680
         Width           =   1095
      End
      Begin VB.Label Label22 
         Caption         =   "BIR"
         Height          =   255
         Left            =   -74880
         TabIndex        =   117
         Top             =   2700
         Width           =   615
      End
      Begin VB.Label Label4 
         Caption         =   "CapRealTime Data"
         Height          =   495
         Left            =   -74880
         TabIndex        =   116
         Top             =   5880
         Width           =   1215
      End
      Begin VB.Label Label17 
         Caption         =   "DeviceControl Description"
         Height          =   495
         Left            =   6675
         TabIndex        =   112
         Top             =   480
         Width           =   1215
      End
      Begin VB.Label Label13 
         Caption         =   "FreezeEvents"
         Height          =   255
         Left            =   6675
         TabIndex        =   111
         Top             =   1080
         Width           =   1095
      End
      Begin VB.Label Label12 
         Caption         =   "DeviceEnabled"
         Height          =   375
         Left            =   6675
         TabIndex        =   110
         Top             =   1560
         Width           =   1095
      End
      Begin VB.Label Label11 
         Caption         =   "DataEvent Enabled"
         Height          =   495
         Left            =   6675
         TabIndex        =   109
         Top             =   2160
         Width           =   975
      End
      Begin VB.Label Label16 
         Caption         =   "State"
         Height          =   255
         Left            =   2985
         TabIndex        =   106
         Top             =   600
         Width           =   615
      End
      Begin VB.Label Label21 
         Caption         =   "PhysicalDevice Description"
         Height          =   495
         Left            =   2985
         TabIndex        =   105
         Top             =   1560
         Width           =   1215
      End
      Begin VB.Label Label20 
         Caption         =   "DeviceService Version"
         Height          =   495
         Left            =   2985
         TabIndex        =   104
         Top             =   2160
         Width           =   1215
      End
      Begin VB.Label Label19 
         Caption         =   "DeviceService Description"
         Height          =   495
         Left            =   6720
         TabIndex        =   103
         Top             =   3120
         Width           =   1095
      End
      Begin VB.Label Label18 
         Caption         =   "DeviceControl Version"
         Height          =   495
         Left            =   6675
         TabIndex        =   102
         Top             =   2640
         Width           =   1215
      End
      Begin VB.Label Label2 
         Caption         =   "PhysicalDevice Name"
         Height          =   495
         Left            =   2985
         TabIndex        =   101
         Top             =   1080
         Width           =   1200
      End
      Begin VB.Label Label9 
         Caption         =   "Claimed"
         Height          =   255
         Left            =   3000
         TabIndex        =   100
         Top             =   2760
         Width           =   855
      End
      Begin VB.Label Label8 
         Caption         =   "CheckHealth Text"
         Height          =   495
         Left            =   3000
         TabIndex        =   99
         Top             =   3240
         Width           =   1095
      End
      Begin VB.Label Label1 
         Caption         =   "AutoDisable"
         Height          =   255
         Left            =   120
         TabIndex        =   61
         Top             =   600
         Width           =   1095
      End
      Begin VB.Label Label6 
         Caption         =   "CapUpdate Firmware"
         Height          =   495
         Left            =   120
         TabIndex        =   59
         Top             =   2160
         Width           =   975
      End
      Begin VB.Label Label7 
         Caption         =   "CapUpdate Statistics"
         Height          =   495
         Left            =   120
         TabIndex        =   57
         Top             =   2760
         Width           =   855
      End
      Begin VB.Label Label3 
         Caption         =   "CapCompare FirmwareVirsion"
         Height          =   495
         Left            =   120
         TabIndex        =   55
         Top             =   960
         Width           =   1095
      End
      Begin VB.Label Label5 
         Caption         =   "CapStatistics Reporting"
         Height          =   495
         Left            =   120
         TabIndex        =   53
         Top             =   1560
         Width           =   1095
      End
      Begin VB.Label Label14 
         Caption         =   "PowerNotify"
         Height          =   495
         Left            =   120
         TabIndex        =   51
         Top             =   3240
         Width           =   975
      End
      Begin VB.Label Label15 
         Caption         =   "PowerState"
         Height          =   255
         Left            =   120
         TabIndex        =   49
         Top             =   4440
         Width           =   975
      End
   End
   Begin VB.TextBox txtExtendedResultCode 
      Height          =   375
      Left            =   120
      Locked          =   -1  'True
      TabIndex        =   152
      Top             =   5880
      Width           =   615
   End
   Begin VB.ListBox listResult 
      Height          =   1230
      Left            =   0
      MultiSelect     =   2  'Extended
      TabIndex        =   148
      Top             =   6840
      Width           =   10380
   End
   Begin VB.CommandButton btnBeginEnrollCapture 
      Caption         =   "Begin Enroll Capture"
      Enabled         =   0   'False
      Height          =   615
      Left            =   1680
      TabIndex        =   4
      Top             =   360
      Width           =   1095
   End
   Begin VB.CommandButton btnBeginVerifyCapture 
      Caption         =   "Begin Verify Capture"
      Enabled         =   0   'False
      Height          =   615
      Left            =   3360
      TabIndex        =   5
      Top             =   360
      Width           =   1095
   End
   Begin VB.CommandButton btnIdentify 
      Caption         =   "Identify"
      Enabled         =   0   'False
      Height          =   615
      Left            =   8640
      TabIndex        =   6
      Top             =   360
      Width           =   1155
   End
   Begin VB.CommandButton btnIdentifyMatch 
      Caption         =   "Identify Match"
      Enabled         =   0   'False
      Height          =   615
      Left            =   10320
      TabIndex        =   7
      Top             =   360
      Width           =   1095
   End
   Begin VB.CommandButton btnVerify 
      Caption         =   "Verify "
      Enabled         =   0   'False
      Height          =   615
      Left            =   5160
      TabIndex        =   8
      Top             =   360
      Width           =   1095
   End
   Begin VB.CommandButton btnVerifyMatch 
      Caption         =   "Verify Match"
      Enabled         =   0   'False
      Height          =   615
      Left            =   6840
      TabIndex        =   9
      Top             =   360
      Width           =   1095
   End
   Begin VB.Frame FrameSpecificMethods 
      Caption         =   "Specific Methods"
      Height          =   975
      Left            =   1560
      TabIndex        =   48
      Top             =   120
      Width           =   10215
   End
   Begin VB.CommandButton btnOpen 
      Caption         =   "Open( )"
      Height          =   615
      Left            =   120
      TabIndex        =   1
      Top             =   480
      Width           =   1095
   End
   Begin VB.CommandButton btnClose 
      Caption         =   "Close( )"
      Enabled         =   0   'False
      Height          =   615
      Left            =   120
      TabIndex        =   2
      Top             =   2520
      Width           =   1095
   End
   Begin VB.CommandButton btnClaim 
      Caption         =   "Claim( )"
      Enabled         =   0   'False
      Height          =   615
      Left            =   120
      TabIndex        =   3
      Top             =   1560
      Width           =   1095
   End
   Begin VB.Frame FrameCommonMethods 
      Caption         =   "Common Methods"
      Height          =   6615
      Left            =   0
      TabIndex        =   0
      Top             =   120
      Width           =   1575
      Begin VB.CommandButton cmdClearData 
         Caption         =   "Clear Data"
         Enabled         =   0   'False
         Height          =   615
         Left            =   120
         TabIndex        =   154
         Top             =   3360
         Width           =   1095
      End
      Begin VB.TextBox txtResultCode 
         Height          =   375
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   150
         Top             =   4560
         Width           =   615
      End
      Begin VB.Label Label40 
         Caption         =   "Extended Result Code"
         Height          =   375
         Left            =   120
         TabIndex        =   151
         Top             =   5160
         Width           =   1215
      End
      Begin VB.Label lblResultCode 
         Caption         =   "Result Code"
         Height          =   255
         Left            =   120
         TabIndex        =   149
         Top             =   4200
         Width           =   1095
      End
   End
   Begin VB.Label lblStatus 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C00000&
      Height          =   495
      Left            =   1680
      TabIndex        =   153
      Top             =   1200
      Width           =   10095
   End
End
Attribute VB_Name = "DPOPOSDemo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'**************** Copyright (c) 1996-2012, DigitalPersona, Inc. *************************/
'DPOPOSDemo.frm
'Contents:
'This application provides interface to test both the enrollment
'and the verification operations for the dpfingerprint reader
'The appropriate methods of the Control Object are called to achieve the same.
'Also, the properties, both Common and Specific are displayed,
'in the tabs - Common Properties and Specific Properties.
'****************************************************************************************/


Option Explicit

Dim WithEvents obj As OPOSBiometrics
Attribute obj.VB_VarHelpID = -1

Public Enum dEvent
    None
    Register
    BeginVerify
    Verify
    VerifyMatch
    Identify
    IdentifyMatch
End Enum

Public Enum state
    None
    Opened
    Claimed
    Released
    Closed
End Enum
    
Dim bOpenDevice As Boolean
Dim RegTemplate() As String
Dim VerificationTemplate As String
Dim RawSensorData As String
Dim index As Integer
Dim pResult As Boolean
Dim dataEvent As dEvent
Dim dState As state
Dim ret As Long
Dim flag As Boolean

Dim test() As Byte

Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
Private Declare Function GetSystemMetrics Lib "user32" _
(ByVal nIndex As Long) As Long



Private Sub btnBeginEnrollCapture_Click()
    
    'txtResultCode.Text = "0"
    'txtExtendedResultCode = "0"
    txtstatus.Visible = False
    lblStatus.Caption = ""
    '----------------------------------------------------------------
    btnBeginEnrollCapture.Enabled = False
    '----------------------------------------------------------------
    listResult.AddItem ("BeginEnrollCapture method is called...")
     
    flag = True
    btnBeginVerifyCapture.Enabled = False
    btnVerify.Enabled = False
    btnIdentify.Enabled = False
    btnIdentifyMatch.Enabled = False
    btnVerifyMatch.Enabled = False
    cmdClearData.Enabled = True
    
    dataEvent = dEvent.Register
    ret = obj.BeginEnrollCapture("s", "s")
    txtResultCode.Text = ret
    txtExtendedResultCode = "0"
    If ret = OposSuccess Then
       listResult.AddItem ("BeginEnrollCapture successful...")
       lblStatus.Caption = "Waiting for fingerprint scan"
'    ElseIf ret = OposEIllegal Then
'    listResult.AddItem ("BeginEnrollCapture failed... Biometric capture is in progress!")
    Else
    
       listResult.AddItem ("BeginEnrollCapture failed!" & "Retval = " & ret)
        
    End If
    listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub btnBeginVerifyCapture_Click()
    flag = True
    txtstatus.Visible = False
    
    btnVerify.Enabled = False
    btnIdentify.Enabled = False
    btnVerifyMatch.Enabled = False
    btnIdentifyMatch.Enabled = False
    btnBeginEnrollCapture.Enabled = False
    btnBeginVerifyCapture.Enabled = False
    lblStatus.Caption = ""
    dataEvent = dEvent.BeginVerify
    listResult.AddItem ("BeginVerifyCapture method is called...")
     
    
    txtExtendedResultCode.Text = "0"
  
    lblStatus.Caption = "Waiting For Fingerprint Scan"
    ret = obj.BeginVerifyCapture()
    txtResultCode.Text = ret
    '----------------------------------------------------------------
    If ret = OposSuccess Then
    listResult.AddItem "BeginVerifyCapture Successful. " & "Retval = " & ret
    Else
     listResult.AddItem "BeginVerifyCapture Failed. " & "Retval = " & ret
    End If
    '----------------------------------------------------------------
    listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub btnClaim_Click()
    listResult.AddItem ("ClaimDevice method is called...")
     
    txtExtendedResultCode.Text = "0"
    
    ret = obj.ClaimDevice(2)
    txtResultCode.Text = ret
    If ret = 102 Then
    obj.Close
    lblStatus.Caption = ""
    btnClose.Enabled = False
    btnClaim.Enabled = False
    btnOpen.Enabled = True
    
     'Call btnClose_Click
    Exit Sub
    End If
    
    If ret = OposSuccess Then
        listResult.AddItem "ClaimDevice Success.  " & "RetVal = " & ret
         
        obj.DeviceEnabled = True
        listResult.AddItem "DeviceEnabled Property has been set to true."
         
        obj.DataEventEnabled = True
        listResult.AddItem "DataEventEnabled Property has been set to true."
        
        obj.Algorithm = 2
        Call getProperty
         
        btnClaim.Enabled = False
        btnBeginEnrollCapture.Enabled = True
        'cmdProp.Enabled = True
        lblStatus.Caption = "Device Claimed"
        dState = Claimed
        'Call getProperty
        Call getClaimProp
        
    Else
        listResult.AddItem "ClaimDevice failed.  " & "RetVal = " & ret
         
    End If
   listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub btnClose_Click()
    If obj.DeviceEnabled <> True Then
    lblStatus.Caption = "Device Disconnected"
    btnClose.Enabled = False
    End If
    
    listResult.AddItem ("Close method is called...")
     
    txtExtendedResultCode.Text = "0"
   
    ReDim RegTemplate(0)
    VerificationTemplate = ""
    index = 0
    
    RawSensorData = ""
    
    If dState = Claimed Then
        ret = obj.ReleaseDevice()
        dState = Released
        If ret = OposSuccess Then
        listResult.AddItem "ReleaseDevice Success." & "RetVal = " & ret
         
        ret = obj.Close
            If ret = OposSuccess Then
                listResult.AddItem "Close Success." & "RetVal = " & ret
                 
                lblStatus.Caption = "Device Closed"
                btnOpen.Enabled = True
                btnClaim.Enabled = False
                btnClose.Enabled = False
                btnBeginEnrollCapture.Enabled = False
                btnBeginVerifyCapture.Enabled = False
                btnVerify.Enabled = False
                btnVerifyMatch.Enabled = False
                btnIdentify.Enabled = False
                btnIdentifyMatch.Enabled = False
                cmdClearData.Enabled = False
                
                'cmdProp.Enabled = False
                dState = Closed
            Else
                listResult.AddItem "Close failed." & "RetVal = " & ret
                 
            End If
            txtResultCode.Text = ret
        Else
            listResult.AddItem "ReleaseDevice failed." & "RetVal = " & ret
             
            txtResultCode.Text = ret
        End If
    ElseIf dState = Opened Then
        ret = obj.Close
            If ret = OposSuccess Then
                listResult.AddItem "Close Success." & "RetVal = " & ret
                 
                lblStatus.Caption = "Device Closed"
                btnOpen.Enabled = True
                btnClaim.Enabled = False
                btnClose.Enabled = False
                btnBeginEnrollCapture.Enabled = False
                btnBeginVerifyCapture.Enabled = False
                btnVerify.Enabled = False
                btnVerifyMatch.Enabled = False
                btnIdentify.Enabled = False
                btnIdentifyMatch.Enabled = False
                cmdClearData.Enabled = False
                'cmdProp.Enabled = False
            Else
                listResult.AddItem "Close failed." & "RetVal = " & ret
                 
            End If
            txtResultCode.Text = ret
    End If
    Call resetProperties
    lblStatus.Caption = ""
    txtExtendedResultCode.Text = "0"
    listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub btnIdentify_Click()
    
    txtstatus.Visible = False
    
    txtResultCode.Text = "0"
    txtExtendedResultCode = "0"
    lblStatus.Caption = "Waiting for a finger scan"
    
    DPOPOSDemo.Refresh
    
    btnVerify.Enabled = False
    btnIdentify.Enabled = False
    btnVerifyMatch.Enabled = False
    btnIdentifyMatch.Enabled = False
    
    btnBeginEnrollCapture.Enabled = False
    btnBeginVerifyCapture.Enabled = False
    dataEvent = dEvent.Identify
    listResult.AddItem ("Identify is called...")
     
    
    Dim maxFARRequested, maxFRRRequested, Timeout As Integer
    maxFARRequested = 1000
    maxFRRRequested = 1000
    Timeout = 3000
    Dim u_bound As Integer
    Dim l_bound As Integer
    
    Dim CandidateRank
    Dim CandidateArrayList() As String
    dataEvent = dEvent.Identify
    ret = obj.Identify(maxFARRequested, maxFRRRequested, True, RegTemplate, CandidateRank, Timeout)
    'MsgBox ret
    If ret = OposETimeout Then
        
        lblStatus.Caption = "Timeout Error..."
    Else
    
    u_bound = UBound(CandidateRank)
    l_bound = LBound(CandidateRank)
    
        If ((ret = OposSuccess) And (u_bound > -1)) Then
               
            listResult.AddItem "Identify Successful  " & "Retval = " & ret
             
            ReDim CandidateArrayList(UBound(CandidateRank))
            Dim I As Integer
            For I = LBound(CandidateRank) To UBound(CandidateRank)
                CandidateArrayList(I) = CandidateRank(I)
            Next
        
            Dim show1 As String
            show1 = ""
            For I = LBound(CandidateArrayList) To UBound(CandidateArrayList)
                show1 = CandidateArrayList(I) + "    " + show1
            Next
        
            txtstatus.Visible = True
            txtstatus.Text = "Candidate Array:  " & show1
            'lblStatus.Caption = "Candidate Array:  " & show1
        
    
        ElseIf ((ret = OposSuccess) And (u_bound <= -1)) Then
            lblStatus.Caption = "Candidate ranking array is empty!"
        
        Else
            listResult.AddItem ("Identify failed!")
             
        End If
    End If
    
            btnVerify.Enabled = True
            btnIdentify.Enabled = True
            btnBeginEnrollCapture.Enabled = True
            btnBeginVerifyCapture.Enabled = True
            listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub btnIdentifyMatch_Click()
    
    txtstatus.Visible = False
    lblStatus.Caption = ""
    btnIdentify.Enabled = False
    btnVerify.Enabled = False
    btnIdentifyMatch.Enabled = False
    btnVerifyMatch.Enabled = False
    btnBeginEnrollCapture.Enabled = False
    btnBeginVerifyCapture.Enabled = False
    
    ret = -1
    listResult.AddItem ("IdentifyMatch called")
     
    dataEvent = dEvent.IdentifyMatch
    
    Dim CandidateRank
    Dim CandidateArrayList() As String
    
    Dim maxFARRequested, maxFRRRequested As Integer
    maxFARRequested = 1000
    maxFRRRequested = 1000
    Dim u_bound As Integer
    Dim l_bound As Integer
    ret = obj.IdentifyMatch(maxFARRequested, maxFRRRequested, True, VerificationTemplate, RegTemplate, CandidateRank)
        
        
    
    u_bound = UBound(CandidateRank)
    l_bound = LBound(CandidateRank)
    
    If ((ret = OposSuccess) And (u_bound > -1)) Then
        
        listResult.AddItem "IdentifyMatch Successful  " & "Retval = " & ret
        ReDim CandidateArrayList(UBound(CandidateRank))
        Dim I As Integer
        For I = LBound(CandidateRank) To UBound(CandidateRank)
            CandidateArrayList(I) = CandidateRank(I)
        Next
        
        Dim show1 As String
        show1 = ""
        For I = LBound(CandidateArrayList) To UBound(CandidateArrayList)
            show1 = CandidateArrayList(I) + "    " + show1
        Next
        txtstatus.Visible = True
        txtstatus.Text = "Candidate Array:  " & show1
        'lblStatus.Caption = "Candidate Array:  " & show1
    ElseIf ((ret = OposSuccess) And (u_bound <= -1)) Then
            lblStatus.Caption = "Candidate ranking array is empty!"
        
    Else
        lblStatus.Caption = "Candidate ranking array is empty!"

        listResult.AddItem ("IdentifyMatch failed!")
         
    End If
       
    btnIdentify.Enabled = True
    btnVerify.Enabled = True
    
    btnBeginEnrollCapture.Enabled = True
    btnBeginVerifyCapture.Enabled = True
    
    btnIdentifyMatch.Enabled = False
    listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub btnOpen_Click()
    lblStatus.Caption = ""
    listResult.AddItem ("Open method is called...")
    
    ret = obj.Open("DPFingerPrintReader")
    txtResultCode.Text = ret
    txtExtendedResultCode.Text = "0"
    
    If ret = OposSuccess Then
        listResult.AddItem "Open method success.  " & "RetVal = " & ret
         
        btnOpen.Enabled = False
        btnClaim.Enabled = True
        btnClose.Enabled = True
        lblStatus.Caption = "Device Opened"
        bOpenDevice = True
        dState = Opened
        Call getProperty
    Else
        listResult.AddItem "Open method fail.  " & "RetVal = " & ret
         
        bOpenDevice = False
    End If
    listResult.ListIndex = listResult.NewIndex
    
End Sub


Private Sub btnVerify_Click()
    
    txtstatus.Visible = False
    txtResultCode.Text = "0"
    txtExtendedResultCode.Text = "0"
    lblStatus.Caption = "Waiting for a finger scan"
    DPOPOSDemo.Refresh
    '--------------------------------------------------------
    btnVerify.Enabled = False
    '--------------------------------------------------------
    btnIdentify.Enabled = False
    
    btnVerifyMatch.Enabled = False
    btnIdentifyMatch.Enabled = False
    
    btnBeginEnrollCapture.Enabled = False
    btnBeginVerifyCapture.Enabled = False
    
    listResult.AddItem ("Verify is called...")
     
    Dim pResult As Boolean
    txtExtendedResultCode.Text = "0"
    pResult = False
    
    dataEvent = dEvent.Verify
   
    Dim pFARAchieved As Long
    Dim pFRRAchieved As Long
    Dim pAdaptedBIR As String
    
    
    Dim maxFARRequested, maxFRRRequested, Timeout As Integer
    maxFARRequested = 1000
    maxFRRRequested = 1000
    Timeout = 3000
         
    ret = obj.Verify(maxFARRequested, maxFRRRequested, True, RegTemplate(index - 1), pAdaptedBIR, pResult, pFARAchieved, pFRRAchieved, "pPayload", Timeout)
    txtResultCode.Text = "0"
    If ret = OposSuccess Then
        listResult.AddItem "Verify Successful  " & "Retval = " & ret
         
        If pResult Then
             lblStatus.Caption = "Fingerprint Matches"
             
        ElseIf lblStatus.Caption <> "Timeout Error..." And pResult <> True Then
             lblStatus.Caption = "Fingerprint Does Not Match"
        End If
        
        ElseIf ret = OposETimeout Then
        lblStatus.Caption = "Timeout Error..."
        
    Else
        listResult.AddItem "Verify Failed  " & "Retval = " & ret
         
    End If
    
        
    btnVerify.Enabled = True
    btnIdentify.Enabled = True
    
    btnBeginEnrollCapture.Enabled = True
    btnBeginVerifyCapture.Enabled = True
    listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub btnVerifyMatch_Click()
    lblStatus.Caption = ""
    listResult.AddItem ("VerifyMatch method is called...")
     
    
    btnIdentify.Enabled = False
    btnVerify.Enabled = False
    btnIdentifyMatch.Enabled = False
    btnBeginEnrollCapture.Enabled = False
    btnBeginVerifyCapture.Enabled = False
    
    txtstatus.Visible = False
    txtExtendedResultCode.Text = "0"
    Dim a, b, C As Integer
    
    Dim pFARAchieved As Long
    Dim pFRRAchieved As Long
    Dim pAdaptedBIR As String
    
   
    
    Dim maxFARRequested, maxFRRRequested As Integer
    maxFARRequested = 1000
    maxFRRRequested = 1000
    
    
    listResult.AddItem ("VerifyMatch is called..")
     
    ret = obj.VerifyMatch(maxFARRequested, maxFRRRequested, True, VerificationTemplate, RegTemplate(index - 1), pAdaptedBIR, pResult, pFARAchieved, pFRRAchieved, "pPayload")
    txtResultCode.Text = ret
    
    If ret = OposSuccess Then
        listResult.AddItem "VerifyMatch Success.  " & "Retval = " & ret
         
        If (pResult) Then
            lblStatus.Caption = "Fingerprint matches"
           
        Else
            
            lblStatus.Caption = "Fingerprint does not matches"
            
        End If
    Else
        listResult.AddItem "VerifyMatch Failed.  " & "Retval = " & ret
         
    End If
   
    btnIdentify.Enabled = True
    btnVerify.Enabled = True
    btnBeginEnrollCapture.Enabled = True
    btnBeginVerifyCapture.Enabled = True
    btnVerifyMatch.Enabled = False
    listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub cmdClearData_Click()
    ReDim RegTemplate(0)
    VerificationTemplate = ""
    RawSensorData = ""
    index = 0
    btnVerify.Enabled = False
    btnIdentify.Enabled = False
    btnBeginVerifyCapture.Enabled = False
    lblStatus.Caption = ""
    txtResultCode.Text = ""
    txtExtendedResultCode.Text = ""
        
    txtstatus.Visible = False
    
    If flag = True Then
    obj.EndCapture
    flag = False
    End If
    btnBeginEnrollCapture.Enabled = True
    btnBeginVerifyCapture.Enabled = False

    btnIdentify.Enabled = False
    btnIdentifyMatch.Enabled = False

    btnVerify.Enabled = False
    btnVerifyMatch.Enabled = False
    
    
    
    
End Sub



Private Sub Form_Load()
    
    Dim screenResolution As Long
    'MsgBox DPOPOSDemo.Width
    screenResolution = GetSystemMetrics(screenResolution)
    If screenResolution = 800 Then
    DPOPOSDemo.listResult.Height = listResult.Height - 300
    ElseIf screenResolution = 1024 Then
    'DPOPOSDemo.Width = 1024
    End If
    
    Set obj = New OPOSBiometrics
    
    flag = False
End Sub

Private Sub Form_Unload(Cancel As Integer)
    If (bOpenDevice) Then
        Call btnClose_Click
    End If
    Set obj = Nothing
End Sub

Private Sub listResult_Click()
'MsgBox (listResult.ListIndex)
  
End Sub

Private Sub listResult_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
'MsgBox (listResult.ListIndex)

End Sub

Private Sub obj_StatusUpdateEvent(ByVal Data As Long)
If Data = BIO_SUE_RAW_DATA Then
    Call getProperty
    Dim myBytes() As Byte
    myBytes = obj.RawSensorData
End If
End Sub


Private Sub obj_DataEvent(ByVal Status As Long)
    Select Case dataEvent
        Case dEvent.Identify
             dataEvent = dEvent.None
    
        Case dEvent.BeginVerify
             VerificationTemplate = obj.BIR
             lblStatus.Caption = "Fingerprint Image Scanned"
             ret = obj.EndCapture()
            If ret = OposSuccess Then
                listResult.AddItem "Verification Capture method success.  " & "Retval = " & ret
                 
                
                btnVerify.Enabled = True
                btnIdentify.Enabled = True
                btnVerifyMatch.Enabled = True
                btnIdentifyMatch.Enabled = True
                btnBeginEnrollCapture.Enabled = True
                btnBeginVerifyCapture.Enabled = True
                flag = False

            Else
                listResult.AddItem "Verification Capture method failed.  " & "Retval = " & ret
                 
            End If
            
            obj.DataEventEnabled = True
            listResult.AddItem "DataEventEnabled Property has been set to true."
             
            dataEvent = dEvent.None
            
        Case dEvent.Register
             ReDim Preserve RegTemplate(index)
             
             RegTemplate(index) = obj.BIR
             
             'Picture1.Picture = "c:\test.bmp"
             index = index + 1
                     
             lblStatus.Caption = "Fingerprint Image Scanned"
             ret = obj.EndCapture()
             If ret = OposSuccess Then
                listResult.AddItem "Enrollment method success.  " & "Retval = " & ret
                 
                               
                btnBeginVerifyCapture.Enabled = True
                btnVerify.Enabled = True
                btnIdentify.Enabled = True
                
                flag = False
             Else
                listResult.AddItem "Enrollment method failed.  " & "Retval = " & ret
                 
             End If
            
             obj.DataEventEnabled = True
             listResult.AddItem "DataEventEnabled Property has been set to true."
              
             btnBeginEnrollCapture.Enabled = True
             dataEvent = dEvent.None
            
        Case dEvent.Verify
             lblStatus.Caption = ""
             dataEvent = dEvent.None
    
        Case dEvent.None
    
    End Select
    listResult.ListIndex = listResult.NewIndex
End Sub

Private Sub obj_DirectIOEvent(ByVal EventNumber As Long, pData As Long, pString As String)
   ' MsgBox (listResult.ListIndex)
   If flag = True Then
   
        If EventNumber = DP_DIOE_ENROLL_FEATURES_ADDED Then
            lblStatus.Caption = "Image " + Conversion.CStr(pData) + " captured, put same finger for image " + Conversion.CStr(pData + 1)

        ElseIf EventNumber = DP_DIOE_DISCONNECT Then
            listResult.AddItem ("DisConnected")
             
        ElseIf EventNumber = DP_DIOE_RECONNECT Then
            listResult.AddItem ("ReConnected")
             
        ElseIf EventNumber = DP_DIOE_SAMPLE_QUALITY Then
             Select Case pData
             Case DP_QUALITY_GOOD
                    listResult.AddItem ("The image is of good quality.")
                     
             Case DP_QUALITY_NONE
                    listResult.AddItem ("No finger detected. Please try again.")
                     
             Case DP_QUALITY_TOOLIGHT
                    listResult.AddItem ("The image is too light.")
                     

             Case DP_QUALITY_TOODARK
                    listResult.AddItem ("The image is too dark.")
                     

             Case DP_QUALITY_TOONOISY
                    listResult.AddItem ("The image is too noisy.")
                     

             Case DP_QUALITY_LOWCONTR
                    listResult.AddItem ("The image contrast is too low.")
                     

             Case DP_QUALITY_FTRNOTENOUGH
                    listResult.AddItem ("The image does not contain enough information.")
                     

             Case DP_QUALITY_NOCENTRAL
                    listResult.AddItem ("The image is not centered.")
                     
             End Select
            
        ElseIf EventNumber = DP_DIOE_FINGER_TOUCHED Then
            listResult.AddItem ("Finger touched")
             
        ElseIf EventNumber = DP_DIOE_FINGER_GONE Then
            listResult.AddItem ("Finger gone")
             
        ElseIf EventNumber = DP_DIOE_IMAGE_READY Then
            listResult.AddItem ("Image ready")
             
        ElseIf EventNumber = DP_DIOE_OPERATION_STOPPED Then
            listResult.AddItem ("Stop capturing")
             
           
        End If

   End If
   listResult.ListIndex = listResult.NewIndex
    End Sub

Private Sub obj_ErrorEvent(ByVal ResultCode As Long, ByVal ResultCodeExtended As Long, ByVal ErrorLocus As Long, pErrorResponse As Long)
    If ResultCode = OposETimeout Then
        lblStatus.Caption = "Timeout Error..."
          
        btnIdentify.Enabled = True
        btnVerify.Enabled = True
        btnBeginEnrollCapture.Enabled = True
        btnBeginVerifyCapture.Enabled = True
        
        ElseIf ResultCode = OposENohardware Then
            lblStatus.Caption = "Device Disconnected"
            btnClose.Enabled = False
            cmdClearData.Enabled = False
            DPOPOSDemo.Refresh
        ElseIf ResultCode = 0 Then
            lblStatus.Caption = "Device Connected"
            txtResultCode.Text = "0"
            txtExtendedResultCode.Text = "0"
            btnClose.Enabled = True
            cmdClearData.Enabled = True
            DPOPOSDemo.Refresh
    
    Else
        lblStatus.Caption = "Error"
        If (flag) Then
            ret = obj.EndCapture()
            btnBeginEnrollCapture.Enabled = True
            obj.DataEventEnabled = True
            flag = False
        End If
    End If
    txtResultCode.Text = ResultCode
    txtExtendedResultCode.Text = ResultCodeExtended
    listResult.ListIndex = listResult.NewIndex
End Sub

Function getProperty()
    obj.AutoDisable = False
    obj.FreezeEvents = False
    'obj.DataEventEnabled = False
    obj.RealTimeDataEnabled = False
    
    txtSensorBpp.Text = obj.SensorBPP
    txtSensorHeight.Text = obj.SensorHeight
    txtSensorWidth1.Text = obj.SensorWidth
    
    obj.CheckHealth (1)
    
    txtCheckHealthText.Text = obj.CheckHealthText
        
    If obj.AutoDisable Then
       rdoAutoDisableTrue.Value = True
       Else
       rdoAutoDisableFalse.Value = True
    End If
    
    If obj.CapCompareFirmwareVersion Then
        rdoCapCompareFirmwareVirsionTrue.Value = True
    Else
        rdoCapCompareFirmwareVirsionFalse.Value = True
    End If
        
    If obj.CapStatisticsReporting Then
        rdoCapStatisticsReportingTrue.Value = True
    Else
        rdoCapStatisticsReportingFalse.Value = True
    End If
            
    If obj.CapUpdateFirmware Then
        rdocapUpdateFirmwareTrue.Value = True
    Else
        rdocapUpdateFirmwareFalse.Value = True
    End If
     
    If obj.CapUpdateStatistics Then
        rdoCapUpdateStatisticsTrue.Value = True
    Else
        rdoCapUpdateStatisticsfalse.Value = True
    End If
    
    If obj.FreezeEvents Then
        rdoFreezeEventsTrue.Value = True
    Else
        rdoFreezeEventsFalse.Value = True
    End If
    
    If obj.Claimed Then
        rdoClaimedTrue.Value = True
    Else
        rdoClaimedFalse.Value = True
    End If
    
    If obj.DeviceEnabled Then
        rdoDeviceEnabledTrue.Value = True
    Else
        rdoDeviceEnabledFalse.Value = True
    End If
    
    If obj.DataEventEnabled Then
         rdoDataEventEnabledTrue.Value = True
    Else
         rdoDataEventEnabledFalse.Value = True
    End If
    
    If obj.CapPrematchData Then
         rdoCapPrematchDataTrue.Value = True
    Else
         rdoCapPrematchDataFalse.Value = True
    End If
    
    If obj.CapRawSensorData Then
        rdoCapRawSensorDataTrue.Value = True
    Else
          rdoCapRawSensorDataFalse.Value = True
    End If
    
    If obj.CapRealTimeData Then
        rdoCapRealTimeDataTrue.Value = True
    Else
        rdoCapRealTimeDataFalse.Value = True
    End If
    
    If obj.CapTemplateAdaptation Then
        rdoCapTemplateAdaptationTrue.Value = True
    Else
        rdoCapTemplateAdaptationFalse.Value = True
    End If
    
    If obj.RealTimeDataEnabled Then
        rdoRealTimeDataEnabledTrue.Value = True
    Else
        rdoCapRealTimeDataFalse.Value = True
    End If
    
    'rdoCapPowerReportingPR_ADVANCED.Value = True
 
    If rdoCapStatisticsReportingFalse.Value = True Then
        rdoCapUpdateStatisticsfalse.Value = True
    End If

    If obj.PowerNotify Then
        rdoPowerNotifyPN_Enable.Value = True
    Else
        rdoPowerNotifyPN_Disabled.Value = True
    End If
   
    If obj.CapPowerReporting = OposPrNone Then
    rdoCapPowerReportingPR_NONE.Value = True
    End If
    
    If obj.PowerState = OposPsUnknown Then
    rdoPowerStatePS_Unknown.Value = True
    End If
    
    If obj.state = OposSIdle Then
    rdoStateS_Idle.Value = True
    End If
    
    txtPhysicalDeviceName.Text = obj.DeviceName
    
    txtPhysicalDeviceDescription.Text = obj.DeviceDescription
    txtDeviceControlDescription.Text = obj.ControlObjectDescription
    txtDeviceControlVersion.Text = obj.ControlObjectVersion
    txtDeviceServiceDescription.Text = obj.ServiceObjectDescription
    txtDeviceServiceVersion.Text = obj.ServiceObjectVersion
    SSTabSpecificProperties.Enabled = True
    
    txtAlgorithm.Text = obj.Algorithm
    txtAlgorithmList.Text = obj.AlgorithmList
    rdoCapSensorColorGrayScale.Value = True
    
    If obj.CapSensorOrientation = 1 Then
        rdoCapSensorOrientation_0 = True
    End If
    
    If obj.SensorOrientation = 1 Then
        rdoSensorOrientation_0 = True
    End If
    
    comboCapSensorType.ListIndex = 0
    rdoSensorColorGrayScale.Value = True
    comboSensorType.ListIndex = 0

End Function
Function resetProperties()
     
     
    If obj.state = OposSClosed Then
    rdoStateS_Closed.Value = True
    End If
    
    txtstatus.Visible = False
    txtSensorWidth1.Text = ""
    txtAlgorithm.Text = ""
    txtAlgorithmList.Text = ""
    txtBir.Text = ""
    txtCheckHealthText.Text = ""
    txtDeviceControlDescription.Text = ""
    txtDeviceControlVersion.Text = ""
    txtDeviceServiceDescription.Text = ""
    txtDeviceServiceVersion.Text = ""
    txtExtendedResultCode.Text = ""
    txtPhysicalDeviceDescription.Text = ""
    txtPhysicalDeviceName.Text = ""
    txtRawSensorData.Text = ""
    'txtResultCode.Text = ""
    txtSensorBpp.Text = ""
    txtSensorHeight.Text = ""
    txtSensorWidth.Text = ""
    
    rdoAutoDisableFalse.Value = True
    rdoCapCompareFirmwareVirsionFalse.Value = True
    rdocapUpdateFirmwareFalse.Value = True
    rdoCapUpdateStatisticsfalse.Value = True
    rdoPowerNotifyPN_Disabled.Value = True
    'rdoCapPowerReportingPR_NONE.Value = True
    rdoPowerStatePS_Unknown.Value = True
    
    
    
    rdoClaimedFalse.Value = True
    rdoFreezeEventsFalse.Value = True
    rdoDeviceEnabledFalse.Value = True
    rdoDataEventEnabledFalse.Value = True
    rdoCapPrematchDataFalse.Value = True
    rdoCapRawSensorDataFalse.Value = True
    rdoCapSensorColorBW.Value = True
    rdoCapSensorOrientation_0.Value = True
    rdoCapTemplateAdaptationFalse.Value = True
    rdoSensorColorGrayScale.Value = True
    rdoSensorOrientation_0.Value = True
    
    comboCapSensorType.ListIndex = 3
    comboSensorType.ListIndex = 3
    
    SSTabSpecificProperties.Enabled = False
    
    
    
End Function
 
Function getClaimProp()

If obj.Claimed Then
        rdoClaimedTrue.Value = True
    Else
        rdoClaimedFalse.Value = True
    End If
    
    If obj.DeviceEnabled Then
        rdoDeviceEnabledTrue.Value = True
    Else
        rdoDeviceEnabledFalse.Value = True
    End If
    
    If obj.DataEventEnabled Then
         rdoDataEventEnabledTrue.Value = True
    Else
         rdoDataEventEnabledFalse.Value = True
    End If
End Function



