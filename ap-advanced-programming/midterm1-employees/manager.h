#ifndef PA_1FREQ_MANAGER_H
#define PA_1FREQ_MANAGER_H

#include "employee.h"
#include <string>

class Manager : public Employee {
private:
    int teamSize;
public:
    Manager(std::string name, int id, double baseSalary, int teamSize);
    void display() const;
    virtual std::string getType() const;
    double calculateSalary() const;
    void promote();
};

#endif //PA_1FREQ_MANAGER_H
