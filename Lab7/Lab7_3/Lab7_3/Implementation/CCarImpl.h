#pragma once
#include "../Dictionary/CarBrand.h"
#include "CVehicleImpl.h"

template <typename T>
class CCarImpl : public CVehicleImpl<T>
{
public:
	using PassengerType = typename T::PassengerType;
	
	CarBrand GetCarBrand() const noexcept override;

protected:
	CCarImpl(size_t placeCount, CarBrand carBrand);
private:
	CarBrand m_carBrand;
};

template <typename T>
CCarImpl<T>::CCarImpl(size_t placeCount, const CarBrand carBrand)
	: CVehicleImpl<T>(placeCount)
	, m_carBrand(carBrand)
{
}

template <typename T>
CarBrand CCarImpl<T>::GetCarBrand() const noexcept
{
	return m_carBrand;
}
