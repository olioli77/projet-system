namespace RestaurantG5.Model.Salle.Components
{
    public enum EquipementState
    {
        Available,
        InUse,
        Dirty
    };
    public class Equipement
    {
        private EquipementState state;

        public EquipementState State { get => state; set => state = value; }

        public Equipement()
        {
            this.state = EquipementState.Available;
        }
    }
}
