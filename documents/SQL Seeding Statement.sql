DROP TABLE weird_weather_table_name

CREATE TABLE weird_weather_table_name (Id int IDENTITY(1,1) PRIMARY KEY, Date datetime2(7) NOT NULL, TemperatureCelsius decimal NOT NULL, Summary nvarchar(50) NOT NULL)

INSERT INTO weird_weather_table_name (Date, TemperatureCelsius, Summary)
VALUES ('2024-10-01T07:20:33.791709+00:00', 3.1, 'Balmy'),
('2024-10-02T07:20:33.7918462+00:00', 24.0, 'Hot'),
('2024-10-03T07:20:33.7918472+00:00', 22.2, 'Hot'),
('2024-10-04T07:20:33.7918473+00:00', -14.3, 'Sweltering'),
('2024-10-05T07:20:33.7918474+00:00', -10, 'Mild')

SELECT * FROM weird_weather_table_name