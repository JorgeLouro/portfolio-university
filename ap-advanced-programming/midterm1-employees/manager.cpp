/**
 * @file manager.cpp
 * @brief Implementation of the Manager derived class.
 * @author Jorge Louro
 * @bug No Bugs
 */

#include "manager.h"
#include <iostream>

/**
 * @brief Manager Object
 *
 * @param name Manager Name
 * @param id Manager ID
 * @param baseSalary Manager Base Salary
 * @param teamSize Size Of The Manager's Team
 */
Manager::Manager(std::string name, int id, double baseSalary, int teamSize)
        : Employee(std::move(name), id, baseSalary), teamSize(teamSize) {}

/**
 * @brief Display the manager details
 */
void Manager::display() const {
    std::cout << "Manager: " << name << ", ID: " << id << ", Team Size: " << teamSize
              << ", Base Salary: " << baseSalary << ", Total Salary: " << calculateSalary();
}

/**
 * @brief Get The Type Of Employee
 *
 * @return std::string Type of employee
 */
std::string Manager::getType() const {
    return "Manager";
}

/**
 * @brief Calculate The Total Salary Of The Manager
 *
 * @return Double Total salary
 */
double Manager::calculateSalary() const {
    return baseSalary + 100 * teamSize;
}

/**
 * @brief Promote The Manager
 */
void Manager::promote() {
    baseSalary *= 1.20;
}
