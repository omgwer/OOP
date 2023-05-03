#pragma once
#include <iterator>

template<typename T>
class CMyStringIterator : public std::iterator<std::input_iterator_tag, T>
{
	friend class CMyString;
public:
	CMyStringIterator(T* p, size_t length, size_t index);
	CMyStringIterator(const CMyStringIterator &it);
	bool operator!=(CMyStringIterator const& other) const;
	bool operator==(CMyStringIterator const& other) const;
	typename CMyStringIterator<T>::reference operator*() const;
	CMyStringIterator& operator++();   // prefixVers &
	CMyStringIterator& operator--();
	int operator-(const CMyStringIterator& other)const;
	CMyStringIterator operator+(const CMyStringIterator& other);
	CMyStringIterator operator+(size_t value);
private:
	T* m_ch;
	size_t m_length;
	size_t m_index;
};