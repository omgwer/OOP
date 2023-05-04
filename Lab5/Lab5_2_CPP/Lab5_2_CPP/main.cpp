#include "CMyStringIterator.cpp"
#include "CMyStringReverseIterator.cpp"
#include "headers/CMyString.h"
#include <iostream>

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
		++test;
	}
	std::cout << *(test) << " ";
	std::cout << std::endl;
}

void TestReverseIterators()
{
	CMyString str("Hello, world!");

	auto bgn = str.rbegin();
	auto en = str.rend();
	
	
	 while (bgn != en)
	 {
	 	std::cout << *(bgn) << " ";
	 	++bgn;
	 }
	std::cout << *(bgn) << " ";
	std::cout << std::endl;
}

int main(int argc, char* argv[])
{
	RangeBasedFor();
	TestForwardIterators();
	TestReverseIterators();
	return 0;
}


// #include <cassert>
//
// class MyIterator {
// public:
// 	// Конструкторы, методы и т.д.
//
// 	// Перегрузка префиксной версии оператора ++
// 	MyIterator& operator++() {
// 		assert(ptr_ < end_ && "Iterator out of range!"); // проверка границ
// 		++ptr_;
// 		return *this;
// 	}
//
// private:
// 	int* ptr_; // Указатель на элемент в массиве
// 	int* end_; // Указатель на конец массива
// };
