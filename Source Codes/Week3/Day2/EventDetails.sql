CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,

    EventName VARCHAR(50) NOT NULL
        CHECK (LEN(EventName) BETWEEN 1 AND 50),

    EventCategory VARCHAR(50) NOT NULL
        CHECK (LEN(EventCategory) BETWEEN 1 AND 50),

    EventDate DATETIME NOT NULL,

    Description VARCHAR(255) NULL,

    Status VARCHAR(20)
        CHECK (Status IN ('Active', 'In-Active'))
);


INSERT INTO EventDetails VALUES
(1, 'Tech Summit', 'Technology', '2026-03-03', 'Annual Tech Event', 'Active'),
(2, 'Developer Conference', 'IT', '2026-02-13', 'Dev Event', 'Active');


SELECT * FROM EventDetails;