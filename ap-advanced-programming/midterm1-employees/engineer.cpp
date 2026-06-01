/**
 * @file engineer.cpp
 * @brief Engineer Derived Class.
 * @author Jorge Louro
 * @bug No Bugs
 */

#include "engineer.h"
#include <iostream>

/**
 * @brief Engineer Object
 *
 * @param name Engineer Name
 * @param id Engineer ID
 * @param baseSalary Engineer Base Salary
 * @param specialty Engineer Specialty
 */
Engineer::Engineer(std::string name, int id, double baseSalary, std::string specialty)
        : Employee(std::move(name), id, baseSalary), specialty(std::move(specialty)) {}

/**
 * @brief Display The Engineer Details
 */
void Engineer::display() const {
    std::cout << "Engineer: " << name << ", ID: " << id << ", Specialty: " << specialty
              << ", Base Salary: " << baseSalary << ", Total Salary: " << calculateSalary();
}

/**
 * @brief Get The Type Of Employee
 *
 * @return std::string Type Of Employee
 */
std::string Engineer::getType() const {
    return "Engineer";
}

/**
 * @brief Calculate The Total Salary Of The Engineer
 *
 * @return Double Total salary
 */
double Engineer::calculateSalary() const {
    return baseSalary;
}

/**
 * @brief Promote The Engineer
 */
void Engineer::promote() {
    baseSalary *= 1.15;
}
