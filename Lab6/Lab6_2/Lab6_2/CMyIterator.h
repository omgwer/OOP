#pragma once
#include <iterator>

template <typename T> class CMyIterator
{
public:
	using value_type = T;
	using difference_type = std::ptrdiff_t;
	using pointer = T*;
	using reference = T&;
	using iterator_category = std::random_access_iterator_tag;

	CMyIterator(T* p, const size_t length, const size_t index)
		: m_data(p), m_length(length), m_index(index)
	{
	}

	CMyIterator(T* p)
		: m_data(p), m_length(0), m_index(0)
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
	ptrdiff_t operator-(const CMyIterator& other) const;
	T* m_data;

private:
	size_t m_length;
	size_t m_index;
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
	m_index++;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator++(const int ch)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->next;
	m_index++;
	return copy;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator--()
{
	m_data = m_data->prev;
	m_index--;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator--(const int ch)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->prev;
	m_index--;
	return copy;
}

template <typename T> ptrdiff_t CMyIterator<T>::operator-(const CMyIterator<T>& other) const
{
	return m_index - other.m_index;
}
