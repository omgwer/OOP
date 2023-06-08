#include "gtest/gtest.h"
#include "../Lab7_2/CMyList.h"

//: TODO добавить проверку корректности вызова дестуктора у ListElement ( использовать +1 в констукртоа -1 в деструкторе, в конце должно быть 0)
//: TODO: добавить проверку констуктора по умолчанию ( запретить default constructor)

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

TEST(CMyListTest, BeginEndIterators)
{
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");

	auto itBegin = list.begin();
	ASSERT_EQ("hello", (*itBegin).Value());
}

TEST(CMyListTest, BeginIterator)
{
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");
	list.PushBack("efim");
	list.PushBack("test");

	auto itBegin = list.begin();
	ASSERT_EQ("hello", (*itBegin).Value());
	++itBegin;
	ASSERT_EQ("world", (*itBegin).Value());
	--itBegin;
	ASSERT_EQ("hello", (*itBegin).Value());
}

// range-based for
TEST(CMyListTest, RangeBasedForEmptyList)
{
	CMyList<std::string> list;
	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("", ss.str());
}

TEST(CMyListTest, NotEmpty)
{
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushFront("world");
	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("worldhello", ss.str());
}

TEST(CMyListTest, InsertTest)
{
	CMyList<std::string> list;
	list.PushFront("world");
	list.PushFront("hello");

	auto it = list.cbegin();

	list.Insert(it, "some");

	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("somehelloworld", ss.str());
}

TEST(CMyListTest, InsertTestEmptyList)
{
	CMyList<std::string> list;

	auto it = list.cbegin();

	list.Insert(it, "some");

	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("some", ss.str());
}

TEST(CMyListTest, CopyEqualsOperator)
{
	CMyList<std::string> list;
	list.PushBack("some");
	list.PushBack("one");
	list.PushBack("kek");

	CMyList<std::string> list2 = list;

	std::stringstream ss1;
	for (auto& listElement : list)
	{
		ss1 << listElement.Value();
	}

	std::stringstream ss2;
	for (auto& listElement : list2)
	{
		ss2 << listElement.Value();
	}
	ASSERT_EQ(ss2.str(), ss1.str());
}

TEST(CMyListTest, MoveEqualOperator)
{
	CMyList<std::string> list;
	list.PushBack("some");
	list.PushBack("one");
	list.PushBack("kek");

	CMyList<std::string> list2 = std::move(list);

	std::stringstream ss1;
	for (auto& listElement : list)
	{
		ss1 << listElement.Value();
	}

	std::stringstream ss2;
	for (auto& listElement : list2)
	{
		ss2 << listElement.Value();
	}
	ASSERT_EQ("", ss1.str());
	ASSERT_EQ("someonekek", ss2.str());
}


TEST(CMyListTest, EraseFirstElement)
{
	CMyList<std::string> list;
	list.PushBack("some");

	list.Erase(list.begin());

	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("", ss.str());
	ASSERT_EQ(0, list.GetLength());
}

TEST(CMyListTest, EraseEmptyList)
{
	CMyList<std::string> list;

	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("", ss.str());
	ASSERT_THROW(list.Erase(list.begin()), std::exception, "Exception dont throw!");
}

TEST(CMyListTest, TwoElements)
{
	CMyList<std::string> list;
	list.PushBack("some");
	list.PushBack("one");

	list.Erase(list.begin());

	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("one", ss.str());
	ASSERT_EQ(1, list.GetLength());
}

TEST(CMyListTest, TwoElements_DeleteLast)
{
	CMyList<std::string> list;
	list.PushBack("some");
	list.PushBack("one");

	list.Erase(++list.begin());

	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("some", ss.str());
	ASSERT_EQ(1, list.GetLength());
}

TEST(CMyListTest, ThreeElements_DeleteLast)
{
	CMyList<std::string> list;
	list.PushBack("some");
	list.PushBack("one");
	list.PushBack("cat");

	list.Erase(++list.begin());

	std::stringstream ss;
	for (auto& listElement : list)
	{
		ss << listElement.Value();
	}
	ASSERT_EQ("somecat", ss.str());
	ASSERT_EQ(2, list.GetLength());
}

TEST(CMyListTest, ReverseIteratorTest)
{
	CMyList<std::string> test;
	test.PushBack("value");
	test.PushBack("efim");
	test.PushBack("test");

	auto rbegin = test.rbegin();
	auto rend = test.rend();

	std::stringstream ss;
	while (rbegin != rend)
	{
		ss << (*rbegin).Value();
		++rbegin;
	}
	ASSERT_EQ("testefimvalue", ss.str());
}


TEST(StringListTest, PushBackTest)
{
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");
	ASSERT_EQ(list.GetLength(), 2);
}

TEST(StringListTest, DefaultConstructor)
{
	CMyList<std::string> list;
	ASSERT_EQ(list.GetLength(), 0);
}

TEST(StringListTest, PushFrontTest)
{
	CMyList<std::string> list;
	list.PushFront("world");
	list.PushFront("hello");
	ASSERT_EQ(list.GetLength(), 2);
}

TEST(StringListTest, IsEmptyTest)
{
	CMyList<std::string> list;
	ASSERT_TRUE(list.IsEmpty());
	list.PushBack("hello");
	ASSERT_FALSE(list.IsEmpty());
}

TEST(StringListTest, ClearTest)
{
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");
	list.Clear();
	ASSERT_EQ(list.GetLength(), 0);
	ASSERT_TRUE(list.IsEmpty());
}

TEST(StringListTest, CopyConstructor)
{
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");

	CMyList<std::string> newList(list);

	ASSERT_EQ(list.GetLength(), 2);
	ASSERT_EQ(newList.GetLength(), 2);
}

TEST(StringListTest, MoveConstructor)
{
	CMyList<std::string> list;
	list.PushBack("hello");
	list.PushBack("world");

	CMyList<std::string> newList(std::move(list));

	ASSERT_EQ(list.GetLength(), 0);
	ASSERT_EQ(newList.GetLength(), 2);
}

TEST(StringListTest, TestListElementConstructor)
{
	m_listDataConstructor = 0;
	m_listDataDestructor = 0;
	CMyList<std::string> list;
	 ASSERT_EQ(m_listDataConstructor, 1);
	 ASSERT_EQ(m_listDataDestructor, 0);
	 list.PushBack("hello");
	 ASSERT_EQ(m_listDataConstructor, 2);
	 ASSERT_EQ(m_listDataDestructor, 0);
	 list.PushBack("world");
	 ASSERT_EQ(m_listDataConstructor, 3);
	 ASSERT_EQ(m_listDataDestructor, 0);
	 list.Erase(list.begin());
	 ASSERT_EQ(m_listDataConstructor, 3);
	 ASSERT_EQ(m_listDataDestructor, 1);
	 list.Clear();
	 ASSERT_EQ(m_listDataConstructor, 3);
	 ASSERT_EQ(m_listDataDestructor, 2);	
}

TEST(StringListTest, WithoutDefaultConstructor)
{
	m_listDataConstructor = 0;
	m_listDataDestructor = 0;
	CMyList<MyChar> list;
	list.PushBack(MyChar('c'));
}
