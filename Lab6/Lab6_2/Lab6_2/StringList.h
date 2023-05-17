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
	StringList(StringList&& stringList);
	~StringList();

	StringList& operator=(const StringList& copy);
	StringList& operator=(StringList&& move);

	void PushBack(const std::string& value);
	void PushFront(const std::string& value);
	size_t GetLength() const;
	bool IsEmpty() const;
	void Clear();
	// TODO: Insert для insert использовать constIterator , возвращает новый итератор
	Iterator Insert(const Iterator& it,const std::string& value);
	// TODO: Erase возвращает новый итератор указывающий на следующий элемент после удаленного либо end
	Iterator Erase(Iterator&);
	
	Iterator begin();
	Iterator end();
	ConstIterator begin() const;
	ConstIterator end() const;
	ReverseIterator rbegin();
	ReverseIterator rend();
	ConstReverseIterator rсbegin() const;
	ConstReverseIterator rсend() const;
	
private:  // TODO: убрать умные указатели
	ListElement* m_end = nullptr;
	ListElement* m_first = nullptr;
	ListElement* m_last = nullptr;
	size_t m_length = 0;
};
