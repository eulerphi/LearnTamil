using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LearnTamil
{
    class LearnViewModel : INotifyPropertyChanged
    {
        #region Properties

        private List<Card> Cards { get; set; }

        private Card card_;
        public Card Card
        {
            get { return this.card_; }
            set { this.card_ = value; this.NotifyPropertyChanged("Card"); }
        }
        
        private int currentIndex_;
        private int CurrentIndex
        {
            get { return this.currentIndex_; }
            set { this.currentIndex_ = value; this.NotifyPropertyChanged("Current"); }
        }

        public int Current
        {
            get { return this.CurrentIndex + 1; }
        }

        private int total_;
        public int Total
        {
            get { return this.total_; }
            set { this.total_ = value; this.NotifyPropertyChanged("Total"); }
        }

        private bool isFlipped_;
        public bool IsFlipped
        {
            get { return this.isFlipped_; }
            set { this.isFlipped_ = value; this.NotifyPropertyChanged("IsFlipped"); }
        }

        #endregion Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            var eh = this.PropertyChanged;
            if (eh != null)
            {
                eh(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Events

        public LearnViewModel(int lessonId)
        {
            var lesson = new Lessons()[lessonId - 1];
            this.Cards = lesson.Facts
                               .Select(f => new Card(f, StudyMode.QuestionOrAnswer))
                               .ToList();
            this.Total = this.Cards.Count;

            this.Cards.ShuffleSort();
            this.SetCard(0);
        }

        public void Flip()
        {
            this.IsFlipped = !this.IsFlipped;
        }

        public bool MoveNext()
        {
            var nextIndex = this.CurrentIndex + 1;
            return this.SetCard(nextIndex);
        }

        public bool MovePrevious()
        {
            var previousIndex = this.CurrentIndex - 1;
            return this.SetCard(previousIndex);
        }

        private bool SetCard(int index)
        {
            if (index >= this.Total || index < 0)
            {
                return false;
            }

            this.Card = this.Cards[index];
            this.CurrentIndex = index;
            this.IsFlipped = false;

            return true;
        }
    }
}
