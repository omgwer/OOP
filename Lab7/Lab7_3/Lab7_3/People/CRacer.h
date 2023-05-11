#pragma once
#include "../Implementation/CPersonImpl.h"
#include "Interfaces/IRacer.h"

class CRacer : public CPersonImpl<IRacer>
{
public:
	CRacer(const std::string& name, size_t awardsCount = 0);

	size_t GetAwardsCount() const override;
private:
	size_t m_awardsCount;
};
