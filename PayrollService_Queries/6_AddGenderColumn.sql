use Payroll_Service;

alter table payroll_service_table add gender varchar(10);

update payroll_service_table
set gender='male' where name='Bill' or name='Rishav';

update payroll_service_table
set gender='female' where name='Nikita' or name='Terissa' or name='Charlie';

select * from payroll_service_table;