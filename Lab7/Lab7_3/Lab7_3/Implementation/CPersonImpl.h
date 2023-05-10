#pragma once
#include <iostream>
#include <string>

template <typename T>
class CPersonImpl : public T
{
public:
	std::string GetName() const noexcept final;
	void Speak(const std::string& phrase, std::ostream& os = std::cout) const override;
protected:
	CPersonImpl(const std::string& name);
	std::string m_name;
};

template <typename T>
CPersonImpl<T>::CPersonImpl(const std::string& name)
	: m_name(name)
{
}

template <typename T>
void CPersonImpl<T>::Speak(const std::string& phrase, std::ostream& os) const
{
	os << phrase << std::endl;
}

template<typename T>
std::string CPersonImpl<T>::GetName() const noexcept
{
	return m_name;
}