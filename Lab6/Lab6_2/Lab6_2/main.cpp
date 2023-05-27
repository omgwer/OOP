#include "StringList.h"
#include <iostream>

using Iterator = CMyIterator<ListElement>;
using ConstIterator = CMyIterator<const ListElement>;
using ReverseIterator = std::reverse_iterator<Iterator>;
using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

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

	auto iterator = test.begin();
	auto constIterator = test.cbegin();

	auto itToConst = static_cast<ConstIterator>(iterator);
	auto itToIt = static_cast<Iterator>(iterator);
	auto constToConst = static_cast<ConstIterator>(constIterator);
	auto constToIt = static_cast<Iterator>(constIterator);
	
	auto begin = test.cbegin();
	auto end = test.cend();
	
	auto rer = test.Insert(begin, "some");
	auto lol = test.Insert(end, "end_cat");

	auto some1 = test.end();
	std::cout << (*some1).value << std::endl;
	
	begin = test.cbegin();
	end = test.cend();
 	while ( begin != end)
	{
		std::cout << (*begin).value << std::endl;
		++begin;
	}

	return 0;
}
