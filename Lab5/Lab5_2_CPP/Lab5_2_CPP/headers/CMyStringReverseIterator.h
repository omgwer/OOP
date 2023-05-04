#pragma once
#include <iterator>

template<typename T>
class CMyStringReverseIterator : public std::iterator<std::input_iterator_tag, T>
{
	friend class CMyString;
public:
	CMyStringReverseIterator(T* p, size_t length, size_t index)
	: m_ch(p), m_length(length), m_index(index)
	{
	}
	CMyStringReverseIterator(const CMyStringReverseIterator &it)
	: CMyStringReverseIterator(it.m_ch, it.m_length, it.m_index)
	{
	}
	
	bool operator!=(CMyStringReverseIterator const& other) const;
	bool operator==(CMyStringReverseIterator const& other) const;
	typename CMyStringReverseIterator<T>::reference operator*() const;
	CMyStringReverseIterator& operator++();   // prefixVers &
	CMyStringReverseIterator& operator--();
	int operator-(const CMyStringReverseIterator& other)const;
	CMyStringReverseIterator operator+(const CMyStringReverseIterator& other);
	CMyStringReverseIterator operator+(size_t value);
private:
	T* m_ch;
	size_t m_length;
	size_t m_index;
};