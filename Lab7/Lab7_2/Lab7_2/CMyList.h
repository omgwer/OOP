#pragma once
#include "CMyIterator.h"

static int m_listDataConstructor = 0;
static int m_listDataDestructor = 0;

namespace detail
{
template <typename T> class ListData
{
public:
	ListData()
	{
		m_root = new ListElement<T>();
		m_root->next = m_root;
		m_root->prev = m_root;
	}

	ListData(ListData&& other) noexcept(false)
	{
		const auto newRootElement = new ListElement<T>();
		m_root = other.m_root;
		m_length = other.m_length;
		other.m_root = newRootElement;
		other.m_root->next = newRootElement;
		other.m_root->prev = newRootElement;
		other.m_length = 0;
	}

	~ListData()
	{
		if (m_root->next == m_root)
			return;
		auto currentNode = m_root->next;
		while (currentNode != m_root)
		{
			const ListElement<T>* elementToDelete = currentNode;
			currentNode = currentNode->next;
			delete elementToDelete;
		}
		delete m_root;
	}

protected:
	ListElement<T>* m_root = nullptr;
	size_t m_length = 0;
};
}

template <typename T> class CMyList : private detail::ListData<T>
{
public:
	using Iterator = CMyIterator<ListElement<T>>;
	using ConstIterator = CMyIterator<const ListElement<T>>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;
	using ValueType = T;
	using Reference = ValueType&;
	using ConstReference = const ValueType&;
	using NodePtr = ListElement<T>*;

	CMyList();
	CMyList(const CMyList& other);
	CMyList(CMyList&& other) noexcept(false);

	CMyList& operator=(const CMyList& copy);
	CMyList& operator=(CMyList&& move);

	void PushBack(const T& value);
	void PushFront(const T& value);
	size_t GetLength() const noexcept;
	bool IsEmpty() const noexcept;
	void Clear() noexcept;
	Iterator Insert(const ConstIterator&, const T& value);
	Iterator Erase(Iterator&);

	Iterator begin();
	Iterator end();
	ConstIterator cbegin() const;
	ConstIterator cend() const;
	ReverseIterator rbegin();
	ReverseIterator rend();
	ConstReverseIterator rсbegin() const;
	ConstReverseIterator rсend() const;
};

template <typename T> CMyList<T>::CMyList()
	: detail::ListData<T>()
{
}

template <typename T> CMyList<T>::CMyList(const CMyList& other)
	: detail::ListData<T>()
{
	if (other.m_length == 0)
	{
		return;
	}
	auto currentNode = other.m_root->next;
	while (currentNode != other.m_root)
	{
		PushBack(currentNode->Value());
		currentNode = currentNode->next;
	}
}

template <typename T> CMyList<T>::CMyList(CMyList&& other) noexcept(false)
	: detail::ListData<T>(std::move(other))
{
}

template <typename T> CMyList<T>& CMyList<T>::operator=(const CMyList& copy)
{
	if (this != &copy)
	{
		T tmp(copy);
		std::swap(this->m_root, tmp.m_root);
		std::swap(this->m_length, tmp.m_length);
	}
	return *this;
}

template <typename T> CMyList<T>& CMyList<T>::operator=(CMyList&& move)
{
	if (this != &move)
	{
		std::swap(this->m_root, move.m_root);
		std::swap(this->m_length, move.m_length);
	}
	return *this;
}

template <typename T> void CMyList<T>::PushBack(const T& value)
{
	auto lastElement = new ListElement<T>(value);
	this->m_root->prev->next = lastElement;
	lastElement->prev = this->m_root->prev;
	this->m_root->prev = lastElement;
	lastElement->next = this->m_root;
	++this->m_length;
}

template <typename T> void CMyList<T>::PushFront(const T& value)
{
	auto firstElement = new ListElement<T>(value);
	firstElement->next = this->m_root->next;
	firstElement->prev = this->m_root;
	this->m_root->next->prev = firstElement;
	this->m_root->next = firstElement;
	++this->m_length;
}

template <typename T> size_t CMyList<T>::GetLength() const noexcept
{
	return this->m_length;
}

template <typename T> bool CMyList<T>::IsEmpty() const noexcept
{
	return this->m_length == 0;
}

template <typename T> void CMyList<T>::Clear() noexcept
{
	if (this->m_root->next == this->m_root)
		return;

	auto currentNode = this->m_root->next;
	while (currentNode != this->m_root)
	{
		const ListElement<T>* elementToDelete = currentNode;
		currentNode = currentNode->next;
		delete elementToDelete;
	}
	this->m_root->next = this->m_root;
	this->m_root->prev = this->m_root;
	this->m_length = 0;
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::Insert(const ConstIterator& it, const T& value)
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
	const auto newElement = new ListElement<T>(value);
	currentIterator.prev->next = newElement;
	newElement->next = const_cast<ListElement<T>*>(&*it);
	newElement->prev = currentIterator.prev;
	++this->m_length;
	return { newElement, this->m_root };
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::Erase(Iterator& it)
{
	if (this->m_length == 0)
	{
		throw std::exception("List is empty!");
	}
	if (it == end())
	{
		throw std::exception("Cant delete root element");
	}

	ListElement<T>* toDelete = it.m_data;
	Iterator newIterator(toDelete->next, this->m_root);
	toDelete->next->prev = toDelete->prev;
	toDelete->prev->next = toDelete->next;
	delete toDelete;
	--this->m_length;
	return newIterator;
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::begin()
{
	return { this->m_root->next, this->m_root };
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::end()
{
	return { this->m_root, this->m_root };
}

template <typename T> typename CMyList<T>::ConstIterator CMyList<T>::cbegin() const
{
	return { this->m_root->next, this->m_root };
}

template <typename T> typename CMyList<T>::ConstIterator CMyList<T>::cend() const
{
	return { this->m_root, this->m_root };
}

template <typename T> typename CMyList<T>::ReverseIterator CMyList<T>::rbegin()
{
	return std::make_reverse_iterator(this->end());
}

template <typename T> typename CMyList<T>::ReverseIterator CMyList<T>::rend()
{
	return std::make_reverse_iterator(this->begin());
}

template <typename T> typename CMyList<T>::ConstReverseIterator CMyList<T>::rсbegin() const
{
	return std::make_reverse_iterator(this->cend());
}

template <typename T> typename CMyList<T>::ConstReverseIterator CMyList<T>::rсend() const
{
	return std::make_reverse_iterator(this->cbegin());
}
