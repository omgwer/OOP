#include "gtest/gtest.h"
#include "../Lab7_2/CMyList.h"


class MyChar
{
public:
	MyChar() = delete;

	explicit MyChar(const char ch)
	{
		classChar = ch;
	}
	char classChar;
};

TEST(CMyListTest, BeginEndIterators) {
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");

	auto itBegin = list.begin();
	auto dereferenceBegin = *itBegin;
	ASSERT_EQ("hello", dereferenceBegin.value);
}

TEST(CMyListTest, BeginIterator) {
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");
	
	auto itBegin = list.begin();	
	ASSERT_EQ("hello", (*itBegin).value);
	++itBegin;
	ASSERT_EQ("world", (*itBegin).value);
	--itBegin;
	ASSERT_EQ("hello", (*itBegin).value);
}

TEST(CMyListTest, ReverseDifference) {
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");
	
	auto itBegin = list.begin();
	auto itEnd = list.end();
	ASSERT_EQ(0, itBegin - itEnd);
	ASSERT_EQ(0, itBegin - itBegin);
	ASSERT_EQ(0, itEnd - itEnd);
}

// range-based for
TEST(CMyListTest, RangeBasedForEmptyList) {
	CMyList<std::string> list;
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("", ss.str());
}

TEST(CMyListTest, NotEmpty) {
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushFront("world");
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("worldhello", ss.str());
}

TEST(CMyListTest, InsertTest) {
	CMyList<std::string> list;
	list.PushFront("world");
	list.PushFront("hello");

	auto it = list.begin();

	list.Insert(it, "some");
	
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("somehelloworld", ss.str());
}

TEST(CMyListTest, InsertTestEmptyList) {
	CMyList<std::string> list;
	
	auto it = list.begin();

	list.Insert(it, "some");
	
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("some", ss.str());
}

TEST(CMyListTest, CopyEqualsOperator) {
	CMyList<std::string> list;
	list.PushBack("some");
	list.PushBack("one");
	list.PushBack("kek");

	CMyList<std::string> list2 = list;
	
	std::stringstream ss1;
	for (const auto& listElement : list)
	{
		ss1 << listElement.value;
	}

	std::stringstream ss2;
	for (const auto& listElement : list2)
	{
		ss2 << listElement.value;
	}
	ASSERT_EQ(ss2.str(), ss1.str());
}

TEST(CMyListTest, MoveEqualOperator) {
	CMyList<std::string> list;
	list.PushBack("some");
	list.PushBack("one");
	list.PushBack("kek");

	CMyList<std::string> list2 = std::move(list);
	
	std::stringstream ss1;
	for (const auto& listElement : list)
	{
		ss1 << listElement.value;
	}

	std::stringstream ss2;
	for (const auto& listElement : list2)
	{
		ss2 << listElement.value;
	}
	ASSERT_EQ("", ss1.str());
	ASSERT_EQ("someonekek", ss2.str());
}


TEST(CMyListTest, EraseFirstElement) {
	CMyList<std::string> list;
	list.PushBack("some");	

	list.Erase(list.begin());	
	
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("", ss.str());
	ASSERT_EQ(0, list.GetLength());
}

TEST(CMyListTest, EraseEmptyList) {
	CMyList<std::string> list;

	list.Erase(list.begin());	
	
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("", ss.str());
}

TEST(CMyListTest, TwoElements) {
	CMyList<std::string> list;
	list.PushBack("some");	
	list.PushBack("one");	

	list.Erase(list.begin());	
	
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("one", ss.str());
	ASSERT_EQ(1, list.GetLength());
}

TEST(CMyListTest, TwoElements_DeleteLast) {
	CMyList<std::string> list;
	list.PushBack("some");	
	list.PushBack("one");	

	list.Erase(++list.begin());	
	
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("some", ss.str());
	ASSERT_EQ(1, list.GetLength());
}

TEST(CMyListTest, ThreeElements_DeleteLast) {
	CMyList<std::string> list;
	list.PushBack("some");	
	list.PushBack("one");	
	list.PushBack("cat");	

	list.Erase(++list.begin());	
	
	std::stringstream ss;
	for (const auto& listElement : list)
	{
		ss << listElement.value;
	}
	ASSERT_EQ("somecat", ss.str());
	ASSERT_EQ(2, list.GetLength());
}

TEST(CMyListTest, ReverseIteratorTest) {
	CMyList<std::string> test;
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