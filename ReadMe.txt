*** READ ME *******************************************************************************************************
*** OVERVIEW ******************************************************************************************************
	The Payslip application is an application designed to take an employees name and salary and create a payslip 
from these details. Creating this payslip involves calculating three elements. These elements are; the employees 
monthly gross wage, the monthly income tax on the salary, and the net monthly income. Whilst the income tax has a 
more complex calculation the Gross and Net salaries are calculated as follows;

	- GrossMonthlyIncome = Salary / 12; 
	- NetMonthlyIncome = GrossMonthlyIncome - MonthlyIncomeTax;

*** INCOME TAX CALCULATION ****************************************************************************************
The income tax for a monthly payslip is calculated using a series of Tax Brackets. In the payslip application
a tax bracket has an upper amount, lower amount, and a tax rate. These ranges tell the calculator where 
the braket begins and ends and therefore the amount to apply the tax rate to. The calculation is as follows;

	- The salary is checked against each brackets upper amount.
	- If the salary is greater than the upper amount;
		- The tax is calculated on that whole bracket;
		- bracket tax = (brackets upper bound - lastBracketsUpperBound) * brackets tax rate;
	- If the salary is not greater than the upper amount.
		- The tax is calculated on the part of salary that is above the end of last bracket;
		- tax = (salary - lastBracketsUpperBound) * tax rate;
	- The final accumulated amount is divided by the number of months for a time period. In this case it is 
		12 months. So the period is for monthly tax.

*** RUNNING PAYSLIP.CONSOLE ***************************************************************************************
The Payslip.console program is run by opening a command prompt and running the following commands;
	- cd <path to the Payslip.console executable>
	- Payslip.console "<Employee Name>" <salary>
	- e.g. Payslip.console "Richard Wiz" 50000
	- The program can also be run in visual studio for the example in the requirements.
		 - The commanline arguments are setup in the Debug tab of the Project properties.

*** DESIGN NOTES **************************************************************************************************
Whilst the payslip application simple, it has also been designed to be both extendable and easily testable. 
To this end it has been designed in a Model, View, Controller idiom. Whilst aspects of the application may not 
completely adhere to the MVC paradigm the intent is that if the application was to be extended it could be easily 
modifiable. One of the main aims of the design is to reduce the dependancies between components. 
An example of this; the obfuscation of the Employee Payslip in the controller that removes the console's
dependancy on a model (payslip). This modularisation allows each module to be tested individually. 
Interfaces have been provided for the Controller as a basis for future dependancy injection and use in web APIs.

*** COMPONENTS ****************************************************************************************************
*** PAYSLIP.CONSOLE ***********************************************************************************************
The Payslip.console applications User Interface. It uses the Payslip.Controller to validate the input and then 
calculate the tax and complete an employee payslip. The console's only dependancy is the Controller.

*** PAYSLIP.CONTROLLER ********************************************************************************************
The Payslip.Controller holds all the processing for the application. It uses a Validator and a Calculator. 
As the application is a simple application this controller is not a true controller in the MVC pattern sense as it 
does not completely render the view (Payslip.console). However, it could be easily expanded to become a true 
controller. The calculator and the validator are individually testable and have been kept simple for ease of 
use and understanding. The controllers dependencies are the Payslip.Model (business objects) and the Payslip.Data
(the Database simulator).

*** PAYSLIP.DATA **************************************************************************************************
Payslip Data is a simple data layer that serves as a database simulator. In reality the Tax brackets may be found 
in a static data table in a database. So the provider would connect to the database and provide data where needed.
The static data in particular could be added to a cache in the controller for in memory use as it usually has
less records for retrieval than transactional data. The data is dependant on the Payslip.Model as it loads the 
Tax brackets up for use by the Controller.

*** PAYSLIP.MODEL *************************************************************************************************
The Payslip.Model holds the business objects, essentially the Employee payslip and the Tax brackets. The Payslip
has some basic inheritance to pave the way for other kinds of payslips. The Model has no dependancies. 

*** PAYSLIP.TEST **************************************************************************************************
The Payslip.Tests is the component that holds the unit tests. These tests are run currently from the Visual Studio 
interface but as they are part of the solution they can easily be triggered by a build server. The tests are 
essentially another view or interface so it is dependant on the controller.

*** TESTING *******************************************************************************************************
The tests have been written to excercise positive, negative, and boundary scenarios. The bulk of the tests 
are for the Tax Calculation and have been made to test the lowest, highest, and normal tax brackets.
The example from the requirements was also tested. 
The Validator has a test for each validation, both positive and negative. The Data Provider has one test that tests 
that the Tax Brackets are loaded correctly.

