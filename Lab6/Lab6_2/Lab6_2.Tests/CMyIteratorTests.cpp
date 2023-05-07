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
	auto dereferenceBegin = *itBegin;
	ASSERT_EQ("hello", dereferenceBegin.value);
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

TEST(StringListTest, ReverseDifference) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");
	
	CMyIterator<ListElement> itBegin = list.begin();
	CMyIterator<ListElement> itEnd = list.end();
	ASSERT_EQ(0, itBegin - itEnd);
	ASSERT_EQ(0, itBegin - itBegin);
	ASSERT_EQ(0, itEnd - itEnd);
}

// range-based for
TEST(StringListTest, RangeBasedForEmptyList) {
	StringList list;
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("", ss.str());
}

TEST(StringListTest, NotEmpty) {
	StringList list;
	list.PushBack("hello");
	list.PushFront("world");
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("worldhello", ss.str());
}