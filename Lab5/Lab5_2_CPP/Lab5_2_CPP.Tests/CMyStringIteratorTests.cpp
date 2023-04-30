#include "../Lab5_2_CPP/CMyStringIterator.cpp"
#include "../Lab5_2_CPP/headers/CMyString.h"
#include <gtest/gtest.h>

TEST(CMyStringIteratorTest, TestBegin) {
	CMyString str("hello");
	auto iter = str.begin();
	ASSERT_EQ(*iter, 'h');
}

TEST(CMyStringIteratorTest, TestEnd) {
	CMyString str("hello");
	auto iter = str.end();
	ASSERT_EQ(*(--iter), 'o');
}

TEST(CMyStringIteratorTest, TestIncrement) {
	CMyString str("hello");
	auto iter = str.begin();
	++iter;
	ASSERT_EQ(*iter, 'e');
}

TEST(CMyStringIteratorTest, TestDecrement) {
	CMyString str("hello");
	auto iter = str.end();
	--iter;
	ASSERT_EQ(*iter, 'o');
}

TEST(CMyStringIteratorTest, TestDereference) {
	CMyString str("hello");
	auto iter = str.begin();
	ASSERT_EQ(*iter, 'h');
	++iter;
	ASSERT_EQ(*iter, 'e');
	++iter;
	ASSERT_EQ(*iter, 'l');
	++iter;
	ASSERT_EQ(*iter, 'l');
	++iter;
	ASSERT_EQ(*iter, 'o');
}