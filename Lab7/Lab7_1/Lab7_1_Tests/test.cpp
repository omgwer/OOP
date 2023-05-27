#include "gtest/gtest.h"
#include "../Lab7_1/FindMaxEx.h"

TEST(FindMaxExTests, FindMaxInt)
{
	std::vector<int> arr{ 4, 8, 0, 1, 6, -5, 4 };
	int max{};
	std::less<int> less;
	EXPECT_TRUE(FindMaxEx(arr, max, less), "FindMax on not empty vector returned false");
	EXPECT_EQ(8, max, "Expected max value doesn't match actual");  
}

TEST(FindMaxExTests, EmptyVector)
{
	std::vector<int> arr;
	int max{};
	std::less<int> less;
	EXPECT_FALSE(FindMaxEx(arr, max, less), "FindMax on not empty vector returned false");
}


TEST(FindMaxExTests, FloatVector)
{
	std::vector<float> arr{8.3, 4.5, 0.3, 1.2, 6.7, -5.9, 4.2};
	float max{};
	std::less<float> less;
	EXPECT_TRUE(FindMaxEx(arr, max, less), "FindMax on not empty vector returned false");
	EXPECT_EQ(8.3f, max, "Expected max value doesn't match actual");  
}

TEST(FindMaxExTests, StringVector)
{
	std::vector<std::string> arr{"some", "one", "work", "efim"};
	std::string max{};
	std::less<std::string> less;
	EXPECT_TRUE(FindMaxEx(arr, max, less), "FindMax on not empty vector returned false");
	EXPECT_EQ("work", max, "Expected max value doesn't match actual");  
}

TEST(FindMaxExTests, CustomClasses)
{
	struct Car
	{
		std::string color;
		int horsePower;

		bool operator < (const Car& car) const
		{
			return horsePower < car.horsePower;
		}
		
	};
	
	std::vector<Car> arr;
	arr.push_back({"red", 255});
	arr.push_back({"blue", 0});
	arr.push_back({"black", 365});
	arr.push_back({"white", 50});
	Car max;
	
	std::less<Car> less;
	EXPECT_TRUE(FindMaxEx(arr, max, less), "FindMax on not empty vector returned false");
	EXPECT_EQ("black", max.color, "Expected max value doesn't match actual");  
	EXPECT_EQ(365, max.horsePower, "Expected max value doesn't match actual");  
}
