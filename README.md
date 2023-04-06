# Race-Simulation

## Overview

This is a console application made for running a car race simulation.
This was made mainly for gaining more knowledge about asynchronous programming by using Await/Task in C#.

## Functionality

Car objects are used by creating instances of the Car class.

Each car object have properties which stores the following values:

- Id
- Model (name of the car)
- DistanceTraveled (the total distance the car has traveled in the simulation)
- Speed (current speed of the car)
- FinishTime (the time the car crosses the finishline)

DistanceTraveled, Speed and FinishTime are crucial properties used the determine which car will reach the finishline first.

Below formula was used to calculate different elements:
![alt text](https://thirdspacelearning.com/wp-content/uploads/2022/04/speed-distance-time-image-2.png)

## Structure

The main file (Program.cs) consists of methods which are all run asynchronously. The only method which is run synchronously is PrintCar() which is called when a car has crossed the finish line. It displays the time, speed and distance the car traveled.

Important files in the repository:

- Program.cs - (Main file)
- Car.cs (Class model for cars used in the simulation)

## Tools

All of the tools used during the development of this program:

#### Integrated Development Environment (IDE)

- Visual Studio

#### Dependencies / Packages

- Dotnet / runtime

#### Languages

- C#
