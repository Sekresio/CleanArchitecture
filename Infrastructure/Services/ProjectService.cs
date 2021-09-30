using System;
using System.Collections.Generic;
using Application.Services;
using DataAccess;
using Domain;

namespace Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var projects = _unitOfWork.Projects.GetAll();
            return projects;
        }

        public void AddProject(Project project)
        {
            _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();
        }
    }
}