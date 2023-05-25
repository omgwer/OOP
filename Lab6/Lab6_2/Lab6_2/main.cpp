#include "StringList.h"
#include <iostream>
#include <list>
//
int main(int argc, char* argv[])
{
	StringList test2;
	 test2.PushBack("cat");
	 test2.PushBack("efim");
	 test2.PushBack("grumpy");
	

	StringList test(test2);

//	StringList test;
	// test.PushFront("jerry");
	// test.PushFront("mouse");
	// test.PushFront("someone");
	
	auto begin = test.cbegin();
	auto end = test.cend();
	
	auto rer = test.Insert(begin, "some");
	auto lol = test.Insert(end, "end_cat");
	begin = test.cbegin();
	end = test.cend();
 	while ( begin != end)
	{
		std::cout << (*begin).value << std::endl;
		++begin;
	}

	return 0;
}
