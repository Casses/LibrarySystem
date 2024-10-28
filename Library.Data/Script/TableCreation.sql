CREATE TABLE Members (
    ID INT PRIMARY KEY,
    CardIdentifier VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    DateOfBirth DATE NOT NULL,
    MaxCheckouts INT DEFAULT 5
);

CREATE TABLE Books (
    ID INT PRIMARY KEY,
    Title VARCHAR2(255) NOT NULL,
    Description TEXT NOT NULL,
    Author VARCHAR2(255) NOT NULL,
    ISBN VARCHAR2(20) NOT NULL,
    Category INT not null,
    Genre int not null,
    Rating int not null,
    RatingDescription TEXT,
    HistoricalSignificance TEXT
);

CREATE TABLE ActivityLog (
    Id INT PRIMARY KEY,
    Checkout DATE NOT NULL,
    Return DATE,
    MemberID INT,
    BookID INT,
    FOREIGN KEY (MemberID) REFERENCES Members(ID),
    FOREIGN KEY (BookID) REFERENCES Books(ID)
);