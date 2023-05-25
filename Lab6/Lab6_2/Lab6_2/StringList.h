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

class StringList
{
public:
	using Iterator = CMyIterator<ListElement>;
	using ConstIterator = CMyIterator<const ListElement>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;
	
	StringList();
	StringList(const StringList& stringList);
	StringList(StringList&& stringList) noexcept;
	~StringList();

	StringList& operator=(const StringList& copy);
	StringList& operator=(StringList&& move) noexcept;

	void PushBack(const std::string& value);
	void PushFront(const std::string& value);
	size_t GetLength() const;
	bool IsEmpty() const;
	void Clear();
	// TODO: Insert для insert использовать constIterator , возвращает новый итератор
	Iterator Insert(const ConstIterator& it,const std::string& value);
	// TODO: Erase возвращает новый итератор указывающий на следующий элемент после удаленного либо end
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
	/**
	 * @param next - (first element)
	 * @param last - (last element) 
	 */
	ListElement* m_root = nullptr;
	size_t m_length = 0;
};
