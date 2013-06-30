using System.Runtime.Serialization;

namespace Stephen.Webb.HR.DataTransferObjects
{
    [DataContract]
    public class EmployeeExternal
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int EmployeeCode { get; set; }
        [DataMember]
        public System.DateTime StartDate { get; set; }
    }
}
