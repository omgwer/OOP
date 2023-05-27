#pragma once
#include <vector>

// добавить less компаратор 
template <typename T, typename Comp>
bool FindMaxEx(std::vector<T> const& array, T& maxValue, const Comp& comp)
{
	if (array.empty())
		return false;

	auto varMax = array.begin();
	for (auto it = array.cbegin(); it != array.cend(); ++it)
		if (comp(*varMax, *it))
			varMax = it;

	maxValue = *varMax;
	return true;
}
