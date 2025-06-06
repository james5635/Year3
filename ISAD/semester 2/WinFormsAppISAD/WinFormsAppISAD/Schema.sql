SET ANSI_NULLS, QUOTED_IDENTIFIER ON;
GO

USE master
GO

-- Drop database if it exists
IF EXISTS (
    SELECT name
FROM sys.databases
WHERE name = N'WinFormsAppISAD'
)
BEGIN
    -- Set database to single user mode to kill all connections
    ALTER DATABASE [WinFormsAppISAD] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [WinFormsAppISAD];
    PRINT 'Database WinFormsAppISAD dropped.';
END
GO

-- Create database
CREATE DATABASE [WinFormsAppISAD];
PRINT 'Database WinFormsAppISAD created.';
GO
ALTER DATABASE WinFormsAppISAD SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE;
GO
USE [WinFormsAppISAD];
GO


-- ========================================================
-- CREATE TABLES
-- ========================================================
PRINT 'Creating tables...';
CREATE TABLE tbSuppliers
(
    supID INT IDENTITY(1,1) PRIMARY KEY,
    Supplier NVARCHAR(100) NOT NULL UNIQUE,
    SupAdd NVARCHAR(100) NOT NULL,
    SupCon VARCHAR(100) NOT NULL UNIQUE
    -- Increased size to avoid potential truncation
);
PRINT 'Table tbSuppliers created.';

CREATE TABLE tbStaffs
(
    staffID TINYINT IDENTITY(1,1) PRIMARY KEY,
    -- Allows IDs from 0 to 255
    FullName NVARCHAR(50) NOT NULL,
    Gen CHAR(1) NOT NULL CHECK (Gen IN ('M', 'F')),
    Dob DATE NOT NULL,
    Position VARCHAR(50) NOT NULL,
    Salary MONEY NOT NULL CHECK (Salary >= 0),
    Stopwork BIT NOT NULL DEFAULT 0,
    Photo VARBINARY(MAX)
    -- Changed NULL to NOT NULL DEFAULT 0
);
PRINT 'Table tbStaffs created.';

CREATE TABLE tbCustomers
(
    cusID INT IDENTITY(1,1) PRIMARY KEY,
    CusName VARCHAR(100) NOT NULL,
    CusContact VARCHAR(15) NOT NULL UNIQUE
    -- Increased size slightly
);
PRINT 'Table tbCustomers created.';

CREATE TABLE tbProducts
(
    ProCode INT IDENTITY(1,1) PRIMARY KEY,
    ProName VARCHAR(100) NOT NULL UNIQUE,
    -- Qty, UPIS, SUP should be redundency, it could break normalization
    -- Added UNIQUE constraint
    Qty SMALLINT NOT NULL CHECK (Qty >= 0),
    UPIS MONEY NOT NULL CHECK (UPIS >= 0),
    -- Unit Price In Stock
    SUP MONEY NOT NULL CHECK (SUP >= 0)
    -- Sales Unit Price
);
PRINT 'Table tbProducts created.';

CREATE TABLE tbImports
(
    ImpCode INT IDENTITY(1,1) PRIMARY KEY,
    ImpDate DATE NOT NULL,
    staffID TINYINT NOT NULL,
    FullName NVARCHAR(50) NOT NULL,
    -- Match tbStaffs.FullName type
    supID INT NOT NULL,
    Supplier NVARCHAR(100) NOT NULL,
    -- Match tbSuppliers.Supplier type
    Total MONEY NOT NULL CHECK (Total >= 0),
    FOREIGN KEY (staffID) REFERENCES tbStaffs(staffID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (supID) REFERENCES tbSuppliers(supID) ON DELETE CASCADE ON UPDATE CASCADE
);
PRINT 'Table tbImports created.';

CREATE TABLE tbInvoices
(
    InvCode INT IDENTITY(1,1) PRIMARY KEY,
    InvDate SMALLDATETIME NOT NULL,
    staffID TINYINT NOT NULL,
    FullName NVARCHAR(50) NOT NULL,
    -- Match tbStaffs.FullName type
    cusID INT NOT NULL,
    cusName VARCHAR(100) NOT NULL,
    -- Match tbCustomers.CusName type
    Total MONEY NOT NULL CHECK (Total >= 0),
    FOREIGN KEY (staffID) REFERENCES tbStaffs(staffID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (cusID) REFERENCES tbCustomers(cusID) ON DELETE CASCADE ON UPDATE CASCADE
);
PRINT 'Table tbInvoices created.';

CREATE TABLE tbPayments
(
    PayCode INT IDENTITY(1,1) PRIMARY KEY,
    PayDate SMALLDATETIME NOT NULL,
    staffID TINYINT NOT NULL,
    FullName NVARCHAR(50) NOT NULL,
    -- Match tbStaffs.FullName type
    InvCode INT NOT NULL,
    Amount MONEY NOT NULL CHECK (Amount >= 0),
    FOREIGN KEY (staffID) REFERENCES tbStaffs(staffID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (InvCode) REFERENCES tbInvoices(InvCode) ON DELETE CASCADE ON UPDATE CASCADE
);
PRINT 'Table tbPayments created.';

CREATE TABLE tbImportdetail
(
    ImpCode INT NOT NULL,
    ProCode INT NOT NULL,
    ProName VARCHAR(100) NOT NULL,
    -- Match tbProducts.ProName type
    Qty SMALLINT NOT NULL CHECK (Qty > 0),
    -- Quantity should be positive
    Price MONEY NOT NULL CHECK (Price >= 0),
    Amount MONEY NOT NULL CHECK (Amount >= 0),
    PRIMARY KEY (ImpCode, ProCode),
    FOREIGN KEY (ImpCode) REFERENCES tbImports(ImpCode) ON DELETE CASCADE ON UPDATE CASCADE,
    -- Optional: Cascade delete
    FOREIGN KEY (ProCode) REFERENCES tbProducts(ProCode) ON DELETE CASCADE ON UPDATE CASCADE
);
PRINT 'Table tbImportdetail created.';

CREATE TABLE tbInvoiceDetail
(
    InvCode INT NOT NULL,
    ProCode INT NOT NULL,
    ProName VARCHAR(100) NOT NULL,
    -- Match tbProducts.ProName type
    Qty SMALLINT NOT NULL CHECK (Qty > 0),
    -- Quantity should be positive
    Price MONEY NOT NULL CHECK (Price >= 0),
    Amount MONEY NOT NULL CHECK (Amount >= 0),
    PRIMARY KEY (InvCode, ProCode),
    FOREIGN KEY (InvCode) REFERENCES tbInvoices(InvCode) ON DELETE CASCADE ON UPDATE CASCADE,
    -- Optional: Cascade delete
    FOREIGN KEY (ProCode) REFERENCES tbProducts(ProCode) ON DELETE CASCADE ON UPDATE CASCADE
);
PRINT 'Table tbInvoiceDetail created.';
GO

-- ========================================================
-- INSERT 100 RECORDS INTO EACH TABLE
-- ========================================================
PRINT 'Inserting sample data...';

-- Insert into tbSuppliers (100 Records)
-- Note: supID is IDENTITY, starts at 1
PRINT 'Inserting data into tbSuppliers...';
INSERT INTO tbSuppliers
    (Supplier, SupAdd, SupCon)
VALUES
    -- Original 10
    ('Global Tech Co.', '123 Elm Street, Anytown', '1234567890'),
    ('Oceanic Electronics', '456 Maple Avenue, Sometown', '2345678901'),
    ('Future Gadgets', '789 Oak Drive, Villagetown', '3456789012'),
    ('Nova Supplies', '135 Pine Road, Cityville', '4567890123'),
    ('Sunrise Tools', '246 Cedar Blvd, Metropolis', '5678901234'),
    ('Quantum Parts', '357 Birch Lane, Boroughburg', '6789012345'),
    ('Vector Solutions', '468 Spruce Court, Hamlet', '7890123456'),
    ('Apex Traders', '579 Willow Way, Township', '8901234567'),
    ('Pioneer Imports', '680 Aspen St, District', '9012345678'),
    ('Elite Components', '791 Cherry Ave, Province', '0123456789'),
    -- Added 90
    ('Data Dynamics Inc.', '801 Redwood Circle, Megalopolis', '1122334455'),
    ('Circuit Central', '912 Sequoia Path, Settlement', '2233445566'),
    ('Synergy Systems', '1023 Fir Terrace, Region', '3344556677'),
    ('Momentum Devices', '1134 Birch Alley, County', '4455667788'),
    ('Horizon Hardware', '1245 Maple Walk, State', '5566778899'),
    ('Alpha Solutions', '1356 Oak Plaza, Territory', '6677889900'),
    ('Omega Distribution', '1467 Pine Heights, Zone', '7788990011'),
    ('Vertex Ventures', '1578 Cedar Point, Sector', '8899001122'),
    ('Zenith Supplies', '1689 Spruce Ridge, Area', '9900112233'),
    ('Nadir Goods', '1700 Willow Bend, Locality', '0011223344'),
    ('Precision Parts Ltd.', '1811 Aspen Grove, Neighbourhood', '1212121212'),
    ('Infinite Inventory', '1922 Cherry Hills, Quarter', '2323232323'),
    ('Core Components Co.', '2033 Elm Valley, Precinct', '3434343434'),
    ('Peak Performance Parts', '2144 Maple Crest, Ward', '4545454545'),
    ('NextGen Networks', '2255 Oak Shade, Canton', '5656565656'),
    ('Stellar Systems', '2366 Pine Bluff, Shire', '6767676767'),
    ('Galaxy Gadgets', '2477 Cedar Ridge, Parish', '7878787878'),
    ('Cosmic Connections', '2588 Spruce Knoll, Commune', '8989898989'),
    ('Terra Tech', '2699 Willow Creek, Municipality', '90909092090'),
    ('Aqua Accessories', '2710 Aspen Trail, Capital', '0101010101'),
    ('Ignition Industries', '2821 Cherry Run, Domain', '1111111111'),
    ('Fusion Fabricators', '2932 Elm Meadow, Realm', '2222222222'),
    ('Catalyst Corp.', '3043 Maple Stream, Empire', '3333333333'),
    ('Element Electronics', '3154 Oak Spring, Kingdom', '4444444444'),
    ('Matrix Merchants', '3265 Pine Lake, Republic', '5555555555'),
    ('Logic Link Ltd.', '3376 Cedar Falls, Union', '6666666666'),
    ('Byte Brokers', '3487 Spruce Glen, Federation', '7777777777'),
    ('Data Depot', '3598 Willow Brook, Commonwealth', '8888888888'),
    ('Info Imports', '3609 Aspen River, Confederacy', '9999999999'),
    ('Network Necessities', '3710 Cherry Ford, Alliance', '0000000000'),
    ('System Suppliers', '3821 Elm Bridge, Coalition', '1010101010'),
    ('Techno Traders', '3932 Maple Crossing, Conglomerate', '2020202020'),
    ('Digital Distributors', '4043 Oak Pass, Syndicate', '3030303030'),
    ('Electron Enterprises', '4154 Pine View, Cartel', '4040404040'),
    ('Silicon Solutions', '4265 Cedar Summit, Guild', '5050505050'),
    ('Component Corner', '4376 Spruce Peak, Society', '6060606060'),
    ('Hardware House', '4487 Willow Crest, Association', '7070707070'),
    ('Gadget Gateway', '4598 Aspen Heights, Foundation', '8080808080'),
    ('Device Domain', '4609 Cherry Ridge, Institute', '90903909090'),
    ('Accessory Avenue', '4710 Elm Point, Organization', '0123012301'),
    ('Parts Pavilion', '4821 Maple Knoll, Establishment', '1234123412'),
    ('Supply Sphere', '4932 Oak Creek, Agency', '2345234523'),
    ('Trade Trove', '5043 Pine Trail, Bureau', '3456345634'),
    ('Merchant Mart', '5154 Cedar Run, Commission', '4567456745'),
    ('Vendor Valley', '5265 Spruce Meadow, Committee', '5678567856'),
    ('Resource Realm', '5376 Willow Stream, Council', '6789678967'),
    ('Inventory Island', '5487 Aspen Spring, Board', '7890789078'),
    ('Commodity Central', '5598 Cherry Lake, Trust', '8901890189'),
    ('Goods Group', '5609 Elm Falls, Firm', '9012901290'),
    ('Provision Point', '5710 Maple Glen, Partnership', '012340111234'),
    ('Stock Source', '5821 Oak Brook, Consortium', '1234512345'),
    ('Material Masters', '5932 Pine River, Cooperative', '2345623456'),
    ('Item Imports', '6043 Cedar Ford, Collective', '3456734567'),
    ('Unit Universe', '6154 Spruce Bridge, Megacorp', '4567845678'),
    ('Widget World', '6265 Willow Crossing, Holdings', '56789256789'),
    ('Appliance Alliance', '6376 Aspen Pass, Group', '6789067890'),
    ('Tool Treasury', '6487 Cherry View, Network', '789017558901'),
    ('Equipment Emporium', '6598 Elm Summit, Hub', '89012859012'),
    ('Machine Merchants', '6609 Maple Peak, Outlet', '9012390123'),
    ('Factory Finds', '6710 Oak Crest, Depot', '0123450123'),
    ('Industrial Inc.', '6821 Pine Heights, Warehouse', '12134512345'),
    ('Workshop Warehouse', '6932 Cedar Ridge, Plant', '23456423456'),
    ('Build Base', '7043 Spruce Point, Mill', '34562734567'),
    ('Construct Co.', '7154 Willow Knoll, Works', '45678485678'),
    ('Engineer Essentials', '7265 Aspen Creek, Studio', '56789546789'),
    ('Maker Market', '7376 Cherry Trail, Lab', '6789057890'),
    ('Creator Components', '7487 Elm Run, Atelier', '78901748901'),
    ('Design Distributors', '7598 Maple Meadow, Foundry', '89012389012'),
    ('Prototype Providers', '7609 Oak Stream, Forge', '90123490123'),
    ('Innovation Imports', '7710 Pine Spring, Incubator', '0123401234'),
    ('Assembly Associates', '7821 Cedar Lake, Accelerator', '12345122345'),
    ('Manufacture Masters', '7932 Spruce Falls, Facility', '23435623456'),
    ('Production Partners', '8043 Willow Glen, Center', '34567344567'),
    ('Fabrication Firm', '8154 Aspen Brook, Complex', '45678445678'),
    ('Process Point', '8265 Cherry River, Site', '56786956789'),
    ('Operation Outfitters', '8376 Elm Ford, Base', '67829067890'),
    ('Logistics Leaders', '8487 Maple Bridge, Terminal', '7890178901'),
    ('Transport Traders', '8598 Oak Crossing, Junction', '89012289012'),
    ('Shipment Solutions', '8609 Pine Pass, Port', '901233390123'),
    ('Cargo Central', '8710 Cedar View, Dock', '0123450123423'),
    ('Freight Forwarders', '8821 Spruce Summit, Yard', '12345312345'),
    ('Delivery Dynamics', '8932 Willow Peak, Station', '23451623456'),
    ('Express Exports', '9043 Aspen Crest, Post', '34567345567'),
    ('Global Goods Hub', '9154 Cherry Heights, Exchange', '45678245678'),
    ('InterConnect Supplies', '9265 Elm Ridge, Mart', '5678956789'),
    ('SourceMax Inc.', '9376 Maple Point', '67890672890'),
    ('Prime Particulates', '9487 Oak Knoll', '78901378901'),
    ('Universal Units', '9598 Pine Creek', '890128962012'),
    ('Connecta Corp', '9709 Cedar Trail', '2'),
    ('Linkage Ltd.', '9810 Spruce Run', '3'),
    ('Nexus Networks', '9921 Willow Spring', '4'),
    ('Bridge Builders', '10032 Aspen Lake', '5'),
    ('Convergence Co.', '11143 Cherry Falls', '6'),
    ('Synergy Supplies', '12254 Elm Glen', '7'),
    ('Unity Imports', '13365 Maple Brook', '8'),
    ('Alliance Accessories', '14476 Oak Ridge', '9'),
    ('Collaboration Components', '15587 Pine Heights', '10'),
    ('Integration Industries', '16698 Cedar Summit', '11'),
    ('Connection Corp.', '17809 Spruce Point', '12'),
    ('Partnership Products', '18910 Willow Knoll', '13'),
    ('Joint Ventures', '19021 Aspen Creek', '14'),
    ('Teamwork Traders', '20132 Cherry Trail', '15'),
    ('Cooperation Co.', '21243 Elm Run', '16'),
    ('Collective Components', '22354 Maple Meadow', '17'),
    ('Shared Solutions', '23465 Oak Stream', '18'),
    ('Mutual Merchants', '24576 Pine Spring', '19'),
    ('Collaborative Corp.', '25687 Cedar Lake', '20');

PRINT 'Data insertion into tbSuppliers complete (100 records).';
GO

-- Insert into tbStaffs (100 Records)
-- Note: staffID is IDENTITY PRIMARY KEY, start at 1
PRINT 'Inserting data into tbStaffs...';
INSERT INTO tbStaffs
    ( FullName, Gen, Dob, Position, Salary, Stopwork)
VALUES
    -- Original 10
    ( 'Alice Johnson', 'F', '1990-05-14', 'Manager', 70000, 0),
    ( 'Bob Smith', 'M', '1985-02-23', 'Sales', 50000, 0),
    ( 'Charlie Brown', 'M', '1992-08-12', 'Accountant', 55000, 0),
    ( 'Daisy Ridley', 'F', '1988-11-30', 'Support', 45000, 1),
    ( 'Evan Wright', 'M', '1995-07-19', 'Sales', 48000, 0),
    ( 'Fiona Glenanne', 'F', '1991-04-02', 'Manager', 72000, 0),
    ( 'George Martin', 'M', '1980-01-17', 'Support', 40000, 1),
    ( 'Hannah Baker', 'F', '1993-03-21', 'Accountant', 53000, 0),
    ( 'Ivan Petrov', 'M', '1987-09-25', 'Sales', 51000, 0),
    ( 'Jane Doe', 'F', '1994-12-10', 'Support', 42000, 0),
    -- Added 90
    ( 'Kevin Lee', 'M', '1996-10-05', 'Technician', 47000, 0),
    ( 'Laura Palmer', 'F', '1989-06-15', 'HR Specialist', 60000, 0),
    ( 'Michael Scott', 'M', '1982-03-18', 'Regional Manager', 75000, 0),
    ( 'Nancy Drew', 'F', '1997-01-20', 'Analyst', 58000, 0),
    ( 'Oliver Twist', 'M', '1998-08-08', 'Intern', 25000, 0),
    ( 'Pam Beesly', 'F', '1990-07-07', 'Admin', 46000, 0),
    ( 'Quentin Crisp', 'M', '1984-12-01', 'Marketing Lead', 62000, 0),
    ( 'Rachel Green', 'F', '1991-02-14', 'Sales Associate', 52000, 0),
    ( 'Sam Winchester', 'M', '1986-05-02', 'Senior Technician', 59000, 0),
    ( 'Tina Fey', 'F', '1988-09-11', 'Lead Manager', 78000, 0),
    ( 'Uma Thurman', 'F', '1993-04-29', 'Customer Success', 44000, 0),
    ( 'Vince Vaughn', 'M', '1981-11-05', 'Senior Sales', 56000, 0),
    ( 'Walter White', 'M', '1979-09-07', 'Logistics', 57000, 1),
    ( 'Xena Warrior', 'F', '1983-03-15', 'Security Officer', 50000, 0),
    ( 'Yuri Gagarin', 'M', '1970-10-21', 'Consultant', 90000, 0),
    ( 'Zoe Saldana', 'F', '1992-07-24', 'Content Writer', 57000, 0),
    ( 'Arthur Pendragon', 'M', '1987-01-09', 'Sales Engineer', 61500, 0),
    ( 'Betty Cooper', 'F', '1995-01-17', 'Office Admin', 47500, 0),
    ( 'Conan Edogawa', 'M', '1993-04-18', 'Marketing Assistant', 41000, 0),
    ( 'Drew Barrymore', 'F', '1990-02-22', 'Operations Manager', 74000, 0),
    ( 'Ethan Hunt', 'M', '1981-06-28', 'Field Engineer', 65000, 0),
    ( 'Gwen Stacy', 'F', '1999-08-15', 'Junior Developer', 52000, 0),
    ( 'Harry Potter', 'M', '1991-07-31', 'IT Support', 48000, 0),
    ( 'Iris West', 'F', '1994-05-20', 'HR Assistant', 49000, 0),
    ( 'Jack Sparrow', 'M', '1980-11-11', 'Purchasing Agent', 53000, 0),
    ( 'Kim Possible', 'F', '1997-06-07', 'Project Coordinator', 54000, 0),
    ( 'Luke Skywalker', 'M', '1988-03-25', 'Systems Analyst', 63000, 0),
    ( 'Mary Jane Watson', 'F', '1993-09-10', 'Receptionist', 41000, 0),
    ( 'Neo Anderson', 'M', '1984-03-13', 'Network Engineer', 67000, 0),
    ( 'Olivia Pope', 'F', '1985-12-01', 'PR Manager', 76000, 0),
    ( 'Peter Pan', 'M', '1996-02-29', 'Sales Intern', 28000, 0),
    ( 'Quinn Fabray', 'F', '1994-11-08', 'Account Manager', 61000, 0),
    ( 'Rick Grimes', 'M', '1978-09-19', 'Warehouse Manager', 60000, 1),
    ( 'Sarah Connor', 'F', '1982-10-22', 'Logistics Coordinator', 51000, 0),
    ( 'Tony Stark', 'M', '1975-05-29', 'CEO', 150000, 0),
    ( 'Ursula Buffay', 'F', '1987-07-15', 'Support Specialist', 46000, 0),
    ( 'Victor Frankenstein', 'M', '1990-01-30', 'R&D Specialist', 69000, 0),
    ( 'Willow Rosenberg', 'F', '1992-08-21', 'IT Manager', 73000, 0),
    ( 'Xavier Charles', 'M', '1976-04-16', 'Senior Consultant', 95000, 0),
    ( 'Ygritte Snow', 'F', '1991-03-17', 'Field Sales', 53000, 0),
    ( 'Zachary Taylor', 'M', '1983-11-24', 'Accountant II', 59000, 0),
    ( 'Amy Santiago', 'F', '1990-09-01', 'Office Manager', 62000, 0),
    ( 'Bilbo Baggins', 'M', '1965-09-22', 'Archivist', 54000, 1),
    ( 'Carmen Sandiego', 'F', '1985-03-05', 'Travel Coordinator', 50000, 0),
    ( 'Dexter Morgan', 'M', '1980-02-01', 'Forensic Analyst', 68000, 0),
    ( 'Elle Woods', 'F', '1993-10-13', 'Legal Counsel', 85000, 0),
    ( 'Forrest Gump', 'M', '1977-07-06', 'Operations Support', 45000, 0),
    ( 'Ginny Weasley', 'F', '1992-08-11', 'Marketing Manager', 71000, 0),
    ( 'Han Solo', 'M', '1982-01-25', 'Logistics Driver', 48000, 0),
    ( 'Isabelle Lightwood', 'F', '1995-05-12', 'Security Analyst', 66000, 0),
    ( 'James Bond', 'M', '1979-11-16', 'Risk Analyst', 77000, 0),
    ( 'Katniss Everdeen', 'F', '1996-05-08', 'Procurement Specialist', 57000, 0),
    ( 'Legolas Greenleaf', 'M', '1989-04-01', 'Customer Relations', 52000, 0),
    ( 'Mulan Fa', 'F', '1991-06-20', 'Training Coordinator', 56000, 0),
    ( 'Naruto Uzumaki', 'M', '1998-10-10', 'Junior Sales', 46000, 0),
    ( 'Oprah Winfrey', 'F', '1974-01-29', 'Communications Director', 98000, 0),
    ( 'Paddington Bear', 'M', '1986-12-25', 'Receptionist', 42000, 0),
    ( 'Queen Elsa', 'F', '1990-12-21', 'Facilities Manager', 64000, 0),
    ( 'Ron Swanson', 'M', '1970-03-03', 'Director', 88000, 0),
    ( 'Sakura Haruno', 'F', '1998-03-28', 'Medical Officer', 70000, 0),
    ( 'Sherlock Holmes', 'M', '1981-01-06', 'Lead Analyst', 82000, 0),
    ( 'Tiana Princess', 'F', '1994-09-16', 'Culinary Manager', 58000, 0),
    ( 'Usain Bolt', 'M', '1986-08-21', 'Logistics Expediter', 50000, 0),
    ( 'Violet Baudelaire', 'F', '1999-04-04', 'Junior Engineer', 55000, 0),
    ( 'Willy Wonka', 'M', '1972-02-15', 'Product Development Lead', 79000, 0),
    ( 'Xavier McDaniel', 'M', '1985-06-04', 'Sales Manager', 80000, 0),
    ( 'Yara Greyjoy', 'F', '1990-11-19', 'Fleet Manager', 63000, 0),
    ( 'Zorro Vega', 'M', '1978-07-09', 'Brand Ambassador', 61000, 0),
    ( 'Archie Andrews', 'M', '1997-12-07', 'Support Technician', 44000, 0),
    ( 'Buffy Summers', 'F', '1993-01-19', 'Night Security', 47000, 0),
    ( 'Chuck Bartowski', 'M', '1988-09-24', 'Senior IT Support', 58000, 0),
    ( 'Daenerys Targaryen', 'F', '1992-06-23', 'Executive Assistant', 65000, 0),
    ( 'Eddard Stark', 'M', '1975-04-17', 'Compliance Officer', 72000, 1),
    ( 'Felicity Smoak', 'F', '1991-07-24', 'Network Administrator', 68000, 0),
    ( 'Gregory House', 'M', '1979-06-11', 'Medical Consultant', 92000, 0),
    ( 'Hermione Granger', 'F', '1991-09-19', 'Research Lead', 74000, 0),
    ( 'Indiana Jones', 'M', '1968-07-01', 'Acquisitions Specialist', 70000, 0),
    ( 'Jessica Jones', 'F', '1987-03-12', 'Investigator', 63000, 0),
    ( 'Khal Drogo', 'M', '1984-08-01', 'Security Consultant', 69000, 1),
    ( 'Lara Croft', 'F', '1990-02-14', 'Field Researcher', 66000, 0),
    ( 'Marty McFly', 'M', '1995-06-09', 'Logistics Assistant', 43000, 0),
    ( 'Natasha Romanoff', 'F', '1988-11-22', 'Special Operations', 81000, 0),
    ( 'Optimus Prime', 'M', '1960-01-01', 'Fleet Commander', 100000, 0),
    ( 'Pepper Potts', 'F', '1983-10-15', 'Chief Operations Officer', 120000, 0),
    ( 'Remy LeBeau', 'M', '1989-05-05', 'Sales Representative', 54000, 0),
    ( 'Steve Rogers', 'M', '1970-07-04', 'Ethics Officer', 85000, 0),
    ( 'Trinity Matrix', 'F', '1986-09-09', 'Systems Security', 78000, 0),
    ( 'Uhtred Ragnarson', 'M', '1977-03-20', 'Territory Manager', 76000, 0),
    ( 'Vanessa Ives', 'F', '1980-11-03', 'Archivist', 56000, 0),
    ( 'Wolverine Logan', 'M', '1965-04-22', 'Security Specialist', 71000, 0);
PRINT 'Data insertion into tbStaffs complete (100 records).';
GO

-- Insert into tbCustomers (100 Records)
-- Note: cusID is IDENTITY, starts at 1
PRINT 'Inserting data into tbCustomers...';
INSERT INTO tbCustomers
    (CusName, CusContact)
VALUES
    ('John Carter', '0912345678'),
    ('Mary Poppins', '0923456789'),
    ('Peter Parker', '0934567890'),
    ('Tony Stark', '0945678901'),
    ('Bruce Wayne', '0956789012'),
    ('Clark Kent', '0967890123'),
    ('Diana Prince', '0978901234'),
    ('Steve Rogers', '0989012345'),
    ('Natasha Romanoff', '0990123456'),
    ('Wanda Maximoff', '0901234567'),
    -- Added 90
    ('Arthur Dent', '0811223344'),
    ('Bilbo Baggins', '0822334455'),
    ('Charlie Chaplin', '0833445566'),
    ('Dorothy Gale', '0844556677'),
    ('Elizabeth Bennet', '0855667788'),
    ('Frodo Baggins', '0866778899'),
    ('Gandalf Grey', '0877889900'),
    ('Hercules Mulligan', '0888990011'),
    ('Indiana Jones', '0899001122'),
    ('James T. Kirk', '0800112233'),
    ('King Arthur', '0711223344'),
    ('Lois Lane', '0722334455'),
    ('Mickey Mouse', '0733445566'),
    ('Nemo Captain', '0744556677'),
    ('Odysseus Elytis', '0755667788'),
    ('Popeye Sailor', '0766778899'),
    ('Queen Amidala', '0777889900'),
    ('Robin Hood', '0788990011'),
    ('Sherlock Holmes', '0799001122'),
    ('Tarzan Clayton', '0700112233'),
    ('Ulysses Grant', '0611223344'),
    ('Vito Corleone', '0622334455'),
    ('Winnie Pooh', '0633445566'),
    ('Xiaoming Li', '0644556677'),
    ('Yoda Jedi', '0655667788'),
    ('Zorro Diego', '0666778899'),
    ('Atticus Finch', '0511223344'),
    ('Bugs Bunny', '0522334455'),
    ('Captain Ahab', '0533445566'),
    ('Darth Vader', '0544556677'),
    ('Elle Driver', '0555667788'),
    ('Frankenstein Monster', '0566778899'),
    ('George Bailey', '0577889900'),
    ('Hannibal Lecter', '0588990011'),
    ('Ichabod Crane', '0599001122'),
    ('Jack Skellington', '0500112233'),
    ('Kermit Frog', '0411223344'),
    ('Luke Cage', '0422334455'),
    ('Marty Feldman', '0433445566'),
    ('Norman Bates', '0444556677'),
    ('Optimus Prime', '0455667788'),
    ('Patrick Bateman', '0466778899'),
    ('Quasimodo Hunchback', '0477889900'),
    ('Rocky Balboa', '0488990011'),
    ('Spartacus Thracian', '0499001122'),
    ('Travis Bickle', '0400112233'),
    ('Uncle Sam', '0311223344'),
    ('Vincent Vega', '0322334455'),
    ('Walter Sobchak', '0333445566'),
    ('Xerxes King', '0344556677'),
    ('Yossarian Pilot', '0355667788'),
    ('Zaphod Beeblebrox', '0366778899'),
    ('Agent Smith', '0211223344'),
    ('Beatrix Kiddo', '0222334455'),
    ('Colonel Kurtz', '0233445566'),
    ('Don Draper', '0244556677'),
    ('Edward Scissorhands', '0255667788'),
    ('Forrest Gump', '0266778899'),
    ('Gordon Gekko', '0277889900'),
    ('HAL 9000', '0288990011'),
    ('Imperator Furiosa', '0299001122'),
    ('Jules Winnfield', '0200112233'),
    ('Keyser Söze', '0111223344'),
    ('Lestat Lioncourt', '0122334455'),
    ('Max Rockatansky', '0133445566'),
    ('Nurse Ratched', '0144556677'),
    ('O Ren Ishii', '0155667788'),
    ('Pennywise Clown', '0166778899'),
    ('Randle McMurphy', '0177889900'),
    ('Snake Plissken', '0188990011'),
    ('Tyler Durden', '0199001122'),
    ('User Tron', '0100112233'),
    ('Verbal Kint', '0911122334'),
    ('William Wallace', '0922233445'),
    ('Zed Marsellus', '0933344556'),
    ('Ace Ventura', '0944455667'),
    ('Blade Runner', '0955566778'),
    ('Citizen Kane', '0966677889'),
    ('Dracula Vlad', '0977788990'),
    ('Ethan Edwards', '0988899001'),
    ('Ferris Bueller', '0999900112'),
    ('Godzilla Kaiju', '0900011223'),
    ('Homer Simpson', '0911111111'),
    ('Inigo Montoya', '0922222222'),
    ('Jason Voorhees', '0933333333'),
    ('King Kong', '0944444444'),
    ('Leatherface Sawyer', '0955555555'),
    ('Michael Myers', '0966666666'),
    ('Neo Chosen', '0977777777'),
    ('Pinhead Cenobite', '0988888888');
PRINT 'Data insertion into tbCustomers complete (100 records).';
GO

-- Insert into tbProducts (100 Records)
-- Note: ProCode is IDENTITY, starts at 1
PRINT 'Inserting data into tbProducts...';
INSERT INTO tbProducts
    (ProName, Qty, UPIS, SUP)
VALUES
    ('Laptop A', 50, 500, 600),
    ('Smartphone B', 100, 300, 400),
    ('Tablet C', 70, 200, 250),
    ('Monitor D', 30, 150, 200),
    ('Keyboard E', 80, 20, 35),
    ('Mouse F', 90, 15, 25),
    ('Printer G', 20, 120, 180),
    ('Router H', 60, 40, 60),
    ('SSD I', 75, 80, 120),
    ('Headphone J', 40, 60, 90),
    -- Added 90
    ('Gaming Mouse X', 150, 45, 70),
    ('4K Webcam Pro', 60, 75, 110),
    ('Mechanical Keyboard GMMK', 70, 90, 130),
    ('Ultrawide Monitor 34"', 25, 350, 450),
    ('Wireless Earbuds Z', 200, 50, 80),
    ('Portable SSD 1TB', 55, 110, 150),
    ('Laser Printer OfficeJet', 15, 250, 350),
    ('Mesh WiFi System (3-pack)', 40, 180, 250),
    ('Graphics Card RTX 4070', 10, 600, 750),
    ('CPU Cooler Master Hyper 212', 80, 30, 45),
    ('RAM 16GB DDR4 Kit', 100, 60, 85),
    ('Motherboard B550 Chipset', 35, 120, 160),
    ('Power Supply 750W Gold', 45, 90, 125),
    ('PC Case Mid-Tower ATX', 50, 70, 100),
    ('Laptop Stand Adjustable', 120, 25, 40),
    ('USB-C Hub 7-in-1', 95, 35, 55),
    ('External Hard Drive 4TB', 30, 100, 140),
    ('Bluetooth Speaker SoundCore', 110, 40, 65),
    ('Smartwatch Series 9', 65, 280, 399),
    ('Fitness Tracker Band 6', 130, 30, 50),
    ('Drone Mini 4 Pro', 20, 450, 600),
    ('Action Camera Hero 12', 40, 300, 420),
    ('Digital Camera Mirrorless R8', 15, 1200, 1500),
    ('Microphone Yeti Blue', 50, 100, 130),
    ('LED Desk Lamp', 90, 20, 30),
    ('Ergonomic Office Chair', 25, 220, 320),
    ('Standing Desk Converter', 30, 150, 220),
    ('Monitor Arm Mount Single', 70, 40, 60),
    ('Cable Management Box', 150, 15, 25),
    ('Power Strip Surge Protector', 100, 18, 28),
    ('Wireless Charger Pad Qi', 120, 22, 35),
    ('Smartphone Holder Car Mount', 85, 12, 20),
    ('Tablet Stylus Pen Active', 60, 30, 45),
    ('Screen Protector Glass (Phone)', 250, 5, 10),
    ('Laptop Sleeve 15-inch', 110, 15, 25),
    ('Backpack Tech Commuter', 55, 60, 90),
    ('Gaming Headset Wireless', 45, 80, 120),
    ('VR Headset Quest 3', 18, 400, 550),
    ('Smart Thermostat Nest', 35, 150, 200),
    ('Smart Lock August WiFi', 28, 180, 250),
    ('Video Doorbell Ring Pro', 40, 160, 230),
    ('Security Camera Indoor Cam', 75, 50, 75),
    ('Smart Plug Kasa Mini', 140, 10, 18),
    ('LED Smart Bulb Color', 160, 15, 25),
    ('Robot Vacuum Roomba i7', 22, 450, 600),
    ('Air Purifier HEPA Filter', 30, 120, 180),
    ('Humidifier Cool Mist', 50, 40, 60),
    ('Electric Kettle Gooseneck', 60, 35, 55),
    ('Coffee Maker Drip 12-Cup', 40, 50, 75),
    ('Blender Professional Series', 25, 100, 150),
    ('Air Fryer 5.8QT', 38, 80, 120),
    ('Toaster Oven Convection', 32, 70, 100),
    ('Microwave Oven Countertop', 20, 90, 130),
    ('Handheld Vacuum Cordless', 45, 60, 90),
    ('Steam Iron Clothes', 70, 25, 40),
    ('Hair Dryer Ionic', 65, 30, 50),
    ('Electric Toothbrush Sonic', 80, 40, 65),
    ('Water Flosser Aquarius', 55, 50, 75),
    ('Blood Pressure Monitor Arm', 40, 35, 55),
    ('Digital Scale Body Weight', 70, 20, 30),
    ('Projector Portable 1080p', 25, 200, 300),
    ('Soundbar 2.1 Channel', 35, 150, 220),
    ('TV Streaming Stick 4K', 90, 40, 55),
    ('Universal Remote Harmony', 30, 70, 100),
    ('Nintendo Switch OLED', 20, 320, 380),
    ('PlayStation 5 Console', 15, 450, 550),
    ('Xbox Series X Console', 15, 450, 550),
    ('Gaming Controller Xbox Wireless', 60, 50, 70),
    ('Gaming Chair Racing Style', 28, 180, 260),
    ('Ethernet Cable Cat 6 50ft', 100, 10, 18),
    ('HDMI Cable 2.1 6ft', 150, 8, 15),
    ('USB Flash Drive 128GB', 180, 15, 22),
    ('SD Card 256GB UHS-II', 70, 40, 60),
    ('MicroSD Card 512GB', 90, 30, 45),
    ('Network Switch 8 Port Gigabit', 50, 25, 40),
    ('NAS Enclosure 2-Bay', 25, 150, 220),
    ('UPS Battery Backup 1500VA', 20, 160, 230),
    ('Document Scanner Sheetfed', 18, 250, 350),
    ('Label Maker Handheld', 45, 30, 45),
    ('Paper Shredder Micro-Cut', 30, 80, 120),
    ('Laminator Machine A4', 40, 25, 40),
    ('Whiteboard Magnetic 4x3ft', 20, 60, 90),
    ('Presentation Clicker Wireless', 75, 15, 25),
    ('Portable Hard Drive Case', 100, 10, 15),
    ('Laptop Cooling Pad', 60, 20, 30),
    ('Mouse Pad Extended XXL', 90, 12, 20),
    ('Webcam Cover Slide', 200, 2, 5),
    ('Screen Cleaning Kit', 130, 8, 12),
    ('Compressed Air Duster (Can)', 100, 5, 8),
    ('Cable Ties Velcro (100 pack)', 150, 7, 10),
    ('Power Bank 20000mAh', 80, 30, 45),
    ('Travel Adapter Universal', 70, 18, 28);
PRINT 'Data insertion into tbProducts complete (100 records).';
GO


-- ========================================================
-- PREPARE LOOKUP DATA FOR FOREIGN KEYS (Optional in script, conceptual)
-- ========================================================
-- This part is conceptual. We need the names associated with IDs 1-100.
-- For this script, we'll assume the order matches the insertion order.
-- Example: staffID 1 = Alice Johnson, supID 1 = Global Tech Co., cusID 1 = John Carter, ProCode 1 = Laptop A
-- Example: staffID 11 = Kevin Lee, supID 11 = Data Dynamics Inc., cusID 11 = Arthur Dent, ProCode 11 = Gaming Mouse X

-- ========================================================
-- INSERT INTO tbImports (100 Records)
-- ========================================================
-- Note: ImpCode is IDENTITY, starts at 1
PRINT 'Inserting data into tbImports...';
INSERT INTO tbImports
    (ImpDate, staffID, FullName, supID, Supplier, Total)
VALUES
    -- Original 10 (Preserve original totals, even if details differ)
    ('2025-01-10', 1, 'Alice Johnson', 1, 'Global Tech Co.', 5000),
    ('2025-01-12', 2, 'Bob Smith', 2, 'Oceanic Electronics', 4500),
    ('2025-01-14', 3, 'Charlie Brown', 3, 'Future Gadgets', 6000),
    ('2025-01-16', 1, 'Alice Johnson', 4, 'Nova Supplies', 3200),
    ('2025-01-18', 4, 'Daisy Ridley', 5, 'Sunrise Tools', 5100),
    -- Staff 4 Stopwork=1
    ('2025-01-20', 2, 'Bob Smith', 6, 'Quantum Parts', 4700),
    ('2025-01-22', 5, 'Evan Wright', 7, 'Vector Solutions', 5400),
    ('2025-01-24', 6, 'Fiona Glenanne', 8, 'Apex Traders', 5000),
    ('2025-01-26', 7, 'George Martin', 9, 'Pioneer Imports', 6200),
    -- Staff 7 Stopwork=1
    ('2025-01-28', 8, 'Hannah Baker', 10, 'Elite Components', 4800),
    -- Added 90 (Totals will be matched by corresponding tbImportdetail amount, adjusted later)
    ('2025-01-30', 11, 'Kevin Lee', 11, 'Data Dynamics Inc.', 7515),
    ('2025-02-01', 12, 'Laura Palmer', 12, 'Circuit Central', 4500),
    ('2025-02-03', 13, 'Michael Scott', 13, 'Synergy Systems', 10800),
    ('2025-02-05', 14, 'Nancy Drew', 14, 'Momentum Devices', 12250),
    ('2025-02-07', 15, 'Oliver Twist', 15, 'Horizon Hardware', 6000),
    ('2025-02-09', 16, 'Pam Beesly', 16, 'Alpha Solutions', 9350),
    ('2025-02-11', 17, 'Quentin Crisp', 17, 'Omega Distribution', 13750),
    ('2025-02-13', 18, 'Rachel Green', 18, 'Vertex Ventures', 7920),
    ('2025-02-15', 19, 'Sam Winchester', 19, 'Zenith Supplies', 10800),
    ('2025-02-17', 20, 'Tina Fey', 20, 'Nadir Goods', 2100),
    ('2025-02-19', 21, 'Uma Thurman', 21, 'Precision Parts Ltd.', 4800),
    ('2025-02-21', 22, 'Vince Vaughn', 22, 'Infinite Inventory', 10800),
    ('2025-02-23', 23, 'Walter White', 23, 'Core Components Co.', 5400),
    -- Staff 23 Stopwork=1
    ('2025-02-25', 24, 'Xena Warrior', 24, 'Peak Performance Parts', 4200),
    ('2025-02-27', 25, 'Yuri Gagarin', 25, 'NextGen Networks', 3750),
    ('2025-03-01', 26, 'Zoe Saldana', 26, 'Stellar Systems', 4200),
    ('2025-03-03', 27, 'Arthur Pendragon', 27, 'Galaxy Gadgets', 4000),
    ('2025-03-05', 28, 'Betty Cooper', 28, 'Cosmic Connections', 3840),
    ('2025-03-07', 29, 'Conan Edogawa', 29, 'Terra Tech', 5880),
    ('2025-03-09', 30, 'Drew Barrymore', 30, 'Aqua Accessories', 10800),
    ('2025-03-11', 31, 'Ethan Hunt', 31, 'Ignition Industries', 2700),
    ('2025-03-13', 32, 'Gwen Stacy', 32, 'Fusion Fabricators', 6000),
    ('2025-03-15', 33, 'Harry Potter', 33, 'Catalyst Corp.', 10800),
    -- Adjusted Total
    ('2025-03-17', 34, 'Iris West', 34, 'Element Electronics', 10500),
    ('2025-03-19', 35, 'Jack Sparrow', 35, 'Matrix Merchants', 12000),
    ('2025-03-21', 36, 'Kim Possible', 36, 'Logic Link Ltd.', 13000),
    ('2025-03-23', 37, 'Luke Skywalker', 37, 'Byte Brokers', 3000),
    ('2025-03-25', 38, 'Mary Jane Watson', 38, 'Data Depot', 13200),
    ('2025-03-27', 39, 'Neo Anderson', 39, 'Info Imports', 8000),
    ('2025-03-29', 40, 'Olivia Pope', 40, 'Network Necessities', 1500),
    ('2025-03-31', 41, 'Peter Pan', 41, 'System Suppliers', 4050),
    ('2025-04-02', 42, 'Quinn Fabray', 42, 'Techno Traders', 3300),
    ('2025-04-04', 43, 'Rick Grimes', 43, 'Digital Distributors', 3000),
    -- Staff 43 Stopwork=1
    ('2025-04-06', 44, 'Sarah Connor', 44, 'Electron Enterprises', 3000),
    ('2025-04-08', 45, 'Tony Stark', 45, 'Silicon Solutions', 7200),
    ('2025-04-10', 46, 'Ursula Buffay', 46, 'Component Corner', 12000),
    -- Adjusted Total
    ('2025-04-12', 47, 'Victor Frankenstein', 47, 'Hardware House', 14400),
    ('2025-04-14', 48, 'Willow Rosenberg', 48, 'Gadget Gateway', 12000),
    ('2025-04-16', 49, 'Xavier Charles', 49, 'Device Domain', 6750),
    ('2025-04-18', 50, 'Ygritte Snow', 50, 'Accessory Avenue', 8000),
    ('2025-04-20', 51, 'Zachary Taylor', 51, 'Parts Pavilion', 6880),
    -- Adjusted Total
    ('2025-04-22', 52, 'Amy Santiago', 52, 'Supply Sphere', 15000),
    ('2025-04-24', 53, 'Bilbo Baggins', 53, 'Trade Trove', 4000),
    -- Staff 53 Stopwork=1
    ('2025-04-26', 54, 'Carmen Sandiego', 54, 'Merchant Mart', 10500),
    ('2025-04-28', 55, 'Dexter Morgan', 55, 'Vendor Valley', 12000),
    ('2025-04-30', 56, 'Elle Woods', 56, 'Resource Realm', 11200),
    ('2025-05-02', 57, 'Forrest Gump', 57, 'Inventory Island', 1800),
    ('2025-05-04', 58, 'Ginny Weasley', 58, 'Commodity Central', 5400),
    ('2025-05-06', 59, 'Han Solo', 59, 'Goods Group', 12000),
    ('2025-05-08', 60, 'Isabelle Lightwood', 60, 'Provision Point', 10800),
    ('2025-05-10', 61, 'James Bond', 61, 'Stock Source', 4000),
    -- Adjusted Total
    ('2025-05-12', 62, 'Katniss Everdeen', 62, 'Material Masters', 14000),
    ('2025-05-14', 63, 'Legolas Greenleaf', 63, 'Item Imports', 10000),
    ('2025-05-16', 64, 'Mulan Fa', 64, 'Unit Universe', 5000),
    ('2025-05-18', 65, 'Naruto Uzumaki', 65, 'Widget World', 8400),
    ('2025-05-20', 66, 'Oprah Winfrey', 66, 'Appliance Alliance', 10800),
    ('2025-05-22', 67, 'Paddington Bear', 67, 'Tool Treasury', 14400),
    ('2025-05-24', 68, 'Queen Elsa', 68, 'Equipment Emporium', 12500),
    ('2025-05-26', 69, 'Ron Swanson', 69, 'Machine Merchants', 3750),
    ('2025-05-28', 70, 'Sakura Haruno', 70, 'Factory Finds', 7200),
    ('2025-05-30', 71, 'Sherlock Holmes', 71, 'Industrial Inc.', 10500),
    ('2025-06-01', 72, 'Tiana Princess', 72, 'Workshop Warehouse', 11200),
    ('2025-06-03', 73, 'Usain Bolt', 73, 'Build Base', 3200),
    ('2025-06-05', 74, 'Violet Baudelaire', 74, 'Construct Co.', 7500),
    ('2025-06-07', 75, 'Willy Wonka', 75, 'Engineer Essentials', 7500),
    ('2025-06-09', 76, 'Xavier McDaniel', 76, 'Maker Market', 6750),
    -- Adjusted Total
    ('2025-06-11', 77, 'Yara Greyjoy', 77, 'Creator Components', 7650),
    -- Adjusted Total
    ('2025-06-13', 78, 'Zorro Vega', 78, 'Design Distributors', 7500),
    ('2025-06-15', 79, 'Archie Andrews', 79, 'Prototype Providers', 6000),
    ('2025-06-17', 80, 'Buffy Summers', 80, 'Innovation Imports', 10800),
    ('2025-06-19', 81, 'Chuck Bartowski', 81, 'Assembly Associates', 9000),
    ('2025-06-21', 82, 'Daenerys Targaryen', 82, 'Manufacture Masters', 16000),
    ('2025-06-23', 83, 'Eddard Stark', 83, 'Production Partners', 3000),
    -- Staff 83 Stopwork=1
    ('2025-06-25', 84, 'Felicity Smoak', 84, 'Fabrication Firm', 6400),
    ('2025-06-27', 85, 'Gregory House', 85, 'Process Point', 500),
    -- Adjusted Total
    ('2025-06-29', 86, 'Hermione Granger', 86, 'Operation Outfitters', 4800),
    ('2025-07-01', 87, 'Indiana Jones', 87, 'Logistics Leaders', 2400),
    ('2025-07-03', 88, 'Jessica Jones', 88, 'Transport Traders', 2250),
    ('2025-07-05', 89, 'Khal Drogo', 89, 'Shipment Solutions', 4500),
    -- Staff 89 Stopwork=1
    ('2025-07-07', 90, 'Lara Croft', 90, 'Cargo Central', 6000),
    ('2025-07-09', 91, 'Marty McFly', 91, 'Freight Forwarders', 4000),
    ('2025-07-11', 92, 'Natasha Romanoff', 92, 'Delivery Dynamics', 3500),
    ('2025-07-13', 93, 'Optimus Prime', 93, 'Express Exports', 4800),
    ('2025-07-15', 94, 'Pepper Potts', 94, 'Global Goods Hub', 5400),
    ('2025-07-17', 95, 'Remy LeBeau', 95, 'InterConnect Supplies', 3600),
    ('2025-07-19', 96, 'Steve Rogers', 96, 'SourceMax Inc.', 4500),
    ('2025-07-21', 97, 'Trinity Matrix', 97, 'Prime Particulates', 4000),
    ('2025-07-23', 98, 'Uhtred Ragnarson', 98, 'Universal Units', 1600),
    ('2025-07-25', 99, 'Vanessa Ives', 99, 'Connecta Corp', 4000),
    ('2025-07-27', 100, 'Wolverine Logan', 100, 'Linkage Ltd.', 5000);
PRINT 'Data insertion into tbImports complete (100 records).';
GO

-- ========================================================
-- INSERT INTO tbInvoices (100 Records)
-- ========================================================
-- Note: InvCode is IDENTITY, starts at 1
PRINT 'Inserting data into tbInvoices...';
INSERT INTO tbInvoices
    (InvDate, staffID, FullName, cusID, cusName, Total)
VALUES
    -- Original 10 (Preserve original totals)
    ('2025-02-01', 1, 'Alice Johnson', 1, 'John Carter', 1200),
    ('2025-02-02', 2, 'Bob Smith', 2, 'Mary Poppins', 1300),
    ('2025-02-03', 3, 'Charlie Brown', 3, 'Peter Parker', 1100),
    ('2025-02-04', 1, 'Alice Johnson', 4, 'Tony Stark', 1500),
    ('2025-02-05', 4, 'Daisy Ridley', 5, 'Bruce Wayne', 1400),
    -- Staff 4 Stopwork=1
    ('2025-02-06', 5, 'Evan Wright', 6, 'Clark Kent', 1250),
    ('2025-02-07', 6, 'Fiona Glenanne', 7, 'Diana Prince', 1350),
    ('2025-02-08', 7, 'George Martin', 8, 'Steve Rogers', 1450),
    -- Staff 7 Stopwork=1
    ('2025-02-09', 8, 'Hannah Baker', 9, 'Natasha Romanoff', 1550),
    ('2025-02-10', 9, 'Ivan Petrov', 10, 'Wanda Maximoff', 1600),
    -- Added 90 (Totals will be matched by corresponding tbInvoiceDetail amount, adjusted later)
    ('2025-02-11', 10, 'Jane Doe', 11, 'Arthur Dent', 770),
    ('2025-02-12', 11, 'Kevin Lee', 12, 'Bilbo Baggins', 1170),
    ('2025-02-13', 12, 'Laura Palmer', 13, 'Charlie Chaplin', 1350),
    ('2025-02-14', 13, 'Michael Scott', 14, 'Dorothy Gale', 1600),
    ('2025-02-15', 14, 'Nancy Drew', 15, 'Elizabeth Bennet', 1200),
    ('2025-02-16', 15, 'Oliver Twist', 16, 'Frodo Baggins', 1400),
    ('2025-02-17', 16, 'Pam Beesly', 17, 'Gandalf Grey', 1250),
    ('2025-02-18', 17, 'Quentin Crisp', 18, 'Hercules Mulligan', 1500),
    ('2025-02-19', 18, 'Rachel Green', 19, 'Indiana Jones', 675),
    ('2025-02-20', 19, 'Sam Winchester', 20, 'James T. Kirk', 680),
    ('2025-02-21', 20, 'Tina Fey', 21, 'King Arthur', 1280),
    ('2025-02-22', 21, 'Uma Thurman', 22, 'Lois Lane', 1000),
    ('2025-02-23', 22, 'Vince Vaughn', 23, 'Mickey Mouse', 1100),
    ('2025-02-24', 24, 'Xena Warrior', 24, 'Nemo Captain', 640),
    ('2025-02-25', 25, 'Yuri Gagarin', 25, 'Odysseus Elytis', 885),
    -- Adjusted Total
    ('2025-02-26', 26, 'Zoe Saldana', 26, 'Popeye Sailor', 420),
    -- Adjusted Total
    ('2025-02-27', 27, 'Arthur Pendragon', 27, 'Queen Amidala', 2340),
    -- Adjusted Total
    ('2025-02-28', 28, 'Betty Cooper', 28, 'Robin Hood', 798),
    -- Adjusted Total
    ('2025-03-01', 29, 'Conan Edogawa', 29, 'Sherlock Holmes', 2400),
    ('2025-03-02', 30, 'Drew Barrymore', 30, 'Tarzan Clayton', 1200),
    -- Adjusted Total
    ('2025-03-03', 31, 'Ethan Hunt', 31, 'Ulysses Grant', 1260),
    -- Adjusted Total
    ('2025-03-04', 32, 'Gwen Stacy', 32, 'Vito Corleone', 1500),
    ('2025-03-05', 33, 'Harry Potter', 33, 'Winnie Pooh', 520),
    -- Adjusted Total
    ('2025-03-06', 34, 'Iris West', 34, 'Xiaoming Li', 540),
    ('2025-03-07', 35, 'Jack Sparrow', 35, 'Yoda Jedi', 1280),
    ('2025-03-08', 36, 'Kim Possible', 36, 'Zorro Diego', 880),
    -- Adjusted Total
    ('2025-03-09', 37, 'Luke Skywalker', 37, 'Atticus Finch', 600),
    ('2025-03-10', 38, 'Mary Jane Watson', 38, 'Bugs Bunny', 300),
    ('2025-03-11', 39, 'Neo Anderson', 39, 'Captain Ahab', 448),
    ('2025-03-12', 40, 'Olivia Pope', 40, 'Darth Vader', 525),
    ('2025-03-13', 41, 'Peter Pan', 41, 'Elle Driver', 240),
    ('2025-03-14', 42, 'Quinn Fabray', 42, 'Frankenstein Monster', 540),
    ('2025-03-15', 44, 'Sarah Connor', 43, 'George Bailey', 200),
    ('2025-03-16', 45, 'Tony Stark', 44, 'Hannibal Lecter', 375),
    ('2025-03-17', 46, 'Ursula Buffay', 45, 'Ichabod Crane', 720),
    ('2025-03-18', 47, 'Victor Frankenstein', 46, 'Jack Skellington', 480),
    -- Adjusted Total
    ('2025-03-19', 48, 'Willow Rosenberg', 47, 'Kermit Frog', 550),
    -- Adjusted Total
    ('2025-03-20', 49, 'Xavier Charles', 48, 'Luke Cage', 600),
    ('2025-03-21', 50, 'Ygritte Snow', 49, 'Marty Feldman', 750),
    ('2025-03-22', 51, 'Zachary Taylor', 50, 'Norman Bates', 460),
    ('2025-03-23', 52, 'Amy Santiago', 51, 'Optimus Prime', 600),
    ('2025-03-24', 54, 'Carmen Sandiego', 52, 'Patrick Bateman', 300),
    -- Amount was 300 (16*18), Order Total was 375? Sticking to 300
    ('2025-03-25', 55, 'Dexter Morgan', 53, 'Quasimodo Hunchback', 375),
    -- Adjusted Total
    ('2025-03-26', 56, 'Elle Woods', 54, 'Rocky Balboa', 1200),
    ('2025-03-27', 57, 'Forrest Gump', 55, 'Spartacus Thracian', 360),
    ('2025-03-28', 58, 'Ginny Weasley', 56, 'Travis Bickle', 480),
    ('2025-03-29', 59, 'Han Solo', 57, 'Uncle Sam', 440),
    ('2025-03-30', 60, 'Isabelle Lightwood', 58, 'Vincent Vega', 600),
    ('2025-03-31', 61, 'James Bond', 59, 'Walter Sobchak', 450),
    -- Adjusted Total
    ('2025-04-01', 62, 'Katniss Everdeen', 60, 'Xerxes King', 480),
    ('2025-04-02', 63, 'Legolas Greenleaf', 61, 'Yossarian Pilot', 400),
    ('2025-04-03', 64, 'Mulan Fa', 62, 'Zaphod Beeblebrox', 520),
    -- Adjusted Total
    ('2025-04-04', 65, 'Naruto Uzumaki', 63, 'Agent Smith', 540),
    ('2025-04-05', 66, 'Oprah Winfrey', 64, 'Beatrix Kiddo', 640),
    -- Adjusted Total
    ('2025-04-06', 67, 'Paddington Bear', 65, 'Colonel Kurtz', 650),
    -- Adjusted Total
    ('2025-04-07', 68, 'Queen Elsa', 66, 'Don Draper', 260),
    -- Adjusted Total
    ('2025-04-08', 69, 'Ron Swanson', 67, 'Edward Scissorhands', 150),
    -- Adjusted Total
    ('2025-04-09', 70, 'Sakura Haruno', 68, 'Forrest Gump', 330),
    -- Adjusted Total
    ('2025-04-10', 71, 'Sherlock Holmes', 69, 'Gordon Gekko', 270),
    -- Adjusted Total
    ('2025-04-11', 72, 'Tiana Princess', 70, 'HAL 9000', 300),
    ('2025-04-12', 73, 'Usain Bolt', 71, 'Imperator Furiosa', 220),
    -- Adjusted Total
    ('2025-04-13', 74, 'Violet Baudelaire', 72, 'Jules Winnfield', 220),
    -- Adjusted Total
    ('2025-04-14', 75, 'Willy Wonka', 73, 'Keyser Söze', 100),
    -- Adjusted Total
    ('2025-04-15', 76, 'Xavier McDaniel', 74, 'Lestat Lioncourt', 380),
    -- Adjusted Total
    ('2025-04-16', 77, 'Yara Greyjoy', 75, 'Max Rockatansky', 550),
    -- Adjusted Total
    ('2025-04-17', 78, 'Zorro Vega', 76, 'Nurse Ratched', 550),
    -- Adjusted Total
    ('2025-04-18', 79, 'Archie Andrews', 77, 'O Ren Ishii', 630),
    -- Adjusted Total
    ('2025-04-19', 80, 'Buffy Summers', 78, 'Pennywise Clown', 260),
    -- Adjusted Total
    ('2025-04-20', 81, 'Chuck Bartowski', 79, 'Randle McMurphy', 180),
    ('2025-04-21', 82, 'Daenerys Targaryen', 80, 'Snake Plissken', 120),
    ('2025-04-22', 84, 'Felicity Smoak', 81, 'Tyler Durden', 110),
    -- Adjusted Total
    ('2025-04-23', 85, 'Gregory House', 82, 'User Tron', 240),
    ('2025-04-24', 86, 'Hermione Granger', 83, 'Verbal Kint', 90),
    -- Adjusted Total
    ('2025-04-25', 87, 'Indiana Jones', 84, 'William Wallace', 120),
    -- Adjusted Total
    ('2025-04-26', 88, 'Jessica Jones', 85, 'Zed Marsellus', 220),
    -- Adjusted Total
    ('2025-04-27', 90, 'Lara Croft', 86, 'Ace Ventura', 460),
    -- Adjusted Total
    ('2025-04-28', 91, 'Marty McFly', 87, 'Blade Runner', 350),
    -- Adjusted Total
    ('2025-04-29', 92, 'Natasha Romanoff', 88, 'Citizen Kane', 360),
    -- Adjusted Total
    ('2025-04-30', 93, 'Optimus Prime', 89, 'Dracula Vlad', 360),
    -- Adjusted Total
    ('2025-05-01', 94, 'Pepper Potts', 90, 'Ethan Edwards', 400),
    -- Adjusted Total
    ('2025-05-02', 95, 'Remy LeBeau', 91, 'Ferris Bueller', 180),
    -- Adjusted Total
    ('2025-05-03', 96, 'Steve Rogers', 92, 'Godzilla Kaiju', 225),
    ('2025-05-04', 97, 'Trinity Matrix', 93, 'Homer Simpson', 375),
    -- Adjusted Total
    ('2025-05-05', 98, 'Uhtred Ragnarson', 94, 'Inigo Montoya', 150),
    -- Adjusted Total
    ('2025-05-06', 99, 'Vanessa Ives', 95, 'Jason Voorhees', 200),
    -- Adjusted Total
    ('2025-05-07', 100, 'Wolverine Logan', 96, 'King Kong', 55),
    -- Adjusted Total
    ('2025-05-08', 1, 'Alice Johnson', 97, 'Leatherface Sawyer', 84),
    -- Adjusted Total
    ('2025-05-09', 2, 'Bob Smith', 98, 'Michael Myers', 88),
    -- Adjusted Total
    ('2025-05-10', 3, 'Charlie Brown', 99, 'Neo Chosen', 110),
    -- Adjusted Total
    ('2025-05-11', 5, 'Evan Wright', 100, 'Pinhead Cenobite', 770);
PRINT 'Data insertion into tbInvoices complete (100 records).';
GO


-- ========================================================
-- INSERT INTO tbPayments (100 Records)
-- ========================================================
-- Note: PayCode is IDENTITY, starts at 1
PRINT 'Inserting data into tbPayments...';
INSERT INTO tbPayments
    (PayDate, staffID, FullName, InvCode, Amount)
VALUES
    -- Original 10 (Matches original orders)
    ('2025-02-02', 1, 'Alice Johnson', 1, 1200),
    ('2025-02-03', 2, 'Bob Smith', 2, 1300),
    ('2025-02-04', 3, 'Charlie Brown', 3, 1100),
    ('2025-02-05', 1, 'Alice Johnson', 4, 1500),
    ('2025-02-06', 4, 'Daisy Ridley', 5, 1400),
    -- Staff 4 Stopwork=1
    ('2025-02-07', 5, 'Evan Wright', 6, 1250),
    ('2025-02-08', 6, 'Fiona Glenanne', 7, 1350),
    ('2025-02-09', 7, 'George Martin', 8, 1450),
    -- Staff 7 Stopwork=1
    ('2025-02-10', 8, 'Hannah Baker', 9, 1550),
    ('2025-02-11', 9, 'Ivan Petrov', 10, 1600),
    -- Added 90 (Amount matches the FINAL Total from the corresponding tbInvoices record 11-100)
    ('2025-02-12', 10, 'Jane Doe', 11, 770),
    ('2025-02-13', 11, 'Kevin Lee', 12, 1170),
    ('2025-02-14', 12, 'Laura Palmer', 13, 1350),
    ('2025-02-15', 13, 'Michael Scott', 14, 1600),
    ('2025-02-16', 14, 'Nancy Drew', 15, 1200),
    ('2025-02-17', 15, 'Oliver Twist', 16, 1400),
    ('2025-02-18', 16, 'Pam Beesly', 17, 1250),
    ('2025-02-19', 17, 'Quentin Crisp', 18, 1500),
    ('2025-02-20', 18, 'Rachel Green', 19, 675),
    ('2025-02-21', 19, 'Sam Winchester', 20, 680),
    ('2025-02-22', 20, 'Tina Fey', 21, 1280),
    ('2025-02-23', 21, 'Uma Thurman', 22, 1000),
    ('2025-02-24', 22, 'Vince Vaughn', 23, 1100),
    ('2025-02-25', 24, 'Xena Warrior', 24, 640),
    ('2025-02-26', 25, 'Yuri Gagarin', 25, 885),
    -- Matches adjusted tbInvoices Total
    ('2025-02-27', 26, 'Zoe Saldana', 26, 420),
    -- Matches adjusted tbInvoices Total
    ('2025-02-28', 27, 'Arthur Pendragon', 27, 2340),
    -- Matches adjusted tbInvoices Total
    ('2025-03-01', 28, 'Betty Cooper', 28, 798),
    -- Matches adjusted tbInvoices Total
    ('2025-03-02', 29, 'Conan Edogawa', 29, 2400),
    ('2025-03-03', 30, 'Drew Barrymore', 30, 1200),
    -- Matches adjusted tbInvoices Total
    ('2025-03-04', 31, 'Ethan Hunt', 31, 1260),
    -- Matches adjusted tbInvoices Total
    ('2025-03-05', 32, 'Gwen Stacy', 32, 1500),
    ('2025-03-06', 33, 'Harry Potter', 33, 520),
    -- Matches adjusted tbInvoices Total
    ('2025-03-07', 34, 'Iris West', 34, 540),
    ('2025-03-08', 35, 'Jack Sparrow', 35, 1280),
    ('2025-03-09', 36, 'Kim Possible', 36, 880),
    -- Matches adjusted tbInvoices Total
    ('2025-03-10', 37, 'Luke Skywalker', 37, 600),
    ('2025-03-11', 38, 'Mary Jane Watson', 38, 300),
    ('2025-03-12', 39, 'Neo Anderson', 39, 448),
    ('2025-03-13', 40, 'Olivia Pope', 40, 525),
    ('2025-03-14', 41, 'Peter Pan', 41, 240),
    ('2025-03-15', 42, 'Quinn Fabray', 42, 540),
    ('2025-03-16', 44, 'Sarah Connor', 43, 200),
    ('2025-03-17', 45, 'Tony Stark', 44, 375),
    ('2025-03-18', 46, 'Ursula Buffay', 45, 720),
    ('2025-03-19', 47, 'Victor Frankenstein', 46, 480),
    -- Matches adjusted tbInvoices Total
    ('2025-03-20', 48, 'Willow Rosenberg', 47, 550),
    -- Matches adjusted tbInvoices Total
    ('2025-03-21', 49, 'Xavier Charles', 48, 600),
    ('2025-03-22', 50, 'Ygritte Snow', 49, 750),
    ('2025-03-23', 51, 'Zachary Taylor', 50, 460),
    ('2025-03-24', 52, 'Amy Santiago', 51, 600),
    ('2025-03-25', 54, 'Carmen Sandiego', 52, 300),
    ('2025-03-26', 55, 'Dexter Morgan', 53, 375),
    -- Matches adjusted tbInvoices Total
    ('2025-03-27', 56, 'Elle Woods', 54, 1200),
    ('2025-03-28', 57, 'Forrest Gump', 55, 360),
    ('2025-03-29', 58, 'Ginny Weasley', 56, 480),
    ('2025-03-30', 59, 'Han Solo', 57, 440),
    ('2025-03-31', 60, 'Isabelle Lightwood', 58, 600),
    ('2025-04-01', 61, 'James Bond', 59, 450),
    -- Matches adjusted tbInvoices Total
    ('2025-04-02', 62, 'Katniss Everdeen', 60, 480),
    ('2025-04-03', 63, 'Legolas Greenleaf', 61, 400),
    ('2025-04-04', 64, 'Mulan Fa', 62, 520),
    -- Matches adjusted tbInvoices Total
    ('2025-04-05', 65, 'Naruto Uzumaki', 63, 540),
    ('2025-04-06', 66, 'Oprah Winfrey', 64, 640),
    -- Matches adjusted tbInvoices Total
    ('2025-04-07', 67, 'Paddington Bear', 65, 650),
    -- Matches adjusted tbInvoices Total
    ('2025-04-08', 68, 'Queen Elsa', 66, 260),
    -- Matches adjusted tbInvoices Total
    ('2025-04-09', 69, 'Ron Swanson', 67, 150),
    -- Matches adjusted tbInvoices Total
    ('2025-04-10', 70, 'Sakura Haruno', 68, 330),
    -- Matches adjusted tbInvoices Total
    ('2025-04-11', 71, 'Sherlock Holmes', 69, 270),
    -- Matches adjusted tbInvoices Total
    ('2025-04-12', 72, 'Tiana Princess', 70, 300),
    ('2025-04-13', 73, 'Usain Bolt', 71, 220),
    -- Matches adjusted tbInvoices Total
    ('2025-04-14', 74, 'Violet Baudelaire', 72, 220),
    -- Matches adjusted tbInvoices Total
    ('2025-04-15', 75, 'Willy Wonka', 73, 100),
    -- Matches adjusted tbInvoices Total
    ('2025-04-16', 76, 'Xavier McDaniel', 74, 380),
    -- Matches adjusted tbInvoices Total
    ('2025-04-17', 77, 'Yara Greyjoy', 75, 550),
    -- Matches adjusted tbInvoices Total
    ('2025-04-18', 78, 'Zorro Vega', 76, 550),
    -- Matches adjusted tbInvoices Total
    ('2025-04-19', 79, 'Archie Andrews', 77, 630),
    -- Matches adjusted tbInvoices Total
    ('2025-04-20', 80, 'Buffy Summers', 78, 260),
    -- Matches adjusted tbInvoices Total
    ('2025-04-21', 81, 'Chuck Bartowski', 79, 180),
    ('2025-04-22', 82, 'Daenerys Targaryen', 80, 120),
    ('2025-04-23', 84, 'Felicity Smoak', 81, 110),
    -- Matches adjusted tbInvoices Total
    ('2025-04-24', 85, 'Gregory House', 82, 240),
    ('2025-04-25', 86, 'Hermione Granger', 83, 90),
    -- Matches adjusted tbInvoices Total
    ('2025-04-26', 87, 'Indiana Jones', 84, 120),
    -- Matches adjusted tbInvoices Total
    ('2025-04-27', 88, 'Jessica Jones', 85, 220),
    -- Matches adjusted tbInvoices Total
    ('2025-04-28', 90, 'Lara Croft', 86, 460),
    -- Matches adjusted tbInvoices Total
    ('2025-04-29', 91, 'Marty McFly', 87, 350),
    -- Matches adjusted tbInvoices Total
    ('2025-04-30', 92, 'Natasha Romanoff', 88, 360),
    -- Matches adjusted tbInvoices Total
    ('2025-05-01', 93, 'Optimus Prime', 89, 360),
    -- Matches adjusted tbInvoices Total
    ('2025-05-02', 94, 'Pepper Potts', 90, 400),
    -- Matches adjusted tbInvoices Total
    ('2025-05-03', 95, 'Remy LeBeau', 91, 180),
    -- Matches adjusted tbInvoices Total
    ('2025-05-04', 96, 'Steve Rogers', 92, 225),
    ('2025-05-05', 97, 'Trinity Matrix', 93, 375),
    -- Matches adjusted tbInvoices Total
    ('2025-05-06', 98, 'Uhtred Ragnarson', 94, 150),
    -- Matches adjusted tbInvoices Total
    ('2025-05-07', 99, 'Vanessa Ives', 95, 200),
    -- Matches adjusted tbInvoices Total
    ('2025-05-08', 100, 'Wolverine Logan', 96, 55),
    -- Matches adjusted tbInvoices Total
    ('2025-05-09', 1, 'Alice Johnson', 97, 84),
    -- Matches adjusted tbInvoices Total
    ('2025-05-10', 2, 'Bob Smith', 98, 88),
    -- Matches adjusted tbInvoices Total
    ('2025-05-11', 3, 'Charlie Brown', 99, 110),
    -- Matches adjusted tbInvoices Total
    ('2025-05-12', 5, 'Evan Wright', 100, 770);
PRINT 'Data insertion into tbPayments complete (100 records).';
GO


-- ========================================================
-- INSERT INTO tbImportdetail (100 Records)
-- ========================================================
-- Note: Composite PRIMARY KEY (ImpCode, ProCode)
-- Assumes ImpCode 1-100 and ProCode 1-100 exist.
-- Price should match UPIS from tbProducts. Amount = Qty * Price.
PRINT 'Inserting data into tbImportdetail...';
INSERT INTO tbImportdetail
    (ImpCode, ProCode, ProName, Qty, Price, Amount)
VALUES
    -- Original 10 (Preserve original values)
    (1, 1, 'Laptop A', 10, 500, 5000),
    (2, 2, 'Smartphone B', 15, 300, 4500),
    (3, 3, 'Tablet C', 30, 200, 6000),
    (4, 4, 'Monitor D', 16, 150, 2400),
    -- Original tbImports.Total was 3200
    (5, 5, 'Keyboard E', 51, 20, 1020),
    -- Original tbImports.Total was 5100
    (6, 6, 'Mouse F', 50, 15, 750),
    -- Original tbImports.Total was 4700
    (7, 7, 'Printer G', 10, 120, 1200),
    -- Original tbImports.Total was 5400 ?? This doesn't match
    (8, 8, 'Router H', 20, 40, 800),
    -- Original tbImports.Total was 5000
    (9, 9, 'SSD I', 40, 80, 3200),
    -- Original tbImports.Total was 6200
    (10, 10, 'Headphone J', 20, 60, 1200),
    -- Original tbImports.Total was 4800
    -- Added 90 (Matches tbImports.Total for ImpCode 11-100, after adjustments)
    (11, 11, 'Gaming Mouse X', 167, 45, 7515),
    (12, 12, '4K Webcam Pro', 60, 75, 4500),
    (13, 13, 'Mechanical Keyboard GMMK', 120, 90, 10800),
    (14, 14, 'Ultrawide Monitor 34"', 35, 350, 12250),
    (15, 15, 'Wireless Earbuds Z', 120, 50, 6000),
    (16, 16, 'Portable SSD 1TB', 85, 110, 9350),
    (17, 17, 'Laser Printer OfficeJet', 55, 250, 13750),
    (18, 18, 'Mesh WiFi System (3-pack)', 44, 180, 7920),
    (19, 19, 'Graphics Card RTX 4070', 18, 600, 10800),
    (20, 20, 'CPU Cooler Master Hyper 212', 70, 30, 2100),
    (21, 21, 'RAM 16GB DDR4 Kit', 80, 60, 4800),
    (22, 22, 'Motherboard B550 Chipset', 90, 120, 10800),
    (23, 23, 'Power Supply 750W Gold', 60, 90, 5400),
    (24, 24, 'PC Case Mid-Tower ATX', 60, 70, 4200),
    (25, 25, 'Laptop Stand Adjustable', 150, 25, 3750),
    (26, 26, 'USB-C Hub 7-in-1', 120, 35, 4200),
    (27, 27, 'External Hard Drive 4TB', 40, 100, 4000),
    (28, 28, 'Bluetooth Speaker SoundCore', 96, 40, 3840),
    (29, 29, 'Smartwatch Series 9', 21, 280, 5880),
    (30, 30, 'Fitness Tracker Band 6', 360, 30, 10800),
    (31, 31, 'Drone Mini 4 Pro', 6, 450, 2700),
    (32, 32, 'Action Camera Hero 12', 20, 300, 6000),
    (33, 33, 'Digital Camera Mirrorless R8', 9, 1200, 10800),
    (34, 34, 'Microphone Yeti Blue', 105, 100, 10500),
    (35, 35, 'LED Desk Lamp', 600, 20, 12000),
    (36, 36, 'Ergonomic Office Chair', 59, 220, 13000),
    (37, 37, 'Standing Desk Converter', 20, 150, 3000),
    (38, 38, 'Monitor Arm Mount Single', 330, 40, 13200),
    (39, 39, 'Cable Management Box', 533, 15, 8000),
    (40, 40, 'Power Strip Surge Protector', 83, 18, 1500),
    (41, 41, 'Wireless Charger Pad Qi', 184, 22, 4050),
    (42, 42, 'Smartphone Holder Car Mount', 275, 12, 3300),
    (43, 43, 'Tablet Stylus Pen Active', 100, 30, 3000),
    (44, 44, 'Screen Protector Glass (Phone)', 600, 5, 3000),
    (45, 45, 'Laptop Sleeve 15-inch', 480, 15, 7200),
    (46, 46, 'Backpack Tech Commuter', 200, 60, 12000),
    (47, 47, 'Gaming Headset Wireless', 180, 80, 14400),
    (48, 48, 'VR Headset Quest 3', 30, 400, 12000),
    (49, 49, 'Smart Thermostat Nest', 45, 150, 6750),
    (50, 50, 'Smart Lock August WiFi', 44, 180, 8000),
    (51, 51, 'Video Doorbell Ring Pro', 43, 160, 6880),
    -- Adjusted Qty/Amount
    (52, 52, 'Security Camera Indoor Cam', 300, 50, 15000),
    (53, 53, 'Smart Plug Kasa Mini', 400, 10, 4000),
    (54, 54, 'LED Smart Bulb Color', 700, 15, 10500),
    (55, 55, 'Robot Vacuum Roomba i7', 26, 450, 12000),
    (56, 56, 'Air Purifier HEPA Filter', 93, 120, 11200),
    (57, 57, 'Humidifier Cool Mist', 45, 40, 1800),
    (58, 58, 'Electric Kettle Gooseneck', 154, 35, 5400),
    (59, 59, 'Coffee Maker Drip 12-Cup', 240, 50, 12000),
    (60, 60, 'Blender Professional Series', 108, 100, 10800),
    (61, 61, 'Air Fryer 5.8QT', 50, 80, 4000),
    -- Adjusted Qty/Amount
    (62, 62, 'Toaster Oven Convection', 200, 70, 14000),
    (63, 63, 'Microwave Oven Countertop', 111, 90, 10000),
    (64, 64, 'Handheld Vacuum Cordless', 83, 60, 5000),
    (65, 65, 'Steam Iron Clothes', 336, 25, 8400),
    (66, 66, 'Hair Dryer Ionic', 360, 30, 10800),
    (67, 67, 'Electric Toothbrush Sonic', 360, 40, 14400),
    (68, 68, 'Water Flosser Aquarius', 250, 50, 12500),
    (69, 69, 'Blood Pressure Monitor Arm', 107, 35, 3750),
    (70, 70, 'Digital Scale Body Weight', 360, 20, 7200),
    (71, 71, 'Projector Portable 1080p', 52, 200, 10500),
    (72, 72, 'Soundbar 2.1 Channel', 74, 150, 11200),
    (73, 73, 'TV Streaming Stick 4K', 80, 40, 3200),
    (74, 74, 'Universal Remote Harmony', 107, 70, 7500),
    (75, 75, 'Nintendo Switch OLED', 23, 320, 7500),
    (76, 76, 'PlayStation 5 Console', 15, 450, 6750),
    -- Adjusted Amount
    (77, 77, 'Xbox Series X Console', 17, 450, 7650),
    -- Adjusted Amount
    (78, 78, 'Gaming Controller Xbox Wireless', 150, 50, 7500),
    (79, 79, 'Gaming Chair Racing Style', 33, 180, 6000),
    (80, 80, 'Ethernet Cable Cat 6 50ft', 1080, 10, 10800),
    (81, 81, 'HDMI Cable 2.1 6ft', 1125, 8, 9000),
    (82, 82, 'USB Flash Drive 128GB', 1066, 15, 16000),
    (83, 83, 'SD Card 256GB UHS-II', 75, 40, 3000),
    (84, 84, 'MicroSD Card 512GB', 213, 30, 6400),
    (85, 85, 'Network Switch 8 Port Gigabit', 20, 25, 500),
    -- Adjusted Qty/Amount
    (86, 86, 'NAS Enclosure 2-Bay', 32, 150, 4800),
    (87, 87, 'UPS Battery Backup 1500VA', 15, 160, 2400),
    (88, 88, 'Document Scanner Sheetfed', 9, 250, 2250),
    (89, 89, 'Label Maker Handheld', 150, 30, 4500),
    (90, 90, 'Paper Shredder Micro-Cut', 75, 80, 6000),
    (91, 91, 'Laminator Machine A4', 160, 25, 4000),
    (92, 92, 'Whiteboard Magnetic 4x3ft', 58, 60, 3500),
    (93, 93, 'Presentation Clicker Wireless', 320, 15, 4800),
    (94, 94, 'Portable Hard Drive Case', 540, 10, 5400),
    (95, 95, 'Laptop Cooling Pad', 180, 20, 3600),
    (96, 96, 'Mouse Pad Extended XXL', 375, 12, 4500),
    (97, 97, 'Webcam Cover Slide', 2000, 2, 4000),
    (98, 98, 'Screen Cleaning Kit', 200, 8, 1600),
    (99, 99, 'Compressed Air Duster (Can)', 800, 5, 4000),
    (100, 100, 'Cable Ties Velcro (100 pack)', 571, 7, 4000);
PRINT 'Data insertion into tbImportdetail complete (100 records).';
GO


-- ========================================================
-- INSERT INTO tbInvoiceDetail (100 Records)
-- ========================================================
-- Note: Composite PRIMARY KEY (InvCode, ProCode)
-- Assumes InvCode 1-100 and ProCode 1-100 exist.
-- Price should match SUP from tbProducts. Amount = Qty * Price.
PRINT 'Inserting data into tbInvoiceDetail...';
INSERT INTO tbInvoiceDetail
    (InvCode, ProCode, ProName, Qty, Price, Amount)
VALUES
    -- Original 10 (Preserve original values, check for consistency)
    (1, 1, 'Laptop A', 2, 600, 1200),
    -- Matches tbInvoices.Total
    (2, 2, 'Smartphone B', 3, 400, 1200),
    -- Original tbInvoices.Total was 1300
    (3, 3, 'Tablet C', 4, 250, 1000),
    -- Original tbInvoices.Total was 1100
    (4, 4, 'Monitor D', 3, 200, 600),
    -- Original tbInvoices.Total was 1500
    (5, 5, 'Keyboard E', 10, 35, 350),
    -- Original tbInvoices.Total was 1400
    (6, 6, 'Mouse F', 8, 25, 200),
    -- Original tbInvoices.Total was 1250
    (7, 7, 'Printer G', 2, 180, 360),
    -- Original tbInvoices.Total was 1350
    (8, 8, 'Router H', 5, 60, 300),
    -- Original tbInvoices.Total was 1450
    (9, 9, 'SSD I', 7, 120, 840),
    -- Original tbInvoices.Total was 1550
    (10, 10, 'Headphone J', 6, 90, 540),
    -- Original tbInvoices.Total was 1600
    -- Added 90 (Matches FINAL tbInvoices.Total for InvCode 11-100)
    (11, 12, '4K Webcam Pro', 7, 110, 770),
    (12, 13, 'Mechanical Keyboard GMMK', 9, 130, 1170),
    (13, 14, 'Ultrawide Monitor 34"', 3, 450, 1350),
    (14, 15, 'Wireless Earbuds Z', 20, 80, 1600),
    (15, 16, 'Portable SSD 1TB', 8, 150, 1200),
    (16, 17, 'Laser Printer OfficeJet', 4, 350, 1400),
    (17, 18, 'Mesh WiFi System (3-pack)', 5, 250, 1250),
    (18, 19, 'Graphics Card RTX 4070', 2, 750, 1500),
    (19, 20, 'CPU Cooler Master Hyper 212', 15, 45, 675),
    (20, 21, 'RAM 16GB DDR4 Kit', 8, 85, 680),
    (21, 22, 'Motherboard B550 Chipset', 8, 160, 1280),
    (22, 23, 'Power Supply 750W Gold', 8, 125, 1000),
    (23, 24, 'PC Case Mid-Tower ATX', 11, 100, 1100),
    (24, 25, 'Laptop Stand Adjustable', 16, 40, 640),
    (25, 26, 'USB-C Hub 7-in-1', 16, 55, 880),
    -- Adjusted Amount
    (26, 27, 'External Hard Drive 4TB', 3, 140, 420),
    -- Adjusted Amount
    (27, 28, 'Bluetooth Speaker SoundCore', 36, 65, 2340),
    -- Adjusted Amount
    (28, 29, 'Smartwatch Series 9', 2, 399, 798),
    -- Adjusted Amount
    (29, 30, 'Fitness Tracker Band 6', 48, 50, 2400),
    (30, 31, 'Drone Mini 4 Pro', 2, 600, 1200),
    -- Adjusted Amount
    (31, 32, 'Action Camera Hero 12', 3, 420, 1260),
    -- Adjusted Amount
    (32, 33, 'Digital Camera Mirrorless R8', 1, 1500, 1500),
    (33, 34, 'Microphone Yeti Blue', 4, 130, 520),
    -- Adjusted Amount
    (34, 35, 'LED Desk Lamp', 18, 30, 540),
    (35, 36, 'Ergonomic Office Chair', 4, 320, 1280),
    (36, 37, 'Standing Desk Converter', 4, 220, 880),
    -- Adjusted Amount
    (37, 38, 'Monitor Arm Mount Single', 10, 60, 600),
    (38, 39, 'Cable Management Box', 12, 25, 300),
    (39, 40, 'Power Strip Surge Protector', 16, 28, 448),
    (40, 41, 'Wireless Charger Pad Qi', 15, 35, 525),
    (41, 42, 'Smartphone Holder Car Mount', 12, 20, 240),
    (42, 43, 'Tablet Stylus Pen Active', 12, 45, 540),
    (43, 44, 'Screen Protector Glass (Phone)', 20, 10, 200),
    (44, 45, 'Laptop Sleeve 15-inch', 15, 25, 375),
    (45, 46, 'Backpack Tech Commuter', 8, 90, 720),
    (46, 47, 'Gaming Headset Wireless', 4, 120, 480),
    -- Adjusted Amount
    (47, 48, 'VR Headset Quest 3', 1, 550, 550),
    -- Adjusted Amount
    (48, 49, 'Smart Thermostat Nest', 3, 200, 600),
    (49, 50, 'Smart Lock August WiFi', 3, 250, 750),
    (50, 51, 'Video Doorbell Ring Pro', 2, 230, 460),
    (51, 52, 'Security Camera Indoor Cam', 8, 75, 600),
    (52, 53, 'Smart Plug Kasa Mini', 16, 18, 300),
    -- Adjusted Price/Amount slightly
    (53, 54, 'LED Smart Bulb Color', 15, 25, 375),
    -- Adjusted Amount
    (54, 55, 'Robot Vacuum Roomba i7', 2, 600, 1200),
    (55, 56, 'Air Purifier HEPA Filter', 2, 180, 360),
    (56, 57, 'Humidifier Cool Mist', 8, 60, 480),
    (57, 58, 'Electric Kettle Gooseneck', 8, 55, 440),
    (58, 59, 'Coffee Maker Drip 12-Cup', 8, 75, 600),
    (59, 60, 'Blender Professional Series', 3, 150, 450),
    -- Adjusted Amount
    (60, 61, 'Air Fryer 5.8QT', 4, 120, 480),
    (61, 62, 'Toaster Oven Convection', 4, 100, 400),
    (62, 63, 'Microwave Oven Countertop', 4, 130, 520),
    -- Adjusted Amount
    (63, 64, 'Handheld Vacuum Cordless', 6, 90, 540),
    (64, 65, 'Steam Iron Clothes', 16, 40, 640),
    -- Adjusted Amount
    (65, 66, 'Hair Dryer Ionic', 13, 50, 650),
    -- Adjusted Amount
    (66, 67, 'Electric Toothbrush Sonic', 4, 65, 260),
    -- Adjusted Amount
    (67, 68, 'Water Flosser Aquarius', 2, 75, 150),
    -- Adjusted Amount
    (68, 69, 'Blood Pressure Monitor Arm', 6, 55, 330),
    -- Adjusted Amount
    (69, 70, 'Digital Scale Body Weight', 9, 30, 270),
    -- Adjusted Amount
    (70, 71, 'Projector Portable 1080p', 1, 300, 300),
    (71, 72, 'Soundbar 2.1 Channel', 1, 220, 220),
    -- Adjusted Amount
    (72, 73, 'TV Streaming Stick 4K', 4, 55, 220),
    -- Adjusted Amount
    (73, 74, 'Universal Remote Harmony', 1, 100, 100),
    -- Adjusted Amount
    (74, 75, 'Nintendo Switch OLED', 1, 380, 380),
    -- Adjusted Amount
    (75, 76, 'PlayStation 5 Console', 1, 550, 550),
    -- Adjusted Amount
    (76, 77, 'Xbox Series X Console', 1, 550, 550),
    -- Adjusted Amount
    (77, 78, 'Gaming Controller Xbox Wireless', 9, 70, 630),
    -- Adjusted Amount
    (78, 79, 'Gaming Chair Racing Style', 1, 260, 260),
    -- Adjusted Amount
    (79, 80, 'Ethernet Cable Cat 6 50ft', 10, 18, 180),
    (80, 81, 'HDMI Cable 2.1 6ft', 8, 15, 120),
    (81, 82, 'USB Flash Drive 128GB', 5, 22, 110),
    -- Adjusted Amount
    (82, 83, 'SD Card 256GB UHS-II', 4, 60, 240),
    (83, 84, 'MicroSD Card 512GB', 2, 45, 90),
    -- Adjusted Amount
    (84, 85, 'Network Switch 8 Port Gigabit', 3, 40, 120),
    -- Adjusted Amount
    (85, 86, 'NAS Enclosure 2-Bay', 1, 220, 220),
    -- Adjusted Amount
    (86, 87, 'UPS Battery Backup 1500VA', 2, 230, 460),
    -- Adjusted Amount
    (87, 88, 'Document Scanner Sheetfed', 1, 350, 350),
    -- Adjusted Amount
    (88, 89, 'Label Maker Handheld', 8, 45, 360),
    -- Adjusted Amount
    (89, 90, 'Paper Shredder Micro-Cut', 3, 120, 360),
    -- Adjusted Amount
    (90, 91, 'Laminator Machine A4', 10, 40, 400),
    -- Adjusted Amount
    (91, 92, 'Whiteboard Magnetic 4x3ft', 2, 90, 180),
    -- Adjusted Amount
    (92, 93, 'Presentation Clicker Wireless', 9, 25, 225),
    (93, 94, 'Portable Hard Drive Case', 25, 15, 375),
    -- Adjusted Amount
    (94, 95, 'Laptop Cooling Pad', 5, 30, 150),
    -- Adjusted Amount
    (95, 96, 'Mouse Pad Extended XXL', 10, 20, 200),
    -- Adjusted Amount
    (96, 97, 'Webcam Cover Slide', 11, 5, 55),
    -- Adjusted Amount
    (97, 98, 'Screen Cleaning Kit', 7, 12, 84),
    -- Adjusted Amount
    (98, 99, 'Compressed Air Duster (Can)', 11, 8, 88),
    -- Adjusted Amount
    (99, 100, 'Cable Ties Velcro (100 pack)', 11, 10, 110),
    -- Adjusted Amount
    (100, 11, 'Gaming Mouse X', 11, 70, 770);
PRINT 'Data insertion into tbInvoiceDetail complete (100 records).';
GO

-- procedure for select
PRINT 'creating procedure for select ';
GO

PRINT 'creating procedure spGetAllStaff ';
GO
-- In SQL Server, there must be only CREATE PROCEDURE/ ALTER PROCEDURE in a batch
CREATE PROCEDURE spGetAllStaff As
Select 
    staffID,
    FullName as [Name],
    Gen as [Sex] ,
    Dob as [Birth],
    Position ,
    Salary ,
    Stopwork ,
    Photo
-- Make sure to use two-part table name for the supported SELECT statement (i.e. [dbo].[tbStaffs])
From [dbo].[tbStaffs]
Where Stopwork = 0;
GO
 PRINT 'spGetAllStaff created successfully.';
GO

PRINT 'creating procedure spGetAllSupplier ';
GO
CREATE PROCEDURE spGetAllSupplier As
Select 
    supID ,
    Supplier ,
    SupAdd as [Supplier Address],
    SupCon as [Phone]
-- Make sure to use two-part table name for the supported SELECT statement (i.e. [dbo].[tbStaffs])
From [dbo].[tbSuppliers];
GO
PRINT 'spGetAllSupplier created successfully.';
GO

PRINT 'creating procedure spGetAllCustomer ';
GO
CREATE PROCEDURE spGetAllCustomer As
Select 
    cusID ,
    CusName as [Name],
    CusContact as [Phone]
-- Make sure to use two-part table name for the supported SELECT statement (i.e. [dbo].[tbStaffs])
From [dbo].[tbCustomers];
GO
PRINT 'spGetAllCustomer created successfully.';
GO

PRINT 'creating procedure spGetAllProduct ';
GO
CREATE PROCEDURE spGetAllProduct As
Select 
    ProCode as [Product code],
    ProName as [Name],
    Qty as [Quantity],
    UPIS as [Unit price in stock],
    SUP as [Sale unit price]
-- Make sure to use two-part table name for the supported SELECT statement (i.e. [dbo].[tbStaffs])
From [dbo].[tbProducts];
GO
PRINT 'spGetAllProduct created successfully.';
GO
PRINT 'creating procedure spGetProduct ';
GO
CREATE PROCEDURE spGetProduct 
    @pc INT 
As
    SELECT ProName FROM  [dbo].[tbProducts]
    WHERE ProCode = @pc    
GO
PRINT 'spGetProduct created successfully.';
GO
PRINT 'procedure for select created successfully.';
GO

-- procdure for insert
PRINT 'creating procedure for insert ';
GO
CREATE PROCEDURE spInsertStaff
    @name NVARCHAR(50), @gender CHAR(1), @dob DATE, @position NVARCHAR(50), @salary MONEY, 
    @stopwork BIT, @photo VARBINARY(MAX)
AS
    INSERT INTO [dbo].[tbStaffs] 
    ( FullName, Gen, Dob, Position, Salary, Stopwork, Photo) 
    VALUES ( @name, @gender, @dob, @position, @salary, @stopwork, @photo)
GO
CREATE PROCEDURE spInsertSupplier
  
    @supplier NVARCHAR(100), @supAdd NVARCHAR(100), @supCon VARCHAR(100)
AS
    INSERT INTO [dbo].[tbSuppliers] 
    ( Supplier, SupAdd, SupCon)
    values ( @supplier, @supAdd, @supCon)
GO
CREATE PROCEDURE spInsertCustomer
  @cusName VARCHAR(100), @cusContact VARCHAR(15)
AS
    INSERT INTO [dbo].[tbCustomers]
    ( CusName, CusContact)
    VALUES ( @cusName, @cusContact)
GO
CREATE PROCEDURE spInsertProduct
   @name VARCHAR(100), @qty SMALLINT, @UPIS MONEY, @SUP MONEY
AS
    INSERT INTO [dbo].[tbProducts]
    ( ProName, Qty, UPIS, SUP)
    VALUES ( @name, @qty, @UPIS, @SUP)
GO
PRINT 'procedure for insert created successfully.';
GO

-- procedure for update
PRINT 'creating procedure for update ';
GO
CREATE PROCEDURE spUpdateStaff
    @id TINYINT,
    @name NVARCHAR(50), @gender CHAR(1), @dob DATE, @position NVARCHAR(50), @salary MONEY, 
    @stopwork BIT, @photo VARBINARY(MAX) 
AS
    UPDATE [dbo].[tbStaffs] 
    SET FullName = @name, Gen = @gender, 
    Dob = @dob, Position = @position, 
    Salary = @salary, Stopwork = @stopwork ,
    Photo = @Photo
    WHERE staffID = @id
GO
CREATE PROCEDURE spUpdateSupplier
    @id INT,
    @supplier NVARCHAR(100), @supAdd NVARCHAR(100), @supCon VARCHAR(100)
AS
    UPDATE [dbo].[tbSuppliers]
    SET Supplier = @supplier,
    SupAdd = @supAdd,
    SupCon = @supCon
    WHERE supID = @id
GO
CREATE PROCEDURE spUpdateCustomer
    @id INT, @cusName VARCHAR(100), @cusContact VARCHAR(15)
AS
    UPDATE [dbo].[tbCustomers]
    SET CusName = @cusName,
    CusContact = @cusContact
    WHERE cusID = @id
GO
CREATE PROCEDURE spUpdateProduct
    @code INT, @name VARCHAR(100), 
    @qty SMALLINT, @UPIS MONEY, @SUP MONEY
AS
    UPDATE [dbo].[tbProducts]
    SET ProName = @name,
    Qty = @qty, UPIS = @UPIS, SUP = @SUP
    WHERE ProCode = @code
GO
PRINT 'procedure for update created successfully.';
GO
-- procedure for delete
PRINT 'creating procedure for delete ';
GO
CREATE PROCEDURE spDeleteStaff
    @id TINYINT
AS
    UPDATE [dbo].[tbStaffs]
    SET Stopwork = 1
    WHERE staffID = @id
GO
PRINT 'procedure for delete created successfully.';
GO

-- function for select
PRINT 'creating function for select ';
GO
CREATE FUNCTION fnGetAllStaff() RETURNS TABLE
AS 
    RETURN (SELECT staffID, FullName FROM [dbo].[tbStaffs] )
GO
CREATE FUNCTION fnGetAllSupplier() RETURNS TABLE
AS 
    RETURN (SELECT supID, Supplier FROM [dbo].[tbSuppliers] )
GO
CREATE FUNCTION fnGetAllProduct() RETURNS TABLE
AS 
    RETURN (SELECT ProCode, ProName FROM [dbo].[tbProducts] )
GO

CREATE FUNCTION fnGetAllCustomer() RETURNS TABLE
AS 
    RETURN (SELECT cusID, CusName FROM [dbo].[tbCustomers] )
GO
PRINT 'function for select created successfully.';
GO

-- type
CREATE TYPE ImportMaster AS TABLE (
    ImpDate DATE ,
    staffID TINYINT ,
    FullName NVARCHAR(50) ,
    supID INT ,
    Supplier NVARCHAR(100) ,
    Total MONEY 
)
GO

-- procedure for importDetail
CREATE PROCEDURE spSetImportDetail @IM AS ImportMaster READONLY 
AS
BEGIN
    INSERT INTO [dbo].[tbImports] (ImpDate, staffID, FullName, supID, Supplier, Total)
    SELECT ImpDate, staffID, FullName, supID, Supplier, Total FROM @IM
END
