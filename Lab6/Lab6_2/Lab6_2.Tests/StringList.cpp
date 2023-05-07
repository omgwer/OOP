#include "gtest/gtest.h"
#include "../Lab6_2/headers/StringList.h"

TEST(StringListTest, PushBackTest) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	ASSERT_EQ(list.GetLength(), 2);
}

TEST(StringListTest, DefaultConstructor) {
	StringList list;
	ASSERT_EQ(list.GetLength(), 0);
}

TEST(StringListTest, PushFrontTest) {
	StringList list;
	list.PushFront("world");
	list.PushFront("hello");
	ASSERT_EQ(list.GetLength(), 2);
}

TEST(StringListTest, IsEmptyTest) {
	StringList list;
	ASSERT_TRUE(list.IsEmpty());
	list.PushBack("hello");
	ASSERT_FALSE(list.IsEmpty());
}

TEST(StringListTest, ClearTest) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.Clear();
	ASSERT_EQ(list.GetLength(), 0);
	ASSERT_TRUE(list.IsEmpty());
}