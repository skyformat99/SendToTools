#include "stdafx.h"


extern "C" {
	DllImport int libmain(LPCWSTR pAppName);
}

//int libmain();
int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPWSTR    lpCmdLine,
	_In_ int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);
	// return AfxWinInit(hInstance, hPrevInstance, lpCmdLine, nCmdShow);
	return libmain(L"MoveTo");
}