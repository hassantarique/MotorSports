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
                    Description = "Small Stadium",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name = "Point 1",
                            Description = "Description for point 1 goes here."
                        }
                    }
                },
                new EventDto()
                {
                    Id= 2,
                    Name = "EventTwo",
                    Description = "Normal Stadium",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Point 2",
                            Description = "Description for point 2 goes here."
                        }
                    }
                },
                new EventDto()
                {
                    Id = 3,
                    Name = "EventThree",
                    Description = "Big Stadium",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Point 3",
                            Description = "Description for point 3 goes here."
                        }
                    }
                }
            };
        }
    }
}
