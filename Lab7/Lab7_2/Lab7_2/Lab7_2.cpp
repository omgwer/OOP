#include <iostream>
#include "CMyList.h"
#include "new"
struct TestObj
{
	TestObj(int v):value(v){}
	int value;	
};

int main()
{
	// CMyList<std::string> test;
	//
	// test.PushFront("cat");
	// test.PushFront("efim");
	// test.PushFront("grumpy");
	//
	//
	// auto rbegin = test.cbegin();
	// auto rend = test.cend();
	//
	// auto rer = test.Insert(rbegin, "some");
	// auto rer1 = test.Insert(rend, "kek");
	// rbegin = test.cbegin();
	// rend = test.cend();
	// while (rbegin != rend)
	// {
	// 	std::cout << (*rbegin).value << std::endl;
	// 	++rbegin;
	// }

	CMyList<TestObj> test;
	test.PushBack(1);

	// TODO: placement new object

	struct Node
	{
		auto pNode() = defaul
		Node(const T& value ) 
		{
			new (buffer) T(value);
		}

		private T& Value() noexcept { return *reintepret_cast<T*>(&buffer); } 
		alignas(T) char buffer[sizeof(T)];
		void Destroy()
		{
			Value().~T();
		}
	};

	//
	Node<std::string> node("helloe");
	node.Value = "hello1";
	return 0;	
}

