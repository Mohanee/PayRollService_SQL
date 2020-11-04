create table payroll_service_table 
(
id int identity(1,1),
name varchar(25) not null,
salary money not null,
start date not null
);