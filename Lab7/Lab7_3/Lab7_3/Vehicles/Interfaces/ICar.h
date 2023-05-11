#pragma once
#include "IVehicle.h"
#include "../../Dictionary/CarBrand.h"

// автомобиль, перевозящий заданный тип пассажиров
template <typename T>
class ICar : public IVehicle<T>
{
public:
	virtual CarBrand GetCarBrand()const = 0;
};





