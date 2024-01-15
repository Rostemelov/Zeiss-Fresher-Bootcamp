#include <iostream>
#include <boost/di.hpp>

namespace di = boost::di;

// Forward declarations
class FuelPump;
class StartupMotor;

// Service interfaces
class Engine {
public:
    virtual void start() = 0;
    virtual ~Engine() = default;
};

class Transmission {
public:
    virtual void shift() = 0;
    virtual ~Transmission() = default;
};

class FuelPump {
public:
    virtual void pumpFuel() = 0;
    virtual ~FuelPump() = default;
};

class StartupMotor {
public:
    virtual void startMotor() = 0;
    virtual ~StartupMotor() = default;
};

// Service implementations
class FuelPumpImpl : public FuelPump {
public:
    void pumpFuel() override {
        std::cout << "Fuel pumped to the engine." << std::endl;
    }
};

class StartupMotorImpl : public StartupMotor {
public:
    void startMotor() override {
        std::cout << "Startup motor started." << std::endl;
    }
};

class EngineImpl : public Engine {
private:
    std::shared_ptr<FuelPump> fuelPump;
    std::shared_ptr<StartupMotor> startupMotor;

public:
    // Constructor with dependency injection
    EngineImpl(std::shared_ptr<FuelPump> fp, std::shared_ptr<StartupMotor> sm)
        : fuelPump(fp), startupMotor(sm) {}

    void start() override {
        startupMotor->startMotor();
        fuelPump->pumpFuel();
        std::cout << "Engine started." << std::endl;
    }
};

class TransmissionImpl : public Transmission {
public:
    void shift() override {
        std::cout << "Transmission shifted." << std::endl;
    }
};

class Car {
private:
    std::shared_ptr<Engine> engine;
    std::shared_ptr<Transmission> transmission;

public:
    // Constructor with dependency injection
    Car(std::shared_ptr<Engine> e, std::shared_ptr<Transmission> t)
        : engine(e), transmission(t) {}

    void drive() {
        engine->start();
        transmission->shift();
        std::cout << "Car is driving." << std::endl;
    }
};

int main() {
    // Using Boost.DI to create instances and inject dependencies
    auto injector = di::make_injector(
        di::bind<StartupMotor>().to<StartupMotorImpl>(),
        di::bind<FuelPump>().to<FuelPumpImpl>(),
        di::bind<Engine>().to<EngineImpl>(),
        di::bind<Transmission>().to<TransmissionImpl>(),
        di::bind<Car>().to<Car>()
    );

    auto car = injector.create<Car>();

    // Using the Car
    car.drive();

    return 0;
}
