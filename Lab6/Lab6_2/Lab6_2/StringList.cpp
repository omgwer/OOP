#include "StringList.h"

StringList::StringList()
{
	m_end = new ListElement();
	m_end->prev = m_last;
	m_end->next = nullptr;
};

StringList::StringList(const StringList& stringList) // копируем данные, создаем новые указатели
{
	m_end = new ListElement();
	auto varPtr = stringList.m_first;
	while (varPtr != stringList.m_end)
	{
		PushBack(varPtr->value);
		varPtr = varPtr->next;
	}
	m_end->prev = m_last;
	m_end->next = nullptr;
	m_last->next = m_end;
}

StringList::StringList(StringList&& stringList) // копируем указатели на начало и конец, забираем value у исходного файла удаляем начало и конец.
{
	m_first = stringList.m_first;
	m_last = stringList.m_last;
	m_length = stringList.m_length;

	stringList.m_first = nullptr;
	stringList.m_last = nullptr;
	stringList.m_length = 0;

	m_end = new ListElement();
	m_end->prev = m_last;
	m_end->next = nullptr;
	m_last->next = m_end;
}

StringList::~StringList()
{
	Clear();
}

StringList& StringList::operator=(const StringList& copy)
{
	if (this != &copy)
	{
		StringList tmp(copy);
		std::swap(m_first, tmp.m_first);
		std::swap(m_last, tmp.m_last);
		std::swap(m_length, tmp.m_length);
		std::swap(m_end, tmp.m_end);
	}
	return *this;
}

StringList& StringList::operator=(StringList&& move)
{
	if (this != &move)
	{
		std::swap(m_first, move.m_first);
		std::swap(m_last, move.m_last);
		std::swap(m_length, move.m_length);
		std::swap(m_end, move.m_end);
	}
	return *this;
}

void StringList::PushBack(const std::string& value)
{
	if (m_first == nullptr)
	{
		m_first = new ListElement(value); // TODO: добавить конструктор для ListElement -- сделано
		m_last = m_first;
	}
	else
	{
		auto lastElement = new ListElement(value);
		m_last->next = lastElement;
		lastElement->prev = m_last;
		m_last = lastElement;
	}
	m_end->prev = m_last;
	m_last->next = m_end;
	m_length++;
}

void StringList::PushFront(const std::string& value)
{
	if (m_first == nullptr) // TODO: m_last должен указыать на последний - сделано
	{
		m_first = new ListElement(value);
		m_last = m_first;
		m_end->prev = m_last;
		m_last->next = m_end;
	}
	else
	{
		auto lastElement = new ListElement(value);
		lastElement->next = m_first;
		m_first->prev = lastElement;
		m_first = lastElement;
	}
	m_end->next = nullptr;
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
	while (varPtr != m_end)
	{
		const ListElement* elementToDelete = varPtr; // TODO: rename item to delte and join -- сделано		
		varPtr = varPtr->next;
		delete elementToDelete;
	}
	m_first = nullptr;
	m_last = nullptr;
	m_end->prev = m_first;
	m_end->next = nullptr;
	m_length = 0;
}

// возвращает новый итератор указывающий на добавленный объект
StringList::Iterator StringList::Insert(const Iterator& it, const std::string& value)
{
	if (it == this->begin())
	{
		PushFront(value);
		return this->begin();
	}
	if (it == this->end())
	{
		PushBack(value);		
		return { m_last, m_length, m_length };
	}
	const auto currentIterator = *it;
	const auto newElement = new ListElement(value);
	currentIterator.prev->next = newElement;
	newElement->next = &*it;
	newElement->prev = currentIterator.prev;
	++m_length;
	return {newElement, m_length, m_length}; // TODO: доработать работу с индексами	
}

StringList::Iterator StringList::Erase(Iterator& it)
{
	if (m_first == nullptr || it.m_data == nullptr)
	{
		return;
	}
	auto prev = (*it).prev;
	auto next = (*it).next;
	ListElement* toDelete = it.m_data;
	Iterator newIterator(toDelete->next, m_length, end() - it);  // TODO: допилить оператор erase!
	if (it.m_data == m_first) // it means first element
	{
		m_first = m_first->next;
		if (m_first != nullptr)
			m_first->prev = nullptr; // если список не стал пустым
		else
			m_last = nullptr; // если список стал пустым
	}
	else
	{
		toDelete->prev->next = toDelete->next;
		if (toDelete->next != nullptr)
			toDelete->next->prev = toDelete->prev;
		else
			m_last = toDelete->prev; // если удаляем последний элемент
	}
	delete toDelete;
	--m_length;
	return newIterator;
}

StringList::Iterator StringList::begin()
{
	if (m_first == nullptr)
	{
		return {m_end, 0,0};
	}
	return { m_first, m_length, 0 };
}

StringList::Iterator StringList::end()
{
	return { m_end };
}

StringList::ConstIterator StringList::begin() const
{
	return { m_first, m_length, 0 };
}

StringList::ConstIterator StringList::end() const
{
	return { m_end,  m_length, m_length };
}

StringList::ReverseIterator StringList::rbegin()
{
	return std::make_reverse_iterator(this->end());
}

StringList::ReverseIterator StringList::rend()
{
	return std::make_reverse_iterator(this->begin());
}

StringList::ConstReverseIterator StringList::rсbegin() const
{
	return std::make_reverse_iterator(this->end());
}

StringList::ConstReverseIterator StringList::rсend() const
{
	return std::make_reverse_iterator(this->begin());
}
