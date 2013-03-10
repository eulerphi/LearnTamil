using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearnTamil
{
    class Lessons : List<Lesson>
    {
        public Lessons()
        {
            this.AddRange(this.GetLessons());
        }

        private IEnumerable<Lesson> GetLessons()
        {
            var xml = this.LoadLessonsXml();

            return from lesson in xml.Element("Lessons").Elements("Lesson")
                   select new Lesson(lesson);
        }

        private XDocument LoadLessonsXml()
        {
            const string uri = "Resources/Lessons.xml";
            return XDocument.Load(uri);
        }
    }
}
