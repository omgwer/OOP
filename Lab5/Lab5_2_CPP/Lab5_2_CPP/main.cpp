#include "headers/CMyString.h"
#include <iostream>


using Iterator = CMyStringIterator<char>;
using ConstIterator = CMyStringIterator<const char>;
using ReverseIterator = std::reverse_iterator<Iterator>;
using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

int RangeBasedFor()
{
	CMyString str("Hello, world!");

	// range-based for loop
	for (const auto ch : str)
	{
		std::cout << ch << " ";
	}
	std::cout << std::endl;
	return 0;
}

void TestForwardIterators()
{
	CMyString str("Hello, world!");

	auto bgn = str.begin();
	auto en = str.end();

	CMyStringIterator<char> test = bgn + 3;

	while (test != en)
	{
		std::cout << *(test) << " ";
		test++;
	}
	std::cout << *(test) << " ";
	std::cout << std::endl;
}

void TestReverseIterators()
{
	CMyString str("Hello, world!");

	ReverseIterator rbegin = str.rbegin();
	ReverseIterator rend = str.rend();

	while (rbegin != rend)
	{
		std::cout << *(rbegin) << " ";
		++rbegin;
	}
	std::cout << std::endl;
}


void Input(Iterator it)
{
	auto test = 5;
}

void InputConst(ConstIterator it)
{
	auto test = 5;
}

void TestOverloadCastIterators()
{
	CMyString str("Hello, world!");
	Iterator iterator = str.begin();
	ConstIterator constIterator = str.сbegin();
	auto itToConst = static_cast<ConstIterator>(iterator);
	auto itToIt = static_cast<Iterator>(iterator);
	auto constToConst = static_cast<ConstIterator>(constIterator);
	auto constToIt = static_cast<Iterator>(constIterator);

	InputConst(iterator);
	InputConst(constIterator);
	Input(iterator);
	Input(constIterator);

}

int main(int argc, char* argv[])
{
	TestOverloadCastIterators();
	//RangeBasedFor();
	//TestForwardIterators();
	//TestReverseIterators();
	return 0;

}
