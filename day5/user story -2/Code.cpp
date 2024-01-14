*******************************************************************************/
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
            machine.temp();
            machine.duration();
            machine.variation();
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
    RuntimeMonitor runtimeMonitor
    
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
    
    temp()
    {
        //code that calls the monitor function of temperatureMonitor and passes in the temperature reading
    }
    duration()
    {
        //code that calls the monitor function of runtimeMonitor to check the runtime
    }
    variation()
    {
        //code that calls the monitor function of variationMonitor to monitor the variation of the parts
    }
};
//------------------------------------------------------------------------------
using namespace std;

int main()
{
    CNC Machine;
    return 0;
}
