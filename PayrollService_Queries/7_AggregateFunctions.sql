use Payroll_Service;

select max(salary) as Max_salary,gender from payroll_service_table group by gender;
select min(salary) as Min_salary,gender from payroll_service_table group by gender;
select AVG(salary) as Avg_salary,gender from payroll_service_table group by gender;
select sum(salary)as Total_salary,gender from payroll_service_table group by gender;