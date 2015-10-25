using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;

namespace Fundamentals.Controllers
{
    [RoutePrefix("api")]
    public class DataController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id == 1)
            {
                var eventData = new Event
                {
                    Id = 1,
                    Name = "Angular Boot Camp",
                    Date = "1/1/2013",
                    Time = "10:30 am",
                    Location = new Location
                    {
                        Address = "Google Headquarters",
                        City = "Mountain View",
                        Province = "CA"
                    },
                    ImageUrl = "/img/angularjs-logo.png",
                    Sessions = new List<Session>
                    {
                        new Session
                        {
                            Name = "Directives Masterclass",
                            CreatorName = "Zack Sullivan",
                            Duration = 1,
                            Level = "Advanced",
                            Abstract = "In this sesison you will learn the ins and outs of directives!",
                            UpVoteCount = 0
                        },
                        new Session
                        {
                            Name = "All about Scopes for fun and profit",
                            CreatorName = "John Doe",
                            Duration = 2,
                            Level = "Introductory",
                            Abstract =
                                "This session will take a closer look at scopes.  Learn what they do, how they do it, and how to get them to do it for you.",
                            UpVoteCount = 0
                        },
                        new Session
                        {
                            Name = "Well Behaved Controllers",
                            CreatorName = "Jane Doe",
                            Duration = 4,
                            Level = "Intermediate",
                            Abstract =
                                "Controllers are the beginning of everything Angular does.  Learn how to craft controllers that will win the respect of your friends and neighbors.",
                            UpVoteCount = 0
                        }
                    }
                };

                return Ok(eventData);
            }
            else
            {
                return BadRequest("event does not exist");
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Domain.Event eventData)
        {
            if (eventData == null)
                return BadRequest("Event Empty");

            return Ok("Event Saved!");
        }
    }



}
