#include "CPoliceMan.h"
#include <string>

CPoliceMan::CPoliceMan(const std::string& name, const std::string& departmentName)
	: CPersonImpl(name)
	, m_departmentName(departmentName)
{
}

std::string CPoliceMan::GetDepartmentName() const
{
	return m_departmentName;
}