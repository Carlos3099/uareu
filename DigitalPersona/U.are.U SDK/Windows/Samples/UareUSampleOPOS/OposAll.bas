Attribute VB_Name = "OposConstants"

'**************** Copyright (c) 1996-2012, DigitalPersona, Inc. ************************/
' File:OposAll.bas
'Contents:
'It contains all the error codes supported by OPOS.
'****************************************************************************************/

Rem *///////////////////////////////////////////////////////////////////
Rem * OPOS "State" Property Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposSClosed& = 1
Public Const OposSIdle& = 2
Public Const OposSBusy& = 3
Public Const OposSError& = 4


Rem *///////////////////////////////////////////////////////////////////
Rem * OPOS "ResultCode" Property Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposSuccess& = 0
Public Const OposEClosed& = 101
Public Const OposEClaimed& = 102
Public Const OposENotclaimed& = 103
Public Const OposENoservice& = 104
Public Const OposEDisabled& = 105
Public Const OposEIllegal& = 106
Public Const OposENohardware& = 107
Public Const OposEOffline& = 108
Public Const OposENoexist& = 109
Public Const OposEExists& = 110
Public Const OposEFailure& = 111
Public Const OposETimeout& = 112
Public Const OposEBusy& = 113
Public Const OposEExtended& = 114


Rem *///////////////////////////////////////////////////////////////////
Rem * OPOS "OpenResult" Property Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const Oposopenerr& = 300

Public Const OposOrAlreadyopen& = 301
Public Const OposOrRegbadname& = 302
Public Const OposOrRegprogid& = 303
Public Const OposOrCreate& = 304
Public Const OposOrBadif& = 305
Public Const OposOrFailedopen& = 306
Public Const OposOrBadversion& = 307

Public Const Oposopenerrso& = 400

Public Const OposOrsNoport = 401
Public Const OposOrsNotsupported = 402
Public Const OposOrsConfig = 403
Public Const OposOrsSpecific = 450


Rem *///////////////////////////////////////////////////////////////////
Rem * OPOS "BinaryConversion" Property Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposBcNone& = 0
Public Const OposBcNibble& = 1
Public Const OposBcDecimal& = 2


Rem *///////////////////////////////////////////////////////////////////
Rem * "CheckHealth" Method: "Level" Parameter Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposChInternal& = 1
Public Const OposChExternal& = 2
Public Const OposChInteractive& = 3


Rem *///////////////////////////////////////////////////////////////////
Rem * OPOS "CapPowerReporting", "PowerState", "PowerNotify" Property
Rem *   Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposPrNone& = 0
Public Const OposPrStandard& = 1
Public Const OposPrAdvanced& = 2

Public Const OposPnDisabled& = 0
Public Const OposPnEnabled& = 1

Public Const OposPsUnknown& = 2000
Public Const OposPsOnline& = 2001
Public Const OposPsOff& = 2002
Public Const OposPsOffline& = 2003
Public Const OposPsOffOffline& = 2004


Rem *///////////////////////////////////////////////////////////////////
Rem * "ErrorEvent" Event: "ErrorLocus" Parameter Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposElOutput& = 1
Public Const OposElInput& = 2
Public Const OposElInputData& = 3


Rem *///////////////////////////////////////////////////////////////////
Rem * "ErrorEvent" Event: "ErrorResponse" Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposErRetry& = 11
Public Const OposErClear& = 12
Public Const OposErContinueinput& = 13


Rem *///////////////////////////////////////////////////////////////////
Rem * "StatusUpdateEvent" Event: Common "Status" Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposSuePowerOnline& = 2001
Public Const OposSuePowerOff& = 2002
Public Const OposSuePowerOffline& = 2003
Public Const OposSuePowerOffOffline& = 2004


Rem *///////////////////////////////////////////////////////////////////
Rem * General Constants
Rem *///////////////////////////////////////////////////////////////////

Public Const OposForever& = -1
Public Const FT_WRN_FEAT_LEN_TOO_BIG = 261
Rem *End of OPOSALL.BAS*





