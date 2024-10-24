CREATE TABLE ate_type(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
ate_type_name VARCHAR(50) NOT NULL
);

CREATE TABLE ate(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
ate_type_id INT NOT NULL FOREIGN KEY REFERENCES ate_type(id),
number_of_customers INT,
phone_number_qty INT
);

CREATE TABLE phone_type(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
phone_type_name VARCHAR(50) NOT NULL,
);

CREATE TABLE category(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
category_name VARCHAR(50)
);

CREATE TABLE customer(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(50) NOT NULL,
gender VARCHAR(1) NOT NULL,
age INT NOT NULL,
phone_type_id INT FOREIGN KEY REFERENCES phone_type(id),
ate_id INT FOREIGN KEY REFERENCES ate(id),
category_id INT FOREIGN KEY REFERENCES category(id),
has_debt BIT,
has_intercity BIT,
phone_number_id INT
);

CREATE TABLE phone_number(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
address VARCHAR(100),
phone_type_id INT FOREIGN KEY REFERENCES phone_type(id),
ate_id INT FOREIGN KEY REFERENCES ate(id),
customer_id INT
);

CREATE TABLE phone_number_customer(
phone_number_id INT FOREIGN KEY REFERENCES phone_number(id),
customer_id INT FOREIGN KEY REFERENCES customer(id),
PRIMARY KEY (phone_number_id, customer_id)
);