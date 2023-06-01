#pragma once
#include <iterator>
#include <cassert>
#include <iostream>
#include <list>


template <typename T> class CMyStringIterator
{
	using Iterator = CMyStringIterator<char>;
	using ConstIterator = CMyStringIterator<const char>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

public: //TODO: добавить random access iterator , не наследловать от str::iterator  -- сделано
	using value_type = T;
	using difference_type = std::ptrdiff_t;
	using pointer = T*;
	using reference = T&;
	using iterator_category = std::random_access_iterator_tag;

	CMyStringIterator(T* p, T* m_start, T* m_end)
		: m_ch(p), m_start(m_start), m_end(m_end)
	{
	}

	CMyStringIterator(const CMyStringIterator<T>& it)
		: m_ch(it.m_ch), m_start(it.m_start), m_end(it.m_end)
	{
	}

	~CMyStringIterator();

	// SFINAE (Substitution failure is not an error) - неудачная замена не является ошибкой

	/**
	 *  Если T != Iterator, то тип перегружаемого оператора ConstIterator
	 *  Сначала проверяем тип шаблона(is_same), если он совпадает с Iterator, то false
	 */
	operator std::enable_if_t<!std::is_same<T, Iterator>::value, ConstIterator> ()
	{
		std::cout << "Iterator -> ConstIterator success" << std::endl;
		return ConstIterator(m_ch, m_start, m_end );
	}
	
	operator std::enable_if_t<!std::is_same<T, ConstIterator>::value, Iterator> ()
	{
		std::cout << "ConstIterator -> Iterator success" << std::endl;
		auto ch = const_cast<char *>(m_ch);
		auto start = const_cast<char *>(m_start);
		auto end = const_cast<char *>(m_end);		
		return Iterator(ch, start,end);
	}

	bool operator!=(CMyStringIterator const& other) const;
	bool operator==(CMyStringIterator const& other) const;
	T& operator*() const;
	CMyStringIterator& operator++(); // prefixVers &
	CMyStringIterator operator++(int); // prefixVers &  // TODO: добавить постфиксную версию -- сделано
	CMyStringIterator& operator--();
	CMyStringIterator operator--(int); // TODO: добавить постфиксную версию -- сделано
	ptrdiff_t operator-(const CMyStringIterator& other) const; //  TODO: добавить ptrdifft -- сделано
	CMyStringIterator operator+(const CMyStringIterator& other);
	CMyStringIterator operator+(size_t value);
	T& operator[](ptrdiff_t index); // TODO: добавить индексированный доступ -- сделано
	T& operator[](ptrdiff_t index) const;

private:
	T* m_ch;
	T* m_start;
	T* m_end;
};

template <typename T> CMyStringIterator<T>::~CMyStringIterator()
= default;

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
	assert(m_end > m_ch + 1 && "Iterator out of range!");
	++m_ch;
	return *this;
}

template <typename T> CMyStringIterator<T>& CMyStringIterator<T>::operator--()
{
	assert(m_start < m_ch - 1 && "Iterator out of range!");
	--m_ch;
	return *this;
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator++(const int ch)
{
	assert(m_end > m_ch + 1 && "Iterator out of range!");
	CMyStringIterator<T> copy = { *this };
	++m_ch;
	return copy;
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator--(const int ch)
{
	assert(m_start < m_ch - 1 && "Iterator out of range!");
	CMyStringIterator<T> copy = { *this };
	--m_ch;
	return copy;
}

template <typename T> ptrdiff_t CMyStringIterator<T>::operator-(const CMyStringIterator<T>& other) const
{
	auto distance = std::distance(this, other);
	assert(distance < 0 && "Iterator out of range!");
	return distance;
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator+(const CMyStringIterator<T>& other)
{
	auto distance = std::distance(this, other);
	assert(distance < 0 && "Iterator out of range!");
	return { m_ch + distance, m_end, m_start };
}

template <typename T> CMyStringIterator<T> CMyStringIterator<T>::operator+(size_t value)
{
	assert(m_ch + value > m_end && "Iterator out of range!");
	return { m_ch + value, m_end, m_start };
}

template <typename T> T& CMyStringIterator<T>::operator[](ptrdiff_t index)
{
	assert(m_ch + index < m_end && "Iterator out of range!");
	auto link = m_ch + index;
	return *link;
}

template <typename T> T& CMyStringIterator<T>::operator[](ptrdiff_t index) const
{
	assert(m_ch + index < m_end && "Iterator out of range!");
	auto link = m_ch + index;
	return *link;
}
