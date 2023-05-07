#include "CMyIterator.cpp"
#include "headers/StringList.h"
#include <iostream>

// TODO: Для лабы 7 некоторые типы не имеют конструкторы по умолчанию
int main(int argc, char* argv[])
{
	// auto test = new StringList();
	StringList test;
	test.PushBack("value");
	test.PushBack("polina");
	test.PushBack("test");

	auto begin = test.begin();
	auto end = test.end();
	while (begin != end)
	{
		std::cout << (*begin).value << std::endl;
		++begin;
	}

	for (const ListElement& listElement : test)
	{
		std::cout << listElement.value << std::endl;
	}

	return 0;
}
