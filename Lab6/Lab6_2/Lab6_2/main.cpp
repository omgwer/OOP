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
	test.Clear();
	std::cout <<  "test" << std::endl;
    return 0;
}
