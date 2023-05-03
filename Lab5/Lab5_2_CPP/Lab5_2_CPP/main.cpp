#include "headers/CMyString.h"
#include "headers/CMyStringIterator.h"
#include "CMyStringIterator.cpp"
#include <iostream>

// range based for
int rangeBasedFor()
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

int main(int argc, char* argv[])
{
	rangeBasedFor();
	return 0;
}




