// Weekly payment calculator/ Basir Sultani/ 05/06/22
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace OO_programming
{
    public partial class Form1 : Form
    {   /// <summary>
        /// Form1 contains all the classes and their methods. Which is populated by reading the 
        /// employee.csv file into a list of paySlip objects.
        /// </summary>
        private List<Employee> EmployeeList; 
        public Form1()
        {   
            InitializeComponent();

            // Add code below to complete the implementation to populate the listBox
            // by reading the employee.csv file into a List of PaySlip objects, then binding this to the ListBox.
            // CSV file format: <employee ID>, <first name>, <last name>, <hourly rate>,<taxthreshold>
            EmployeeList = new List<Employee> { };

            // StreamWriter helps us to write things in the first place.
            // Programmer Basir_Sultani
            // We then use this to construct our CsvReader
            //First we need to tell the reader that there is no header record, using configuration.
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(@"employee.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Employee>().ToList();
                for (int i = 0; i < records.Count(); i++)
                    EmployeeList.Add(records[i]);
            }
            Employees.DataSource = EmployeeList;
            Employees.DisplayMember = "getEmployeeDetail";
        }




        // Properties used to ease the implementation of functionalities 

        private Employee emp;
        //supper annuation rate is 10% of employees gross income
        private double superRate = 0.1;
        // Capture details accociated with an employee's pay slip record
        private PaySlip empPayslip;

        /// <summary>
        /// Populates the payment summary taxt bo using the PaySlip and PayCalculator classes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation to populate the
            // payment summary (textBox2) using the PaySlip and PayCalculatorNoThreshold
            // and PayCalculatorWithThresholds classes object and methods.
            double hourWorked = double.Parse(hoursWorked.Text);

            //Form1.IsKeyLocked
            // Getting the selected employee from the employee listbox
            string selectedEmp= Employees.Text;

            var employeeIds = Employees.Text.Trim().ToList();
            string employeeId = employeeIds[0].ToString();

            // finding the employee with the selected employee id
            
            for (int i=0; i<EmployeeList.Count(); i++)
            {
                if (EmployeeList[i].getEmployeeDetail == selectedEmp)
                {
                    emp = EmployeeList[i];
                    break;
                }
            }

            double grossPay, tax, netPay, superannuation;
            // Employee has claimed tax free threshold
            PayCalculator calculator;
            if (emp.isTaxFreeThresholdClaimed())
            {
                calculator = new PayCalculatorWithThreshold(emp.getHourlyRate(), hourWorked, superRate);
            }
            else // Employee has not claimed tax free threshold
            {
                calculator = new PayCalculatorNoThreshold
                    (emp.getHourlyRate(), hourWorked, superRate);
            }

            // Calculate payments, tax, supper.
            grossPay = calculator.calculateGrossPay();
            tax = calculator.calculateTax();
            netPay = calculator.calculateNetPay();
            superannuation = calculator.calculateSupperannuation();


            // Capture details accociated with an employee's pay slip record
            empPayslip = new PaySlip(hourWorked, grossPay, tax, netPay, superannuation);

            // Display the payment summary
            if (empPayslip == null)
                paymentSummary.Text = "Please select an employee";
            else
            {
                string paySummary = emp.getEmployeeDetail;
                var empDetails = paySummary.Split().ToList();
                paySummary = "Employee Id --- "+ empDetails[0]
                    + Environment.NewLine + "First Name --- "+ empDetails[1]
                    + Environment.NewLine + "Last Name --- "+ empDetails[2]
                    + Environment.NewLine + "Hours worked --- " + empPayslip.hoursWorked 
                    + Environment.NewLine + "Hourly Rate --- " + emp.hourlyRate
                    + Environment.NewLine + "Tax Threshold --- " + emp.isTaxFreeThresholdClaimed()
                    + Environment.NewLine + "Gross Pay --- " + empPayslip.grossPay
                    + Environment.NewLine + "Net Pay --- " + empPayslip.netPay
                    + Environment.NewLine + "Tax --- " + empPayslip.tax
                    + Environment.NewLine + "Super --- " + empPayslip.superannuation;
                
                //paymentSummary.AppendText(paySummary);
                paymentSummary.Text = paySummary;
            }

        }
        /// <summary>
        /// This function saves the calculated payment data into a csv file.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event Arguments</param>
        private void button2_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation for saving the
            // calculated payment data into a csv file.
            // File naming convention: Pay_<full name>_<datetimenow>.csv
            // Data fields expected - EmployeeId, Full Name, Hours Worked, Hourly Rate, Tax Threshold, Gross Pay, Tax, Net Pay, Superannuation

            if (empPayslip != null)
            {
                //Creating an object of ExportPaySlipFormat class to write them in csv file
                ExportPaySlipFormat exp = new ExportPaySlipFormat(emp.getEmpId(),
                    emp.getFirsName(), emp.getLastName(), empPayslip.hoursWorked,
                    emp.getHourlyRate(), emp.getTaxThreshold(), empPayslip.grossPay,
                    empPayslip.tax, empPayslip.netPay, empPayslip.superannuation);

                // Date and time used for file name
                // In a format that can be used in a filename or extension.
                // programmer Basir Sultani
                var today = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
                string fileName = "Pay_" + emp.getFirsName()+"_"+emp.getLastName() + "_" + today;

                using(var streamWriter = new StreamWriter(fileName+ ".csv"))
                {
                    using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                    {
                        // Tels the csvWriter to use the class map and passing exportPayslipFormatMap as type
                        csvWriter.Context.RegisterClassMap<ExportPayslipFormatMap>();
                        csvWriter.WriteRecord(exp);
                    }
                }
                paymentSummary.Text = "File saved successfully!";
                empPayslip = null;
                paymentSummary.AppendText(Environment.NewLine+ "File Name --- "+ fileName + ".csv");
            }
            else
            {
                paymentSummary.Text = "Employee not selected.";

            }
            if (Employees.SelectedIndex != -1)
            {
                Employees.SelectedIndex = -1;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
