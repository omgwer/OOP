#include "gtest/gtest.h"
#include "../Lab6_2/StringList.cpp"
#include "../Lab6_2/headers/StringList.h"

TEST(StringListTest, asd) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	ASSERT_EQ(list.GetLength(), 2);
}