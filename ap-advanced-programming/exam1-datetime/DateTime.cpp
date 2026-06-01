#include "datetime.h"

DateTime::DateTime() {
    auto now = std::chrono::system_clock::now();
    std::time_t currentTime = std::chrono::system_clock::to_time_t(now);
    m_time = *std::localtime(&currentTime);
}

DateTime::DateTime(const std::string& dateTimeStr) {
    std::stringstream ss(dateTimeStr);
    char discard;
    int day, month, year, hour, minute, second;
    ss >> day >> discard >> month >> discard >> year >> hour >> discard >> minute >> discard >> second;
    m_time.tm_sec = second;
    m_time.tm_min = minute;
    m_time.tm_hour = hour;
    m_time.tm_mday = day;
    m_time.tm_mon = month - 1;
    m_time.tm_year = year - 1900;
}

bool DateTime::operator==(const DateTime& other) const {
    std::tm lhs_copy = m_time;
    std::tm rhs_copy = other.m_time;
    return std::mktime(&lhs_copy) == std::mktime(&rhs_copy);
}

bool DateTime::operator<(const DateTime& other) const {
    std::tm lhs_copy = m_time;
    std::tm rhs_copy = other.m_time;
    return std::mktime(&lhs_copy) < std::mktime(&rhs_copy);
}

bool DateTime::operator>(const DateTime& other) const {
    std::tm lhs_copy = m_time;
    std::tm rhs_copy = other.m_time;
    return std::mktime(&lhs_copy) > std::mktime(&rhs_copy);
}

std::ostream& operator<<(std::ostream& os, const DateTime& dt) {
    const char* weekday_names[] = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
    const char* month_names[] = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    os << weekday_names[dt.m_time.tm_wday] << ", "
       << std::setfill('0') << std::setw(2) << dt.m_time.tm_mday << " of "
       << month_names[dt.m_time.tm_mon] << ", "
       << dt.m_time.tm_year + 1900 << " "
       << std::setfill('0') << std::setw(2) << dt.m_time.tm_hour << ":"
       << std::setfill('0') << std::setw(2) << dt.m_time.tm_min << ":"
       << std::setfill('0') << std::setw(2) << dt.m_time.tm_sec;

    return os;
}
