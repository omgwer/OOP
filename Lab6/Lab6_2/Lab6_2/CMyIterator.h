#pragma once
#include <iterator>

template <typename T> class CMyIterator
{
public:
	using value_type = T;
	using difference_type = std::ptrdiff_t;
	using pointer = T*;
	using reference = T&;
	using iterator_category = std::bidirectional_iterator_tag;   

	CMyIterator(T* p)
		: m_data(p)
	{
	}

	~CMyIterator() = default;

	bool operator !=(CMyIterator const& other) const;
	bool operator ==(CMyIterator const& other) const;
	T& operator*() const;
	CMyIterator& operator++(); // prefix
	CMyIterator operator++(int); // postfix
	CMyIterator& operator--();
	CMyIterator operator--(int);
	T* m_data;
};

template <typename T> bool CMyIterator<T>::operator!=(CMyIterator const& other) const
{
	return m_data != other.m_data;
}

template <typename T> bool CMyIterator<T>::operator==(CMyIterator const& other) const
{
	return m_data == other.m_data;
}

template <typename T> T& CMyIterator<T>::operator*() const
{
	return *m_data;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator++()
{
	m_data = m_data->next;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator++(int)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->next;
	return copy;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator--()
{
	m_data = m_data->prev;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator--(int)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->prev;
	return copy;
}