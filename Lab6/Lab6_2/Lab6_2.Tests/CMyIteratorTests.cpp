#include "../Lab6_2/StringList.cpp"
#include "../Lab6_2/CMyIterator.cpp"
#include "gtest/gtest.h"
#include "../Lab6_2/headers/StringList.h"

TEST(StringListTest, BeginEndIterators) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");

	CMyIterator<ListElement> itBegin = list.begin();
	CMyIterator<ListElement> itEnd = list.end();
	auto dereferenceBegin = *itBegin;
	auto dereferenceEnd = *itEnd;
	ASSERT_EQ("hello", dereferenceBegin.value);
	ASSERT_EQ("test", dereferenceEnd.value);	
}

TEST(StringListTest, BeginIterator) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");
	
	CMyIterator<ListElement> itBegin = list.begin();	
	ASSERT_EQ("hello", (*itBegin).value);
	++itBegin;
	ASSERT_EQ("world", (*itBegin).value);
	--itBegin;
	ASSERT_EQ("hello", (*itBegin).value);
}

TEST(StringListTest, EndIterator) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");
	
	CMyIterator<ListElement> itBegin = list.end();	
	ASSERT_EQ("test", (*itBegin).value);
	--itBegin;
	ASSERT_EQ("efim", (*itBegin).value);
	++itBegin;
	ASSERT_EQ("test", (*itBegin).value);
}

TEST(StringListTest, Difference) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");
	
	CMyIterator<ListElement> itBegin = list.begin();
	CMyIterator<ListElement> itEnd = list.end();
	ASSERT_EQ(list.GetLength(), itEnd - itBegin);
}

TEST(StringListTest, ReverseDifference) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");
	
	CMyIterator<ListElement> itBegin = list.begin();
	CMyIterator<ListElement> itEnd = list.end();
	ASSERT_EQ(-list.GetLength(), itBegin - itEnd);
	ASSERT_EQ(0, itBegin - itBegin);
	ASSERT_EQ(0, itEnd - itEnd);
}