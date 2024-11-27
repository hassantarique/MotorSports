using Microsoft.OpenApi.Services;
using MotorSports.APILearning.NewFolder;
namespace MotorSports.APILearning
{
    public class EventDataStore
    {
        public List<EventDto> Events { get; set; }
        public static EventDataStore Current {get; } = new EventDataStore();

        public EventDataStore()
        {
            Events = new List<EventDto>()
            {
                new EventDto()
                {
                    Id = 1,
                    Name = "EventOne",
                    Description = "Small Stadium"
                },
                new EventDto()
                {
                    Id= 2,
                    Name = "EventTwo",
                    Description = "Normal Stadium"
                },
                new EventDto()
                {
                    Id = 3,
                    Name = "EventThree",
                    Description = "Big Stadium"
                }
            };
        }
    }
}
