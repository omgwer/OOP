#include "People/CPerson.h"
#include "People/CPoliceMan.h"
#include "People/CRacer.h"
#include "Vehicles/CPoliceCar.h"
#include "Vehicles/CTaxi.h"

int main(int argc, char* argv[])
{
	CPoliceMan policeJohnSmith("John Smith", "Northwest police station");
	CPoliceCar policeCar(5, CarBrand::FORD);
	
	policeCar.AddPassenger(std::make_shared<CPoliceMan>(policeJohnSmith));
	CPoliceMan policeJimmClark("Jimm Clark", "Southwest police station");
	policeCar.AddPassenger(std::make_shared<CPoliceMan>(policeJimmClark));
	std::cout << "First policeman name is - " << policeJohnSmith.GetName() << std::endl;
	std::cout << "Second policeman name is - " << policeJimmClark.GetName() << std::endl;
	std::cout << "First Department name is - " << policeJohnSmith.GetDepartmentName() << std::endl;
	std::cout << "First Department name is - " << policeJimmClark.GetDepartmentName() << std::endl;

	policeCar.RemovePassenger(1);
	CTaxi taxi(2, CarBrand::TOYOTA);
	CPerson taxiDriver("Raja Ghandi");
	CRacer racerMichael("Michael Shumacher", 100);
	taxi.AddPassenger(std::make_shared<CPerson>(taxiDriver));
	taxi.AddPassenger(std::make_shared<CRacer>(racerMichael));

	policeJimmClark.Speak("Taxi driver! This is my gun! Get out the car!");
	taxi.RemovePassenger(0);
	taxi.AddPassenger(std::make_shared<CPoliceMan>(policeJimmClark));

	try
	{
		taxi.AddPassenger(std::make_shared<CPerson>(taxiDriver));
	} catch (std::logic_error& ex)
	{
		std::cout << "Car driver cant get into a car. Car is full" << std::endl;
	}
	
    return 0;
}
