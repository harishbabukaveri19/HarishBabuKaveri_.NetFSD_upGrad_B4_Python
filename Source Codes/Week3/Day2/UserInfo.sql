CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,

    UserName VARCHAR(50) NOT NULL
        CHECK (LEN(UserName) BETWEEN 1 AND 50),

    Role VARCHAR(20) NOT NULL
        CHECK (Role IN ('Admin', 'Participant')),

    Password VARCHAR(20) NOT NULL
        CHECK (LEN(Password) BETWEEN 6 AND 20)
);

INSERT INTO UserInfo VALUES
('admin@gmail.com', 'Admin', 'Admin', 'admin123'),
('harish@gmail.com', 'Harish', 'Participant', 'harish123'),
('vikas@gmail.com', 'Vikas', 'Participant', 'vikas123'),
('harshitha@gmail.com', 'Harshitha', 'Participant', 'harshitha123'),
('vasundhara@gmail.com', 'Vasundhara', 'Participant', 'vasundhara123')

SELECT * FROM UserInfo;