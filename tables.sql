CREATE TABLE role(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
role_name NVARCHAR(50) NOT NULL
);

CREATE TABLE users(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
username VARCHAR(16) NOT NULL,
password VARCHAR(16) NOT NULL,
role_id INT FOREIGN KEY REFERENCES role(id) NOT NULL
);

CREATE TABLE ate_type(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
ate_type_name NVARCHAR(50) NOT NULL
);

CREATE TABLE ate(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
ate_type_id INT NOT NULL FOREIGN KEY REFERENCES ate_type(id),
number_of_customers INT NOT NULL,
phone_number_qty INT NOT NULL
);

CREATE TABLE phone_type(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
phone_type_name NVARCHAR(50) NOT NULL,
);

CREATE TABLE category(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
category_name NVARCHAR(50) NOT NULL
);

CREATE TABLE customer(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
name NVARCHAR(50) NOT NULL,
gender NVARCHAR(1) NOT NULL,
age INT NOT NULL,
ate_id INT FOREIGN KEY REFERENCES ate(id) NOT NULL,
category_id INT FOREIGN KEY REFERENCES category(id) NOT NULL,
has_debt BIT NOT NULL,
has_intercity BIT NOT NULL
);

CREATE TABLE phone_number(
id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
full_number NVARCHAR(50) NOT NULL,
address NVARCHAR(100) NOT NULL,
phone_type_id INT FOREIGN KEY REFERENCES phone_type(id) NOT NULL,
ate_id INT FOREIGN KEY REFERENCES ate(id) NOT NULL
);

CREATE TABLE phone_number_customer(
phone_number_id INT FOREIGN KEY REFERENCES phone_number(id),
customer_id INT FOREIGN KEY REFERENCES customer(id),
fee INT NOT NULL,
PRIMARY KEY (phone_number_id, customer_id)
);