#pragma once
#include "../Implementation/CPersonImpl.h"
#include "Interfaces/IPerson.h"

class CPerson : public CPersonImpl<IPerson>
{
public:
	CPerson(const std::string& name);
};
