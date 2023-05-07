//#include "CMyIterator.cpp"
#include "headers/StringList.h"

StringList::StringList() = default;

StringList::StringList(const StringList& stringList) // копируем данные, создаем новые указатели
{
	// for (const auto& str : stringList) {
	// 	PushBack(str.value);
	// }
}

StringList::StringList(StringList&& stringList) // копируем указатели на начало и конец, забираем value у исходного файла удаляем начало и конец.
{
	m_first = stringList.m_first;
	m_last = stringList.m_last;
	m_length = stringList.m_length;

	stringList.m_first = nullptr;
	stringList.m_last = nullptr;
	stringList.m_length = 0;
}

StringList::~StringList()
{
	Clear();
	delete m_first;
	delete m_last;
}

void StringList::PushBack(const std::string& value)
{
	if (m_first == nullptr)
	{
		m_first = new ListElement;
		m_first->value = value;
	}
	else if (m_last == nullptr) // значит элемент второй
	{
		m_last = new ListElement;
		m_last->value = value;
		m_last->prev = m_first;
		m_last->prev->next = m_last;
	}
	else
	{
		auto lastElement = new ListElement;
		lastElement->value = value;
		lastElement->prev = m_last;
		lastElement->prev->next = lastElement;
		m_last = lastElement;
	}
	m_length++;
}

void StringList::PushFront(const std::string& value)
{
	if (m_first == nullptr)
	{
		m_first = new ListElement;
		m_first->value = value;
	}
	else if (m_last == nullptr)
	{
		auto firstElement = new ListElement;
		firstElement->value = value;
		firstElement->next = m_first;
		m_last = m_first;
		m_last->prev = firstElement;
		m_first = firstElement;
	}
	else
	{
		auto firstElement = new ListElement;
		firstElement->value = value;
		m_first->prev = firstElement;
		firstElement->next = m_first;
		m_first = firstElement;
	}
	m_length++;
}

size_t StringList::GetLength() const
{
	return m_length;
}

bool StringList::IsEmpty() const
{
	return m_length == 0 && m_first == nullptr && m_last == nullptr;
}

void StringList::Clear()
{
	if (m_first == nullptr)
		return;

	auto varPtr = m_first;
	ListElement* swap;
	while (varPtr != nullptr)
	{
		varPtr->value.clear();
		varPtr->prev = nullptr;
		swap = varPtr;
		varPtr = varPtr->next;
		delete swap;
	}
	m_first = nullptr;
	m_last = nullptr;
	m_length = 0;
}

StringList::Iterator StringList::begin()
{
	return {m_first, m_length,0};
}

StringList::Iterator StringList::end()
{
	return {nullptr};
}