#include "headers/CMyString.h"
#include "headers/CMyStringIterator.h"
#include "CMyStringIterator.cpp"
#include <iostream>

// range based for
int RangeBasedFor()   // TODO: посмотреть на работу с итераторами .begin() .end()
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

void TestFuct()
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
}

int main(int argc, char* argv[])
{
	TestFuct();
	//RangeBasedFor();
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



