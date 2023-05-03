#pragma once
#include <iterator>

template<typename T>
class CMyStringReverseIterator : public std::iterator<std::input_iterator_tag, T>
{
	friend class CMyString;
public:
	CMyStringReverseIterator(T* p);
	CMyStringReverseIterator(const CMyStringReverseIterator &it);
	bool operator!=(CMyStringReverseIterator const& other) const;
	bool operator==(CMyStringReverseIterator const& other) const;
	typename CMyStringReverseIterator<T>::reference operator*() const;
	CMyStringReverseIterator& operator++();
	CMyStringReverseIterator& operator--();
private:
	T* m_ch;
};

