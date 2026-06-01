#include <iostream>
#include "datetime.h"

int main() {
    DateTime currentDateTime;
    DateTime customDateTime("11-03-2024 15:00:00");
    std::cout << "Data Atual: " << currentDateTime << std::endl;
    std::cout << "\nData Personalizada: " << customDateTime << std::endl;

    // Comparisons
    if (customDateTime > currentDateTime) {
        std::cout << "\nData Personalizada > Data Actual" << std::endl;
    } else if (customDateTime < currentDateTime) {
        std::cout << "\nData Personalizada < Data Actual" << std::endl;
    } else {
        std::cout << "\nData Personalizada = Data Actual" << std::endl;
    }
    return 0;
}