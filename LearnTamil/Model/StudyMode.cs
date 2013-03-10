using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnTamil
{
    enum StudyMode
    {
        Question,
        Answer,
        QuestionOrAnswer
    }

    class StudyModeHelper
    {
        private static Random random = new Random();
        public static StudyMode GetDirectStudyMode(StudyMode source)
        {
            if (source == StudyMode.QuestionOrAnswer)
            {
                source = random.NextDouble() > 0.5
                    ? StudyMode.Question
                    : StudyMode.Answer;
            }

            return source;
        }
    }
}
