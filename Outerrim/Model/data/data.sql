
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

-- extra for aurcrafts, those were not provided in the original data.sql

-- Insert into Machineries table
INSERT INTO Machineries (MachineryId, Label, Function, CompartmentId) VALUES
    (1, 'Laser Cannon', 'High-energy laser weapon', 1),
    (2, 'Missile Launcher', 'Fires guided missiles', 2),
    (3, 'Fusion Reactor', 'Provides power to onboard systems', 3),
    (4, 'AI Navigation', 'Autonomous flight system', 4),
    (5, 'Oxygen Generator', 'Supplies oxygen for crew', 1),
    (6, 'Plasma Beam', 'High-energy plasma weapon', 2),
    (7, 'Hellfire Missiles', 'Fires guided missiles', 3),
    (8, 'Fusion Core', 'Provides power to onboard systems', 4),
    (9, 'AI Navigation', 'Autonomous flight system', 1),
    (10, 'Air Filtration Unit', 'Supplies oxygen for crew', 2),
    (11, 'CO2 Scrubber', 'Removes CO2 from the air', 3),
    (12, 'High-Capacity Battery', 'Provides power to onboard systems', 4);

