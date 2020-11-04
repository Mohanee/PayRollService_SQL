use payroll_service

alter table payroll_service_table
	ADD 
		Basic_pay INT DEFAULT 50000,
		Taxable_pay INT DEFAULT 0,
		Income_tax INT DEFAULT 0,
		Net_pay INT DEFAULT 0