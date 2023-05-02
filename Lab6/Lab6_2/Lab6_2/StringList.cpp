#include "headers/StringList.h"

StringList::StringList() = default;

StringList::StringList(const StringList& stringList)
{
	for (const auto& str : stringList) {
		PushBack(str);
	}
}


