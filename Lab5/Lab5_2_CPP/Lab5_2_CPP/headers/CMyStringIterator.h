#pragma once
#include <iterator>

template <typename T> class CMyStringIterator
{
public: //TODO: добавить random access iterator , не наследловать от str::iterator  -- сделано
	using value_type = T;
	using difference_type = std::ptrdiff_t;
	using pointer = T*;
	using reference = T&;
	using iterator_category = std::random_access_iterator_tag;
	
	CMyStringIterator(T* p, const size_t length, const size_t index)
		: m_ch(p), m_length(length), m_index(index)
	{
	}

	CMyStringIterator(const CMyStringIterator& it)
	: m_ch(it.m_ch), m_length(it.m_length), m_index(it.m_index)
	{
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
	//CMyStringIterator& operator[](size_t index);

private:
	T* m_ch;
	size_t m_length;
	size_t m_index;
};