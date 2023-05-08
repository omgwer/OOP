#pragma once
#include "CMyIterator.h"

template <typename T> class CMyList
{
private:
	struct ListElement
	{
		T value;
		ListElement* prev = nullptr;
		ListElement* next = nullptr;
	};
public:	
	using Iterator = CMyIterator<ListElement>;
	using ConstIterator = CMyIterator<const ListElement>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

	CMyList();
	CMyList(const CMyList& copy);
	CMyList(CMyList&& move);
	~CMyList();

	CMyList& operator=(const CMyList& copy);
	CMyList& operator=(CMyList&& move);

	void PushBack(const T& value);
	void PushFront(const T& value);
	size_t GetLength() const;
	bool IsEmpty() const;
	void Clear();
	void Insert(const Iterator&, const T& value);
	void Erase(Iterator&);

	Iterator begin();
	Iterator end();
	ConstIterator begin() const;
	ConstIterator end() const;
	ReverseIterator rbegin();
	ReverseIterator rend();
	ConstReverseIterator rсbegin() const;
	ConstReverseIterator rсend() const;

private: // TODO: убрать умные указатели
	ListElement* m_first = nullptr;
	ListElement* m_last = nullptr;
	size_t m_length = 0;
};
