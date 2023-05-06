#include "../Lab5_2_CPP/CMyStringIterator.cpp"
#include "../Lab5_2_CPP/headers/CMyString.h"

#include <gtest/gtest.h>

TEST(CMyStringReverseIteratorTest, TestDereferenceOperator) {
	CMyString str("hello");
	auto reverseIterator = str.rbegin();	
	ASSERT_EQ(*reverseIterator, '\0');
	ASSERT_EQ(*(++reverseIterator), 'o');	
}

TEST(CMyStringReverseIteratorTest, TestAdditionOperator) {
	CMyString str("abcd");
	auto first =  str.rbegin();
	auto second = str.rend();
	while (first != second)
	{
		++first;
		--second;
	}	
	ASSERT_EQ(*first, 'c');
}