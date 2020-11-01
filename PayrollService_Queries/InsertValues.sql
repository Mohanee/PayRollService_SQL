use Payroll_Service;

--insert into payroll_service_table values
--('Bill',100000.00,'2018-01-03'),
--('Terissa',200000.00,'2019-11-13'),
--('Charlie',300000.00,'2020-05-21'),
--('Rishav',100000.00,'2013-07-19'),
--('Nikita',700000.00,'2002-01-04');

--WITH cte AS 
--(
--    SELECT 
--        name, salary, start,
--        ROW_NUMBER() OVER (
--            PARTITION BY name,salary,start
--            ORDER BY name,salary,start) row_num
--     FROM payroll_service_table
--)
--DELETE FROM cte
--WHERE row_num > 1;

select * from payroll_service_table;