#include <iostream>
#include <vector>

#include "manager.h"
#include "engineer.h"

int main() {
    std::vector<Employee*> employees;

    employees.push_back(new Engineer("Steve Wozniak", 101, 50000, "Hardware"));
    employees.push_back(new Engineer("Linus Torvalds", 103, 45000, "Software"));
    employees.push_back(new Engineer("Elon Musk", 104, 47000, "Spacecraft Engineering"));
    employees.push_back(new Engineer("Alan Turing", 105, 48000, "Cryptography"));
    employees.push_back(new Engineer("Ada Lovelace", 106, 49000, "Mathematics"));
    employees.push_back(new Engineer("Grace Hopper", 107, 52000, "Computer Programming"));

    employees.push_back(new Manager("Steve Jobs", 102, 70000, 5));
    employees.push_back(new Manager("Bill Gates", 108, 65000, 4));
    employees.push_back(new Manager("Sheryl Sandberg", 109, 68000, 6));
    employees.push_back(new Manager("Jeff Bezos", 110, 72000, 3));

    std::cout << std::endl << "We Have The Following Employeers" << std::endl;
    for (const auto &emp: employees) {
        std::cout << *emp << std::endl;
    }

    for (auto &emp: employees) {
        emp->promote();
    }

    std::cout <<  std::endl << "After Promotion:" << std::endl;
    for (const auto &emp: employees) {
        std::cout << *emp << std::endl;
    }

    sortEmployeesBySalary(employees);

    std::cout <<  std::endl << "After Sorting By Salary:" << std::endl;
    for (const auto &emp: employees) {
        std::cout << *emp << std::endl;
    }

    return 0;
}