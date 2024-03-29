#pragma once
#include <exception>
#include <iterator>

template <typename T> class CMyList;

static int m_listDataConstructor = 0;
static int m_listDataDestructor = 0;

template <typename T> struct ListElement
{
	ListElement()
	{
		++m_listDataConstructor;
	}

	ListElement(const T& value, ListElement* prevPtr = nullptr, ListElement* nextPtr = nullptr)
	{
		new(buffer) T(value);
		prev = prevPtr;
		next = nextPtr;
		++m_listDataConstructor;
	}

	// ~ListElement()   // -- recursive cycle ? 
	// {
	// 	this->Destroy();		
	// }

	T& Value() noexcept { return *reinterpret_cast<T*>(&buffer); }
	void Destroy() noexcept
	{
		Value().~T();
		++m_listDataDestructor;
	}

	ListElement* prev = nullptr;
	ListElement* next = nullptr;

private:
	alignas(T) char buffer[sizeof(T)];
};

template <typename T> class CMyIterator
{
public:	
	using Iterator = CMyIterator<ListElement<T>>;
	using ConstIterator = CMyIterator<const ListElement<T>>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;
	using value_type = T;
	using difference_type = std::ptrdiff_t;
	using pointer = T*;
	using reference = T&;
	using iterator_category = std::random_access_iterator_tag;

	CMyIterator(T* p, T* root)
		: m_data(p), m_root(root)
	{
	}

	~CMyIterator() = default;

	/**
	 *  Если T != Iterator, то тип перегружаемого оператора ConstIterator
	 *  Сначала проверяем тип шаблона(is_same), если он совпадает с Iterator, то false
	 */
	operator std::enable_if_t<!std::is_same<T, Iterator>::value, ConstIterator> ()
	{
		std::cout << "Iterator -> ConstIterator success" << std::endl;
		return ConstIterator(m_data, m_root);
	}

	operator std::enable_if_t<!std::is_same<T, ConstIterator>::value, Iterator> ()
	{
		std::cout << "ConstIterator -> Iterator success" << std::endl;
		auto data = const_cast<ListElement<T> *>(m_data);
		auto root = const_cast<ListElement<T> *>(m_root);		
		return Iterator(data, root);
	}

	bool operator!=(CMyIterator const& other) const;
	bool operator==(CMyIterator const& other) const;
	reference operator*() const;
	CMyIterator& operator++(); 
	CMyIterator operator++(int);
	CMyIterator& operator--();
	CMyIterator operator--(int);
public:
	friend class CMyList<T>;
	T* m_data;
	T* m_root;
};

template <typename T> bool CMyIterator<T>::operator!=(CMyIterator const& other) const
{
	return m_data != other.m_data;
}

template <typename T> bool CMyIterator<T>::operator==(CMyIterator const& other) const
{
	return m_data == other.m_data;
}

template <typename T> typename CMyIterator<T>::reference CMyIterator<T>::operator*() const
{
	if (m_data == m_root)
	{
		throw std::exception("Cant dereference end iterator!");
	}
	return *m_data;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator++()
{
	m_data = m_data->next;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator++(const int ch)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->next;
	return copy;
}

template <typename T> CMyIterator<T>& CMyIterator<T>::operator--()
{
	m_data = m_data->prev;
	return *this;
}

template <typename T> CMyIterator<T> CMyIterator<T>::operator--(const int ch)
{
	CMyIterator<T> copy = { *this };
	m_data = m_data->prev;
	return copy;
}