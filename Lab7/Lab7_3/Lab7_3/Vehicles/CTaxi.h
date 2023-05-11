#pragma once
#include "../Implementation/CCarImpl.h"
#include "Interfaces/ITaxi.h"

class CTaxi : public CCarImpl<ITaxi>
{
public:
	CTaxi(size_t placeCount, CarBrand carBrand);
};
