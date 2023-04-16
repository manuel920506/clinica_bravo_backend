using AutoMapper;
using clinica_bravo_backend.DTOs;
using clinica_bravo_backend.Entities;
using clinica_bravo_backend.Filters;
using clinica_bravo_backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace clinica_bravo_backend.Controllers {
    [Route("api/Blog")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class BlogController : ControllerBase {
        private readonly IRepository repository; 
        private readonly ILogger<BlogController> logger;
        private readonly IMapper mapper;
        public BlogController(IRepository repository, 
            ILogger<BlogController> logger,
            IMapper mapper) {
            this.repository = repository; 
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet] // api/Blog
        [HttpGet("list")] // api/Blog/list
        [HttpGet("/listTopics")] // /listTopics
        [ResponseCache(Duration = 60)]
        [ServiceFilter(typeof(MyActionFilter))]
        [AllowAnonymous]
        public ActionResult<List<TopicDTO>> Get() {
            logger.LogInformation("Let's show the topics");
           
            var topics  = repository.GetAllTopics();
            return mapper.Map<List<TopicDTO>>(topics);
        }
    }
}
