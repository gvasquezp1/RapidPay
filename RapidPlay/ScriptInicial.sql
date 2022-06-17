--create table credit_cards(
-- id int identity(1,1) primary key,
-- name varchar(50),
-- number varchar(30),
-- expiration_date datetime,
-- locked bit,

--)

create table customers(
 id int identity(1,1) primary key,
 name varchar(50),
 address varchar(50),
 locked bit,
)


create table payments(
	Id int identity(1,1) primary key,
	CreditCardId int foreign key references credit_cards(id),
	ClientId int foreign key references customers(id),
	DocDate datetime,
	DocDueDate datetime,
	Fee int,
	Locked bit
)

create table fees(
	Id int identity(1,1) primary key,
	fee decimal(5,2),
	FeeDate datetime
)