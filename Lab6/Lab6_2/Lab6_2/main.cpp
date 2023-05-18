#include "StringList.h"
#include <iostream>
#include <list>
//
// // TODO: Для лабы 7 некоторые типы не имеют конструкторы по умолчанию
int main(int argc, char* argv[])
{
	// StringList test;
	// test.PushBack("cat");
	// test.PushBack("efim");
	// test.PushBack("grumpy");

	StringList test;
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
