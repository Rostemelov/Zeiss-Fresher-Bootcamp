/*******************************************************************************/
#include <iostream>
#include <map>
#include <vector>
#include <random>
//------------------------------------------------------------------------------
class StartupMonitor
{
    private:
    std::map<std::string, string> statusMap;
    // Insert key-value pairs
    statusMap["0xFF"] = "All ok";
    statusMap["0x00"] = "Attention Required by Machine: No data";
    statusMap["0x01"] = "Attention Required by Machine: Controller board in the machine is not ok";
    statusMap["0x02"] = "Attention Required by Machine: Configuration data in the machine is corrupted";
    
    public:
    void startupCheckUp(CNC machine , string code)
    {
        cout<<statusMap[code];
        if(code == "0xFF")
        {
            machine.run();
        }
    }
};
//------------------------------------------------------------------------------
class TemperatureMonitor
{
    private:
    float tempThreshold = 35.00;
    public:
    void monitor(float temperature)
    {
        if (temperature>tempThreshold)
        {
            cout<<"Attention Required by Environment: Temperature Above Optimal";
        }
    }
};
//------------------------------------------------------------------------------
class VariationMonitor
{
    private:
    float variationThreshold = 0.05;
    public:
    void monitor(float variation)
    {
        if (variation>variationThreshold)
        {
            cout<<"Attention Required by Machine: Variation in parts Higher than Expected";
        }
    }
};
//------------------------------------------------------------------------------
class RuntimeMonitor
{
    private:
    int maxRunTime = 24;
    public:
    RuntimeMonitor()
    {counter = 0;}
    void monitor()
    {
        counter++;
        if (counter>maxRunTime)
        {
            cout<<"Attention Required by Machine: Runtime has exceeded 6 hours";
        }
    }
};
//------------------------------------------------------------------------------
class CNC
{
    private:
    StartupMonitor startupMonitor;
    TemperatureMonitor temperatureMonitor;
    VariationMonitor variationMonitor;
    RuntimeMonitor runtimeMonitor;
    
    public:
    CNC()
    {
        // Set of strings
        std::vector<std::string> codeSet = {"0xFF", "0x01", "0x00", "0x02"};
        // Seed the random number generator with a random device
        std::random_device rd;
        std::mt19937 gen(rd());
        // Define a distribution for indices
        std::uniform_int_distribution<size_t> distribution(0, codeSet.size() - 1);
        // Generate a random index
        size_t randomIndex = distribution(gen);

        // Retrieve the randomly selected string
        std::string code = stringSet[randomIndex];
        
        doctor. startupCheckUp( this , code);
    }
    
    void readTemperature()
    {
        std::uniform_float_distribution<size_t> distribution(0, 50);
        // Generate a random index
        float temperature = distribution(gen);
        temperatureMonitor.monitor(temperature);
    }
    void readVariation()
    {
        std::uniform_float_distribution<size_t> distribution(0, 0.1);
        // Generate a random index
        float variation = distribution(gen);
        variationMonitor.monitor();
    }
    
    void run();
    {
        int tcounter = 0, rcounter = 0;
        for (int i = 0; ; i++) 
        {
            if(tcounter == 30)
            {
                readTemperature();
                tcounter = 0;
            }
            if(rcounter == 15)
            {
                runtimeMonitor.monitor();
                rcounter = 0;
            }
            std::cout << "printer 2 Printing line " << i << "..." << std::endl;
            std::this_thread::sleep_for(std::chrono::minutes(1));
            rcounter++;
            tcounter++;
        }
    }
};
//------------------------------------------------------------------------------
using namespace std;

int main()
{
    CNC Machine;
    return 0;
}

