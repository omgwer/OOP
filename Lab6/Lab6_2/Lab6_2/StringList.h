#pragma once
#include "CMyIterator.h"
#include <string>

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

namespace detail
{
struct ListData
{
	// TODO: добавить конструктор перемещения, деструктор, дефолтный конструктор
	// Проверить операции присваивания при приватном наследовании
	ListElement* m_root = nullptr;
	size_t m_length = 0;
	ListData()
	{
		m_root = new ListElement();
		m_root->next = m_root;
		m_root->prev = m_root;
	}
	ListData(ListData&& move) noexcept
	{
		ListElement* newRootElement = new ListElement();
		if (move.m_length == 0)
		{
			m_root->prev = m_root;
			m_root->next = m_root;
		}
		m_root = move.m_root;
		m_length = move.m_length;
		move.m_root = newRootElement;
		move.m_root->next = newRootElement;
		move.m_root->prev = newRootElement;
		move.m_length = 0;
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
		m_root->next = m_root;
		m_root->prev = m_root;
		m_length = 0;
		delete m_root;
	}
};
}

class StringList : private detail::ListData
{
public:
	using Iterator = CMyIterator<ListElement>;
	using ConstIterator = CMyIterator<const ListElement>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

	StringList();
	StringList(const StringList& stringList);
	StringList(StringList&& stringList) noexcept(false);
	~StringList();

	StringList& operator=(const StringList& copy);
	StringList& operator=(StringList&& move) noexcept;

	void PushBack(const std::string& value);
	void PushFront(const std::string& value);
	size_t GetLength() const;
	bool IsEmpty() const;
	void Clear();
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

private:
	// ListElement* m_root = nullptr;
	// size_t m_length = 0;
};
