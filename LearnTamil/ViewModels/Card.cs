using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnTamil
{
    class Card
    {
        public string Front { get; set; }
        public string Back { get; set; }
        public string AudioUri { get; set; }

        public Card(Fact fact, StudyMode mode)
        {
            mode = StudyModeHelper.GetDirectStudyMode(mode);
            if (mode == StudyMode.Answer)
            {
                this.Front = fact.Question;
                this.Back = fact.Answer;
            }
            else
            {
                this.Front = fact.Answer;
                this.Back = fact.Question;
            }

            this.AudioUri = fact.AudioUri;
        }
    }
}
