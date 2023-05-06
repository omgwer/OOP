#include "headers/CMyString.h"

#include <iostream>
#include <stdexcept>

static constexpr char m_endOfLineCh = '\0'; // TODO вынести в статическую переменную или константу -- сделано

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
	m_str = const_cast<char*>(other.GetStringData());
	m_length = other.GetLength();
	other.m_str = nullptr;
	other.m_length = 0;
}

CMyString::CMyString(std::string const& stlString)
	: CMyString(stlString.c_str(), stlString.length())
{
}

CMyString::~CMyString()
{
	delete[] m_str;
}

size_t CMyString::GetLength() const
{
	return m_length;
}

const char* CMyString::GetStringData() const // TODO: для перемещенных строрка возвращать указатель на символ (константнтый) с кодом 0;
{
	return m_str;
}

CMyString CMyString::SubString(const size_t start, const size_t length) const
{
	if (start > m_length)
	{
		throw std::out_of_range("Out of range.");
	}
	// TODO: если m_str перемещена врозвразать указатель на символ с кодом 0 
	return CMyString(m_str + start, std::min(m_length - start, length));
}

void CMyString::Clear()
{
	delete[] m_str;
	m_length = 0;
	m_str = new char[m_length + 1]; // обнулять длину, не выделяя новую память.
	m_str[m_length] = m_endOfLineCh; // TODO: если строка перемещена должна норм работать
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
		m_str = const_cast<char*>(other.GetStringData());
		m_length = other.GetLength();
		other.m_str = nullptr;
		other.m_length = 0;
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
	CMyString newString(pString, length); // TODO: Добавить перегрузку конструктора с bool(выделили память или нет) со ссылкой на уже выделенную память
	delete[] pString;
	return newString;
}

CMyString& CMyString::operator+=(const CMyString& other)
{
	*this = *this + other;
	return *this;
}

bool CMyString::operator==(const CMyString& other) const
{
	// TODO: Неорретно работает с строками с нулевым кодом в середине 
	return m_length == other.GetLength() && std::strcmp(m_str, other.GetStringData()) == 0;
}

bool CMyString::operator!=(const CMyString& other) const
{
	return !(*this == other);
}

bool CMyString::operator>(const CMyString& other) const
{
	// TODO: Некорректно работает со строками с нулевым колом.  //std::memcmp
	if (std::strcmp(this->GetStringData(), other.GetStringData()) > 0)
		return true;
	return false;
}

bool CMyString::operator<(const CMyString& other) const
{
	// TODO: Некорректно работает со строками с нулевым колом.  //std::memcmp
	if (std::strcmp(this->GetStringData(), other.GetStringData()) < 0)
		return true;
	return false;
}

bool CMyString::operator>=(const CMyString& other) const
{
	// TODO: Некорректно работает со строками с нулевым колом.  //std::memcmp
	if (std::strcmp(this->GetStringData(), other.GetStringData()) >= 0)
		return true;
	return false;
}

bool CMyString::operator<=(const CMyString& other) const
{
	// TODO: Некорректно работает со строками с нулевым колом.  //std::memcmp
	if (std::strcmp(this->GetStringData(), other.GetStringData()) <= 0)
		return true;
	return false;
}

const char& CMyString::operator[](size_t index) const
{
	if (index > m_length)
	{
		throw std::out_of_range("Out of range.");
	}
	return m_str[index]; // TODO: некорректная работа с move string
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
	return {&*iterator, m_length ,m_length - *iterator };
}

CMyString::ConstReverseIterator CMyString::ToConst(const ReverseIterator& iterator) const
{
	const auto baseIt = ToConst(iterator.base());	
	return std::make_reverse_iterator(baseIt);
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
	return { m_str, m_length, 0 };
}

CMyString::Iterator CMyString::end()
{
	return { m_str + m_length, m_length, m_length };
}

CMyString::ConstIterator CMyString::сbegin() const
{
	return { m_str, m_length, 0 };
}

CMyString::ConstIterator CMyString::сend() const
{
	return { m_str + m_length, m_length, m_length };
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
