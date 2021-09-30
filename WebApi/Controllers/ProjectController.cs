using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectReadService;

        public ProjectController(IProjectService projectReadService)
        {
            _projectReadService = projectReadService ?? throw new ArgumentNullException(nameof(projectReadService));
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            var projects = _projectReadService.GetAllProjects();
            return projects;
        }

        [HttpPost]
        public void Post([FromBody] Project project)
        {
            _projectReadService.AddProject(project);
        }

    }
}
