#pragma once
#include <iterator>

//TODO: добавить random access iterator , не наследловать от str::iterator 
template <typename T> class CMyStringIterator : public std::iterator<std::input_iterator_tag, T>
{
public:
	CMyStringIterator(T* p, size_t length, size_t index)
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
	//CMyStringIterator operator++(); // prefixVers &  // TODO: добавить постфиксную версию
	CMyStringIterator& operator--();
	int operator-(const CMyStringIterator& other) const; //  TODO: добавить ptrdifft
	CMyStringIterator operator+(const CMyStringIterator& other);
	CMyStringIterator operator+(size_t value);

private:
	T* m_ch;
	size_t m_length;
	size_t m_index;
};