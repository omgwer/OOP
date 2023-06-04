 #include "../Lab6_2/StringList.cpp"
 #include "gtest/gtest.h"
 #include "../Lab6_2/StringList.h"

TEST(StringListTest, BeginEndIterators) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");

	CMyIterator<ListElement> itBegin = list.begin();
	auto dereferenceBegin = *itBegin;
	ASSERT_EQ("hello", dereferenceBegin);
}

TEST(StringListTest, BeginIterator) {
	StringList list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");
	
	CMyIterator<ListElement> itBegin = list.begin();	
	ASSERT_EQ("hello", (*itBegin));
	++itBegin;
	ASSERT_EQ("world", (*itBegin));
	--itBegin;
	ASSERT_EQ("hello", (*itBegin));
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

TEST(StringListTest, InsertTest) {
	StringList list;
	list.PushFront("world");
	list.PushFront("hello");

	auto it = list.cbegin();

	list.Insert(it, "some");
	
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("somehelloworld", ss.str());
}

TEST(StringListTest, InsertTestEmptyList) {
	StringList list;
	
	auto it = list.cbegin();

	list.Insert(it, "some");
	
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("some", ss.str());
}

TEST(StringListTest, CopyEqualsOperator) {
	StringList list;
	list.PushBack("some");
	list.PushBack("one");
	list.PushBack("kek");

	StringList list2 = list;
	
	std::stringstream ss1;
	for (const ListElement& listElement : list)
	{
		ss1 << listElement.value;
	}

	std::stringstream ss2;
	for (const ListElement& listElement : list2)
	{
		ss2 << listElement.value;
	}
	ASSERT_EQ(ss2.str(), ss1.str());
}

TEST(StringListTest, MoveEqualOperator) {
	StringList list;
	list.PushBack("some");
	list.PushBack("one");
	list.PushBack("kek");

	StringList list2 = std::move(list);
	
	std::stringstream ss1;
	for (const ListElement& listElement : list)
	{
		ss1 << listElement.value;
	}

	std::stringstream ss2;
	for (const ListElement& listElement : list2)
	{
		ss2 << listElement.value;
	}
	ASSERT_EQ("", ss1.str());
	ASSERT_EQ("someonekek", ss2.str());
}


TEST(StringListTest, EraseFirstElement) {
	StringList list;
	list.PushBack("some");	

	list.Erase(list.begin());	
	
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("", ss.str());
	ASSERT_EQ(0, list.GetLength());
}

TEST(StringListTest, EraseEmptyList) {
	StringList list;
	
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("", ss.str());
	ASSERT_THROW(list.Erase(list.begin()), std::logic_error, "Exception dont throw!");
}

TEST(StringListTest, TwoElements) {
	StringList list;
	list.PushBack("some");	
	list.PushBack("one");	

	list.Erase(list.begin());	
	
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("one", ss.str());
	ASSERT_EQ(1, list.GetLength());
}

TEST(StringListTest, TwoElements_DeleteLast) {
	StringList list;
	list.PushBack("some");	
	list.PushBack("one");	

	list.Erase(++list.begin());	
	
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("some", ss.str());
	ASSERT_EQ(1, list.GetLength());
}

TEST(StringListTest, ThreeElements_DeleteLast) {
	StringList list;
	list.PushBack("some");	
	list.PushBack("one");	
	list.PushBack("cat");	

	list.Erase(++list.begin());	
	
	std::stringstream ss;
	for (const ListElement& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("somecat", ss.str());
	ASSERT_EQ(2, list.GetLength());
}

TEST(StringListTest, ReverseIteratorTest) {
	StringList test;
	test.PushBack("value");
	test.PushBack("efim");
	test.PushBack("test");
	
	auto rbegin = test.rbegin();
	auto rend = test.rend();
	
	std::stringstream ss;
	while (rbegin != rend)
	{
		ss << (*rbegin).value;
		++rbegin;
	}	
	ASSERT_EQ("testefimvalue", ss.str());
}






	
