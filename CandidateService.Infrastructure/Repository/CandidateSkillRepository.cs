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

        public async Task<bool> UpdateCandidateSkillAsync(Guid skillId, string name, string? level, int yearsOfExperience)
        {
            var skillEntity = await _db.CandidateSkills.FirstOrDefaultAsync(s => s.Id == skillId);
            if (skillEntity is null)
            {
                return false;
            }

            var domainSkill = CandidateSkill.Load(
                skillEntity.Id,
                new CandidateId(skillEntity.CandidateId),
                skillEntity.Name,
                skillEntity.Level,
                skillEntity.YearsOfExperience,
                skillEntity.CreatedAt);

            domainSkill.Update(name, level, yearsOfExperience);

            skillEntity.Name = domainSkill.Name;
            skillEntity.Level = domainSkill.Level;
            skillEntity.YearsOfExperience = domainSkill.YearsOfExperience;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCandidateSkillAsync(Guid skillId)
        {
            var skillEntity = await _db.CandidateSkills.FirstOrDefaultAsync(s => s.Id == skillId);
            if (skillEntity is null)
            {
                return false;
            }

            _db.CandidateSkills.Remove(skillEntity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
