#pragma once
#include "CMyIterator.h"

template <typename T> class CMyList
{
public:
	struct ListElement
	{
		ListElement() = default;

		ListElement(const T& value, ListElement* prevPtr = nullptr, ListElement* nextPtr = nullptr)
		{
			new(buffer) T(value);
			prev = prevPtr;
			next = nextPtr;
		}

		T& Value() noexcept { return *reinterpret_cast<T*>(&buffer); }
		void Destroy() noexcept { Value().~T(); }

		ListElement* prev = nullptr;
		ListElement* next = nullptr;

	private:
		alignas(T) char buffer[sizeof(T)];
	};

public:
	using Iterator = CMyIterator<ListElement>;
	using ConstIterator = CMyIterator<const ListElement>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

	CMyList();
	CMyList(const CMyList& copy);
	CMyList(CMyList&& move) noexcept;
	~CMyList();

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

private:
	/**
	 * @param next - (first element)
	 * @param last - (last element) 
	 */
	ListElement* m_root = nullptr;
	size_t m_length = 0;

};

template <typename T> CMyList<T>::CMyList()
{
	m_root = new ListElement();
	m_root->next = m_root;
	m_root->prev = m_root;
}

template <typename T> CMyList<T>::CMyList(const CMyList& copy)
{
	m_root = new ListElement();
	m_root->next = m_root;
	m_root->prev = m_root;
	if (copy.m_length == 0)
	{
		return;
	}
	auto currentNode = copy.m_root->next;
	while (currentNode != copy.m_root)
	{
		try
		{
			PushBack(currentNode->value);
		}
		catch (const std::bad_alloc& e)
		{
			delete m_root;
			return;
		}
		currentNode = currentNode->next;
	}
}

template <typename T> CMyList<T>::CMyList(CMyList&& other) noexcept
{
	ListElement* newRootElement = new ListElement();
	if (other.m_length == 0)
	{
		m_root->next = m_root;
		m_root->prev = m_root;
		return;
	}
	m_root = other.m_root;
	m_length = other.m_length;

	other.m_root = newRootElement;
	other.m_root->next = newRootElement;
	other.m_root->prev = newRootElement;
	other.m_length = 0;
}

template <typename T> CMyList<T>::~CMyList()
{
	Clear();
	delete m_root;
}

template <typename T> CMyList<T>& CMyList<T>::operator=(const CMyList& copy)
{
	if (this != &copy)
	{
		T tmp(copy);
		std::swap(m_root, tmp.m_root);
		std::swap(m_length, tmp.m_length);
	}
	return *this;
}

template <typename T> CMyList<T>& CMyList<T>::operator=(CMyList&& move)
{
	if (this != &move)
	{
		std::swap(m_root, move.m_root);
		std::swap(m_length, move.m_length);
	}
	return *this;
}

template <typename T> void CMyList<T>::PushBack(const T& value)
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

template <typename T> void CMyList<T>::PushFront(const T& value)
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

template <typename T> size_t CMyList<T>::GetLength() const noexcept
{
	return m_length;
}

template <typename T> bool CMyList<T>::IsEmpty() const noexcept
{
	return m_length == 0;
}

template <typename T> void CMyList<T>::Clear() noexcept
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
	const auto newElement = new ListElement(value);
	currentIterator.prev->next = newElement;
	newElement->next = const_cast<ListElement*>(&*it);
	newElement->prev = currentIterator.prev;
	++m_length;
	return { newElement, m_root };
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::Erase(Iterator& it)
{
	if (m_length == 0)
	{
		throw std::exception("List is empty!");
	}
	if (it == end())
	{
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

template <typename T> typename CMyList<T>::Iterator CMyList<T>::begin()
{
	return { m_root->next, m_root };
}

template <typename T> typename CMyList<T>::Iterator CMyList<T>::end()
{
	return { m_root, m_root };
}

template <typename T> typename CMyList<T>::ConstIterator CMyList<T>::cbegin() const
{
	return { m_root->next, m_root };
}

template <typename T> typename CMyList<T>::ConstIterator CMyList<T>::cend() const
{
	return { m_root, m_root };
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
