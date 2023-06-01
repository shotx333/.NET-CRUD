CREATE TABLE User (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL, 
    Email NVARCHAR(255) NOT NULL UNIQUE,
    IsActive BIT NOT NULL
);

CREATE TABLE UserProfile (
    Id INT IDENTITY(1,1),
    UserId INT UNIQUE,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    PersonalNumber CHAR(11),
    FOREIGN KEY (UserId) REFERENCES User(Id),
    PRIMARY KEY (Id, UserId)
);
