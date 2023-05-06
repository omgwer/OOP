#include "../Lab5_2_CPP/headers/CMyString.h"
#include "gtest/gtest.h"

TEST(CMyStringTest, DefaultConstructor)
{
	CMyString str;
	EXPECT_EQ(0, str.GetLength());
	EXPECT_STREQ("", str.GetStringData());
}

TEST(CMyStringTest, ConstructorWithCString)
{
	const char* cstr = "hello world";
	CMyString str(cstr);
	EXPECT_EQ(strlen(cstr), str.GetLength());
	EXPECT_STREQ(cstr, str.GetStringData());
}

TEST(CMyStringTest, ConstructorWithCStringAndLength)
{
	const char* cstr = "hello world";
	const size_t len = 5;
	CMyString str(cstr, len);
	EXPECT_EQ(len, str.GetLength());
	EXPECT_STREQ("hello", str.GetStringData());
}

TEST(CMyStringTest, CopyConstructor)
{
	const char* cstr = "hello world";
	CMyString str1(cstr);
	CMyString str2(str1);
	EXPECT_EQ(str1.GetLength(), str2.GetLength());
	EXPECT_STREQ(str1.GetStringData(), str2.GetStringData());
}

TEST(CMyStringTest, MoveConstructor)
{
	const char* cstr = "hello world";
	CMyString str1(cstr);
	CMyString str2(std::move(str1));

	const auto actualData = str2.GetStringData();
	const auto actualLength = str2.GetLength();
	EXPECT_STREQ(cstr, actualData);
	EXPECT_EQ(std::strlen(cstr), actualLength);
}

TEST(CMyStringTest, ConstructorWithSTLString)
{
	std::string stlString = "hello world";
	CMyString str(stlString);
	EXPECT_EQ(stlString.length(), str.GetLength());
	EXPECT_STREQ(stlString.c_str(), str.GetStringData());
}

TEST(CMyStringTest, SubString)
{
	const char* cstr = "hello world";
	CMyString str(cstr);
	CMyString subStr = str.SubString(2, 5);
	EXPECT_EQ(5, subStr.GetLength());
	EXPECT_STREQ("llo w", subStr.GetStringData());
}

TEST(CMyStringTest, Clear)
{
	const char* cstr = "hello world";
	CMyString str(cstr);
	str.Clear();
	EXPECT_EQ(0, str.GetLength());
	EXPECT_STREQ("", str.GetStringData());
}

TEST(CMyStringTest, CompateTestFirst)
{
	const CMyString str1("abc");
	const CMyString str2("abc");
	const CMyString str3("");
	const CMyString str4("abcd");
	const CMyString str5("abe");
	EXPECT_EQ(true, str1 == str2);
	EXPECT_EQ(false, str1 != str2);
	EXPECT_EQ(true, str1 != str3);
	EXPECT_EQ(false, str1 == str3);
	EXPECT_EQ(true, str1 != str4);
	EXPECT_EQ(false, str1 == str4);
	EXPECT_EQ(true, str1 != str5);
	EXPECT_EQ(false, str1 == str5);
}

TEST(CMyStringTest, CompareTestLess)
{
	const CMyString str1("abc");
	const CMyString str2("abc");
	const CMyString str3("");
	const CMyString str4("abcd");
	const CMyString str5("abe");
	EXPECT_EQ(false, str1 < str2);
	EXPECT_EQ(true, str1 <= str2);
	EXPECT_EQ(false, str1 > str2);
	EXPECT_EQ(true, str1 >= str2);

	EXPECT_EQ(true, str1 < str5);
	EXPECT_EQ(true, str1 <= str5);
	EXPECT_EQ(false, str1 >= str5);

	EXPECT_EQ(true, str4 < str5);
	EXPECT_EQ(true, str4 <= str5);
	EXPECT_EQ(true, str3 <= str5);
	EXPECT_EQ(true, str4 > str1);
	EXPECT_EQ(true, str4 >= str1);
	
	EXPECT_EQ(true, str3 <= str3);
	EXPECT_EQ(true, str3 >= str3);
	EXPECT_EQ(false, str3 > str3);
	EXPECT_EQ(false, str3 < str3);	
}
