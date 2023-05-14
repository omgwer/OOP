#include "StringList.h"
#include <iostream>
#include <list>
//
// // TODO: Для лабы 7 некоторые типы не имеют конструкторы по умолчанию
int main(int argc, char* argv[])
{
	StringList test;
	test.PushBack("cat");
	test.PushBack("efim");
	test.PushBack("grumpy");

	// StringList test;
	// test.PushFront("cat");
	// test.PushFront("efim");
	// test.PushFront("grumpy");

	auto rbegin = test.begin();
	auto rend = test.end();

	while (rbegin != rend)
	{
		std::cout << (*rbegin).value << std::endl;
		++rbegin;
	}

	return 0;
}
