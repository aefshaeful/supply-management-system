using API.Contracts;
using API.DataTransferObjects.TenderProjects;
using API.Repositories;

namespace API.Services
{
    public class TenderProjectService
    {
        private readonly ITenderProjectRepository _tenderProjectRepository;

        public TenderProjectService(ITenderProjectRepository tenderProjectRepository)
        {
            _tenderProjectRepository = tenderProjectRepository;
        }

        public IEnumerable<TenderProjectDtoGet> Get()
        {
            var tenderProjects = _tenderProjectRepository.GetAll().ToList();
            if (!tenderProjects.Any())
            {
                return Enumerable.Empty<TenderProjectDtoGet>();
            }

            List<TenderProjectDtoGet> tenderProjectDtoGets = new();

            foreach (var tenderProject in tenderProjects)
            {
                tenderProjectDtoGets.Add((TenderProjectDtoGet)tenderProject);
            }

            return tenderProjectDtoGets;
        }

        public TenderProjectDtoGet? Get(Guid guid)
        {
            var tenderProject = _tenderProjectRepository.GetByGuid(guid);
            if (tenderProject is null)
            {
                return null!;
            }

            return (TenderProjectDtoGet)tenderProject;
        }

        public TenderProjectDtoCreate? Create(TenderProjectDtoCreate tenderProjectDtoCreate)
        {
            var tenderProjectCreated = _tenderProjectRepository.Create(tenderProjectDtoCreate);
            if (tenderProjectCreated is null)
            {
                return null!;
            }

            return (TenderProjectDtoCreate)tenderProjectCreated;
        }

        public int Update(TenderProjectDtoUpdate tenderProjectDtoUpdate)
        {
            var tenderProject = _tenderProjectRepository.GetByGuid(tenderProjectDtoUpdate.Guid);
            if (tenderProject is null)
            {
                return -1;
            }

            var tenderProjectUpdated = _tenderProjectRepository.Update(tenderProjectDtoUpdate);
            return !tenderProjectUpdated ? 0 : 1;
        }

        public int Delete(Guid guid)
        {
            var tenderProject = _tenderProjectRepository.GetByGuid(guid);
            if (tenderProject is null)
            {
                return -1;
            }

            var tenderProjectDeleted = _tenderProjectRepository.Delete(tenderProject);
            return !tenderProjectDeleted ? 0 : 1;
        }
    }
}