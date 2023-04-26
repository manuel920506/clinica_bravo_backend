using AutoMapper;
using clinica_bravo_backend.DTOs;
using clinica_bravo_backend.Entities;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite.Geometries;  

namespace clinica_bravo_backend.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Topic, TopicCreationDTO>().ReverseMap();
            CreateMap<TopicCreationDTO, Topic>()
                .ForMember(x => x.Photo, options => options.Ignore());

            CreateMap<SubTopic, SubTopicDTO>().ReverseMap(); ; 

            CreateMap<Topic, TopicDTO>()
              .ForMember(x => x.Photo, opciones => opciones.Ignore())
              .ForMember(x => x.SubTopics, opciones => opciones.MapFrom(MapSubtopics));  

            CreateMap<IdentityUser, UserDTO>();
        }  
        private List<SubTopicDTO> MapSubtopics(Topic topic, TopicDTO topicDTO)
        {
            var response = new List<SubTopicDTO>();
            if (topic.SubTopics != null) {
                foreach (var subTopic in topic.SubTopics) {
                    response.Add(new SubTopicDTO() {
                        Id = subTopic.Id,
                        Name = subTopic.Name,
                        Description = subTopic.Description,
                        Photo = subTopic.Photo,
                        Order = subTopic.Order
                    });
                }
            }

            return response;
        }
    }
}
