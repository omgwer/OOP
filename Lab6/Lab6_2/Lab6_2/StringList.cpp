#include "headers/StringList.h"

StringList::StringList() = default;

StringList::StringList(const StringList& stringList)
{
	// for (const auto& str : stringList) {
	// 	PushBack(str);
	// }
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
	//Clear();
	m_first = nullptr;
	m_last = nullptr;
	m_length = 0;
}

void StringList::PushBack(const std::string& value)
{
	if (m_first == nullptr)
	{
		m_first = std::make_shared<ListElement>();
		m_first->value = value;
	}
	else if (m_last == nullptr) // значит элемент второй
	{
		m_last = std::make_shared<ListElement>();
		m_last->value = value;
		m_last->prev = m_first;
		m_last->prev->next = m_last;
	}
	else
	{
		auto lastElement = std::make_shared<ListElement>();
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
		m_first = std::make_shared<ListElement>();
		m_first->value = value;
	}
	else if (m_last == nullptr)
	{
		auto firstElement = std::make_shared<ListElement>();
		firstElement->value = value;
		firstElement->next = m_first;
		m_last = m_first;
		m_last->prev = firstElement;
		m_first = firstElement;
	}
	else
	{
		auto firstElement = std::make_shared<ListElement>();
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
	return m_length == 0;
}

void Clear()
{
	// auto current = std::move(m_first); // переместить указатель на первый элемент в переменную current
	// while (current) { // пока указатель на текущий элемент не станет нулевым
	// 	auto next = std::move(current->next); // переместить указатель на следующий элемент в переменную next
	// 	current.reset(); // удалить текущий элемент
	// 	current = std::move(next); // переместить указатель на следующий элемент в переменную current
	// }
	// m_last.reset(); // удалить указатель на последний элемент
}

