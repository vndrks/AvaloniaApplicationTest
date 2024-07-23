// dllmain.cpp : Defines the initialization routines for the DLL.

#include "pch.h"


BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        // TRACE0("AvaUITestLib.dll Initializing. \n");

    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        // TRACE0("AvaUITestLib.dll Terminating. \n");
        break;
    }
    return TRUE;
}

