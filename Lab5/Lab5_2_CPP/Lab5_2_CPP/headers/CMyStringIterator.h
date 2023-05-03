#pragma once
#include <iterator>

template<typename T>
class CMyStringIterator : public std::iterator<std::input_iterator_tag, T>
{
	friend class CMyString;
public:
	CMyStringIterator(T* p);
	CMyStringIterator(const CMyStringIterator &it);
	bool operator!=(CMyStringIterator const& other) const;
	bool operator==(CMyStringIterator const& other) const;
	typename CMyStringIterator<T>::reference operator*() const;
	CMyStringIterator& operator++();
	CMyStringIterator& operator--();
	CMyStringIterator operator-(const CMyStringIterator& other);
private:
	T* m_ch;
	size_t m_size;
	size_t m_index;
};