﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Reader
{
    public class ServiceDayModel : ObservableObject
    {
        private DateTime m_dtServiceDay;
        private DateTime m_travelStartTime;
        private DateTime m_arrivalOnsiteTime;
        private DateTime m_departSiteTime;
        private DateTime m_travelEndTime;
        private double m_mileage;
        private Boolean m_dailyAllowance;
        private Boolean m_overnightAllowance;
        private Boolean m_barrierPayment;
        private double m_travelTimeToSite;
        private double m_travelTimeFromSite;
        private double m_totalTravelTime;
        private double m_totalTimeOnsite;
        private string m_dailyReport;
        private string m_partsSupplied;
        //Adding a reference to the Service Submission, to update the sum totals
        private ServiceSubmissionModel m_currentServiceSubmission;

        public ServiceDayModel(ServiceSubmissionModel currentSubmission)
        {
            CurrentServiceSubmission = currentSubmission;
        }

        public DateTime DtServiceDay
        {
            get
            {
                return m_dtServiceDay;
            }

            set
            {
                if (m_dtServiceDay != value)
                {
                    m_dtServiceDay = value;
                    onPropertyChanged("DtServiceDay");
                }
            }
        }

        public DateTime TravelStartTime
        {
            get
            {
                return m_travelStartTime;
            }

            set
            {
                if (m_travelStartTime != value)
                {
                    m_travelStartTime = value;
                    onPropertyChanged("TravelStartTime");
                    calculateTimes();
                }
            }
        }

        private void calculateTimes()
        {
            TimeSpan travelTo = ArrivalOnsiteTime - TravelStartTime;
            TravelTimeToSite = travelTo.TotalHours;
            TimeSpan timeOnsite = DepartSiteTime - ArrivalOnsiteTime;
            TotalTimeOnsite = timeOnsite.TotalHours;
            TimeSpan travelFrom = TravelEndTime - DepartSiteTime;
            TravelTimeFromSite = travelFrom.TotalHours;
            TotalTravelTime = TravelTimeToSite + TravelTimeFromSite;
            //Update the total times on the service submission
            CurrentServiceSubmission.updateTimes();
        }

        public DateTime ArrivalOnsiteTime
        {
            get
            {
                return m_arrivalOnsiteTime;
            }

            set
            {
                if (m_arrivalOnsiteTime != value)
                {
                    m_arrivalOnsiteTime = value;
                    onPropertyChanged("ArrivalOnsiteTime");
                    calculateTimes();
                }
            }
        }

        public DateTime DepartSiteTime
        {
            get
            {
                return m_departSiteTime;
            }

            set
            {
                if (m_departSiteTime != value)
                {
                    m_departSiteTime = value;
                    onPropertyChanged("DepartSiteTime");
                    calculateTimes();
                }
            }
        }

        public DateTime TravelEndTime
        {
            get
            {
                return m_travelEndTime;
            }

            set
            {
                if (m_travelEndTime != value)
                {
                    m_travelEndTime = value;
                    onPropertyChanged("TravelEndTime");
                    calculateTimes();
                }
            }
        }

        public double Mileage
        {
            get
            {
                return m_mileage;
            }

            set
            {
                if (m_mileage != value)
                {
                    m_mileage = value;
                    onPropertyChanged("Mileage");
                }
            }
        }

        public Boolean DailyAllowance
        {
            get
            {
                return m_dailyAllowance;
            }

            set
            {
                if (m_dailyAllowance != value)
                {
                    m_dailyAllowance = value;
                    onPropertyChanged("DailyAllowance");
                }
            }
        }

        public Boolean OvernightAllowance
        {
            get
            {
                return m_overnightAllowance;
            }

            set
            {
                if (m_overnightAllowance != value)
                {
                    m_overnightAllowance = value;
                    onPropertyChanged("OvernightAllowance");
                }
            }
        }

        public Boolean BarrierPayment
        {
            get
            {
                return m_barrierPayment;
            }

            set
            {
                if (m_barrierPayment != value)
                {
                    m_barrierPayment = value;
                    onPropertyChanged("BarrierPayment");
                }
            }
        }

        public double TravelTimeToSite
        {
            get
            {
                return m_travelTimeToSite;
            }

            set
            {
                if (m_travelTimeToSite != value)
                {
                    m_travelTimeToSite = value;
                    onPropertyChanged("TravelTimeToSite");
                }
            }
        }

        public double TravelTimeFromSite
        {
            get
            {
                return m_travelTimeFromSite;
            }

            set
            {
                if (m_travelTimeFromSite != value)
                {
                    m_travelTimeFromSite = value;
                    onPropertyChanged("TravelTimeFromSite");
                }
            }
        }

        public double TotalTravelTime
        {
            get
            {
                return m_totalTravelTime;
            }

            set
            {
                if (m_totalTravelTime != value)
                {
                    m_totalTravelTime = value;
                    onPropertyChanged("TotalTravelTime");
                }
            }
        }

        public double TotalTimeOnsite
        {
            get
            {
                return m_totalTimeOnsite;
            }

            set
            {
                if (m_totalTimeOnsite != value)
                {
                    m_totalTimeOnsite = value;
                    onPropertyChanged("TotalTimeOnsite");
                }
            }
        }

        public string DailyReport
        {
            get
            {
                return m_dailyReport;
            }

            set
            {
                if (m_dailyReport != value)
                {
                    m_dailyReport = value;
                    onPropertyChanged("DailyReport");
                }
            }
        }

        public string PartsSupplied
        {
            get
            {
                return m_partsSupplied;
            }

            set
            {
                if (m_partsSupplied != value)
                {
                    m_partsSupplied = value;
                    onPropertyChanged("PartsSupplied");
                }
            }
        }

        public ServiceSubmissionModel CurrentServiceSubmission
        {
            get
            {
                return m_currentServiceSubmission;
            }

            set
            {
                m_currentServiceSubmission = value;
            }
        }
    }
}