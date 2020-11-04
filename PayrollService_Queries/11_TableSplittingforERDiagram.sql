use Payroll_Service;

create table Department
(
	department_ID int not null primary key,
	name varchar(255) not null
);

create table Employee
(
	Id int not null identity(1,1) primary key,
	name varchar(255),
	Address varchar(255) default 'Home',
	Gender varchar(1) not null,
	StartDate date
)

create table Payroll
(
	ID int not null primary key foreign key references Employee(Id),
	BasicPay Float, Deductions float,TaxablePay float, Tax float, NetPay float
);
