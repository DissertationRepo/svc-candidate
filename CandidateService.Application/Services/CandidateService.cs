using CandidateService.Application.Abstract_Services;
using CandidateService.Application.Models;
using CandidateService.Domain.Entities.Aggregates;
using CandidateService.Domain.ValueObjects;

namespace CandidateService.Application.Services
{
    public class CandidateService : ICandidateService 
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task CreateCandidateAsync(CandidateModel newCandidate)
        {
            var domainCandidate = Candidate.Create(
                Guid.Parse(newCandidate.UserId!),
                newCandidate.FirstName!,
                newCandidate.LastName!,
                newCandidate.Email!,
                newCandidate.PhoneNumber,
                newCandidate.Summary,
                newCandidate.Location
            );
            await _candidateRepository.AddCandidate(domainCandidate);
        }

        public Task<Candidate?> GetCandidateByIdAsync(Guid id)
        {
            var domainCandidate = _candidateRepository.GetCandidateById(id);
            return domainCandidate;
        }
    }
}
