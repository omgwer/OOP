#pragma once
#include "ICar.h"
#include "../../People/Interfaces/IRacer.h"

class IRacingCar : public ICar<IRacer>
{
};
