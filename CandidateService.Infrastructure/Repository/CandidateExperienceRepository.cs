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

namespace CandidateService.Infrastructure.Repository
{
    public class CandidateExperienceRepository : ICandidateExperienceRepository
    {
        private readonly CandidateDbContext _db;
        private readonly IMapper _mapper;

        public CandidateExperienceRepository(CandidateDbContext db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task AddExperienceAsync(CandidateExperience experience)
        {
            var entity = _mapper.Map<CandidateExperienceEntity>(experience);
            try
            {
                await _db.CandidateExperiences.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the candidate experience.", ex);
            }
        }

        public async Task<ICollection<CandidateExperience>> GetExperienceByIdAsync(Guid candidateId)
        {
            var experienceEntities =  _db.CandidateExperiences.Where(e => e.CandidateId == candidateId).ToListAsync();
            List<CandidateExperience> experiences = new List<CandidateExperience>();
            foreach (var experienceEntity in await experienceEntities)
            {
                experiences.Add(
                    CandidateExperience.Load(
                        experienceEntity.Id,
                        new CandidateId(experienceEntity.CandidateId),
                        experienceEntity.Company,
                        experienceEntity.Position,
                        experienceEntity.Description,
                        experienceEntity.StartDate,
                        experienceEntity.EndDate,
                        experienceEntity.IsCurrent,
                        experienceEntity.CreatedAt,
                        experienceEntity.UpdatedAt
                    ));
            }

            return experiences;
        }

        public async Task<bool> UpdateExperienceAsync(
            Guid experienceId,
            string company,
            string position,
            string? description,
            DateOnly startDate,
            DateOnly? endDate,
            bool isCurrent)
        {
            var experienceEntity = await _db.CandidateExperiences.FirstOrDefaultAsync(e => e.Id == experienceId);
            if (experienceEntity is null)
            {
                return false;
            }

            var domainExperience = CandidateExperience.Load(
                experienceEntity.Id,
                new CandidateId(experienceEntity.CandidateId),
                experienceEntity.Company,
                experienceEntity.Position,
                experienceEntity.Description,
                experienceEntity.StartDate,
                experienceEntity.EndDate,
                experienceEntity.IsCurrent,
                experienceEntity.CreatedAt,
                experienceEntity.UpdatedAt);

            domainExperience.Update(company, position, description, startDate, endDate, isCurrent);

            experienceEntity.Company = domainExperience.Company;
            experienceEntity.Position = domainExperience.Position;
            experienceEntity.Description = domainExperience.Description;
            experienceEntity.StartDate = domainExperience.StartDate;
            experienceEntity.EndDate = domainExperience.EndDate;
            experienceEntity.IsCurrent = domainExperience.IsCurrent;
            experienceEntity.UpdatedAt = domainExperience.UpdatedAt;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteExperienceAsync(Guid experienceId)
        {
            var experienceEntity = await _db.CandidateExperiences.FirstOrDefaultAsync(e => e.Id == experienceId);
            if (experienceEntity is null)
            {
                return false;
            }

            _db.CandidateExperiences.Remove(experienceEntity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
