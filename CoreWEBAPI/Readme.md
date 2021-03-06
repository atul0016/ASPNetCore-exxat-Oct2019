﻿Microsoft.EntityFrameworkCore
1. DbContext class
	Manage DB Connection
	Manage DB Transaction for CRUD Operations
	Commit Transactions using SaveChanges() / SaveChangesAsync()
	Manage the Model class mapping with Db Table
		e.g. Student class will be map with Student Table
	The Mapping will be managed using DbSet<T> class.
	T is the Model class name mapped with Table of name T
	DbContext class used DbContextOptions<U> class to read connection string
	for the database
2. Pseduo code
	Consider 'ctx' as an instance f DbContext, Students is an instance of 
	DbSet<Student>
	a. To Read all Students
		var students = ctx.Students.ToList() or ToListAsync()
			Note: ToListAsync() needs Microsoft.EntotyFramewotkCore namespace
	b. To Read Student based on Primary Key
		var student = ctx.Students.FindAsync(p.k. value);
	c. To Append New Student in Students
		1. Create instance of Student class
		2. Set all of its properties
		3. call
			ctx.Students.AddAsync(Student Instance)
		4. Commit Transaction
			ctx.SaveChangesAsync();
	d. To Update Student
		1. Search Student Based on P.K.
		2. Update all its values
		3. Commit Transaction
	e. To Delete Student
		1. Search record based on P.K.
		2. Call remove method of DbSet
			ctx.Students.Remove(Searched-Studnet)
		3. Commit Transaction

Register the DbContext in the DI for the application 

#============================================================================================
Generate Database using EFCore Migrations
1. Generate Migration Class and its metadata

dotnet ef migrations add <NAME-OF-THE-MIGRATION> -c <Namespace based path of DbContext class>

The above command will generate, the SnapshotFile and the MigrationDefinition file

MigrationDefinition file will contains the Class-Mapping with Table
Snapshot file will contain the Table DDL Statement


2. To Create Database from the Migration Metadata file

dotnet ef database update -c <Namespace based path of DbContext class>

#=============================================================================================
WEB API Core
1. The Class that is accessed over Http Request. This is Http Service that
contains HTTP mapped methods
	Get() /Post()/ Put()/ Delete
2. WEB API COre has
	1. ControllerBase, the base class for WEP API
		HttpRequest Processing
		Model Validations in Post and Put request using 'ModelState' property
		IPrincipal object, used for Authorization
		HttpContext, object that represents Http Request and Response
	2. Each Http Method returns IActionResult type
		The IActionResult is as follows
			Ok()
			Ok(object) with OkResult Type, JSON serialization of the Response
			NotFound() / BasRequest() / NoCOntent() / Conflict()
	3. API Controller class is applied with [ApiController] attribute
		The ApiControllerAttribute class performs following
			1. Map the Request Body of Post and Put request from JSON to CLR Object
			2. Perorms Model Binding with Validation



