#include <iostream>
#include "CMyList.h"

int main()
{
	CMyList<std::string> test;
	
	test.PushFront("cat");
	test.PushFront("efim");
	test.PushFront("grumpy");
	

	auto rbegin = test.cbegin();
	auto rend = test.cend();

	auto rer = test.Insert(rbegin, "some");
	auto rer1 = test.Insert(rend, "kek");
	rbegin = test.cbegin();
	rend = test.cend();
	while (rbegin != rend)
	{
		std::cout << (*rbegin).value << std::endl;
		++rbegin;
	}
	

	return 0;	
}

