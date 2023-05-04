#include "headers/StringList.h"

#include <iostream>

// TODO: Для лабы 7 некоторые типы не имеют конструкторы по умолчанию
int main(int argc, char* argv[])
{
    auto test = new StringList();

	test->PushBack("value");
	test->PushBack("polina");
	test->PushFront("test");
	std::cout <<  "test" << std::endl;
    return 0;
}
