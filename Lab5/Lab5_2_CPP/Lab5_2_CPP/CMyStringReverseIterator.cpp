#include "headers/CMyStringReverseIterator.h"

template <typename T> bool CMyStringReverseIterator<T>::operator!=(CMyStringReverseIterator const& other) const
{
	return m_ch != other.m_ch;
}

template <typename T> bool CMyStringReverseIterator<T>::operator==(CMyStringReverseIterator const& other) const
{
	return m_ch == other.m_ch;
}

template <typename T> typename CMyStringReverseIterator<T>::reference CMyStringReverseIterator<T>::operator*() const
{
	return *m_ch;
}

template <typename T> CMyStringReverseIterator<T>& CMyStringReverseIterator<T>::operator++()
{
	--m_ch;
	return *this;
}

template <typename T> CMyStringReverseIterator<T>& CMyStringReverseIterator<T>::operator--()
{
	++m_ch;
	return *this;
}

template <typename T> int CMyStringReverseIterator<T>::operator-(const CMyStringReverseIterator<T>& other) const
{
	int var = -(m_ch - other.m_ch);
	return  var;
}

template <typename T> CMyStringReverseIterator<T> CMyStringReverseIterator<T>::operator+(const CMyStringReverseIterator<T>& other)
{
	return {m_ch - other.m_ch, m_index + other.m_index, m_length};
}

template <typename T> CMyStringReverseIterator<T> CMyStringReverseIterator<T>::operator+(const size_t value)
{
	return {m_ch - value, m_index + value, m_length};
}