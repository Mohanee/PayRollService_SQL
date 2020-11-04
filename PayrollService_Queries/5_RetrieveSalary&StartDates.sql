use Payroll_Service;

select salary from payroll_service_table where name='Bill';
select start from payroll_service_table where start between cast('2018-01-01' as date) and getdate();

--sp_rename 'payroll_service_table.start','start_date','column';