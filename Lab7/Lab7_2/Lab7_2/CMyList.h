#pragma once
#include "CMyIterator.h"

template <typename T> class CMyList
{
public:
	struct ListElement
	{
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
	void Insert(const Iterator&, const T& value);
	void Erase(Iterator&);

	Iterator begin();
	Iterator end();
	ConstIterator begin() const;
	ConstIterator end() const;
	ReverseIterator rbegin();
	ReverseIterator rend();
	ConstReverseIterator rсbegin() const;
	ConstReverseIterator rсend() const;

private:
	ListElement* m_first = nullptr;
	ListElement* m_last = nullptr;
	size_t m_length = 0;
};

template <typename T> CMyList<T>::CMyList() = default;

template <typename T> CMyList<T>::CMyList(const CMyList& CMyList) // копируем данные, создаем новые указатели
{
	auto varPtr = CMyList.m_first;
	while (varPtr != nullptr)
	{
		PushBack(varPtr->value);
		varPtr = varPtr->next;
	}
}

template <typename T> CMyList<T>::CMyList(CMyList&& CMyList) // копируем указатели на начало и конец, забираем value у исходного файла удаляем начало и конец.
{
	m_first = CMyList.m_first;
	m_last = CMyList.m_last;
	m_length = CMyList.m_length;

	CMyList.m_first = nullptr;
	CMyList.m_last = nullptr;
	CMyList.m_length = 0;
}

template <typename T> CMyList<T>::~CMyList()
{
	Clear();
	delete m_first;
	delete m_last;
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
	m_first = move.m_first;
	m_last = move.m_last;
	m_length = move.m_length;

	move.m_first = nullptr;
	move.m_last = nullptr;
	move.m_length = 0;
	return *this;
}

template <typename T> void CMyList<T>::PushBack(const T& value)
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

template <typename T> void CMyList<T>::PushFront(const T& value)
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
	ListElement* swap;
	while (varPtr != nullptr)
	{
		varPtr->prev = nullptr;
		swap = varPtr;
		varPtr = varPtr->next;
		delete swap;
	}
	m_first = nullptr;
	m_last = nullptr;
	m_length = 0;
}

template <typename T> void CMyList<T>::Insert(const Iterator& it, const T& value)
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
	}
	else // значит, что этот элемент первый в списке
	{
		m_first = newElement;
	}
	currentIterator.prev = newElement;
	m_length++;
}

template <typename T> void CMyList<T>::Erase(Iterator& it)
{
	if (m_first == nullptr || it.m_data == nullptr) // TODO: пока костыль, обдумать выбрасывание ошибок
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

template <typename T> typename CMyList<T>::Iterator CMyList<T>::begin()
{
	return { m_first, m_length, 0 };
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::end()
{
	return { nullptr };
}

template <typename T> typename CMyList<T>::ConstIterator CMyList<T>::begin() const
{
	return { m_first, m_length, 0 };
}

template <typename T> typename CMyList<T>::ConstIterator CMyList<T>::end() const
{
	return { nullptr };
}

template <typename T> typename CMyList<T>::ReverseIterator CMyList<T>::rbegin()
{
	auto li = new ListElement;
	li->prev = m_last;
	Iterator it(li, m_length, 0);
	return std::make_reverse_iterator(it);
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