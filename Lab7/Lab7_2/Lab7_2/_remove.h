#pragma once

#include <iostream>
#include <new>

template <typename T>
struct Node
{
	Node() = default;
	Node(const T& value) 
	{
		new (buffer) T(value);
	}
	T& Value() noexcept { return *reinterpret_cast<T*>(&buffer); }
	void Destroy() noexcept { Value().~T(); }
private:
	alignas(T) char buffer[sizeof(T)];
};

int main(int argc, char* argv[])
{
	auto* node = new Node<std::string>("hello");
	node->Value() = "hello1";
	node->Destroy();
	delete node;

	auto sentinelNode = new Node<std::string>();
	delete sentinelNode;

}