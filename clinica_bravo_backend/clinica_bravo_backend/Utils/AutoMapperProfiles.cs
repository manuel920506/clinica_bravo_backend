using AutoMapper;
using clinica_bravo_backend.DTOs;
using clinica_bravo_backend.Entities;
using NetTopologySuite.Geometries;  

namespace clinica_bravo_backend.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        { 
            CreateMap<SubTopic, SubTopicDTO>(); 

            CreateMap<Topic, TopicDTO>() 
                .ForMember(x => x.SubTopics, opciones => opciones.MapFrom(MapSubtopics)); 

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
                        URL = subTopic.URL
                    });
                }
            }

            return response;
        }
    }
}
