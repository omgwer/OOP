#include "headers/CMyString.h"

#include <stdexcept>

CMyString::CMyString()
{
	m_len = 0;
	m_str = new char[m_len + 1];
	m_str[0] = m_endOfLineCh;
}

CMyString::CMyString(const char* pString) : CMyString(pString, std::strlen(pString))
{
}

CMyString::CMyString(const char* pString, const size_t length)
{
	m_len = length;
	m_str = new char[m_len + 1];
	std::memcpy(m_str, pString, length);
	m_str[m_len] = m_endOfLineCh;
}

CMyString::CMyString(CMyString const& other)
	: CMyString(other.GetStringData(), other.GetLength())
{	
}

CMyString::CMyString(CMyString&& other)
{
	m_str = const_cast<char*>(other.GetStringData());
	m_len = other.GetLength();	
}

CMyString::CMyString(std::string const& stlString) : CMyString(stlString.c_str(), stlString.length())
{	
}

CMyString::~CMyString()
{
	delete[] m_str;
}

size_t CMyString::GetLength() const
{
	return m_len;
}

const char* CMyString::GetStringData() const
{
	return m_str;
}

CMyString CMyString::SubString(size_t start, size_t length) const
{
	if (start > m_len)
	{
		throw std::out_of_range("Out of range.");
	}
	return CMyString(m_str + start, std::min(m_len - start, length));
}

void CMyString::Clear()
{
}
