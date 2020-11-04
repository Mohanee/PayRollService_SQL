use Payroll_service

select * from payroll_service_table;

insert into payroll_service_table 
(name,salary,start_date,gender,Phone,Address,Department,Basic_pay,Taxable_pay,Income_tax,Net_pay)
values
('Terissa',100000,'2019-07-23','Female','876543235','Chennai Branch','Logistics',40000,65000,5000,60000),
('Terissa',100000,'2019-08-20','Female','874783883','Sweden Branch','Sales',50000,75000,5000,70000);
