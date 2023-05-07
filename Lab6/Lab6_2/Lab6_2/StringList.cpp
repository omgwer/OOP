#include "headers/StringList.h"

StringList::StringList() = default;

StringList::StringList(const StringList& stringList) // копируем данные, создаем новые указатели
{
	auto varPtr = stringList.m_first;
	while (varPtr != nullptr)
	{
		PushBack(varPtr->value);
		varPtr = varPtr->next;
	}
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

StringList& StringList::operator=(const StringList& copy)
{
	if (this != &copy)
	{
		StringList tmp(copy);
		std::swap(m_first, tmp.m_first);
		std::swap(m_last, tmp.m_last);
		std::swap(m_length, tmp.m_length);
	}
	return *this;
}

StringList& StringList::operator=(StringList&& move)
{
	m_first = move.m_first;
	m_last = move.m_last;
	m_length = move.m_length;

	move.m_first = nullptr;
	move.m_last = nullptr;
	move.m_length = 0;
	return *this;
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

void StringList::Insert(const Iterator& it, const std::string& value)
{
	if (m_first == nullptr)
	{
		PushBack(value);
		return;
	}
	auto currentIterator = *it;
	const auto newElement = new ListElement;
	newElement->value = value;
	newElement->next = &*it;
	
	if (currentIterator.prev != nullptr) 
	{
		currentIterator.prev->next = newElement;
		newElement->prev = (*it).prev;
	} else   // значит, что этот элемент первый в списке
	{ 
		m_first = newElement;
	}
	currentIterator.prev = newElement;
	m_length++;
}

StringList::Iterator StringList::begin()
{
	return { m_first, m_length, 0 };
}

StringList::Iterator StringList::end()
{
	return { nullptr };
}
