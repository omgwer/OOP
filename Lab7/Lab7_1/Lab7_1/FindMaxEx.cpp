#include <vector>

template <typename T>
bool FindMaxEx(std::vector<T> const& array, T& maxValue, std::less<T> const& less)
{
	if (array.empty())
		return false;

	T varMax = array[0];
	for (T element : array)
	{
		if (less(varMax, element))
		{
			varMax = element;
		}
	}
	maxValue = varMax;
	return true;
}
