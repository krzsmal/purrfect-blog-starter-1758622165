using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PurrfectBlog.Models;

namespace PurrfectBlog.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PurrfectBlog.Models.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PurrfectBlog.Models.BlogDbContext context)
        {
            context.BlogPosts.AddOrUpdate(
                p => p.Title,
                new BlogPost
                {
                    Title = "My Cat's First Day at Home",
                    Content = "When I first brought Whiskers home from the shelter, she was so scared that she hid under the couch for three hours! I was worried she'd never come out, but eventually, the smell of tuna got the better of her curiosity.\n\nNow, three months later, she's the queen of the house and acts like she's lived here forever. She has claimed the sunny spot by the window as her personal throne and gives me the most judgmental looks when I'm late with her breakfast.\n\nIt's amazing how quickly cats can go from terrified shelter animals to confident household rulers. Whiskers has definitely made our house feel more like a home.",
                    Category = "Heartwarming",
                    CreatedAt = DateTime.Now.AddDays(-15)
                },
                new BlogPost
                {
                    Title = "The Great Toilet Paper Incident",
                    Content = "Picture this: I come home from work to find my entire bathroom covered in shredded toilet paper. At first, I thought we'd been robbed by the world's messiest burglar. Then I saw the culprit – my cat Shadow, sitting proudly in the middle of the chaos with a piece of toilet paper still hanging from his whisker.\n\nApparently, while I was gone, Shadow had discovered that toilet paper rolls make excellent toys. He had managed to unroll three entire rolls and had turned my bathroom into what looked like a very festive, if somewhat inconvenient, winter wonderland.\n\nThe cleanup took an hour, but I couldn't stay mad at that satisfied little face. Now I keep the toilet paper in a closed cabinet. Lesson learned!",
                    Category = "Funny",
                    CreatedAt = DateTime.Now.AddDays(-8)
                },
                new BlogPost
                {
                    Title = "The Clever Cat",
                    Content = "Why was the cat sitting on the computer?\r\nBecause it wanted to keep an eye on the mouse!",
                    Category = "Joke",
                    CreatedAt = DateTime.Now.AddDays(-3)
                }
            );
        }
    }
}