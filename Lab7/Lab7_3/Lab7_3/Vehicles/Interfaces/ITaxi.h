#pragma once
#include "ICar.h"
#include "../../People/Interfaces/IPerson.h"

class ITaxi : public ICar<IPerson>
{
};
