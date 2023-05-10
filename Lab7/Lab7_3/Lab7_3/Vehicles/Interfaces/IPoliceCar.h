#pragma once
#include "ICar.h"
#include "../../People/Interfaces/IPoliceMan.h"

class IPoliceCar : public ICar<IPoliceMan>
{
};
