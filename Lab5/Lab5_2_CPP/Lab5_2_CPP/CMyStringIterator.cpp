#include "headers/CMyStringIterator.h"

template <typename T> bool CMyStringIterator<T>::operator!=(CMyStringIterator const& other) const
{
	return m_ch != other.m_ch;
}

template <typename T> bool CMyStringIterator<T>::operator==(CMyStringIterator const& other) const
{
	return m_ch == other.m_ch;
}

template <typename T> T& CMyStringIterator<T>::operator*() const
{
	return *m_ch;
}

template <typename T> CMyStringIterator<T>& CMyStringIterator<T>::operator++()
{
	++m_ch;
	return *this;
}

template <typename T> CMyStringIterator<T>& CMyStringIterator<T>::operator--()
{
	--m_ch;
	return *this;
}

template <typename T> int CMyStringIterator<T>::operator-(const CMyStringIterator<T>& other) const
{
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