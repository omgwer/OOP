#pragma once
#include "../CMyIterator.h"
#include <string>

struct ListElement
{
	std::string value;
	ListElement* prev = nullptr;
	ListElement* next = nullptr;
};

class StringList  // TODO: подумать над проблемами перемещающего конструктора как в лабе 5.2
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
	void Insert(const Iterator&,const std::string& value);
	void Erase(const Iterator&);

	

	// ConstIterator ToConst(const Iterator& iterator) const;
	// ConstReverseIterator ToConst(const ReverseIterator& iterator) const;
	Iterator begin();
	Iterator end();
	// ConstIterator сbegin() const;
	// ConstIterator сend() const;
	// ReverseIterator rbegin();
	// ReverseIterator rend();
	// ConstReverseIterator rсbegin() const;
	// ConstReverseIterator rсend() const;
	
private:  // TODO: убрать умные указатели	
	ListElement* m_first = nullptr;
	ListElement* m_last = nullptr;
	size_t m_length = 0;
};
