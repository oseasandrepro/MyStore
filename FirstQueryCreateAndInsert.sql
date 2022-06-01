CREATE TABLE clients(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR(100) NOT NULL,
	email VARCHAR(150) NOT NULL,
	phone VARCHAR(20) NULL,
	address VARCHAR(100) NULL,
	created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
	);

INSERT INTO clients (name, email, phone, address)
VALUES
('Bill Gates', 'bill.gate@microsoft.com', '+123456789', 'New York, USA'),
('Elon Musk', 'elon.musk@spacex.com', '+111222333', 'Florida, USa'),
('Will Smith', 'will.smaith@gamil.com', '+111333555', 'California, USA'),
('Bob Marley', 'bob@gmail.com', '+111555999', 'Texas, USA'),
('Cristiano Ronaldo', 'cristiano.ronaldo@gamil.com', '+32447788993', 'Machester, England'),
('Boris Jonhson', 'boris.johson@gmail.com', '+4499778855', 'London, England');