#pragma once
#include <string>

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
	//
	// void Insert();
	// void Erase();

	
	
private:  // TODO: убрать умные указатели
	struct ListElement
	{
		std::string value;
		ListElement* prev = nullptr;
		ListElement* next = nullptr;
	};	
	ListElement* m_first = nullptr;
	ListElement* m_last = nullptr;
	size_t m_length = 0;
};
