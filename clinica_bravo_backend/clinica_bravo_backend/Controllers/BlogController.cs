using AutoMapper;
using clinica_bravo_backend.DTOs;
using clinica_bravo_backend.Entities;
using clinica_bravo_backend.Filters;
using clinica_bravo_backend.Repositories;
using clinica_bravo_backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinica_bravo_backend.Controllers {
    [ApiController]
    [Route("api/Blog")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class BlogController : ControllerBase {
        private readonly IRepository repository; 
        private readonly ILogger<BlogController> logger;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
         private readonly IStorageFiles storageFiles;
        private readonly string container = "topics";
        public BlogController(ApplicationDbContext context, 
            IRepository repository, 
            ILogger<BlogController> logger,
            IMapper mapper,
            IStorageFiles storageFiles) {
            this.context = context;
            this.repository = repository; 
            this.logger = logger;
            this.mapper = mapper;
            this.storageFiles = storageFiles;
        }

        [HttpGet] // api/Blog
        [HttpGet("list")] // api/Blog/list
        [HttpGet("/listTopics")] // /listTopics
        [ResponseCache(Duration = 60)]
        [ServiceFilter(typeof(MyActionFilter))]
        [AllowAnonymous]
        public async Task<ActionResult<List<TopicDTO>>> GetList() {
            logger.LogInformation("Let's show the topics");
           
            var topics  = await context.Topics.ToListAsync();
            return mapper.Map<List<TopicDTO>>(topics);
        }


        [HttpGet("Id:int")]
        [AllowAnonymous]
        public async Task<ActionResult<TopicDTO>> Get(int Id) {
            logger.LogInformation($"Let's show the topic with id {Id}");

            var topic = await context.Topics
                .Include(x => x.SubTopics).ThenInclude(x => x.Topic)
                .FirstOrDefaultAsync(t => t.Id == Id);
            if (topic == null) { 
                return NotFound(); 
            }
            return mapper.Map<TopicDTO>(topic); 
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Post([FromForm] TopicCreationDTO topicCreationDTO) {
            var topic = mapper.Map<Topic>(topicCreationDTO);

            if (topic.Photo != null) {
                //topic.URL = await storageFiles.SaveFile(container, topicCreationDTO.URL);
            }

            context.Add(topic);
            await context.SaveChangesAsync();
            return topic.Id;
        } 
    }
}
