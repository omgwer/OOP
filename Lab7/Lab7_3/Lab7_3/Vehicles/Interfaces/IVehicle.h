#pragma once
#include "IBasicVehicle.h"

#include <memory>

template <typename Passenger>
class IVehicle : public  IBasicVehicle
{
public:
	using PassengerType = Passenger;
	// добавить пассажира на борт
	// т.к. пассажир может быть полиморфным типом, принимаем его по умному указателю
	// Если нет места, выбрасывается исключение std::logic_error
	virtual void AddPassenger(std::shared_ptr<Passenger> passenger) = 0;

	// Получить ссылку на пассажира с заданным индексом
	// выбрасывает исключение std::out_of_range в случае недопустимого индекса
	virtual const Passenger& GetPassenger(size_t index)const = 0;

	// убрать пассажира с заданным индексом
	// выбрасывает исключение std::out_of_range в случае недопустимого индекса
	virtual void RemovePassenger(size_t index) = 0;
};
