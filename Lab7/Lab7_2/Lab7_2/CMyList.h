#pragma once
#include "CMyIterator.h"

template <typename T> class CMyList
{
public:
	struct ListElement
	{
		ListElement() : value(T()), prev(nullptr), next(nullptr)
		{
		}
		
		ListElement(const T& other, ListElement* prevPtr = nullptr, ListElement* nextPtr = nullptr)
		{
			value = other;
			prev = prevPtr;
			next = nextPtr;
		}

		T value;
		ListElement* prev = nullptr;
		ListElement* next = nullptr;
	};

	using Iterator = CMyIterator<ListElement>;
	using ConstIterator = CMyIterator<const ListElement>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

	CMyList();
	CMyList(const CMyList& copy);
	CMyList(CMyList&& move);
	~CMyList();

	CMyList& operator=(const CMyList& copy);
	CMyList& operator=(CMyList&& move);

	void PushBack(const T& value);
	void PushFront(const T& value);
	size_t GetLength() const;
	bool IsEmpty() const;
	void Clear();
	Iterator Insert(const Iterator&, const T& value);
	Iterator Erase(Iterator&);

	Iterator begin();
	Iterator end();
	ConstIterator begin() const;
	ConstIterator end() const;
	ReverseIterator rbegin();
	ReverseIterator rend();
	ConstReverseIterator rсbegin() const;
	ConstReverseIterator rсend() const;

private:
	ListElement* m_end = nullptr;
	ListElement* m_first = nullptr;
	ListElement* m_last = nullptr;
	size_t m_length = 0;
};

template <typename T> CMyList<T>::CMyList()
{
	m_end = new ListElement();
	m_end->prev = m_last;
	m_end->next = nullptr;
}

template <typename T> CMyList<T>::CMyList(const CMyList& other) // копируем данные, создаем новые указатели
{
	m_end = new ListElement();
	auto varPtr = other.m_first;
	while (varPtr != other.m_end)
	{
		PushBack(varPtr->value);
		varPtr = varPtr->next;
	}
	m_end->prev = m_last;
	m_end->next = nullptr;
	m_last->next = m_end;
}

template <typename T> CMyList<T>::CMyList(CMyList&& other) // копируем указатели на начало и конец, забираем value у исходного файла удаляем начало и конец.
{
	m_first = other.m_first;
	m_last = other.m_last;
	m_length = other.m_length;

	other.m_first = nullptr;
	other.m_last = nullptr;
	other.m_length = 0;

	m_end = new ListElement();
	m_end->prev = m_last;
	m_end->next = nullptr;
	m_last->next = m_end;
}

template <typename T> CMyList<T>::~CMyList()
{
	Clear();	
}

template <typename T> CMyList<T>& CMyList<T>::operator=(const CMyList& copy)
{
	if (this != &copy)
	{
		CMyList tmp(copy);
		std::swap(m_first, tmp.m_first);
		std::swap(m_last, tmp.m_last);
		std::swap(m_length, tmp.m_length);
	}
	return *this;
}

template <typename T> CMyList<T>& CMyList<T>::operator=(CMyList&& move)
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

template <typename T> void CMyList<T>::PushBack(const T& value)
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

template <typename T> void CMyList<T>::PushFront(const T& value)
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

template <typename T> size_t CMyList<T>::GetLength() const
{
	return m_length;
}

template <typename T> bool CMyList<T>::IsEmpty() const
{
	return m_length == 0 && m_first == nullptr && m_last == nullptr;
}

template <typename T> void CMyList<T>::Clear()
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

template <typename T> typename CMyList<T>::Iterator CMyList<T>::Insert(const Iterator& it, const T& value)
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
	return {newElement, m_length, static_cast<size_t>(end() - it)};
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::Erase(Iterator& it)
{
	if (m_first == nullptr || it.m_data == nullptr)
	{
		throw std::exception("List is empty!");
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

template <typename T> typename CMyList<T>::Iterator CMyList<T>::begin()
{
	if (m_first == nullptr)
	{
		return {m_end, 0,0};
	}
	return { m_first, m_length, 0 };
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::end()
{
	return { m_end, m_length, m_length };
}

template <typename T> typename CMyList<T>::ConstIterator CMyList<T>::begin() const
{
	return { m_first, m_length, 0 };
}

template <typename T> typename CMyList<T>::ConstIterator CMyList<T>::end() const
{
	return { m_end,  m_length, m_length };
}

template <typename T> typename CMyList<T>::ReverseIterator CMyList<T>::rbegin()
{
	return std::make_reverse_iterator(this->end());
}

template <typename T> typename CMyList<T>::ReverseIterator CMyList<T>::rend()
{
	return std::make_reverse_iterator(this->begin());
}

template <typename T> typename CMyList<T>::ConstReverseIterator CMyList<T>::rсbegin() const
{
	return std::make_reverse_iterator(this->end());
}

template <typename T> typename CMyList<T>::ConstReverseIterator CMyList<T>::rсend() const
{
	return std::make_reverse_iterator(this->begin());
}