#pragma once
#include "../Implementation/CCarImpl.h"
#include "Interfaces/IPoliceCar.h"

class CPoliceCar : public CCarImpl<IPoliceCar>
{
public:
	CPoliceCar(size_t placeCount, CarBrand carBrand);
};
