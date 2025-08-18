Attribute VB_Name = "DPErrors"

'**************** Copyright (c) 1996-2012, DigitalPersona, Inc. *************************/
' File:ErrorCodes.bas

'Contents:
'It contains all the error codes supported by DP OneTouch SDK.
'****************************************************************************************/


Rem * /**************** return codes common to all the toolkit components *****************/
Public Const FT_OK = 0
Rem * Errors: negative numbers. Range: [-1, -255] */

Public Const FT_ERR_NO_INIT = -1
Public Const FT_ERR_INVALID_PARAM = -2
Public Const FT_ERR_NOT_IMPLEMENTED = -3
Public Const FT_ERR_IO = -4
Public Const FT_ERR_NO_MEMORY = -7
Public Const FT_ERR_INTERNAL = -8
Public Const FT_ERR_BAD_INI_SETTING = -9
Public Const FT_ERR_UNKNOWN_DEVICE = -10
Public Const FT_ERR_INVALID_BUFFER = -11
Public Const FT_ERR_FEAT_LEN_TOO_SHORT = -16
Public Const FT_ERR_INVALID_CONTEXT = -17
Public Const FT_ERR_INVALID_FTRS_TYPE = -29
Public Const FT_ERR_FTRS_INVALID = -32
Public Const FT_ERR_UNKNOWN_EXCEPTION = -33

Rem * /* Warnings: positive numbers. Range: [1, 255]*/
Public Const FT_WRN_NO_INIT = 1
Public Const FT_WRN_INTERNAL = 8
Public Const FT_WRN_KEY_NOT_FOUND = 9
Public Const FT_WRN_UNKNOWN_DEVICE = 11
Public Const FT_WRN_TIMEOUT = 12

Rem */**************************** Direct IO Event Return Codes ***********************/

Public Const DP_DIOE_DISCONNECT = 1
Public Const DP_DIOE_RECONNECT = 2
Public Const DP_DIOE_FINGER_TOUCHED = 3
Public Const DP_DIOE_FINGER_GONE = 4
Public Const DP_DIOE_IMAGE_READY = 5
Public Const DP_DIOE_SAMPLE_QUALITY = 6
Public Const DP_DIOE_ENROLL_FEATURES_ADDED = 7
Public Const DP_DIOE_OPERATION_STOPPED = 8


Rem */**************************** Image quality constants ****************/
Public Const DP_QUALITY_GOOD = 0            ' The image is of good quality.
Public Const DP_QUALITY_NONE = 1           ' There is no image.
Public Const DP_QUALITY_TOOLIGHT = 2        ' The image is too light.
Public Const DP_QUALITY_TOODARK = 3         'The image is too dark.
Public Const DP_QUALITY_TOONOISY = 4        ' The image is too noisy.
Public Const DP_QUALITY_LOWCONTR = 5        ' The image contrast is too low.
Public Const DP_QUALITY_FTRNOTENOUGH = 6    ' The image does not contain enough information.
Public Const DP_QUALITY_NOCENTRAL = 7       'The image is not centered.

Rem */**************************** StatusUpdateEvent constants ****************/
Public Const BIO_SUE_RAW_DATA = 1
 



