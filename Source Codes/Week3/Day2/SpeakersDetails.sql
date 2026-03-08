CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,

    SpeakerName VARCHAR(50) NOT NULL
        CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);


INSERT INTO SpeakersDetails VALUES
(101, 'Ravi Kumar'),
(102, 'Venkat');


SELECT * FROM SpeakersDetails;