//
// template <typename T> struct ListElement
// {
// 	ListElement() = default;
//
// 	ListElement(const T& value, ListElement* prevPtr = nullptr, ListElement* nextPtr = nullptr)
// 	{
// 		new(buffer) T(value);
// 		prev = prevPtr;
// 		next = nextPtr;
// 	}
//
// 	T& Value() noexcept { return *reinterpret_cast<T*>(&buffer); }
// 	void Destroy() noexcept { Value().~T(); }
//
// 	ListElement* prev = nullptr;
// 	ListElement* next = nullptr;
//
// private:
// 	alignas(T) char buffer[sizeof(T)];
// };
//
// namespace detail
// {
// template <typename T> class ListData
// {
// 	ListData()
// 	{
// 		m_root = new ListElement<T>();
// 		m_root->next = m_root;
// 		m_root->prev = m_root;
// 	}
// 	
// 	ListData(ListData&& other) noexcept(false)
// 	{
// 		const auto newRootElement = new ListElement<T>();		
// 		m_root = other.m_root;
// 		m_length = other.m_length;
// 		other.m_root = newRootElement;
// 		other.m_root->next = newRootElement;
// 		other.m_root->prev = newRootElement;
// 		other.m_length = 0;
// 	}
// 	~ListData()
// 	{
// 		if (m_root->next == m_root)
// 			return;	
// 		auto currentNode = m_root->next;
// 		while (currentNode != m_root)
// 		{
// 			const ListElement<T>* elementToDelete = currentNode;
// 			currentNode = currentNode->next;
// 			delete elementToDelete;
// 		}
// 		delete m_root;
// 	}
// public:	
// 	ListElement<T>* m_root = nullptr;
// 	size_t m_length = 0;	
// };
// }
//
