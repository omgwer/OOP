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

	CMyStringIterator(const CMyStringIterator<T>& it)
	: m_ch(it.m_ch), m_length(it.m_length), m_index(it.m_index)
	{
	}

	~CMyStringIterator() = default;

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
	T& operator[](size_t index);   // TODO: добавить индексированный доступ
	T& operator[](size_t index) const;  
private:
	T* m_ch;
	size_t m_length; // TODO: удалить
	size_t m_index;  // TODO: удалить 
};