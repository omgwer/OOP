#include "gtest/gtest.h"
#include "../Lab5_2_CPP/headers/CMyString.h"

TEST(CMyString, AssignmentOperator)
{
	const char* cstr = "Hello, world!";
	CMyString original(cstr);
	CMyString copy;
	copy = original;
	EXPECT_EQ(copy.GetLength(), original.GetLength());
	EXPECT_STREQ(copy.GetStringData(), original.GetStringData());
}

TEST(CMyString, ConcatenationOperator)
{
	const char* cstr1 = "Hello, ";
	const char* cstr2 = "world!";
	CMyString str1(cstr1);
	CMyString str2(cstr2);
	CMyString result = str1 + str2;
	EXPECT_EQ(result.GetLength(), strlen(cstr1) + strlen(cstr2));
	EXPECT_STREQ(result.GetStringData(), "Hello, world!");
}

TEST(CMyString, ConcatenationAssignmentOperator)
{
	const char* cstr1 = "Hello, ";
	const char* cstr2 = "world!";
	CMyString str1(cstr1);
	CMyString str2(cstr2);
	str1 += str2;
	EXPECT_EQ(str1.GetLength(), strlen(cstr1) + strlen(cstr2));
	EXPECT_STREQ(str1.GetStringData(), "Hello, world!");
}

TEST(CMyString, EqualityOperator)
{
	const char* cstr1 = "Hello, world!";
	const char* cstr2 = "Hello, world!";
	CMyString str1(cstr1);
	CMyString str2(cstr2);
	EXPECT_TRUE(str1 == str2);
	EXPECT_FALSE(str1 == CMyString());
}

TEST(CMyString, InequalityOperator)
{
	const char* cstr1 = "Hello, world!";
	const char* cstr2 = "Hello, worls!";
	CMyString str1(cstr1);
	CMyString str2(cstr2);
	EXPECT_TRUE(str1 != str2);
}

TEST(CMyStringTests, OperatorGreaterThan)
{
	CMyString str1("Hello");
	CMyString str2("Hella");
	CMyString str3("Hell");

	ASSERT_TRUE(str1 > str3);
	ASSERT_TRUE(str1 > str2);
	ASSERT_FALSE(str1 > str1);
}

TEST(CMyStringTests, OperatorLessThan)
{
	CMyString str1("Hello");
	CMyString str2("Hella");
	CMyString str3("Hell");

	ASSERT_TRUE(str2 < str1);
	ASSERT_TRUE(str3 < str1);
	ASSERT_FALSE(str1 < str1);
}

TEST(CMyStringTests, OperatorGreaterThanOrEqual)
{
	CMyString str1("Hello");
	CMyString str2("Hella");
	CMyString str3("Hell");

	ASSERT_TRUE(str1 >= str3);
	ASSERT_TRUE(str1 >= str2);
	ASSERT_TRUE(str1 >= str1);
}

TEST(CMyStringTests, OperatorLessThanOrEqual)
{
	CMyString str1("Hello");
	CMyString str2("Hella");
	CMyString str3("Hell");

	ASSERT_TRUE(str2 <= str1);
	ASSERT_TRUE(str3 <= str1);
	ASSERT_TRUE(str1 <= str1);
}

TEST(CMyStringTests, OperatorIndexAccessConst)
{
	CMyString str("Hello, world!");

	ASSERT_EQ(str[0], 'H');
	ASSERT_EQ(str[7], 'w');
	ASSERT_EQ(str[12], '!');
}

TEST(CMyStringTests, OperatorIndexAccess)
{
	CMyString str("Hello, world!");

	str[0] = 'h';
	str[6] = '-';
	str[12] = '?';

	ASSERT_EQ(str[0], 'h');
	ASSERT_EQ(str[6], '-');
	ASSERT_EQ(str[12], '?');
}
