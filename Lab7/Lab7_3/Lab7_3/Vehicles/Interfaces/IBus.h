#pragma once
#include "IVehicle.h"

class IPerson;

// марка автобуса
class IBus : public IVehicle<IPerson>
{
};