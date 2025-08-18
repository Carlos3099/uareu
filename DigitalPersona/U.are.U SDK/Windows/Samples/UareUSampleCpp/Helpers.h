//////////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2016 DigitalPersona, Inc.
//
// U.are.U SDK 2.x
//
//////////////////////////////////////////////////////////////////////////////
//
// Sample code
//
// Helper functions
//
//////////////////////////////////////////////////////////////////////////////

#pragma once

#include <dpfpdd.h>
#include <dpfj.h>
#include <dpfj_compression.h>
#include <dpfj_quality.h>

void FormatErrorMsg(int nError, size_t nStringSize, LPTSTR tszString){
	_tcsncpy_s(tszString, nStringSize, _T(""), _TRUNCATE);
	if(_DP_FACILITY == (nError >> 16)){
		TCHAR* szError = NULL;
		switch(nError){
		case DPFPDD_E_NOT_IMPLEMENTED: szError = _T("API call is not implemented."); break;
		case DPFPDD_E_FAILURE: szError = _T("Unspecified failure."); break;
		case DPFPDD_E_NO_DATA: szError = _T("No data is available."); break;
		case DPFPDD_E_MORE_DATA: szError = _T("The memory allocated by the application is not big enough for the data which is expected."); break;
		case DPFPDD_E_INVALID_PARAMETER: szError = _T("One or more parameters passed to the API call are invalid."); break;
		case DPFPDD_E_INVALID_DEVICE: szError = _T("Reader handle is not valid."); break;
		case DPFPDD_E_DEVICE_BUSY: szError = _T("The API call cannot be completed because another call is in progress."); break;
		case DPFPDD_E_DEVICE_FAILURE: szError = _T("The reader is not working properly."); break;
		case DPFJ_E_INVALID_FID: szError = _T("FID is invalid."); break;
		case DPFJ_E_TOO_SMALL_AREA: szError = _T("Image is too small."); break;
		case DPFJ_E_INVALID_FMD: szError = _T("FMD is invalid."); break;
		case DPFJ_E_ENROLLMENT_IN_PROGRESS: szError = _T("Enrollment operation is in progress."); break;
		case DPFJ_E_ENROLLMENT_NOT_STARTED: szError = _T("Enrollment operation has not begun."); break;
		case DPFJ_E_ENROLLMENT_NOT_READY: szError = _T("Not enough in the pool of FMDs to create enrollment FMD."); break;
		case DPFJ_E_ENROLLMENT_INVALID_SET: szError = _T("Unable to create enrollment FMD with the collected set of FMDs."); break;
		case DPFJ_E_COMPRESSION_IN_PROGRESS: szError = _T("Compression or decompression operation is in progress"); break;
		case DPFJ_E_COMPRESSION_NOT_STARTED: szError = _T("Compression or decompression operation was not started."); break;
		case DPFJ_E_COMPRESSION_INVALID_WSQ_PARAMETER: szError = _T("One or more parameters passed for WSQ compression are invalid."); break;
		case DPFJ_E_COMPRESSION_WSQ_FAILURE: szError = _T("Unspecified error during WSQ compression or decompression."); break;
		case DPFJ_E_COMPRESSION_WSQ_LIB_NOT_FOUND: szError = _T("Library for WSQ compression is not found or not built-in."); break;
		case DPFJ_E_QUALITY_NO_IMAGE: szError = _T("Image is invalid or absent."); break;
		case DPFJ_E_QUALITY_TOO_FEW_MINUTIA: szError = _T("Too few minutia detected in the fingerprint image."); break;
		case DPFJ_E_QUALITY_FAILURE: szError = _T("Unspecified error during execution."); break;
		case DPFJ_E_QUALITY_LIB_NOT_FOUND: szError = _T("Library for image quality is not found or not built-in."); break;
		}
		_stprintf_s(tszString, nStringSize, _T("DP error code: 0x%x; %s"), nError, szError);
	}
	else{
		_stprintf_s(tszString, nStringSize, _T("error code: 0x%x"), nError);
	}
}

void ErrorMsg(LPCTSTR tszMessage, int nError, HWND hWnd = NULL){
	TCHAR tsz[MAX_PATH];
	_stprintf_s(tsz, _countof(tsz), _T("%s (code 0x%x) \n"), tszMessage, nError);
	FormatErrorMsg(nError, _countof(tsz) - _tcslen(tsz), tsz + _tcslen(tsz));
	MessageBox(hWnd, tsz, _T("Error"), MB_ICONSTOP);
}

void FormatQualityMsg(DPFPDD_QUALITY nQuality, size_t nStringSize, LPTSTR tszString){
	_tcsncpy_s(tszString, nStringSize, _T(""), _TRUNCATE);
	switch(nQuality){
	case DPFPDD_QUALITY_NO_FINGER: _stprintf_s(tszString, nStringSize, _T("not a finger detected (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_FAKE_FINGER: _stprintf_s(tszString, nStringSize, _T("fake finger detected (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_FINGER_TOO_LEFT: _stprintf_s(tszString,nStringSize, _T("finger is too far left on the reader (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_FINGER_TOO_RIGHT: _stprintf_s(tszString, nStringSize, _T("finger is too far right on the reader (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_FINGER_TOO_HIGH: _stprintf_s(tszString, nStringSize, _T("finger is too high on the reader (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_FINGER_TOO_LOW: _stprintf_s(tszString, nStringSize, _T("finger is too low in the reader (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_FINGER_OFF_CENTER: _stprintf_s(tszString, nStringSize, _T("finger is not centered on the reader (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_SCAN_SKEWED: _stprintf_s(tszString, nStringSize, _T("scan is skewed too muc (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_SCAN_TOO_SHORT: _stprintf_s(tszString, nStringSize, _T("scan is too short (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_SCAN_TOO_LONG: _stprintf_s(tszString, nStringSize, _T("scan is too long (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_SCAN_TOO_SLOW: _stprintf_s(tszString, nStringSize, _T("speed of the swipe is too slow (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_SCAN_TOO_FAST: _stprintf_s(tszString, nStringSize, _T("speed of the swipe is too fast (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_SCAN_WRONG_DIRECTION: _stprintf_s(tszString, nStringSize, _T("direction of the swipe is wrong (code %d)"), nQuality); break;
	case DPFPDD_QUALITY_READER_DIRTY: _stprintf_s(tszString, nStringSize, _T("reader needs cleaning (code %d)"), nQuality); break;
	default: _stprintf_s(tszString, nStringSize, _T("unknown quality code (code %d)"), nQuality);
	}
}

void QualityMsg(DPFPDD_QUALITY nQuality){
	TCHAR tsz[MAX_PATH];
	FormatQualityMsg(nQuality, MAX_PATH, tsz);
	MessageBox(NULL, tsz, _T("Bad image quality"), MB_ICONSTOP);
}


int StringToLPTSTR(const char* szStr, LPTSTR tszStr, int nStrLength){
	if(1 == sizeof(TCHAR)){
		int length = static_cast<int>(strlen(szStr));
		//mimic MultiByteToWideChar() behavior
		if(0 == nStrLength){
			SetLastError(0);
			return length + 1;
		}
		else if(nStrLength <= length){
			SetLastError(ERROR_INSUFFICIENT_BUFFER);
			return 0;
		}
		else{
			strncpy_s((char*)tszStr, nStrLength, szStr, length + 1);
			return length + 1;
		}
	}
	else{
		return MultiByteToWideChar(CP_ACP, 0, szStr, -1, tszStr, nStrLength);
	}
}

int LPTSTRToString(LPCTSTR tszStr, char* szStr, int nStrLength){
	if(1 == sizeof(TCHAR)){
		int length =  static_cast<int>(_tcslen(tszStr));
		//mimic WideCharToMultiByte() behavior
		if(0 == nStrLength){
			SetLastError(0);
			return length + 1;
		}
		else if(nStrLength <= length){
			SetLastError(ERROR_INSUFFICIENT_BUFFER);
			return 0;
		}
		else{
			strncpy_s(szStr, nStrLength, (char*)tszStr, length + 1);
			return length + 1;
		}
	}
	else{
		return WideCharToMultiByte(CP_ACP, 0, tszStr, -1, szStr, nStrLength, NULL, NULL);
	}
}

unsigned int GetFirstDPI(DPFPDD_DEV dev)
{
    int DPI = 0;
    //get required size for the capabilities structure
    unsigned int size = sizeof(unsigned int);
    int result = dpfpdd_get_device_capabilities(dev,(DPFPDD_DEV_CAPS*) &size);
    if(result != DPFPDD_E_MORE_DATA)
    {
        ErrorMsg(_T("error when calling dpfpdd_get_device_capabilities()"), result);
        return DPI;
    }

    DPFPDD_DEV_CAPS* pCaps = (DPFPDD_DEV_CAPS*)new char[size];
    if(!pCaps)
    {
        return DPI;
    }
    pCaps->size = size;

    result = dpfpdd_get_device_capabilities(dev, pCaps);
    if(result != DPFPDD_SUCCESS)
    {
        ErrorMsg(_T("error when calling dpfpdd_get_device_capabilities()"), result);
    }
    else
    {
        DPI = pCaps->resolutions[0];
    }
    delete pCaps;
    return DPI;
}