use Payroll_Service;

alter table payroll_service_table drop column salary;
select * from payroll_service_table;

create table Department
(
	department_ID int not null primary key,
	name varchar(255) not null
);
insert into Department
values
(101,'Sales'),
(102,'Finance'),
(103,'Logistics'),
(104,'Operations');
select * from Department;

create table Employee
(
	Id int not null identity(1,1) primary key,
	name varchar(255),
	Address varchar(255) default 'Home',
	Gender varchar(10) not null,
	StartDate date
)

alter table Employee drop Gender;

insert into Employee(name,Address,Gender,StartDate) values
('Bill','Sweden','Male','2018-01-03'),
('Terissa','Tokyo','Female','2019-11-13'),
('Charlie','Sweden','Male','2020-05-21'),
('Rishav','Shimla','Male','2013-07-19'),
('Ritwik','Singapore','Female','2013-07-19'),
('Shriya','Chennai','Male','2013-07-19'),
('Riya','Bangalore','Female','2013-07-19'),
('Nikita','Bangalore','Female','2002-01-04');


create table Payroll
(
	ID int not null primary key foreign key references Employee(Id),
	BasicPay Float, Deductions float,TaxablePay float, Tax float, NetPay float
);

insert into Payroll(ID,BasicPay,Deductions,TaxablePay,Tax,NetPay)
values
	(1,50000,5000,60000,600,54000),
	(2,58000,5080,65000,650,60000),
	(3,45000,4500,60000,660,55000),
	(4,58000,5060,60000,600,54500),
	(5,48000,5430,56000,500,52000),
	(6,75000,7000,65000,1000,70000),
	(7,72000,5000,68000,900,70000),
	(8,55000,5500,60000,650,58000);
