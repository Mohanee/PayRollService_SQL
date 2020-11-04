use payroll_service

alter table payroll_service_table
	add
		Phone varchar(12),
		Address varchar(255) default 'Home',
		Department varchar(25)

	
update payroll_service_table
   set Phone = '345678998',
      Address = 'Mumbai Branch',
      Department = 'Finance'


ALTER TABLE payroll_service_table
ALTER COLUMN Department varchar(25) not null
