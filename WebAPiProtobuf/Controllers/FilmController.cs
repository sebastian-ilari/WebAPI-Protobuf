using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Model;

namespace WebAPiProtobuf.Controllers
{
    public class FilmController : ApiController
    {
        private readonly IList<Film> films = new List<Film>
            {
                new Film
                {
                    Id = 1,
                    Brand = "Kodak",
                    Model = "Tri-X",
                    Color = false,
                    Iso = new List<int> {100, 400},
                    Frames = 36,
                    Size = 35,
                    DevelopingTimes = new List<DevelopingTime>
                    {
                        new DevelopingTime
                        {
                            Id = 1,
                            Iso = 400,
                            Development = 780,
                            Stop = 30,
                            Fix = 300,
                            AgitationInterval = 30,
                        }
                    }
                },
                new Film
                {
                    Id = 2,
                    Brand = "Kodak",
                    Model = "TMAX",
                    Color = false,
                    Iso = new List<int> {100, 400},
                    Frames = 36,
                    Size = 35,
                    DevelopingTimes = new List<DevelopingTime>
                    {
                        new DevelopingTime
                        {
                            Id = 2,
                            Iso = 400,
                            Development = 640,
                            Stop = 30,
                            Fix = 600,
                            AgitationInterval = 30,
                        }
                    }
                },
                new Film
                {
                    Id = 3,
                    Brand = "Adox",
                    Model = "Silvermax",
                    Color = false,
                    Iso = new List<int> {100},
                    Frames = 36,
                    Size = 35,
                    DevelopingTimes = new List<DevelopingTime>
                    {
                        new DevelopingTime
                        {
                            Id = 3,
                            Iso = 100,
                            Development = 480,
                            Stop = 30,
                            Fix = 420,
                            AgitationInterval = 30,
                        },
                        new DevelopingTime
                        {
                            Id = 4,
                            Iso = 100,
                            PushedOrPulledTo = 400,
                            Development = 750,
                            Stop = 30,
                            Fix = 600,
                            AgitationInterval = 30,
                        },
                    }
                }
            };

        // GET api/films
        public IEnumerable<Film> Get()
        {
            return this.films;
        }

        // GET api/films/5
        public Film Get(int id)
        {
            return this.films.FirstOrDefault(f => f.Id.Equals(id));
        }
    }
}
