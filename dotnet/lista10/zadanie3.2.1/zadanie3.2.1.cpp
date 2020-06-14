#include <iostream>
#include <string>
#include <windows.h>
#include <shlobj.h>
#include <tchar.h>
#include <sysinfoapi.h>

using namespace std;

int main()
{
	TCHAR path[MAX_PATH];
	SHGetFolderPath(NULL, CSIDL_DESKTOPDIRECTORY, NULL, SHGFP_TYPE_CURRENT, path);
	_tcscat_s(path, MAX_PATH, L"\\plik.txt");

	SYSTEMTIME time = { 0 };
	GetLocalTime(&time);
	string date = "" + to_string(time.wDay) + "." + to_string(time.wMonth) + "." + to_string(time.wYear);


	HANDLE hFile = CreateFile(path, GENERIC_WRITE, 0, NULL, OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	WriteFile(hFile, date.c_str(), date.size(), NULL, NULL);

	ShellExecute(NULL, L"print", path, NULL, NULL, NULL);
}