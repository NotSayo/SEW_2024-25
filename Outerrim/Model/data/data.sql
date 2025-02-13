
INSERT INTO AircraftSpecifications (SpecificationId, StructureId, FuelTankCapacity, MinSpeed, MaxSpeed, MaxAltitude, SpecificationCode) VALUES (1, 3, 10, 2, 6, 5, 'Tunderbolt');
INSERT INTO AircraftSpecifications (SpecificationId, StructureId, FuelTankCapacity, MinSpeed, MaxSpeed, MaxAltitude, SpecificationCode) VALUES (2, 2, 8, 3, 8, 4, 'Vulture');

INSERT INTO Aircrafts (AircraftId, Altitude, Fuel, Name, SpecificationId, Speed) VALUES (1, 5, 6, 'Executioner', 1, 4);
INSERT INTO Aircrafts (AircraftId, Altitude, Fuel, Name, SpecificationId, Speed) VALUES (2, 3, 3, 'Dakkajet', 2, 3);

INSERT INTO Mercenaries (MercenaryId, BodySkills, CombatSkill, FirstName, LastName) VALUES (1, 4, 4, 'Han', 'Solo');
INSERT INTO Mercenaries (MercenaryId, BodySkills, CombatSkill, FirstName, LastName) VALUES (2, 8, 8, 'Luke', 'Skywalker');

INSERT INTO Compartments (CompartmentId, AircraftId) VALUES (1, 1);
INSERT INTO Compartments (CompartmentId, AircraftId) VALUES (2, 1);
INSERT INTO Compartments (CompartmentId, AircraftId) VALUES (3, 1);
INSERT INTO Compartments (CompartmentId, AircraftId) VALUES (4, 1);