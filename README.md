# DroneDeliveryService

## Algoritmy Explanation and Approach

- Even though the output of the proposed algorithm in the "Coding Test" didn't match the input and output examples exactly, it still manages to minimize the number of trips required, just like the desired output suggests.

_______________

### Follow the explanation of the algorithm:

- In the specific case of this drone delivery program, no specific algorithm was used beyond the basic concepts of iteration, comparison and selection of drones with adequate capacity.

- The AssignLocationsToDrones function apply all the logic.

- It sorts the list of locations in desce200nding order based on package weight. Sorting the locations based on package weight ensures that heavier packages are assigned earlier, potentially leading to better overall efficiency in delivery planning.

- It sorts the list of drones in descending order based on their maximum weight capacity. By considering drones with higher capacities first, it maximizes the utilization of drone capacities and increases the chances of successfully assigning more locations.

- While there are still locations remaining to be assigned:

	a. It search for drones that have the remaining capacity to carry the packages.

	b. For each drone, iterate through the list of locations and check if the drone's remaining capacity is sufficient to carry the package weight.

	c. If the drone has enough capacity, assign the location to the drone by adding it to the drone's list of assigned locations and update the remaining capacity of the drone.

	e. If at the end of the cycle there is still space in the drone greater than five percent or  to carry more packages, but the list of locations has already been covered, it moves on to the next drone with a smaller capacity.

	f. Repeat the process until either all locations are assigned or no drone has enough remaining capacity.

- The function finishes when all locations are assigned or no drone has enough capacity to carry any remaining location.

_______________

## Technical Dependencies and Libraries

- Language: C# (version: C# 7.3)
- Framework: .NET Framework (version: 4.7.2)
- IDE: Microsoft Visual Studio (version: 2022) or any other C# development environment.
- Dependencies: No external dependencies or libraries were used.

Please note that the specific versions mentioned here are examples, and the code should be compatible with other versions too

_______________

## Example Input and Output Files

***INPUT FILE #1***

***Enter drone information:***
```
DroneA, 200, DroneB, 250, DroneC, 100
```

***Enter locations and package weights (one per line). If you want to finish inserting the locations press enter again and the program will distribute the locations by the indicated drones:***

```
LocationA, 200
LocationB, 150
LocationC, 50
LocationD, 150
LocationE, 100
LocationF, 200
LocationG, 50
LocationH, 80
LocationI, 70
LocationJ, 50
LocationK, 30
LocationL, 20
LocationM, 50
LocationN, 30
LocationO, 20
LocationP, 90
```

***OUTPUT FILE #1*** 
```
DroneA
Trip #1
LocationH, LocationI, LocationJ
Trip #2
LocationM, LocationK, LocationN, LocationL, LocationO

DroneB
Trip #1
LocationA, LocationC
Trip #2
LocationF, LocationG
Trip #3
LocationB, LocationE
Trip #4
LocationD, LocationP

DroneC
```
_______________

***INPUT FILE #2***

***Enter drone information:***
```
DroneA, 300, DroneB, 350, DroneC, 200
```

***Enter locations and package weights (one per line). If you want to finish inserting the locations press enter again and the program will distribute the locations by the indicated drones:***

```
LocationA, 200
LocationB, 150
LocationC, 50
LocationD, 150
LocationE, 100 
LocationF, 200
LocationG, 50 
LocationH, 80
LocationI, 70
LocationJ, 50 
```

***OUTPUT FILE #2*** 
```
DroneA

DroneB
Trip #1
LocationA, LocationB
Trip #2
LocationF, LocationD
Trip #3
LocationE, LocationH, LocationI, LocationC, LocationG
Trip #4
LocationJ

DroneC
```

***INPUT FILE #3***

***Enter drone information:***
```
DroneA, 150, DroneB, 300, DroneC, 200
```

***Enter locations and package weights (one per line). If you want to finish inserting the locations press enter again and the program will distribute the locations by the indicated drones:***

```
LocationA, 200
LocationB, 150
LocationC, 50
LocationD, 150
LocationE, 100
LocationF, 200
LocationG, 90
LocationH, 80
LocationI, 70
LocationJ, 60
LocationK, 80
LocationL, 20
LocationM, 50
LocationN, 40
LocationO, 20
LocationP, 40
```

***OUTPUT FILE #3*** 
```
DroneA

DroneB
Trip #1
LocationA, LocationE
Trip #2
LocationF, LocationG
Trip #3
LocationB, LocationD
Trip #4
LocationH, LocationK, LocationI, LocationJ
Trip #5
LocationC, LocationM, LocationN, LocationP, LocationL, LocationO

DroneC
```
