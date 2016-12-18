//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service_Reader
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceSheet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceSheet()
        {
            this.ServiceDays = new HashSet<ServiceDay>();
        }
    
        public int Id { get; set; }
        public int SubmissionNumber { get; set; }
        public string AppName { get; set; }
        public string Username { get; set; }
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
        public string CanvasResponseId { get; set; }
        public System.DateTime DtResponse { get; set; }
        public System.DateTime DtDevice { get; set; }
        public string SubmissionFormName { get; set; }
        public int SubmissionFormVersion { get; set; }
        public string Customer { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string TownCity { get; set; }
        public string Postcode { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerPhoneNo { get; set; }
        public string MachineMakeModel { get; set; }
        public string MachineSerial { get; set; }
        public string CncControl { get; set; }
        public System.DateTime DtJobStart { get; set; }
        public string CustomerOrderNo { get; set; }
        public string MttJobNumber { get; set; }
        public string JobDescription { get; set; }
        public double JobTotalTimeOnsite { get; set; }
        public double JobTotalTravelTime { get; set; }
        public int JobTotalMileage { get; set; }
        public int TotalDailyAllowances { get; set; }
        public int TotalOvernightAllowances { get; set; }
        public int TotalBarrierPayments { get; set; }
        public string JobStatus { get; set; }
        public string FinalJobReport { get; set; }
        public string AdditionalFaults { get; set; }
        public bool QuoteRequired { get; set; }
        public string FollowUpPartsRequired { get; set; }
        public string Image1Url { get; set; }
        public string Image2Url { get; set; }
        public string Image3Url { get; set; }
        public string Image4Url { get; set; }
        public string Image5Url { get; set; }
        public string CustomerSignatureUrl { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime DtSigned { get; set; }
        public string MttEngSignatureUrl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceDay> ServiceDays { get; set; }
    }
}
