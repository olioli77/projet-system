using RestaurantG5.Model.Common;
using System.Collections.Generic;

namespace RestaurantG5.Model.Salle.Observer
{
    public class Subject : ISubject
    {
        protected List<IObserver> observers;

        public Subject()
        {
            this.observers = new List<IObserver>();
        }

        public void Notify(Group group)
        {
            this.observers.ForEach(observer => observer.Update(group));
        }

        public void Subscribe(IObserver observer)
        {
            if (observer != null)
                this.observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public int Count
        {
            get
            {
                return observers.Count;
            }
        }
    }
}
