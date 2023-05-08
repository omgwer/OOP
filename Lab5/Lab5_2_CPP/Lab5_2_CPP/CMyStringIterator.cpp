#include "headers/CMyStringIterator.h"
#include <cassert>
template <typename T> bool CMyStringIterator<T>::operator!=(CMyStringIterator<T> const& other) const
{
	return m_ch != other.m_ch;
}

template <typename T> bool CMyStringIterator<T>::operator==(CMyStringIterator<T> const& other) const
{
	return m_ch == other.m_ch;
}

template <typename T> T& CMyStringIterator<T>::operator*() const
{
	return *m_ch;
}

template <typename T> CMyStringIterator<T>& CMyStringIterator<T>::operator++()
{
	assert(m_length < m_index + 1 && "Iterator out of range!");
	++m_ch;
	return *this;
}

template <typename T> CMyStringIterator<T>& CMyStringIterator<T>::operator--()
{
	assert(0 < m_index - 1 && "Iterator out of range!"); 
	--m_ch;
	return *this;
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator++(const int ch)
{
	assert(m_length < m_index + 1 && "Iterator out of range!");
	CMyStringIterator<T> copy = {*this};
	++m_ch;
	return copy;
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator--(const int ch)
{
	assert(0 < m_index - 1 && "Iterator out of range!");
	CMyStringIterator<T> copy = {*this};
	--m_ch;
	return copy;
}

template <typename T> ptrdiff_t CMyStringIterator<T>::operator-(const CMyStringIterator<T>& other) const
{
	assert(0 < m_ch - other.m_ch && "Iterator out of range!"); 
	return  m_ch - other.m_ch;
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator+(const CMyStringIterator<T>& other)
{
	return {m_ch + other.m_ch, m_index + other.m_index, m_length};
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator+(const size_t value)
{
	return {m_ch + value, m_index + value, m_length};
}

template <typename T> T& CMyStringIterator<T>::operator[](size_t index)
{
	auto link = m_ch + index;
	return *link;
}

template <typename T> T& CMyStringIterator<T>::operator[](size_t index) const
{
	auto link = m_ch + index;
	return *link;
}
