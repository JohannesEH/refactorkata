using System;

namespace DddTactical.Domain.AggregatesModdel.CustomerAggregate
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IMembershipStatus MembershipStatus { get; private set; }
    }

    public interface IMembershipStatus
    {
    }

    public class BasicMembershipStatus : IMembershipStatus {}

    public class GoldMembershipStatus : IMembershipStatus {}

    public class PlatinumMembershipStatus : IMembershipStatus {}
}
