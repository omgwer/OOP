#pragma once
#include <iostream>
#include <iterator>
#include <stdexcept>

struct ListElement
{
	ListElement(const std::string& inputString = "", ListElement* prevPtr = nullptr, ListElement* nextPtr = nullptr)
	{
		value = inputString;
		prev = prevPtr;
		next = nextPtr;
	}

	std::string value;
	ListElement* prev;
	ListElement* next;
};

template <typename T> class CMyIterator
{	
public:
	
	using Iterator = CMyIterator<ListElement>;
	using ConstIterator = CMyIterator<const ListElement>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;
	using value_type = T;
	using difference_type = std::ptrdiff_t;
	using pointer = T*;
	using reference = T&;
	using iterator_category = std::bidirectional_iterator_tag;   

	CMyIterator(T* p, T* root)
		: m_data(p), m_root(root)
	{
	}

	~CMyIterator() = default;

	
	operator std::enable_if_t<!std::is_same<T, Iterator>::value, ConstIterator> ()
	{
		std::cout << "Iterator -> ConstIterator success" << std::endl;
		return ConstIterator(m_data, m_root);
	}

	operator std::enable_if_t<!std::is_same<T, ConstIterator>::value, Iterator> ()
	{
		std::cout << "ConstIterator -> Iterator success" << std::endl;
		const auto data = const_cast<ListElement *>(m_data);
		const auto root = const_cast<ListElement *>(m_root);		
		return Iterator(data, root);
	}

	bool operator !=(CMyIterator const& other) const;
	bool operator ==(CMyIterator const& other) const;
	const std::string& operator*() const;	// TODO: возвращать строку, а не шаблонный тип
	CMyIterator& operator++(); 
	CMyIterator operator++(int); 
	CMyIterator& operator--();
	CMyIterator operator--(int);
private:
	T* m_data;
	T* m_root;
	friend class StringList;
};

template <typename T> bool CMyIterator<T>::operator!=(CMyIterator const& other) const
{
	return m_data != other.m_data;
}

template <typename T> bool CMyIterator<T>::operator==(CMyIterator const& other) const
{
	return m_data == other.m_data;
}

template <typename T> const std::string& CMyIterator<T>::operator*() const
{
	if (m_data == m_root)
	{
		throw std::logic_error("Cant dereference end iterator!");
	}
	return m_data->value;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator++()
{
	m_data = m_data->next;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator++(int)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->next;
	return copy;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator--()
{
	m_data = m_data->prev;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator--(int)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->prev;
	return copy;
}