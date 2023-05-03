#include "headers/CMyStringIterator.h"

template <class T> CMyStringIterator<T>::CMyStringIterator(T* p, size_t length, size_t index)
	: m_ch(p), m_length(length), m_index(index)
{
}

template <class T> CMyStringIterator<T>::CMyStringIterator(const CMyStringIterator& it)
	: CMyStringIterator(it.m_ch, it.m_length, it.m_index)
{
}

template <typename T> bool CMyStringIterator<T>::operator!=(CMyStringIterator const& other) const
{
	return m_ch != other.m_ch;
}

template <typename T> bool CMyStringIterator<T>::operator==(CMyStringIterator const& other) const
{
	return m_ch == other.m_ch;
}

template <typename T> typename CMyStringIterator<T>::reference CMyStringIterator<T>::operator*() const
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
	return {m_ch + other.m_ch, m_index + other.m_index, m_length + other.m_length};
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator+(const size_t value)
{
	return {m_ch + value, m_index + value, m_length + value};
}