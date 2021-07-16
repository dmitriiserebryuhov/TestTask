DECLARE @Flowers TABLE(Name nvarchar(20))
INSERT INTO @Flowers
VALUES ('Rose'),
('Tulip'),
('Daisy'),
('Forget-me-not'),
('Lilac'),
('Narcissus'),
('Camomile'),
('Lily of the valley')

SELECT t1.Name color1,
       t2.Name color2,
       t3.Name color3,
       t4.Name color4,
	   t5.Name color5
FROM @Flowers t1
INNER JOIN @Flowers t2 ON t1.Name > t2.Name
INNER JOIN @Flowers t3 ON t2.Name > t3.Name
INNER JOIN @Flowers t4 ON t3.Name > t4.Name
INNER JOIN @Flowers t5 ON t4.Name > t5.Name
