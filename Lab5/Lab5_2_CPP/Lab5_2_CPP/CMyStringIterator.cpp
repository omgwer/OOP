#include "headers/CMyStringIterator.h"

#include <stdexcept>

template <class T> CMyStringIterator<T>::CMyStringIterator(T* p)
	: m_ch(p)
{
}

template <class T> CMyStringIterator<T>::CMyStringIterator(const CMyStringIterator& it)
	: m_ch(it.m_ch)
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

template <typename T>
CMyStringIterator<T> CMyStringIterator<T>::operator-(const CMyStringIterator& other)
{
	int difference = m_index - other.m_index;
	if (difference < 0)
		throw std::out_of_range("Error! Right operator biggest left operator!");
	return new CMyStringIterator(); // TODO: добпавить в конструктор 
}
