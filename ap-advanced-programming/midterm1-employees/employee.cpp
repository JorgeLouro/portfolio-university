/**
 * @file employee.cpp
 * @brief Employee Base Class.
 * @author Jorge Louro
 * @bug No Bugs
 */

#include "employee.h"
#include <iostream>
#include <algorithm>

/**
 * @brief Employee object
 *
 * @param name Employee Name
 * @param id Employee ID
 * @param baseSalary Employee Base Salary
 */
Employee::Employee(std::string name, int id, double baseSalary)
        : name(std::move(name)), id(id), baseSalary(baseSalary) {}

/**
 * @brief Virtual Destructor For Employee
 */
Employee::~Employee() {}

/**
 * @brief Calculate The Total Salary Of The Employee
 *
 * @return Double Total Salary
 */
double Employee::calculateSalary() const {
    return baseSalary;
}

/**
 * @brief Promote The Employee
 */
void Employee::promote() {

}

/**
 * @brief Output Stream Operator For Employee
 *
 * @param os Output Stream
 * @param emp Employee Object
 * @return std::ostream& Output Stream With Employee Details
 */
std::ostream& operator<<(std::ostream& os, const Employee& emp) {
    emp.display();
    return os;
}

/**
 * @brief Sort Employees By Their Total Salary (In Descending Order)
 *
 * @param employees Vector Of Pointers To Employee Objects
 */
void sortEmployeesBySalary(std::vector<Employee*>& employees) {
    std::sort(employees.begin(), employees.end(), [](Employee* a, Employee* b) {
        return a->calculateSalary() > b->calculateSalary();
    });
}
