using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearnTamil
{
    class Fact
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string AudioUri { get; set; }

        public Fact(XElement xml, string lessonId, int factId)
        {
            this.Question = xml.Attribute("Question").Value;
            this.Answer = xml.Attribute("Answer").Value;
            this.AudioUri = String.Format("Assets/LessonAudio/{0}/{1}.mp3", lessonId, factId);
        }
    }
}
