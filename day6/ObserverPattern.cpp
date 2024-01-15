#include <iostream>
#include <thread>
#include <mutex>
#include <vector>
#include <chrono>

class Thread {
public:
    enum State {
        RUNNING,
        PAUSED,
        STOPPED
    };

    Thread() : state(RUNNING), subscribed(false) {}

    void run() {
        while (state != STOPPED) {
            std::this_thread::sleep_for(std::chrono::seconds(1));

            std::unique_lock<std::mutex> lock(mutex_);
            if (subscribed) {
                std::cout << "Thread ID " << std::this_thread::get_id() << ": ";
                displayState();
            }
        }
    }

    void displayState() {
        switch (state) {
            case RUNNING:
                std::cout << "Running" << std::endl;
                break;
            case PAUSED:
                std::cout << "Paused" << std::endl;
                break;
            case STOPPED:
                std::cout << "Stopped" << std::endl;
                break;
        }
    }

    void changeState(State newState) {
        std::unique_lock<std::mutex> lock(mutex_);
        state = newState;
        if (subscribed) {
            std::cout << "Thread ID " << std::this_thread::get_id() << ": State changed to ";
            displayState();
        }
    }

    void subscribe() {
        std::unique_lock<std::mutex> lock(mutex_);
        subscribed = true;
        std::cout << "Thread ID " << std::this_thread::get_id() << ": Subscribed" << std::endl;
    }

    void unsubscribe() {
        std::unique_lock<std::mutex> lock(mutex_);
        subscribed = false;
        std::cout << "Thread ID " << std::this_thread::get_id() << ": Unsubscribed" << std::endl;
    }

private:
    State state;
    bool subscribed;
    std::mutex mutex_;
};

int main() {
    Thread thread1, thread2;

    // Create two threads
    std::thread t1(&Thread::run, &thread1);
    std::thread t2(&Thread::run, &thread2);

    // Subscribe and change states
    thread1.subscribe();
    thread1.changeState(Thread::PAUSED);

    thread2.subscribe();
    thread2.changeState(Thread::RUNNING);

    // Unsubscribe and wait for threads to finish
    thread1.unsubscribe();
    t1.join();

    thread2.unsubscribe();
    t2.join();

    return 0;
}
