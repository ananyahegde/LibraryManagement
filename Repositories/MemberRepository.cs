using LibraryManagement.Models;
using LibraryManagement.Contexts;

namespace LibraryManagement.Repositories
{
    public class MemberRepository : IRepository<Member, int>
    {
        private readonly LibraryDbContext _context;
        public MemberRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public Member Create(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
            return member;
        }

        public List<Member>? ReadAll()
        {
            return _context.Set<Member>().ToList();
        }

        public Member? Read(int key)
        {
            return _context.Members.Find(key);
        }

        public Member? Update(Member member, int key)
        {
            var existing = Read(key);
            if (existing == null)
                throw new Exception("Member not found.");
            _context.Update(member);
            _context.SaveChanges();
            return existing;
        }

        public Member? Delete(int key)
        {
            var existing = Read(key);
            if (existing == null)
                throw new Exception("Member not found.");
            _context.Remove(existing);
            _context.SaveChanges();
            return existing;
        }
    }
}
