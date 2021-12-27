using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Components;
using RestaurantG5.Model.Salle.Role;
using System.Collections.Generic;

namespace RestaurantG5.Controller
{
    class TableController
    {
        public Table OptimizedFindTable(List<Table> tables, int groupSize)
        {
            if (groupSize <= 10)
            {
                int i = groupSize;
                while (i <= 10)
                {
                    if (tables.Exists(table => table.NbPlaces == i && table.State == EquipementState.Available))
                        return tables.Find(table => table.NbPlaces == i && table.State == EquipementState.Available);
                    i++;
                }



            }
            return null;
        }

        public bool AttributionTableGroup(Group group, Table table)
        {
            if ((table.State == EquipementState.Available)
                && (table.NbPlaces >= group.Clients.Count))
            {
                table.Group = group;
                table.State = EquipementState.InUse;
                group.State = GroupState.WaitEntree;
                return true;
            }
            return false;
        }

        public static void CleanTable(Table table)
        {
            if (table.State == EquipementState.Dirty)
                table.State = EquipementState.Available;
        }

        public void DriveGroupTable(Table table, RankChief rankChief)
        {
            if (table.Group != null)
            {
                table.Group.Move(table.PosX, table.PosY);
                rankChief.Move(table.PosX - 32, table.PosY);
            }
        }

        public static bool Restock(Table table)
        {
            if ((table.State == EquipementState.InUse) && (table.Group != null))
            {
                SalleModel.Commis.Move(table.PosX, table.PosY);
                return StockEquipement.Instance.SubstractEquipement("BreadBasket");
            }
            return false;
        }
    }
}
