#pragma once
#include <memory>
#include <string>

class StringList
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
	// void Clear();
	//
	// void Insert();
	// void Erase();
private:  // TODO: убрать умные указатели
	struct ListElement
	{
		std::string value;
		std::shared_ptr<ListElement> prev = nullptr;
		std::shared_ptr<ListElement> next = nullptr;
	};

	std::shared_ptr<ListElement> m_first = nullptr;
	std::shared_ptr<ListElement> m_last = nullptr;
	size_t m_length = 0;
};
