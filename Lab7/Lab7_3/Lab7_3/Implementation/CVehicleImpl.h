#pragma once
#include <memory>
#include <stdexcept>
#include <vector>

template <typename T> class CVehicleImpl : public T
{
public:
	using PassengerType = typename T::PassengerType;

	void AddPassenger(std::shared_ptr<PassengerType> passenger) final;
	const PassengerType& GetPassengerType(size_t index) const final;
	void RemovePassenger(size_t index) final;
	void RemoveAllPassengers() final;
	size_t GetPlaceCount() const noexcept final;
	size_t GetPassengerCount() const noexcept final;
	bool IsEmpty() const noexcept final;
	bool IsFull() const noexcept final;

protected:
	CVehicleImpl(size_t placeCount);
	size_t m_placeCount;
	std::vector<std::shared_ptr<PassengerType>> m_passengers;
};


template <typename T> CVehicleImpl<T>::CVehicleImpl(size_t placeCount)
	: m_placeCount(placeCount)
{
	try
	{
		m_passengers.reserve(placeCount);
	}
	catch (const std::exception&)
	{
		m_placeCount = 0;
		throw;
	}
}

template <typename T> void CVehicleImpl<T>::AddPassenger(std::shared_ptr<typename T::PassengerType> pPassenger)
{
	if (IsFull())
	{
		throw std::logic_error("No free seats");
	}
	m_passengers.push_back(pPassenger);
}

template <typename T> const typename CVehicleImpl<T>::PassengerType&
CVehicleImpl<T>::GetPassengerType(size_t index) const
{
	return *m_passengers.at(index);
}

template <typename T> void CVehicleImpl<T>::RemovePassenger(size_t index)
{
	if (index >= GetPassengerCount())
	{
		throw std::out_of_range("Index is out of range");
	}

	m_passengers.erase(std::next(m_passengers.begin(), index));
}

template <typename T> void CVehicleImpl<T>::RemoveAllPassengers()
{
	m_passengers.clear();
}

template <typename T> size_t CVehicleImpl<T>::GetPlaceCount() const noexcept
{
	return m_placeCount;
}

template <typename T> size_t CVehicleImpl<T>::GetPassengerCount() const noexcept
{
	return m_passengers.size();
}

template <typename T> bool CVehicleImpl<T>::IsEmpty() const noexcept
{
	return m_passengers.empty();
}

template <typename T> bool CVehicleImpl<T>::IsFull() const noexcept
{
	return m_passengers.size() == m_placeCount;
}
