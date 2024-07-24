#include "pch.h"
#include "KcTest.h"

TEST_LIB::KcTest::KcTest()
{
}

TEST_LIB::KcTest::~KcTest()
{
}

string TEST_LIB::KcTest::GetTestLibInfo()
{
	string path = __FILE__;
	return "KcTest::GetTestLibInfo path : " +  path;
}
