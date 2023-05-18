#include <iostream>
#include "CMyList.h"

int main()
{
	CMyList<std::string> test;
	
	test.PushFront("cat");
	test.PushFront("efim");
	test.PushFront("grumpy");
	

	auto rbegin = test.begin();
	auto rend = test.end();

	auto rer = test.Insert(rbegin, "some");
	auto rer1 = test.Insert(rend, "kek");
	rbegin = test.begin();
	rend = test.end();
	while (rbegin != rend)
	{
		std::cout << (*rbegin).value << std::endl;
		++rbegin;
	}
	

	return 0;	
}

