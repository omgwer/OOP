#pragma once
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

	// возвращает длину строки (без учета завершающего нулевого символа)
	size_t GetLength() const;
	// возвращает указатель на массив символов строки.
	// В конце массива обязательно должен быть завершающий нулевой символ
	// даже если строка пустая 
	const char* GetStringData() const;
	// возвращает подстроку с заданной позиции длиной не больше length символов
	CMyString SubString(size_t start, size_t length = SIZE_MAX) const;
	// очистка строки (строка становится снова нулевой длины)
	void Clear();

	CMyString& operator=(const CMyString& other);
	CMyString const operator+(const CMyString& other);
	CMyString& operator+=(const CMyString& other);
	bool operator==(const CMyString& other);
	bool operator!=(const CMyString& other);
	bool operator>(const CMyString& other);
	bool operator<(const CMyString& other);
	bool operator>=(const CMyString& other);
	bool operator<=(const CMyString& other);
	const char& operator[](size_t id) const;
	char& operator[](size_t id);
	CMyString& operator>>();

private:
	size_t m_len;
	char* m_str;
	char m_endOfLineCh = 0;
};
