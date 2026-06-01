#ifndef PA_1FREQ_ENGINEER_H
#define PA_1FREQ_ENGINEER_H

#include "employee.h"

class Engineer : public Employee {
private:
    std::string specialty;
public:
    Engineer(std::string name, int id, double baseSalary, std::string specialty);
    void display() const override;
    virtual std::string getType() const;
    double calculateSalary() const override;
    void promote() override;
};

#endif //PA_1FREQ_ENGINEER_H
