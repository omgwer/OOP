#pragma once
#include <memory>
#include <string>

class StringList
{	
public:
	StringList();
	StringList(const StringList& stringList);
	StringList(StringList&& stringList) noexcept;
	~StringList();
	
	void PushFront(const std::string& value);
	void PushBack(const std::string& value);
	size_t GetLength() const;
	bool IsEmpty() const;	
	void Clear();

	void Insert();
	void Erase();
private:	
	struct ListElement
	{
		std::string value;
		std::unique_ptr<ListElement> prev = nullptr;
		std::unique_ptr<ListElement> next = nullptr;
	};
	std::unique_ptr<ListElement> m_first = nullptr;
	std::unique_ptr<ListElement> m_last = nullptr;
	size_t m_length = 0;	
};
