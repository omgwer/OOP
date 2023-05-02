#include "./FindMaxEx.cpp"

int main(int argc, char* argv[])
{
	std::vector<int> vector({322,15,75,55,5});
	int maxValue;
	
	FindMaxEx(vector, maxValue, std::less<int>());
    return maxValue;
}
