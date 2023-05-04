#include <vector>

// добавить less компаратор 
template <typename T, typename Comp>
bool FindMaxEx(std::vector<T> const& array, T& maxValue, Comp comp)
{
	if (array.empty())
		return false;

	T& varMax = array[0]; // хранить ссылку 
	for (T element : array)
	{
		if (comp(varMax, element))
		{
			varMax = element;
		}
	}
	maxValue = varMax;
	return true;
}
