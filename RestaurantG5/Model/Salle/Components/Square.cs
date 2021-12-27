using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Role;
using System.Collections.Generic;

namespace RestaurantG5.Model.Salle.Components
{
    public class Square
    {
        private List<Table> tables;
        private List<ClientWaiter> waiters;
        private List<RankChief> rankChiefs;

        public List<ClientWaiter> Waiters { get => waiters; set => waiters = value; }
        public List<RankChief> RankChiefs { get => rankChiefs; set => rankChiefs = value; }
        public List<Table> Tables { get => tables; set => tables = value; }

        public Square()
        {
            this.tables = new List<Table>();
            this.waiters = new List<ClientWaiter>();
            this.rankChiefs = new List<RankChief>();



            for (int i = 0; i < Param.WAITER_BY_SQUARE; i++)
                this.waiters.Add(new ClientWaiter());
        }
    }
}
