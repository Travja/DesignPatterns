using System.Collections.Generic;
using Trivia.Models.Iterator;

namespace Trivia.Models.Composite
{
    public class TriviaController : Category
    {
        private List<Component> Items { get; set; } = new List<Component>();

        public TriviaController() : base("Basic", "Just some basic questions")
        {
            Add(new Question("What year was the very first model of the iPhone released?",
                new string[4] { "2007", "2005", "2006", "2008" }));
            Add(new Question("How many heading tags are in HTML?",
                new string[4] { "6", "5", "7", "4" }));

            Category viruses = new BasicCategory("Viruses", "Questions about Viruses");
            viruses.Add(new Question(
                "A program that neither replicates or copies itself, but does damage or compromises the security of the computer. Typically it relies on someone emailing it to you, it does not email itself, it may arrive in the form of a joke program or software of some sort. This is known as a:",
                new string[] { "Trojan", "Worm", "Joke Program", "Hoax" }));
            viruses.Add(new Question("Which of these is a documented hoax virus?",
                new string[] { "McDonalds Screensaver", "Merry Xmas", "Alien.worm", "Adolph" }));

            Category humanViruses = new AdvancedCategory("Human Viruses", "Questions about human virology");
            humanViruses.Add(new Question("What does the “19” in “COVID-19” refer to?",
                new string[]
                {
                    "The coronavirus was identified in 2019",
                    "This is the 19th coronavirus pandemic",
                    "There are 19 symptoms of coronavirus disease",
                    "There are 19 variants of the coronavirus"
                }));

            viruses.Add(humanViruses);
            viruses.Add(new Question(
                "In 1988 one of the most common viruses was unleashed. Activated every Friday the 13th, the virus affects both .EXE and .COM files and deletes any programs run on that day. What is the name of that virus?",
                new string[] { "Jerusalem", "I Love You", "Chernobyl", "Melissa" }));
            Add(viruses);

            Add(new Question(
                "This computer programming language was introduced by Niklaus Wirth in late 1970. What is the name of the language that was named after a famous French mathematician?",
                new string[4] { "Pascal", "Descartes", "Euler", "Gauss" }));
        }

        public override void Add(Component component) => Items.Add(component);

        public override void Remove(Component component) => Items.Remove(component);

        public override IEnumerator<Component> GetEnumerator() => new CompositeIterator(Title, Items.GetEnumerator());
    }
}