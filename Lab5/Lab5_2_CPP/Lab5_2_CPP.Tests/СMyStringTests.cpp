#include "../Lab5_2_CPP/headers/CMyString.h"
#include "gtest/gtest.h"

TEST(CMyStringTest, DefaultConstructor)
{
	CMyString str;
	EXPECT_EQ(0, str.GetLength());
	EXPECT_STREQ("", str.GetStringData());
}

TEST(CMyStringTest, ConstructorWithCString) {
	const char* cstr = "hello world";
	CMyString str(cstr);
	EXPECT_EQ(strlen(cstr), str.GetLength());
	EXPECT_STREQ(cstr, str.GetStringData());
}

TEST(CMyStringTest, ConstructorWithCStringAndLength) {
	const char* cstr = "hello world";
	const size_t len = 5;
	CMyString str(cstr, len);
	EXPECT_EQ(len, str.GetLength());
	EXPECT_STREQ("hello", str.GetStringData());
}

TEST(CMyStringTest, CopyConstructor) {
	const char* cstr = "hello world";
	CMyString str1(cstr);
	CMyString str2(str1);
	EXPECT_EQ(str1.GetLength(), str2.GetLength());
	EXPECT_STREQ(str1.GetStringData(), str2.GetStringData());
}

TEST(CMyStringTest, MoveConstructor) {
	const char* cstr = "hello world";
	CMyString str1(cstr);
	CMyString str2(std::move(str1));
	EXPECT_EQ(std::strlen(cstr), str2.GetLength());
	EXPECT_STREQ(cstr, str2.GetStringData());
}

TEST(CMyStringTest, ConstructorWithSTLString) {
	std::string stlString = "hello world";
	CMyString str(stlString);
	EXPECT_EQ(stlString.length(), str.GetLength());
	EXPECT_STREQ(stlString.c_str(), str.GetStringData());
}

TEST(CMyStringTest, SubString) {
	const char* cstr = "hello world";
	CMyString str(cstr);
	CMyString subStr = str.SubString(2, 5);
	EXPECT_EQ(5, subStr.GetLength());
	EXPECT_STREQ("llo w", subStr.GetStringData());
}

TEST(CMyStringTest, Clear) {
	const char* cstr = "hello world";
	CMyString str(cstr);
	str.Clear();
	EXPECT_EQ(0, str.GetLength());
	EXPECT_STREQ("", str.GetStringData());
}