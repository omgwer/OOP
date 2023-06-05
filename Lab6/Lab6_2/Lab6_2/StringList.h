#pragma once
#include "CMyIterator.h"
#include <string>

namespace detail
{
struct ListData
{
	ListData()
	{
		m_root = new ListElement();
		m_root->next = m_root;
		m_root->prev = m_root;
	}
	ListData(ListData&& other) noexcept(false)
	{
		const auto newRootElement = new ListElement();		
		m_root = other.m_root;
		m_length = other.m_length;
		other.m_root = newRootElement;
		other.m_root->next = newRootElement;
		other.m_root->prev = newRootElement;
		other.m_length = 0;
	}
	~ListData()
	{
		if (m_root->next == m_root)
			return;	
		auto currentNode = m_root->next;
		while (currentNode != m_root)
		{
			const ListElement* elementToDelete = currentNode;
			currentNode = currentNode->next;
			delete elementToDelete;
		}
		delete m_root;
	}
protected:
	ListElement* m_root = nullptr;
	size_t m_length = 0;
};
}

class StringList : private detail::ListData
{
public:
	using Iterator = CMyIterator<ListElement>;
	using ConstIterator = CMyIterator<const ListElement>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;
	using ValueType = std::string;
	using Reference = ValueType&;
	using ConstReference = const ValueType&;
	using NodePtr = ListElement*;
	
	StringList();
	StringList(const StringList& stringList);
	StringList(StringList&& stringList) noexcept(false);

	StringList& operator=(const StringList& copy);
	StringList& operator=(StringList&& move) noexcept;

	void PushBack(const std::string& value);
	void PushFront(const std::string& value);
	size_t GetLength() const noexcept;
	bool IsEmpty() const noexcept;
	void Clear() noexcept; 
	Iterator Insert(const ConstIterator& it, const std::string& value);
	Iterator Erase(const Iterator&);

	Iterator begin();
	Iterator end();
	ConstIterator cbegin() const;
	ConstIterator cend() const;
	ReverseIterator rbegin();
	ReverseIterator rend();
	ConstReverseIterator rсbegin() const;
	ConstReverseIterator rсend() const;
};
