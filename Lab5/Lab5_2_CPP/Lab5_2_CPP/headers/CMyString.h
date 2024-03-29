#pragma once
#include "CMyStringIterator.h"

#include <cstdint>
#include <string>

class CMyString
{
public:
	// конструктор по умолчанию
	CMyString();
	// конструктор, инициализирующий строку данными строки
	// с завершающим нулевым символом
	CMyString(const char* pString);
	// конструктор, инициализирующий строку данными из 
	// символьного массива заданной длины
	CMyString(const char* pString, size_t length);
	// конструктор копирования
	CMyString(CMyString const& other);
	// перемещающий конструктор (для компиляторов, совместимых с C++11)
	//  реализуется совместно с перемещающим оператором присваивания 
	CMyString(CMyString&& other);
	// конструктор, инициализирующий строку данными из 
	// строки стандартной библиотеки C++
	CMyString(std::string const& stlString);
	// деструктор класса - освобождает память, занимаемую символами строки
	~CMyString();

	// возвращает длину строки (без учёта завершающего нулевого символа)
	size_t GetLength() const;
	// возвращает указатель на массив символов строки.
	// В конце массива обязательно должен быть завершающий нулевой символ
	// даже если строка пустая 
	const char* GetStringData() const;
	// возвращает подстроку с заданной позиции длиной не больше length символов
	CMyString SubString(size_t start, size_t length = SIZE_MAX) const;
	// очистка строки (строка становится снова нулевой длины)
	void Clear();
	// overload
	CMyString& operator=(const CMyString& other); // TODO: добавить перемещающий оператор присваивания  --сделано
	CMyString& operator=(CMyString&& other);
	CMyString operator+(const CMyString& other) const;
	CMyString& operator+=(const CMyString& other);
	bool operator==(const CMyString& other) const;
	bool operator!=(const CMyString& other) const;
	bool operator>(const CMyString& other) const;
	bool operator<(const CMyString& other) const;
	bool operator>=(const CMyString& other) const;
	bool operator<=(const CMyString& other) const;
	const char& operator[](size_t index) const;
	char& operator[](size_t index);

	// iterators
	using Iterator = CMyStringIterator<char>;
	using ConstIterator = CMyStringIterator<const char>;
	using ReverseIterator = std::reverse_iterator<Iterator>;
	using ConstReverseIterator = std::reverse_iterator<ConstIterator>;

	Iterator begin(); // TODO: преобразовывать итератор(обычный) к  итератору константтому -- сделано
	Iterator end();
	ConstIterator сbegin() const;
	ConstIterator сend() const;
	ReverseIterator rbegin();
	ReverseIterator rend();
	ConstReverseIterator rсbegin() const;
	ConstReverseIterator rсend() const;

	friend std::istream& operator>>(std::istream& istream, CMyString& myString);
	friend std::ostream& operator<<(std::ostream& ostream, const CMyString& myString);

private:
	struct DontAllocate
	{
		explicit DontAllocate() = default;
	};
	CMyString(char* pString, size_t length, DontAllocate) noexcept;
	size_t m_length;
	char* m_str;
	int CompareStrings(const CMyString& other) const;
};

std::istream& operator>>(std::istream& istream, CMyString& myString);
std::ostream& operator<<(std::ostream& ostream, const CMyString& myString);
