#include "CMyStringIterator.cpp"
#include "headers/CMyString.h"
#include <iostream>

using Iterator = CMyStringIterator<char>;
using ConstIterator = CMyStringIterator<const char>;
using ReverseIterator = std::reverse_iterator<Iterator>;
using ConstReverseIterator =  std::reverse_iterator<ConstIterator>;

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

	auto test = bgn + 3;

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

int main(int argc, char* argv[])
{
	RangeBasedFor();
	TestForwardIterators();
	TestReverseIterators();
	return 0;
}
