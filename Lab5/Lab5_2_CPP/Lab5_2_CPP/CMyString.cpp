#include "headers/CMyString.h"

#include <iostream>
#include <stdexcept>

static char m_endOfLineCh = '\0'; // TODO вынести в статическую переменную или константу -- сделано

CMyString::CMyString()
{
	m_length = 0;
	m_str = new char[m_length + 1];
	m_str[0] = m_endOfLineCh;
}

CMyString::CMyString(const char* pString)
	: CMyString(pString, std::strlen(pString))
{
}

CMyString::CMyString(const char* pString, const size_t length)
{
	if (!pString)
	{
		throw std::invalid_argument("Null pointer");
	}
	
	m_length = length;
	m_str = new char[m_length + 1];
	std::memcpy(m_str, pString, length);
	m_str[m_length] = m_endOfLineCh;
}

CMyString::CMyString(CMyString const& other)
	: CMyString(other.GetStringData(), other.GetLength())
{
}

CMyString::CMyString(CMyString&& other)
{	
	m_str = const_cast<char*>(other.GetStringData());  // TODO : заменить на обращение к приватному полю
	m_length = other.GetLength();
	//other = CMyString(); // TODO: при перемещении возвращать ссылку на строку  с символом \0  -- сделано
	other.m_length = 0;
	other.m_str = &m_endOfLineCh;
}

//TODO убрать const из параметров
CMyString::CMyString(const char* pString, const size_t length, const bool isAllocatedMemory)
{
	if (isAllocatedMemory)
	{
		m_str = const_cast<char*>(pString);
		m_length = length;
	}
	else
	{
		//*this = CMyString(pString, length); // TODO: убрать конструктор, добавить нормальную инициализацию -- сделано
		m_length = length;
		m_str = new char[m_length + 1];
		std::memcpy(m_str, pString, length);
		m_str[m_length] = m_endOfLineCh;
	}
}

CMyString::CMyString(std::string const& stlString)
	: CMyString(stlString.c_str(), stlString.length())
{
}

CMyString::~CMyString()
{
	if (m_str != &m_endOfLineCh)
		delete[] m_str;
}

size_t CMyString::GetLength() const
{
	return m_length;
}

const char* CMyString::GetStringData() const // TODO: для перемещенных сторка возвращать указатель на символ (константнтый) с кодом 0 -- сделано
{
	return m_str;
}

CMyString CMyString::SubString(const size_t start, const size_t length) const
{
	if (m_length == 0) // TODO: если m_str перемещена врозвразать указатель на символ с кодом 0  - сделано
		return {};
	if (start > m_length)
	{
		throw std::out_of_range("Out of range.");
	}
	return CMyString(m_str + start, std::min(m_length - start, length));
}

void CMyString::Clear()
{
	this->m_length = 0; // TODO: обнулять длину, не выделяя новую память. -- сделано
	this->m_str[m_length] = m_endOfLineCh; // TODO: если строка перемещена должна норм работать -сделано.
}

CMyString& CMyString::operator=(const CMyString& other)
{
	if (this != &other)
	{
		CMyString tmp(other);
		std::swap(m_str, tmp.m_str);
		std::swap(m_length, tmp.m_length);
	}
	return *this;
}

CMyString& CMyString::operator=(CMyString&& other)
{
	if (this != &other)
	{
		// TODO: очищать обьект перед записью . можно использовать swap -- сделано
		// m_str = const_cast<char*>(other.GetStringData());
		// m_length = other.GetLength();
		// other.m_str = nullptr;
		// other.m_length = 0;
		std::swap(m_str, other.m_str);
		std::swap(m_length, other.m_length);

		// TODO: удалить  
		other.m_length = 0;
		other.m_str = &m_endOfLineCh;
	}
	return *this;
}

CMyString CMyString::operator+(const CMyString& other) const
{
	const size_t length = m_length + other.GetLength();
	char* pString = new char[length + 1];
	std::memcpy(pString, m_str, m_length);
	std::memcpy(pString + m_length, other.GetStringData(), other.GetLength());
	pString[length] = m_endOfLineCh;
	CMyString newString(pString, length, true); // TODO: Добавить перегрузку конструктора с bool(выделили память или нет) со ссылкой на уже выделенную память -- сделано
	return newString;
}

CMyString& CMyString::operator+=(const CMyString& other)
{
	*this = *this + other;
	return *this;
}

bool CMyString::operator==(const CMyString& other) const
{
	// TODO: если строки разной длины false
	// TODO: Неорретно работает с строками с нулевым кодом в середине -- поправил
	return CompareStrings(other) == 0;
}

bool CMyString::operator!=(const CMyString& other) const
{
	return !(*this == other);
}

bool CMyString::operator>(const CMyString& other) const
{
	// TODO: Некорректно работает со строками с нулевым колом.  //std::memcmp -- поправил
	return CompareStrings(other) > 0;
}

bool CMyString::operator<(const CMyString& other) const
{
	// TODO: Некорректно работает со строками с нулевым колом.  //std::memcmp -- поправил
	return CompareStrings(other) < 0;
}

bool CMyString::operator>=(const CMyString& other) const
{
	// TODO: Некорректно работает со строками с нулевым колом.  //std::memcmp -- поправил
	return CompareStrings(other) >= 0;
}

bool CMyString::operator<=(const CMyString& other) const
{
	// TODO: Некорректно работает со строками с нулевым колом.  //std::memcmp  -- поправил
	return CompareStrings(other) <= 0;
}

const char& CMyString::operator[](size_t index) const
{
	if (index > m_length)
	{
		throw std::out_of_range("Out of range.");
	}
	return m_str[index]; // TODO: некорректная работа с move string -- сделано, в случае moveConstructor там будет нулевой символ
}

char& CMyString::operator[](size_t index)
{
	if (index > m_length)
	{
		throw std::out_of_range("Out of range.");
	}
	return m_str[index];
}

CMyString::ConstIterator CMyString::ToConst(const Iterator& iterator) const
{
	return { &*iterator, m_str, m_str + m_length };
}

CMyString::ConstReverseIterator CMyString::ToConst(const ReverseIterator& iterator) const
{
	const auto baseIt = ToConst(iterator.base());
	return std::make_reverse_iterator(baseIt);
}

int CMyString::CompareStrings(const CMyString& other) const
{
	const size_t firstLength = this->GetLength();
	const size_t secondLength = other.GetLength();
	const size_t minLenght = firstLength <= secondLength ? firstLength : secondLength;

	const int memoryCompareResult = std::memcmp(this->GetStringData(), other.GetStringData(), minLenght);
	if (memoryCompareResult == 0)
	{
		if (firstLength > secondLength)
			return 1;
		if (firstLength < secondLength)
			return -1;
	}
	return memoryCompareResult;
}

std::istream& operator>>(std::istream& istream, CMyString& myString)
{
	std::string varString;
	istream >> varString;
	myString = CMyString(varString);
	return istream;
}

std::ostream& operator<<(std::ostream& ostream, const CMyString& myString)
{
	ostream << std::string(myString.GetStringData());
	return ostream;
}

CMyString::Iterator CMyString::begin()
{
	return { m_str, m_str, m_str + m_length };
}

CMyString::Iterator CMyString::end()
{
	return { m_str + m_length, m_str, m_str + m_length };
}

CMyString::ConstIterator CMyString::сbegin() const
{
	return { m_str, m_str, m_str + m_length };
}

CMyString::ConstIterator CMyString::сend() const
{
	return { m_str + m_length, m_str, m_str + m_length };
}

CMyString::ReverseIterator CMyString::rbegin()
{
	return std::make_reverse_iterator(this->end());
}

CMyString::ReverseIterator CMyString::rend()
{
	return std::make_reverse_iterator(this->begin());
}

CMyString::ConstReverseIterator CMyString::rсbegin() const
{
	return std::make_reverse_iterator(this->сend());
}

CMyString::ConstReverseIterator CMyString::rсend() const
{
	return std::make_reverse_iterator(this->сbegin());
}
