#pragma once
#include <iterator>

template <typename T> class CMyIterator
{
public:
	using value_type = T;
	using difference_type = std::ptrdiff_t;
	using pointer = T*;
	using reference = T&;
	using iterator_category = std::random_access_iterator_tag;

	CMyIterator(T* p, const size_t length, const size_t index)
		: m_data(p), m_length(length), m_index(index)
	{
	}

	//CMyIterator(const T* other) : m_data(other->m_element), m_length(0), m_index(0){}

	~CMyIterator();

	bool operator !=(CMyIterator const& other) const;
	bool operator ==(CMyIterator const& other) const;
	T& operator*() const;
	CMyIterator& operator++();  // prefix
	CMyIterator operator++(int); // postfix
	CMyIterator& operator--();
	CMyIterator operator--(int);
	ptrdiff_t operator-(const CMyIterator& other) const;
private:
	T* m_data;
	size_t m_length;
	size_t m_index;
};

