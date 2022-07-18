// Weekly payment calculator/ Basir Sultani/ 05/06/22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;


namespace OO_programming
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    // The person class contains a person's details
    public class Person
    {
        private string firstName;
        private string lastName;

        /// <summary>
        /// It is a constructor which initializes the fields of the person class
        /// </summary>
        /// <param name="fName">First Name to be initialized</param>
        /// <param name="lName">Last Name to be initialized</param>
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }
        /// <summary>
        /// Returnns First name and last name of a person as a string
        /// </summary>
        /// <return>First name Last name</return>
        public string fullName
        {
            get
            {
                return $"{firstName} {lastName}";
            }
        }

        /// <summary>
        /// This Methd Returns first name of a person
        /// </summary>
        /// <returns>First Name</returns>
        public string getFirsName()
        {
            return firstName;
        }

        /// <summary>
        /// This Methd Returns last name of a person
        /// </summary>
        /// <returns>Last Name</returns>
        public string getLastName()
        {
            return lastName;
        }
    }

    /// <summary>
    /// Employee class  inherits Person class, contains person and employee details
    /// </summary>
    public class Employee : Person
    {
        private string employeeId;
        private string taxThreshold;
        public double hourlyRate;

        /// <summary>
        /// Employee constructor receives 5 arguments for initialization. 
        /// </summary>
        /// <param name="employeeId">Employee Id to be initialized</param>
        /// <param name="firstName">First name of the employee to be initialized</param>
        /// <param name="lastName">Last Name to be initialized</param>
        /// <param name="hourlyRate">Hourly rate to be initialized</param>
        /// <param name="taxThreshold">tax Threshold to be initialized</param>
        public Employee(string employeeId, string firstName, string lastName, double hourlyRate, string taxThreshold) : base(firstName, lastName)
        {
            this.employeeId = employeeId;
            this.taxThreshold = taxThreshold;
            this.hourlyRate = hourlyRate;
        }

        /// <summary>
        /// Returns employee ID and full name of an employee as a string 
        /// </summary>
        public string getEmployeeDetail
        {
            get
            {
                return $"{employeeId} {fullName}";
            }
        }

        /// <summary>
        /// Checks if an employee has claimed tax free threshold. 
        /// </summary>
        /// <returns>True if tax free threshold is claimed, false otherwise</returns>
        public bool isTaxFreeThresholdClaimed()
        {
            if (this.taxThreshold == "Y")
                return true;
            return false;
        }

        /// <summary>
        /// Used to return the private data field of employee class 
        /// </summary>
        /// <returns>Employee ID of an employee</returns>
        public string getEmpId()
        {
            return employeeId;
        }

        /// <summary>
        /// Used to return the private data field of employee class 
        /// </summary>
        /// <returns>Hourly rate of an employee</returns>
        public double getHourlyRate()
        {
            return hourlyRate;
        }

        /// <summary>
        /// Used to return the private data field of employee class 
        /// </summary>
        /// <returns>Tax threshold of an employee</returns>
        public string getTaxThreshold()
        {
            return taxThreshold;
        }
    }


    /// <summary>
    /// Programmer Basir Sultani
    /// Class a capture details accociated with an employee's pay slip record
    /// </summary>
    public class PaySlip
    {
        public double hoursWorked, grossPay, tax, netPay, superannuation;

        //public PaySlip(string employeeId, string firstName, string lastName, double hourlyRate, char taxThreshold)
        //    : base(firstName, lastName, employeeId, hourlyRate, taxThreshold)
        //{ }

        /// <summary>
        /// class constructor initializes the data field.
        /// </summary>
        /// <param name="hoursWorked">The total hours workded to be initialized</param>
        /// <param name="grossPay">The gross pay to be initialized</param>
        /// <param name="tax">Tax to be initialized</param>
        /// <param name="netPay">Net pay to be initialized</param>
        /// <param name="superannuation">Superannuation to be initialized</param>
        public PaySlip(double hoursWorked, double grossPay, double tax, double netPay, double superannuation)
        {
            this.hoursWorked = hoursWorked;
            this.grossPay = grossPay;
            this.tax = tax;
            this.netPay = netPay;
            this.superannuation = superannuation;
        }

        // Returns all the attributes of PaySlip class
        
    }


    /// <summary>
    /// Base class to hold all Pay calculation functions
    /// Default class behaviour is tax calculated with tax threshold applied
    /// </summary>
    public class PayCalculator
    {
        private double hourlyRate, hoursWorked, taxRateA, taxRateB, superRate;

        public PayCalculator(double hourlyRate, double hoursWorked, double superRate)
        {
            this.hourlyRate = hourlyRate;
            this.hoursWorked = hoursWorked;
            this.superRate = superRate;
        }

        public double getHourlyRate()
        {
            return this.hourlyRate;
        }
        public double gethoursWorked()
        {
            return this.hoursWorked;
        }

        // Initializes tax rates for A and B
        public void setRates(double taxRateA, double taxRateB)
        {
            this.taxRateA = taxRateA;
            this.taxRateB = taxRateB;
        }

        // Returns the tax
        public double calculateTax()
        { 
            double weeklyEarning = hourlyRate * hoursWorked;
            // y = ax − b
            return ((taxRateA * weeklyEarning) - taxRateB);
        }

        // Total income or baseline salary is returned
        public double calculateGrossPay()
        {
            double weeklyEarning = hourlyRate * hoursWorked;
            return weeklyEarning;
        }

        //Super is calculated by multiplying gross salary and wages by 10%, and returned
        public double calculateSupperannuation()
        {
            double grossSalary = hourlyRate * hoursWorked;
            return grossSalary * superRate;
        }
        public double calculateNetPay()
        {
            double weeklyEarning = hourlyRate * hoursWorked;
            // y = ax − b
            double tax = (taxRateA * weeklyEarning) - taxRateB;
            double super = weeklyEarning * superRate;

            return (weeklyEarning - (tax + super));
        }
    }

    /// <summary>
    /// Extends PayCalculator class handling No tax threshold
    /// </summary>
    public class PayCalculatorNoThreshold : PayCalculator
    {
        public PayCalculatorNoThreshold(double hourlyRate, double hoursWorked, double superRate) :
            base(hourlyRate, hoursWorked, superRate)
        {
            double weeklyEarning = hourlyRate * hoursWorked;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(@"taxrate-nothreshold.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<TaxRate>();
                foreach(TaxRate record in records)
                {
                    if(weeklyEarning>= record.min && weeklyEarning <= record.max)
                    {
                        setRates(record.rateA, record.rateB);
                        break;
                    }
                }
                Console.WriteLine("Tax Rate does not exit for this weekly income.");
            }
        }

    }

    /// <summary>
    /// Extends PayCalculator class handling With tax threshold
    /// </summary>
    public class PayCalculatorWithThreshold : PayCalculator
    {
        public PayCalculatorWithThreshold(double hourlyRate, double hoursWorked, double superRate) :
            base(hourlyRate, hoursWorked, superRate)
        {
            double weeklyEarning = hourlyRate * hoursWorked;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            // Reading taxrate-withthreshold.csv to set the value of rate A and B,
            // for calculating tax : y = ax.b.  B_a_s_i_r
            using (var reader = new StreamReader(@"taxrate-withthreshold.csv"))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<TaxRate>();
                    foreach (TaxRate record in records)
                    {
                        // Employee's weekly income fals in one of th tax rate catagory
                        if (weeklyEarning >= record.min && weeklyEarning <= record.max)
                        {
                            setRates(record.rateA, record.rateB);
                            break;
                        }
                    }
                    Console.WriteLine("Tax Rate does not exit for this weekly income.");
                }
            }
            
        }
    }

    // TaxRate type is used to get records from csv file
    public class TaxRate
    {
        public double min { get; set; }
        public double max { get; set; }
        public double rateA { get; set; }
        public double rateB { get; set; }
    }


    // Data fields format: 
    //EmployeeId, Full Name, Hours Worked, Hourly Rate, Tax Threshold,
    // Gross Pay, Tax, Net Pay, Superannuation
    public class ExportPaySlipFormat
    {
        public string employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public double hoursWorked { get; set; }
        public double hourlyRate { get; set; }
        public string taxThreshold { get; set; }
        public double grossPay { get; set; }
        public double tax { get; set; }
        public double netPay { get; set; }
        public double superannuation { get; set; }


        // Constructor initializes all the fields
        public ExportPaySlipFormat(string employeeId, string firstName, string lastName, double hoursWorked,
        double hourlyRate, string taxThreshold, double grossPay, double tax,
        double netPay, double superannuation)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.hoursWorked = hoursWorked;
            this.hourlyRate = hourlyRate;
            this.taxThreshold = taxThreshold;
            this.grossPay = grossPay;
            this.tax = tax;
            this.netPay = netPay;
            this.superannuation = superannuation; 

        }
    }

    // class map is used to control csv column headers and format, 
    // it tells csvHelper how to map C# properties to csv columns
    public class ExportPayslipFormatMap: ClassMap<ExportPaySlipFormat>
    {
        public ExportPayslipFormatMap()
        {
            Map(r => r.employeeId).Name("employee_id");
            Map(r => r.firstName).Name("first_name");
            Map(r => r.lastName).Name("last_name");
            Map(r => r.hoursWorked).Name("hours_worked");
            Map(r => r.hourlyRate).Name("hourly_rate");
            Map(r => r.taxThreshold).Name("tax_threshold");
            Map(r => r.grossPay).Name("gross_pay");
            Map(r => r.tax).Name("tax");
            Map(r => r.netPay).Name("net_pay");
            Map(r => r.superannuation).Name("superannuation");
        }
    }
}

