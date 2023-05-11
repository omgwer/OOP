#pragma once
#include "../Implementation/CPersonImpl.h"
#include "Interfaces/IPoliceMan.h"

class CPoliceMan : CPersonImpl<IPoliceMan>
{
public:
	CPoliceMan(const std::string& name, const std::string& departmentName);

	std::string GetDepartmentName() const final;
private:
	std::string m_departmentName;
};
