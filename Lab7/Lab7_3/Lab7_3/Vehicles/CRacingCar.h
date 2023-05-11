#pragma once
#include "../Implementation/CCarImpl.h"
#include "Interfaces/IRacingCar.h"

class CRacingCar : CCarImpl<IRacingCar>
{
public:
	CRacingCar(size_t placeCount, CarBrand carBrand);	
};
