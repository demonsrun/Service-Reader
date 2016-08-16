﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Collections.ObjectModel;

namespace Service_Reader
{
    public class CsvServiceImport
    {
        private TextReader csvTextReader;
        private CsvReader csvReaderInput;
        private ServiceSubmissionModel currentServiceSubmission;
        List<ServiceSubmissionModel> importedSubmissions;

        //This class imports the historical data from a csv file and displays it in the application

        public Boolean importCsvData()
        {
            //First get the user to select the file with the data
            string csvFilename = openFilename();
            csvTextReader = File.OpenText(csvFilename);
            csvReaderInput = new CsvReader(csvTextReader);
            csvReaderInput.Configuration.Delimiter = ",";

            //For each record in the csv file, we need to create a submission with all the days
            //Loop through all the rows in the csv import

            //If the row submission no matches the current submission number, then we are loading days.
            //If not, then it it a new submssion

            int currentReadSubmissionNo = -1;
            importedSubmissions = new List<ServiceSubmissionModel>();

            while (csvReaderInput.Read())
            {
                var row = csvReaderInput.CurrentRecord;
                int submissionNo = Convert.ToInt32(row[2]);

                //If first time through, then set the current submission no
                //Load the first row
                if (currentReadSubmissionNo == -1)
                {
                    currentReadSubmissionNo = submissionNo;
                    currentServiceSubmission = new ServiceSubmissionModel();
                    loadNewSubmission(row);
                    continue;
                }

                if (currentReadSubmissionNo == submissionNo)
                {
                    loadDayForSubmission(row, currentServiceSubmission);
                }
                else
                {
                    importedSubmissions.Add(currentServiceSubmission);
                    Console.WriteLine("Submission: " + currentReadSubmissionNo + " created");
                    currentReadSubmissionNo = submissionNo;
                    currentServiceSubmission = new ServiceSubmissionModel();
                    loadNewSubmission(row);
                    
                }
                
            }


            return false;
        }

        private void loadNewSubmission(string[] row)
        {
            //First two dates aren't read
            currentServiceSubmission.SubmissionNo = Convert.ToInt32(row[2]);
            //App Name isn't used
            currentServiceSubmission.Username = row[4];
            currentServiceSubmission.UserSurname = row[5];
            currentServiceSubmission.UserFirstName = row[6];
            currentServiceSubmission.ResponseId = row[7];
            string dateFormatMinutes = "M/d/yyyy HH:mm";
            string dateFormatSeconds = "M/d/yyyy HH:mm:ss";
            string responseDate = row[8];
            //RT 15/8/16 - The time is either includes minutes or does not.  
            try
            {
                currentServiceSubmission.DtResponse = DateTime.ParseExact(responseDate, dateFormatMinutes, CultureInfo.InvariantCulture);
            }
            catch
            {
                currentServiceSubmission.DtResponse = DateTime.ParseExact(responseDate, dateFormatSeconds, CultureInfo.InvariantCulture);
            }
            string deviceDate = row[9];
            try
            {
                currentServiceSubmission.DtDevice = DateTime.ParseExact(deviceDate, dateFormatMinutes, CultureInfo.InvariantCulture);
            }
            catch
            {
                currentServiceSubmission.DtDevice = DateTime.ParseExact(deviceDate, dateFormatSeconds, CultureInfo.InvariantCulture);
            }
            //Submission Form name not used
            currentServiceSubmission.SubmissionVersion = Convert.ToInt32(row[11]);
            currentServiceSubmission.Customer = row[12];
            currentServiceSubmission.Address1 = row[13];
            currentServiceSubmission.Address2 = row[14];
            currentServiceSubmission.TownCity = row[15];
            currentServiceSubmission.Postcode = row[16];
            currentServiceSubmission.CustomerContact = row[17];
            currentServiceSubmission.CustomerPhone = row[18];
            currentServiceSubmission.MachineMakeModel = row[19];
            currentServiceSubmission.MachineSerial = row[20];
            currentServiceSubmission.MachineController = row[21];
            string jobStartDate = row[22];
            currentServiceSubmission.JobStart = DateTime.ParseExact(jobStartDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            currentServiceSubmission.CustomerOrderNo = row[23];
            currentServiceSubmission.MttJobNumber = row[24];
            currentServiceSubmission.JobDescription = row[25];

            //Need to load the days
            //First set the timesheets up on the current service submission
            currentServiceSubmission.ServiceTimesheets = new ObservableCollection<ServiceDayModel>();
            loadDayForSubmission(row, currentServiceSubmission);

            currentServiceSubmission.TotalTimeOnsite = Convert.ToDouble(row[41]);
            currentServiceSubmission.TotalTravelTime = Convert.ToDouble(row[42]);
            currentServiceSubmission.TotalMileage = Convert.ToDouble(row[43]);
            currentServiceSubmission.TotalDailyAllowances = Convert.ToDouble(row[44]);
            currentServiceSubmission.TotalOvernightAllowances = Convert.ToDouble(row[45]);
            currentServiceSubmission.TotalBarrierPayments = Convert.ToDouble(row[46]);
            currentServiceSubmission.JobStatus = row[47];
            currentServiceSubmission.FinalJobReport = row[48];
            currentServiceSubmission.AdditionalFaultsFound = row[50];
            currentServiceSubmission.QuoteRequired = Convert.ToBoolean(row[51]);
            currentServiceSubmission.PartsForFollowup = row[52];
            currentServiceSubmission.Image1Url = row[54];
            currentServiceSubmission.Image2Url = row[55];
            currentServiceSubmission.Image3Url = row[56];
            currentServiceSubmission.Image4Url = row[57];
            currentServiceSubmission.Image5Url = row[58];
            currentServiceSubmission.CustomerSignatureUrl = row[60];
            currentServiceSubmission.CustomerSignName = row[61];
            string signedDate = row[62];
            currentServiceSubmission.DtSigned = DateTime.ParseExact(signedDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            currentServiceSubmission.MttEngSignatureUrl = row[63];
        }

        private void loadDayForSubmission(string[] row, ServiceSubmissionModel currentSubmission)
        {
            string dateFormatMinutes = "d/M/yyyy HH:mm";
            string dateFormatSeconds = "d/M/yyyy H:mm:ss";

            //Need to set the submission on the service day
            ServiceDayModel currentDay = new ServiceDayModel(currentSubmission);
            //The times may be with / without the date, depending on when they were imported.
            //Need to load the service date first, in case we need it for the times
            string serviceDate = row[40];
            currentDay.DtServiceDay = DateTime.ParseExact(serviceDate, "d/M/yyyy", CultureInfo.InvariantCulture);

            string travelStartTime = row[26];
            try
            {
                currentDay.TravelStartTime = DateTime.ParseExact(travelStartTime, dateFormatMinutes, CultureInfo.InvariantCulture);
            }
            catch
            {
                try
                {
                    currentDay.TravelStartTime = DateTime.ParseExact(travelStartTime, dateFormatSeconds, CultureInfo.InvariantCulture);
                }
                catch
                {
                    string travelStartIncDate = serviceDate + " " + travelStartTime;
                    currentDay.TravelStartTime = DateTime.ParseExact(travelStartIncDate, dateFormatMinutes, CultureInfo.InvariantCulture);
                }
            }

            string arrivalTimeOnsite = row[27];
            try
            {
                currentDay.ArrivalOnsiteTime = DateTime.ParseExact(arrivalTimeOnsite, dateFormatMinutes, CultureInfo.InvariantCulture);
            }
            catch
            {
                try
                {
                    currentDay.ArrivalOnsiteTime = DateTime.ParseExact(arrivalTimeOnsite, dateFormatSeconds, CultureInfo.InvariantCulture);
                }
                catch
                {
                    string arrivalOnsiteIncDate = serviceDate + " " + arrivalTimeOnsite;
                    currentDay.ArrivalOnsiteTime = DateTime.ParseExact(arrivalOnsiteIncDate, dateFormatMinutes, CultureInfo.InvariantCulture);
                }
            }

            string departureTime = row[28];
            try
            {
                currentDay.DepartSiteTime = DateTime.ParseExact(departureTime, dateFormatMinutes, CultureInfo.InvariantCulture);
            }
            catch
            {
                try
                {
                    currentDay.DepartSiteTime = DateTime.ParseExact(departureTime, dateFormatSeconds, CultureInfo.InvariantCulture);
                }
                catch
                {
                    string departureIncDate = serviceDate + " " + departureTime;
                    currentDay.DepartSiteTime = DateTime.ParseExact(departureIncDate, dateFormatMinutes, CultureInfo.InvariantCulture);
                }
            }

            string travelEndTime = row[29];
            try
            {
                currentDay.TravelEndTime = DateTime.ParseExact(travelEndTime, dateFormatMinutes, CultureInfo.InvariantCulture);
            }
            catch
            {
                try
                {
                    currentDay.TravelEndTime = DateTime.ParseExact(travelEndTime, dateFormatSeconds, CultureInfo.InvariantCulture);
                }
                catch
                {
                    string travelEndIncDate = serviceDate + " " + travelEndTime;
                    currentDay.TravelEndTime = DateTime.ParseExact(travelEndIncDate, dateFormatMinutes, CultureInfo.InvariantCulture);
                }
            }

            currentDay.Mileage = Convert.ToDouble(row[30]);
            try
            {
                currentDay.DailyAllowance = Convert.ToBoolean(row[31]);
            }
            catch
            {
                //If this fails, then it nust be an integer
                int dailyAllowance = Convert.ToInt32(row[31]);
                if (dailyAllowance == 1)
                {
                    currentDay.DailyAllowance = true;
                }
                else
                {
                    currentDay.DailyAllowance = false;
                }
            }

            try
            {
                currentDay.OvernightAllowance = Convert.ToBoolean(row[32]);
            }
            catch
            {
                //If this fails, then it nust be an integer
                int overnightAllowance = Convert.ToInt32(row[32]);
                if (overnightAllowance == 1)
                {
                    currentDay.OvernightAllowance = true;
                }
                else
                {
                    currentDay.OvernightAllowance = false;
                }
            }

            try
            {
                currentDay.BarrierPayment = Convert.ToBoolean(row[33]);
            }
            catch
            {
                //If this fails, then it nust be an integer
                int barrierPayment = Convert.ToInt32(row[33]);
                if (barrierPayment == 1)
                {
                    currentDay.BarrierPayment = true;
                }
                else
                {
                    currentDay.BarrierPayment = false;
                }
            }

            currentDay.TravelTimeToSite = Convert.ToDouble(row[34]);
            currentDay.TravelTimeFromSite = Convert.ToDouble(row[35]);
            currentDay.TotalTravelTime = Convert.ToDouble(row[36]);
            currentDay.TotalTimeOnsite = Convert.ToDouble(row[37]);
            currentDay.DailyReport = row[38];
            currentDay.PartsSupplied = row[39];
        }

        private string openFilename()
        {
            string retval;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "csv files (*.csv)|*.csv";
            Nullable<bool> result = openDialog.ShowDialog();

            if (result == true)
            {
                retval = openDialog.FileName;
            }
            else
            {
                retval = "";
            }

            return retval;
        }

        public List<ServiceSubmissionModel> AllServiceSubmissions
        {
            get
            {
                return importedSubmissions;
            }
        }
    }
}
