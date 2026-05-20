using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface IMemberService
    {
        public Member CreateMember(Member member);
        public Member ReadMember(int id);
        public List<Member> ReadAllMembers();
    }
}
