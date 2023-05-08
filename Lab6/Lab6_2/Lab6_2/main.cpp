#include "CMyIterator.cpp"
#include "StringList.h"
#include <iostream>
#include <list>
//
// // TODO: Для лабы 7 некоторые типы не имеют конструкторы по умолчанию
int main(int argc, char* argv[])
{
	 StringList test;
	test.PushBack("value");
	test.PushBack("efim");
	test.PushBack("test");

	auto rbegin = test.rbegin();
	auto rend = test.rend();


	
	while (rbegin != rend)
	{
		std::cout << (*rbegin).value << std::endl;
		++rbegin;
	}


	return 0;
}
