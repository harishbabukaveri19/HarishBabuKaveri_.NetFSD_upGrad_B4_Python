CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,

    EventId INT NOT NULL,

    SessionTitle VARCHAR(50) NOT NULL
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),

    SpeakerId INT NOT NULL,

    Description VARCHAR(255) NULL,

    SessionStart DATETIME NOT NULL,

    SessionEnd DATETIME NOT NULL,

    SessionUrl VARCHAR(255),

    CONSTRAINT FK_Session_Event
        FOREIGN KEY (EventId)
        REFERENCES dbo.EventDetails(EventId),

    CONSTRAINT FK_Session_Speaker
        FOREIGN KEY (SpeakerId)
        REFERENCES dbo.SpeakersDetails(SpeakerId),

    CONSTRAINT CHK_Session_Time
        CHECK (SessionEnd > SessionStart)
);



INSERT INTO SessionInfo VALUES
(1001, 1, 'AI Trends', 101, 'Latest AI Updates',
 '2026-05-10 10:00:00',
 '2026-05-10 11:00:00',
 'https://www.google.com/ai_trends'),
 (1002, 2, 'DotNet', 102, 'Latest Technology',
 '2026-02-16 09:30:00',
 '2026-05-12 18:30:00',
 'https://www.google.com/DotNet_FSD_Python');


 SELECT * FROM SessionInfo;