#include "headers/StringList.h"

StringList::StringList() = default;

StringList::StringList(const StringList& stringList)
{
	for (const auto& str : stringList) {
		PushBack(str);
	}
}

StringList::StringList(StringList&& stringList)
{
	m_first = std::move(stringList.m_first);
	m_last = std::move(stringList.m_last);
	m_length = stringList.m_length;

	stringList.m_first = nullptr;
	stringList.m_last = nullptr;
	stringList.m_length = 0;	
}

StringList::~StringList()
{
	Clear();
	m_first = nullptr;
	m_last = nullptr;
	m_length = 0;
}

void StringList::PushFront(const std::string& value)
{
	if (m_first == nullptr)
	{
		m_first = std::make_unique<ListElement>();
		m_first->value = value;
		return;
	}

	if (m_last == nullptr) // значит элемент второй
	{
		m_last = std::make_unique<ListElement>();
		m_last->value = value;
		m_last->prev = std::move(m_first);
		m_last->prev->next = std::move(m_last);
	}

	
}


