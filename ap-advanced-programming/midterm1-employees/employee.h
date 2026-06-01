#ifndef PA_1FREQ_EMPLOYEE_H
#define PA_1FREQ_EMPLOYEE_H

#include <string>
#include <vector>

class Employee {
protected:
    std::string name;
    int id;
    double baseSalary;
public:
    Employee(std::string name, int id, double baseSalary);
    virtual void display() const = 0;
    virtual std::string getType() const = 0;
    virtual double calculateSalary() const;
    virtual void promote();
    virtual ~Employee();
    friend std::ostream& operator<<(std::ostream& os, const Employee& emp);
};

std::ostream& operator<<(std::ostream& os, const Employee& emp);

void sortEmployeesBySalary(std::vector<Employee*>& employees);

#endif //PA_1FREQ_EMPLOYEE_H
