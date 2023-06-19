#include <iostream>
#include <bitset>
#include <string>
#include <sstream>
#include <iomanip>

// struct TestObj
// {
// 	TestObj(int v):value(v){}
// 	int value;	
// };
//

void Print(float value) {
	std::cout << value << std::endl;
}

template <typename T>
void Print(T value)
{
	std::cout << static_cast<long>(value) << std::endl;
}

void PrintFloatBinary(float value)
{
	std::bitset<sizeof(float) * 8> binary(*reinterpret_cast<unsigned int*>(&value));
	std::cout << "0b" << binary << std::endl;
}

void ConvertScientificToDecimal(const std::string& scientificNotation)
{
	std::stringstream ss(scientificNotation);
	double value;
	ss >> value;
	std::cout << std::fixed << std::setprecision(10) << value << std::endl;
}

bool compareFloats(const float& a, const float& b)
{
	const unsigned char* bytesA = reinterpret_cast<const unsigned char*>(&a);
	const unsigned char* bytesB = reinterpret_cast<const unsigned char*>(&b);

	for (size_t i = 0; i < sizeof(float); ++i)
	{
		if (bytesA[i] != bytesB[i])
		{
			return false; // Байты не совпадают
		}
	}

	return true; // Все байты совпадают
}

void testFloat() {
	float firstValue = 0b00111110001000000000000000000000;
	float secondValue = 0b00111110001000000000000000100000;
	Print(firstValue);
	Print(secondValue);
	bool res = firstValue == secondValue;
	std::cout << res << std::endl;
}

int main()
{
	std::string emptyString;
	std::cout << "Size of emptyString: " << sizeof(emptyString) << " bytes" << std::endl;


	return 1;	
}
