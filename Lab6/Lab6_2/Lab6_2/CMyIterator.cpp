#include "CMyIterator.h"
#include <stdexcept>

template <typename T> CMyIterator<T>::~CMyIterator()
= default;

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
	// if (m_data->next == nullptr)
	// 	throw std::out_of_range("Operation cannot be performed, out of range!");
	m_data = m_data->next;
	m_index++;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator++(const int ch)
{
	// if (m_data->next == nullptr)
	// 	throw std::out_of_range("Operation cannot be performed, out of range!");
	//
	CMyIterator<T> copy = {*this};	
	m_data = m_data->next;
	m_index++;
	
	return copy;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator--()
{
	// if (m_data->prev == nullptr)
	// 	throw std::out_of_range("Operation cannot be performed, out of range!");

	m_data = m_data->prev;
	m_index--;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator--(const int ch)
{
	if (m_data->prev == nullptr)
		throw std::out_of_range("Operation cannot be performed, out of range!");
	
	CMyIterator<T> copy = {*this};	
	m_data = m_data->prev;
	m_index--;	
	return copy;
}

template <typename T> ptrdiff_t CMyIterator<T>::operator-(const CMyIterator<T>& other) const
{	
	return  m_index - other.m_index;
}