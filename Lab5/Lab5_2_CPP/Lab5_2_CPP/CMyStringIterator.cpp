#include "headers/CMyStringIterator.h"

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
