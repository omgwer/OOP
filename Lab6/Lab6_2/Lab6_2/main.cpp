#include "StringList.h"
#include <iostream>
#include <list>
#include <vector>

using Iterator = CMyIterator<ListElement>;
using ConstIterator = CMyIterator<const ListElement>;
using ReverseIterator = std::reverse_iterator<Iterator>;
using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

int main(int argc, char* argv[])
{
	//StringList test2;
	// test2.PushBack("cat");
	// test2.PushBack("efim");
	// test2.PushBack("grumpy");

	StringList test;
	test.PushFront("jerry");
	test.PushFront("mouse");
	test.PushFront("someone");

	auto iterator = test.begin();
	auto constIterator = test.cbegin();

	auto itToConst = static_cast<ConstIterator>(iterator);
	auto itToIt = static_cast<Iterator>(iterator);
	auto constToConst = static_cast<ConstIterator>(constIterator);
	auto constToIt = static_cast<Iterator>(constIterator);

	auto begin = test.cbegin();
	auto end = test.cend();

	std::list<std::string> sm{ "some", "one" };

	sm.erase(sm.begin());
	sm.insert(sm.begin(), "some");

	auto tt = sm.cbegin();
	
	begin = test.cbegin();
	end = test.cend();
	
	while (begin != end)
	{
		std::cout << *begin << std::endl;
		++begin;
	}

	return 0;
}