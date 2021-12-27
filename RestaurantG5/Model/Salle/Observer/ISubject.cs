using RestaurantG5.Model.Common;

namespace RestaurantG5.Model.Salle.Observer
{
    public interface ISubject
    {
        void Notify(Group group);

        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);
    }
}
