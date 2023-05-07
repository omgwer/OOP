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
	StringList();
	StringList(const StringList& stringList);
	StringList(StringList&& stringList);
	~StringList();

	void PushBack(const std::string& value);
	void PushFront(const std::string& value);
	size_t GetLength() const;
	bool IsEmpty() const;
	void Clear();	
//	void Insert(Iterator);
//	void Erase();

	using Iterator = CMyIterator<ListElement>;
	using ConstIterator = CMyIterator<const ListElement>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

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
