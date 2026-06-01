#ifndef DATETIME_H
#define DATETIME_H
#include <chrono>
#include <iostream>
#include <iomanip>
#include <string>

class DateTime {
public:
    DateTime();
    explicit DateTime(const std::string& dateTimeStr);
    bool operator==(const DateTime& other) const;
    bool operator<(const DateTime& other) const;
    bool operator>(const DateTime& other) const;
    friend std::ostream& operator<<(std::ostream& os, const DateTime& dt);
private:
    std::tm m_time{};
};
#endif
