#pragma once
#include "TestLibAPI.h"

#include <string>

using namespace std;

namespace TEST_LIB
{

class TEST_LIB_API KcTest
{
public:
	KcTest();
	virtual ~KcTest();

public:
	string GetTestLibInfo();
};

}



