#pragma once
#include <iterator>

template<typename T>  //  TODO: add reverse iterator
class CMyStringReverseIterator : public std::iterator<std::input_iterator_tag, T>
{
public:
	CMyStringReverseIterator(T* p, size_t length, size_t index)
	: m_ch(p), m_length(length), m_index(index)
	{
	}
	CMyStringReverseIterator(const CMyStringReverseIterator &it)
	: m_ch(it.m_ch), m_length(it.m_length), m_index(it.m_index)
	{
	}
	
	bool operator!=(CMyStringReverseIterator<T> const& other) const;
	bool operator==(CMyStringReverseIterator<T> const& other) const;
	T& operator*() const;
	CMyStringReverseIterator& operator++();   // TODO: prefixVers &
	CMyStringReverseIterator& operator--();
	int operator-(const CMyStringReverseIterator& other)const;
	CMyStringReverseIterator operator+(const CMyStringReverseIterator& other);
	CMyStringReverseIterator operator+(size_t value);
private:
	T* m_ch;
	size_t m_length;
	size_t m_index;
};