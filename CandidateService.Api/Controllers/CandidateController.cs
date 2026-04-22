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
        private readonly ICandidateExperienceService _candidateExperienceService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, ICandidateSkillService candidateSkillService, ICandidateExperienceService candidateExperienceService, IMapper mapper)
        {
            _candidateService = candidateService ?? throw new ArgumentNullException(nameof(candidateService));
            _candidateSkillService = candidateSkillService ?? throw new ArgumentNullException(nameof(candidateSkillService));
            _candidateExperienceService = candidateExperienceService ?? throw new ArgumentNullException(nameof(candidateExperienceService));
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

        [HttpGet("skills/{candidateId}")]
        public async Task<ICollection<SkillsResponse>> GetCandidateSkills(string candidateId)
        {
            var domainSkills = await _candidateSkillService.GetCandidateSkillsAsync(candidateId);
            var skills = _mapper.Map<ICollection<SkillsResponse>>(domainSkills);
            return skills;
        }

        [HttpPut("skill/update")]
        public async Task<IActionResult> UpdateCandidateSkill([FromBody] UpdateCandidateSkill updateCandidateSkill)
        {
            var updateCandidateSkillModel = _mapper.Map<Application.Models.UpdateCandidateSkillModel>(updateCandidateSkill);
            var updated = await _candidateSkillService.UpdateCandidateSkillAsync(updateCandidateSkillModel);
            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("skill/{id}")]
        public async Task<IActionResult> DeleteCandidateSkill(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest("Invalid skill ID format. Please provide a valid GUID.");
            }

            var deleted = await _candidateSkillService.DeleteCandidateSkillAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("experience/add")]
        public async Task<IActionResult> AddCandidateExperience([FromBody] AddCandidateExperience addCandidateExperience)
        {
            var addCandidateExperienceModel = _mapper.Map<Application.Models.CandidateExperienceModel>(addCandidateExperience);
            await _candidateExperienceService.AddCandidateExperienceAsync(addCandidateExperienceModel);
            return Ok();
        }

        [HttpGet("experiences/{candidateId}")]
        public async Task<ICollection<ExperiencesResponse>> GetCandidateExperiences(string candidateId)
        {
            var domainExperiences = await _candidateExperienceService.GetCandidateExperiencesAsync(candidateId);
            var experiences = _mapper.Map<ICollection<ExperiencesResponse>>(domainExperiences);
            return experiences;
        }

        [HttpPut("experience/update")]
        public async Task<IActionResult> UpdateCandidateExperience([FromBody] UpdateCandidateExperience updateCandidateExperience)
        {
            var updateCandidateExperienceModel = _mapper.Map<Application.Models.UpdateCandidateExperienceModel>(updateCandidateExperience);
            var updated = await _candidateExperienceService.UpdateCandidateExperienceAsync(updateCandidateExperienceModel);
            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("experience/{id}")]
        public async Task<IActionResult> DeleteCandidateExperience(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest("Invalid experience ID format. Please provide a valid GUID.");
            }

            var deleted = await _candidateExperienceService.DeleteCandidateExperienceAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
