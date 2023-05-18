#pragma once
#include "../Implementation/CVehicleImpl.h"
#include "Interfaces/IBus.h"

class CBus : public CVehicleImpl<IBus>
{
public:
	CBus(size_t placeCount);
};
