#include "StringList.h"

#include <list>

StringList::StringList()
{
	m_root = new ListElement();
	m_root->next = m_root;
	m_root->prev = m_root;
};

StringList::StringList(const StringList& stringList)
{
	m_root = new ListElement();
	m_root->next = m_root;
	m_root->prev = m_root;
	if (stringList.m_length == 0)
	{
		return;
	}
	auto currentNode = stringList.m_root->next;
	while (currentNode != stringList.m_root)
	{
		try
		{
			PushBack(currentNode->value);
		}
		catch (const std::bad_alloc& e)
		{
			Clear();
			delete m_root;
			throw;
		}
		currentNode = currentNode->next;
	}
}

StringList::StringList(StringList&& stringList) noexcept(false)
{
	ListElement* newRootElement = new ListElement();
	if (stringList.m_length == 0)
	{
		m_root->next = m_root;
		m_root->prev = m_root;
		return;
	}
	m_root = stringList.m_root;
	m_length = stringList.m_length;

	stringList.m_root = newRootElement;
	stringList.m_root->next = newRootElement;
	stringList.m_root->prev = newRootElement;
	stringList.m_length = 0;
}

StringList::~StringList()
{
	Clear();
	delete m_root;
}

StringList& StringList::operator=(const StringList& copy)
{
	if (this != &copy)
	{
		StringList tmp(copy);
		std::swap(m_root, tmp.m_root);
		std::swap(m_length, tmp.m_length);
	}
	return *this;
}

StringList& StringList::operator=(StringList&& move) noexcept
{
	if (this != &move)
	{
		std::swap(m_root, move.m_root);
		std::swap(m_length, move.m_length);
	}
	return *this;
}

void StringList::PushBack(const std::string& value)
{
	auto lastElement = new ListElement(value);
	if (m_root == m_root->next) // значит элемент первый
	{
		m_root->next = lastElement;
		m_root->prev = lastElement;
		lastElement->next = m_root;
		lastElement->prev = m_root;
	}
	else
	{
		m_root->prev->next = lastElement;
		lastElement->prev = m_root->prev;
		m_root->prev = lastElement;
		lastElement->next = m_root;
	}
	m_length++;
}

void StringList::PushFront(const std::string& value)
{
	auto firstElement = new ListElement(value);
	if (m_root->next == m_root) // значит элeмент первый
	{
		m_root->next = firstElement;
		m_root->prev = firstElement;
		firstElement->next = m_root;
		firstElement->prev = m_root;
	}
	else
	{		
		firstElement->next = m_root->next;
		firstElement->prev = m_root;
		m_root->next->prev = firstElement;
		m_root->next = firstElement;
	}
	m_length++;
}

size_t StringList::GetLength() const
{
	return m_length;
}

bool StringList::IsEmpty() const
{
	return m_length == 0;
}

void StringList::Clear()
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
}

// возвращает новый итератор указывающий на добавленный объект 
StringList::Iterator StringList::Insert(const ConstIterator& it, const std::string& value)
{
	if (it == cbegin())
	{
		PushFront(value);
		return begin();
	}
	if (it == cend())
	{
		PushBack(value);
		return end();
	}
	const auto currentIterator = *it;
	const auto newElement = new ListElement(value);
	currentIterator.prev->next = newElement;
	newElement->next = const_cast<ListElement*>(&*it);
	newElement->prev = currentIterator.prev;
	++m_length;
	return { newElement , m_root};
}


StringList::Iterator StringList::Erase(const Iterator& it)
{
	if (m_length == 0)
	{
		throw std::exception("List is empty!");
	}
	if (it == end())
	{
		// TODO: заменить logic_error
		throw std::exception("Cant delete root element");
	}
	
	ListElement* toDelete = it.m_data;
	Iterator newIterator(toDelete->next, m_root);
	toDelete->next->prev = toDelete->prev;
	toDelete->prev->next = toDelete->next;	
	delete toDelete;
	--m_length;
	return newIterator;
}

StringList::Iterator StringList::begin() // TODO: попробовать обойтись без условия 
{
	return { m_root->next, m_root };
}

StringList::Iterator StringList::end()
{
	return { m_root, m_root };
}

StringList::ConstIterator StringList::cbegin() const
{
	return { m_root->next, m_root };
}

StringList::ConstIterator StringList::cend() const
{
	return { m_root, m_root };
}

StringList::ReverseIterator StringList::rbegin()
{
	return std::make_reverse_iterator(this->end());
}

StringList::ReverseIterator StringList::rend()
{
	return std::make_reverse_iterator(this->begin());
}

StringList::ConstReverseIterator StringList::rсbegin() const
{
	return std::make_reverse_iterator(this->cend());
}

StringList::ConstReverseIterator StringList::rсend() const
{
	return std::make_reverse_iterator(this->cbegin());
}
