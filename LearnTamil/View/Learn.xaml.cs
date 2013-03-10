using System;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace LearnTamil
{
    public partial class Learn : PhoneApplicationPage
    {
        private LearnViewModel Model { get; set; }

        public Learn()
        {
            InitializeComponent();
            this.FrontToBack90.Completed += FrontToBack90_Completed;
            this.BackToFront90.Completed += BackToFront90_Completed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int lessonId = this.GetLessonId();
            this.DataContext = this.Model = new LearnViewModel(lessonId);
        }

        private int GetLessonId()
        {
            string lessonId;
            if (NavigationContext.QueryString.TryGetValue("lessonId", out lessonId))
            {
                return int.Parse(lessonId);
            }

            return 0;
        }

        private void OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.Model.IsFlipped)
            {
                this.BackToFront90.Begin();
            }
            else
            {
                this.FrontToBack90.Begin();
            }
        }

        private void OnPlay(object sender, EventArgs e)
        {
            this.Player.Play();
        }

        private void OnFlick(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            const int flickNextThreshold = -15;
            const int flickPreviousThreshold = 15;

            if (e.TotalManipulation.Translation.X < flickNextThreshold)
            {
                if (this.Model.MoveNext())
                {
                    this.NextCard.Begin();
                }
            }

            if (e.TotalManipulation.Translation.X > flickPreviousThreshold)
            {
                if (this.Model.MovePrevious())
                {
                    this.PreviousCard.Begin();
                }
            }
        }

        private void BackToFront90_Completed(object sender, EventArgs e)
        {
            this.Model.Flip();
            this.BackToFront0.Begin();
        }

        private void FrontToBack90_Completed(object sender, EventArgs e)
        {
            this.Model.Flip();
            this.FrontToBack180.Begin();
        }
    }
}