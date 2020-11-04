use Payroll_Service

select * from Employee as emp inner join Payroll as pay on emp.Id= pay.ID;

select NetPay from Employee as emp inner join Payroll as pay
on emp.ID = pay.ID
where StartDate between cast('2017-01-01' as date) and GETDATE()

select count(*) as no_of_males, avg(NetPay) as avg_net_sal, max(NetPay) as Max_pay, min(NetPay) as Min_pay 
from Employee as emp inner join Payroll as pay
on emp.Id= pay.ID
where Gender='Male' group by Gender;

select count(*) as no_of_females, avg(NetPay) as avg_net_sal, max(NetPay) as Max_pay, min(NetPay) as Min_pay 
from Employee as emp inner join Payroll as pay
on emp.Id= pay.ID
where Gender='Female' group by Gender;

