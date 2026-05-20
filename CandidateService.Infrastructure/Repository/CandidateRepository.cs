using AutoMapper;
using CandidateService.Application.Abstract_Services;
using CandidateService.Domain.Entities.Aggregates;
using CandidateService.Domain.ValueObjects;
using CandidateService.Infrastructure.Entities;
using CandidateService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CandidateService.Infrastructure.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _db;
        private readonly IMapper _mapper;

        public CandidateRepository(CandidateDbContext db, IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReadOnlyList<Candidate>> SearchCandidatesByDescription(string description)
        {
            var pattern = $"%{description.ToLower()}%";

            var candidateEntities = await _db.Candidates
                .AsNoTracking()
                .Where(c => c.Summary != null && EF.Functions.Like(c.Summary.ToLower(), pattern))
                .ToListAsync();

            return candidateEntities
                .Select(candidateEntity => new Candidate(
                    new UserId(candidateEntity.UserId),
                    new FullName(candidateEntity.FirstName, candidateEntity.LastName),
                    new Email(candidateEntity.Email),
                    new PhoneNumber(candidateEntity.Phone),
                    candidateEntity.Summary,
                    !string.IsNullOrEmpty(candidateEntity.Location) ? new Location(candidateEntity.Location) : null))
                .ToList();
        }
        public async Task AddCandidate(Candidate candidate)
        {
            var candidateEntity = _mapper.Map<CandidateEntity>(candidate);
            try
            {
                await _db.Candidates.AddAsync(candidateEntity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions related to database operations
                throw new Exception($"An error occurred while adding the candidate. Exception Message: {ex.Message}", ex);
            }
        }

        public async Task<Candidate?> GetCandidateById(Guid id)
        {
            var candidateEntity = await _db.Candidates.FirstOrDefaultAsync(c => c.UserId == id);
            if (candidateEntity == null)
            {
                return null;
            }
            var domainCandidate = new Candidate(
                    new UserId(candidateEntity.UserId),
                    new FullName(candidateEntity.FirstName, candidateEntity.LastName),
                    new Email(candidateEntity.Email),
                    new PhoneNumber(candidateEntity.Phone),
                    candidateEntity.Summary,
                    !string.IsNullOrEmpty(candidateEntity.Location) ? new Location(candidateEntity.Location) : null
                );
            return domainCandidate;
        }

        public async Task<IReadOnlyList<Candidate>> SearchCandidatesByName(string name)
        {
            var pattern = $"%{name}%";

            var candidateEntities = await _db.Candidates
                .AsNoTracking()
                .Where(c =>
                    EF.Functions.Like(c.FirstName, pattern) ||
                    EF.Functions.Like(c.LastName, pattern) ||
                    EF.Functions.Like(c.FirstName + " " + c.LastName, pattern))
                .ToListAsync();

            return candidateEntities
                .Select(candidateEntity => new Candidate(
                    new UserId(candidateEntity.UserId),
                    new FullName(candidateEntity.FirstName, candidateEntity.LastName),
                    new Email(candidateEntity.Email),
                    new PhoneNumber(candidateEntity.Phone),
                    candidateEntity.Summary,
                    !string.IsNullOrEmpty(candidateEntity.Location) ? new Location(candidateEntity.Location) : null))
                .ToList();
        }
    }
}
