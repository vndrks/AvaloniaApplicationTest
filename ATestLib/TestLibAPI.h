#ifndef TestLibAPI_H
#define TestLibAPI_H

#ifdef _WIN32
	#ifdef	TEST_LIB_EXPORTS
		#define	TEST_LIB_API	__declspec(dllexport)
	#else
		#define	TEST_LIB_API	__declspec(dllimport)
	#endif

//#pragma warning(disable : 4251)
//#pragma warning(disable : 4995)
//#pragma warning(disable : 4996)
//#pragma warning(disable : 4819) // disable deprecated warning
//#pragma warning(disable : 4996)

#else
	#ifdef	TEST_LIB_EXPORTS
		#define	TEST_LIB_API	__declspec(dllexport)
	#else
		#define	TEST_LIB_API	__declspec(dllimport)
	#endif
#endif

#endif