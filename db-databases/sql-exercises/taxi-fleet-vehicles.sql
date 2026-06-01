-- =============================================
-- Fill the tags below using Ctrl + Shift + M
-- Student ID: 11123622 Discipline: Base de Dados
-- =============================================

-- 1)
SELECT * FROM Vehicle
ORDER BY BuyDate;

-- 2)
SELECT F.OwnerName, F.OwnerAddress
FROM Fleet F
INNER JOIN Vehicle V ON F.NumFleet = V.NumFleet;

-- 3)
SELECT F.* FROM Fleet F
LEFT JOIN Vehicle V ON F.NumFLeet = V.NumFleet
WHERE V.NumVehicle is null;

-- 4)
SELECT V.* FROM Vehicle V
LEFT JOIN DriverAssignment DA ON V.NumVehicle = DA.NumVehicle
WHERE DA.NumDriver IS NULL;


-- 5)
SELECT D.* FROM Driver D
LEFT JOIN DriverAssignment DA ON D.NumDriver = DA.NumDriver
WHERE DA.NumVehicle IS NULL;

-- 6)
SELECT V.NrSeats, MI.NumVehicle, SUM (MI.IncomeTotal) AS TotalIncome
FROM Vehicle V
INNER JOIN MonthIncome MI ON V.NumVehicle = MI.Numvehicle WHERE MI.year = 2024 AND MI.Month = 4 GROUP BY V.Nrseats, MI.NumVehicle

-- 7)
SELECT f.OwnerName, me.TotalExpense
FROM Fleet f
JOIN Vehicle v ON f.NumFleet = v.NumFleet
JOIN MonthExpense me ON v.NumVehicle = me.NumVehicle WHERE me.Month = 5 AND me.Year = 2024 AND me.TotalExpense = (SELECT MAX(TotalExpense)FROM MonthExpense WHERE Month = 5 AND Year = 2024);

--8)
SELECT DriverName, DriverAssignment.NumVehicle, Period
FROM DRIVER
JOIN DriverAssignment ON Driver.NumDriver = DriverAssignment.NumDriver
ORDER BY DriverName

--9)
SELECT f.FleetName, v.BuyDate,v.NrSeats,mi.Month,mi.Year,mi.IncomeTotal,me.TotalExpense,(mi.IncomeTotal - me.TotalExpense) AS Balance
FROM Fleet f
JOIN Vehicle v ON f.NumFleet = v.NumFleet
JOIN MonthIncome mi ON v.NumVehicle = mi.NumVehicle
JOIN MonthExpense me ON v.NumVehicle = me.NumVehicle
AND mi.Month = me.Month
AND mi.Year = me.Year
ORDER BY f.FleetName,v.NumVehicle, Balance DESC;