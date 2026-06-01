cmake_minimum_required(VERSION 3.27)
project(PA_1Freq)

set(CMAKE_CXX_STANDARD 20)

add_executable(PA_1Freq main.cpp
        employee.cpp
        employee.h
        engineer.cpp
        engineer.h
        manager.cpp
        manager.h)
