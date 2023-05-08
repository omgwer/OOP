#include <iostream>
#include "CMyList.h"

int main()
{
	CMyList<std::string> test;
	test.PushBack("value");
	test.PushBack("efim");
	test.PushBack("test");
	

	return 0;	
}

