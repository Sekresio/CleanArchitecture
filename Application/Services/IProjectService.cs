using System.Collections;
using System.Collections.Generic;
using Domain;

namespace Application.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();
        void AddProject(Project project);
    }
}