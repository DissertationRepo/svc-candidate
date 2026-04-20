using AutoMapper;
using CandidateService.Api.Models;
using CandidateService.Application.Abstract_Services;
using CandidateService.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandidateService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ICandidateSkillService _candidateSkillService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, ICandidateSkillService candidateSkillService, IMapper mapper)
        {
            _candidateService = candidateService ?? throw new ArgumentNullException(nameof(candidateService));
            _candidateSkillService = candidateSkillService ?? throw new ArgumentNullException(nameof(candidateSkillService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCandidate([FromBody] NewCandidate newCandidate)
        {
            var candidateCommand = _mapper.Map<CandidateService.Application.Models.CandidateModel>(newCandidate);
            await _candidateService.CreateCandidateAsync(candidateCommand);
            return Ok();
        }

        [HttpGet("candidate/{id}")]
        public async Task<IActionResult> GetCandidateById(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid candidate ID format. Please provide a valid GUID.");
            }
            var candidateResponse = await _candidateService.GetCandidateByIdAsync(guid);
            if (candidateResponse == null)
            {
                return NotFound();
            }
            var candidate = _mapper.Map<CandidateModel>(candidateResponse);
            return Ok(candidate);
        }

        [HttpPost("skill/add")]
        public async Task<IActionResult> AddCandidateSkill([FromBody] AddCandidateSkill addCandidateSkill)
        {
            var addCandidateSkillModel = _mapper.Map<Application.Models.CandidateSkillModel>(addCandidateSkill);
            await _candidateSkillService.AddCandidateSkillAsync(addCandidateSkillModel);
            return Ok();
        }
    }
}
