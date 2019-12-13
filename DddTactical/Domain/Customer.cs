using System;

namespace DddTactical.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public MemberShipStatus MemberShipStatus { get; set; }
    }

    public enum MemberShipStatus
    {
        Basic,
        Gold,
        Platinum
    }
}