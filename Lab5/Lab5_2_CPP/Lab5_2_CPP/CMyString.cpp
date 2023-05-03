#include "headers/CMyString.h"
#include "CMyStringIterator.cpp"

#include <iostream>
#include <stdexcept>

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

const char* CMyString::GetStringData() const
{
	return m_str;
}

CMyString CMyString::SubString(const size_t start, const size_t length) const
{
	if (start > m_length)
	{
		throw std::out_of_range("Out of range.");
	}
	return CMyString(m_str + start, std::min(m_length - start, length));
}

void CMyString::Clear()
{
	delete[] m_str;
	m_length = 0;
	m_str = new char[m_length + 1];
	m_str[m_length] = m_endOfLineCh;
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

CMyString CMyString::operator+(const CMyString& other) const
{
	const size_t length = m_length + other.GetLength();
	char* pString = new char[length + 1];
	std::memcpy(pString, m_str, m_length);
	std::memcpy(pString + m_length, other.GetStringData(), other.GetLength());
	pString[length] = m_endOfLineCh;
	CMyString newString(pString, length);
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
	return m_length == other.GetLength() && std::strcmp(m_str, other.GetStringData()) == 0;
}

bool CMyString::operator!=(const CMyString& other) const
{
	return !(*this == other);
}

bool CMyString::operator>(const CMyString& other) const
{
	if (std::strcmp(this->GetStringData(), other.GetStringData()) > 0)
		return true;
	return false;
}

bool CMyString::operator<(const CMyString& other) const
{
	if (std::strcmp(this->GetStringData(), other.GetStringData()) < 0)
		return true;
	return false;
}

bool CMyString::operator>=(const CMyString& other) const
{
	if (std::strcmp(this->GetStringData(), other.GetStringData()) >= 0)
		return true;
	return false;
}

bool CMyString::operator<=(const CMyString& other) const
{
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
	return m_str[index];
}

char& CMyString::operator[](size_t index)
{
	if (index > m_length)
	{
		throw std::out_of_range("Out of range.");
	}
	return m_str[index];
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

CMyString::ConstIterator CMyString::begin() const
{
	return { m_str, m_length, 0 };
}

CMyString::ConstIterator CMyString::end() const
{
	return { m_str + m_length, m_length, m_length };
}
