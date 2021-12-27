using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Components;
using RestaurantG5.Model.Salle.Factory;
using RestaurantG5.Model.Salle.Role;
using System;

namespace RestaurantG5
{
    public class HomeController
    {
        private HotelMaster hotelMaster;

        public HomeController(HotelMaster hotelMaster)
        {
            this.hotelMaster = hotelMaster;
        }

        public Client GenerateClient()
        {
            Client client;
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
            switch (randomNumber)
            {
                case int rn when (rn <= 20):
                    client = ClientFactoryC.Instance.CreateClient();
                    break;

                case int rn when (rn > 20 && rn < 80):
                    client = ClientFactoryA.Instance.CreateClient();
                    break;

                case int rn when (rn >= 80 && rn <= 100):
                    client = ClientFactoryB.Instance.CreateClient();
                    break;

                default:
                    client = ClientFactoryA.Instance.CreateClient();
                    break;
            }

            return client;
        }

        public Group CreateGroup(int clientNumber)
        {
            Group group = new Group();
            for (int i = 0; i < clientNumber; i++)
            {
                group.Clients.Add(this.GenerateClient());
            }
            return group;
        }

        public bool CheckAvailableTables(Group group)
        {
            return this.hotelMaster.RankChiefs.Exists(
                rankchief => rankchief.Squares[0].Tables.Exists(
                    table => (table.State == EquipementState.Available)
                        && (table.NbPlaces >= group.Clients.Count)));
        }

        public RankChief FindRankChief(Group group)
        {
            RankChief designatedRankchief = this.hotelMaster.RankChiefs.Find(
                rankchief => rankchief.Squares[0].Tables.Exists(
                    table => table.Group == group));
            return designatedRankchief;
        }

        public void CallRankChief(RankChief rankChief)
        {
            if (rankChief != null)
                rankChief.Move(hotelMaster.PosX - 10, hotelMaster.PosY);
        }
    }
}
