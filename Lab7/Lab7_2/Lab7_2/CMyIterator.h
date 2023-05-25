#pragma once
#include <exception>
#include <iterator>

template <typename T> class CMyIterator
{
public:
	using value_type = T;
	using difference_type = std::ptrdiff_t;
	using pointer = T*;
	using reference = T&;
	using iterator_category = std::bidirectional_iterator_tag;

	CMyIterator(T* p, T* root)
		: m_data(p), m_root(root)
	{
	}

	~CMyIterator() = default;

	bool operator!=(CMyIterator const& other) const;
	bool operator==(CMyIterator const& other) const;
	T& operator*() const;
	CMyIterator& operator++(); // prefix
	CMyIterator operator++(int); // postfix
	CMyIterator& operator--();
	CMyIterator operator--(int);
	T* m_data;
	T* m_root;
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
	if (m_data == m_root)
	{
		throw std::exception("Cant dereference end iterator!");
	}
	return *m_data;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator++()
{
	m_data = m_data->next;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator++(const int ch)
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

template <typename T> CMyIterator<T> CMyIterator<T>::operator--(const int ch)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->prev;
	return copy;
}