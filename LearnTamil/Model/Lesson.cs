using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearnTamil
{
    class Lesson
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public string Uri { get; private set; }
        public IList<Fact> Facts { get; private set; }

        public Lesson(XElement xml)
        {
            this.Name = xml.Attribute("Name").Value;
            this.Id = xml.Attribute("Id").Value;
            this.Uri = String.Format("/View/Learn.xaml?lessonId={0}", this.Id);
            this.Facts = this.GetFacts(xml).ToList();
        }

        private IEnumerable<Fact> GetFacts(XElement xml)
        {
            var factId = 1;
            return from fact in xml.Elements("Fact")
                   select new Fact(fact, this.Id, factId++);
        }
    }
}
