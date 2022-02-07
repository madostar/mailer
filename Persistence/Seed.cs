using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {

            if (context.Messages.Any()) return;
            
            

            var messages = new List<Message>{
                new Message
                {
                    Subject = "Hello",
                    Content = "This is your friend ",
                    Unread = true
                },
                new Message
                {
                    Subject = "Are you single?",
                    Content = "Findr is a new dating technology that finds single people around you",
                    Unread = true
                },
                new Message
                {
                    Subject = "Job status",
                    Content = "We regret to inform you that you have been fired from your position for bad misconduct",
                    Unread = true
                },
                new Message
                {
                    Subject = "Google dot com",
                    Content = "Hey google where to find fun events for people over 70??",
                    Unread = true
                },
                new Message
                {
                    Subject = "Congratulations!",
                    Content = "You have won 0.0056 BTC!!!! please go to this link and enter your wallet address to collect the the reward!!!!",
                    Unread = true
                },
                new Message
                {
                    Subject = "Canada Express",
                    Content = "Hi this is Linda from Canada immigration agency and I would like to contact you to finish your paperwork!",
                    Unread = true
                },
                new Message
                {
                    Subject = "Job Application",
                    Content = "We are glad to tell you that you have been selected for this job position!!!",
                    Unread = true
                }
            };
            await context.Messages.AddRangeAsync(messages);
            await context.SaveChangesAsync();
        }
    }
}