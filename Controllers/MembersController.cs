using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Services;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public ActionResult<Member> Post(Member member)
        {
            try
            {
                var result = _memberService.CreateMember(member);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<Member> Get()
        {
            try
            {
                var members = _memberService.ReadAllMembers();
                if (members == null)
                    return NotFound("No members yet.");
                return Ok(members);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetById(int id)
        {
            var member = _memberService.ReadMember(id);
            if (member == null)
            {
                return NotFound();
            }
            return member;
        }
    }
}
