#include "headers/CMyStringReverseIterator.h"
#include <cassert>
template <typename T> bool CMyStringReverseIterator<T>::operator!=(CMyStringReverseIterator const& other) const
{
	return m_ch != other.m_ch;
}

template <typename T> bool CMyStringReverseIterator<T>::operator==(CMyStringReverseIterator const& other) const
{
	return m_ch == other.m_ch;
}

template <typename T> T& CMyStringReverseIterator<T>::operator*() const
{
	return *m_ch;
}

template <typename T> CMyStringReverseIterator<T>& CMyStringReverseIterator<T>::operator++()
{
	assert(m_length < m_index + 1 && "Iterator out of range!"); 
	--m_ch;
	return *this;
}

template <typename T> CMyStringReverseIterator<T>& CMyStringReverseIterator<T>::operator--()
{
	assert(0 < m_index - 1 && "Iterator out of range!"); 
	++m_ch;
	return *this;
}

template <typename T> int CMyStringReverseIterator<T>::operator-(const CMyStringReverseIterator<T>& other) const
{	
	int var = -(m_ch - other.m_ch);
	assert(0 < var && "Iterator out of range!"); 
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