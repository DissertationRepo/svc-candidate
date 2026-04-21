using AutoMapper;
using CandidateService.Application.Abstract_Services;
using CandidateService.Domain.Entities.ChildEntities;
using CandidateService.Domain.ValueObjects;
using CandidateService.Infrastructure.Entities;
using CandidateService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateService.Application.Services
{
    public class CandidateSkillRepository : ICandidateSkillRepository
    {
        private readonly CandidateDbContext _db;
        private readonly IMapper _mapper;

        public CandidateSkillRepository(CandidateDbContext db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db), "Database context cannot be null.");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper cannot be null.");
        }
        public async Task AddCandidateSkillAsync(CandidateSkill candidateSkill)
        {
            var entity = _mapper.Map<CandidateSkillEntity>(candidateSkill);
            try
            {
                await _db.CandidateSkills.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the candidate skill.", ex);
            }
        }

        public async Task<ICollection<CandidateSkill>> GetSkillsById(Guid candidateId)
        {
            var skillEntities = await _db.CandidateSkills.Where(s => s.CandidateId == candidateId).ToListAsync();
            List<CandidateSkill> skills = new List<CandidateSkill>();
            foreach (var skill in skillEntities)
            {
                skills.Add(
                    Domain.Entities.ChildEntities.CandidateSkill.Load(
                        skill.Id,
                        new CandidateId(skill.CandidateId),
                        skill.Name,
                        skill.Level,
                        skill.YearsOfExperience,
                        skill.CreatedAt
                        )
                    );
            }

            return skills;
        }
    }
}
