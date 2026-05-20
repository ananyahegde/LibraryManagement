using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Exceptions;

namespace LibraryManagement.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member, int> _memberRepo;
        public MemberService(IRepository<Member, int> memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public Member CreateMember(Member member)
        {
            if (member == null)
                throw new InvalidEntryExceptions("Member cannot be null.");
            if (string.IsNullOrWhiteSpace(member.MemberName))
                throw new InvalidEntryExceptions("Member name cannot be empty.");
            if (string.IsNullOrWhiteSpace(member.Email))
                throw new InvalidEntryExceptions("Email cannot be empty.");
            if (!member.Email.Contains("@"))
                throw new InvalidEntryExceptions("Email is not valid.");
            if (string.IsNullOrWhiteSpace(member.Phone))
                throw new InvalidEntryExceptions("Phone cannot be empty.");
            if (member.MembershipDate == default)
                member.MembershipDate = DateTime.Now;

            return _memberRepo.Create(member);
        }

        public Member ReadMember(int id)
        {
            var member = _memberRepo.Read(id);
            if (member == null)
                throw new InvalidEntryExceptions("Member not found.");
            return member;
        }

        public List<Member> ReadAllMembers()
        {
            var members = _memberRepo.ReadAll();
            if (members == null || members.Count == 0)
                throw new InvalidEntryExceptions("No members found.");
            return members;
        }
    }
}
