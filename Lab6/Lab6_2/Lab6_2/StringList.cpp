#include "StringList.h"

StringList::StringList()
{
	m_end = new ListElement();
	m_end->prev = m_last;
	m_end->next = m_first;
};

StringList::StringList(const StringList& stringList) // копируем данные, создаем новые указатели
{
	auto varPtr = stringList.m_first;
	while (varPtr != nullptr)
	{
		PushBack(varPtr->value);
		m_last = varPtr;
		varPtr = varPtr->next;
	}
	m_end = new ListElement();
	m_end->prev = m_last;
	m_end->next = m_first;
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
	m_end->next = m_first;
}

StringList::~StringList()
{
	Clear();
	delete m_first;
	delete m_last;
	delete m_end;
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
	// TODO: удалиьь данные перед записью  - сделано
	Clear();
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
		m_first = new ListElement(value); // TODO: добавить конструктор для ListElement
		m_last = m_first;
		m_end->prev = m_last;
	}
	else
	{
		auto lastElement = new ListElement(value);

		if (m_first->next == nullptr) // это значит второй элемент отсутсвует
		{
			m_first->next = lastElement;
			lastElement->prev = m_first;
			m_last = lastElement;
			m_end->prev = m_last;
		}
		else
		{
			m_last->next = lastElement;
			lastElement->prev = m_last;
			m_last = lastElement;
			m_end->prev = m_last;
		}
	}
	m_length++;
}

void StringList::PushFront(const std::string& value)
{
	if (m_first == nullptr) // TODO: m_last должен указыать на последний - сделано
	{
		m_first = new ListElement(value);
		m_last = m_first;
		m_end->prev = m_last;
		m_end->next = m_first;
	}
	else
	{
		auto lastElement = new ListElement(value);
		lastElement->next = m_first;
		m_first->prev = lastElement;
		m_first = lastElement;
		m_end->next = m_first;
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
	while (varPtr != nullptr)
	{
		const ListElement* elementToDelete = varPtr; // TODO: rename item to delte and join
		varPtr = varPtr->next;
		delete elementToDelete;
	}
	m_first = nullptr;
	m_last = nullptr;
	m_end = m_first;
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
	const auto newElement = new ListElement(value);
	newElement->next = &*it;

	if (currentIterator.prev != nullptr)
	{
		currentIterator.prev->next = newElement;
		newElement->prev = (*it).prev;
	}
	else // значит, что этот элемент первый в списке
	{
		m_first = newElement;
	}
	currentIterator.prev = newElement;
	m_length++;
}

void StringList::Erase(Iterator& it)
{
	if (m_first == nullptr || it.m_data == nullptr)
	{
		return;
	}
	auto prev = (*it).prev;
	auto next = (*it).next;
	ListElement* toDelete = it.m_data;
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
}

StringList::Iterator StringList::begin()
{
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
	return { m_end };
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
