using Newtonsoft.Json;
using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Components;
using RestaurantG5.Model.Salle.Role;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantG5.Controller
{
    public class CommandController
    {
        private IPAddress localIP;
        private IPEndPoint iPEndPoint;
        private Socket sender;
        private static IPAddress IP;
        private static IPEndPoint EndPoint;
        private readonly object syncLock = new object();

        private HotelMaster hotelMaster;

        private static CommandController instance;

        public static CommandController Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommandController();
                return instance;
            }
        }

        public HotelMaster HotelMaster { get => hotelMaster; set => hotelMaster = value; }

        public CommandController() { }

        public async Task InitClientSocketAsync()
        {
            this.localIP = IPAddress.Parse(Param.SALLE_CLIENT_LOCAL_IP);
            this.iPEndPoint = new IPEndPoint(localIP, Param.SALLE_CLIENT_COMMAND_PORT);
            IP = IPAddress.Parse(Param.SALLE_CLIENT_LOCAL_IP);
            EndPoint = new IPEndPoint(localIP, Param.SALLE_CLIENT_COMMAND_PORT);
            this.sender = new Socket(localIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Param.SALLE_CLIENT_STARTED = true;
            await LoggerController.AppendLineToFile(Param.LOG_PATH, "Salle commands client started");
        }

        public void CloseSocket()
        {
            Param.SALLE_CLIENT_STARTED = false;
            this.sender.Shutdown(SocketShutdown.Both);
            this.sender.Close();
            this.sender.Dispose();
        }

        public void SocketConnect()
        {
            byte[] bytes = new byte[2048];
            sender.Connect(this.iPEndPoint);
            while (Param.SALLE_CLIENT_STARTED == true)
            {
                int counter = sender.Receive(bytes);
                if (counter > 0)
                {
                    Group group = DeserializeGroup(bytes);
                    Console.WriteLine(group.ID);
                }
            }
        }

        public static void ConnectAndSendCommand(Object objectGroup)
        {
            try
            {
                Socket sender = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                byte[] bytes = new byte[2048];

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(EndPoint);

                    // Encode the data string into a byte array.  
                    byte[] msg = SerializeGroup((Group)objectGroup);

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Group group = DeserializeGroup(bytes);
                    Console.WriteLine("Salle: commande reçu du groupe " + group.ID);
                    if (group != null)
                    {
                        Table groupTable = Instance.RetrieveTableFromGroup(group);
                        Instance.ChangeStateByGroup(groupTable);
                        groupTable.Group.Notify();
                        Console.WriteLine("Table " + groupTable.Group.ID + ", " + groupTable.Group.State + " : " + groupTable.Dessert);
                    }

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public Table RetrieveTableFromGroup(Group group)
        {
            /*List<Table> tablesRepository = new List<Table>();
            hotelMaster.RankChiefs.ForEach(r => tablesRepository.AddRange(r.Squares[0].Tables));
            if (tablesRepository != null)
            {
                Table table = tablesRepository.Find(t => t.Group.ID == group.ID);
                return table;
            }*/
            Table table = null;
            if (hotelMaster != null && hotelMaster.RankChiefs != null)
                hotelMaster.RankChiefs.ForEach(r => {
                    if (r.Squares[0].Tables != null)
                    {
                        if (r.Squares[0].Tables.Exists(t => (t.Group != null) ? t.Group.ID == group.ID : false))
                        {
                            Console.WriteLine("Table found");
                            table = r.Squares[0].Tables.Find(t => (t.Group != null) ? t.Group.ID == group.ID : false);
                        }
                        else
                        {
                            Console.WriteLine("Table not found");
                        }

                    }
                });
            return table;
        }

        public void ChangeStateByGroup(Table table)
        {
            switch (table.Group.State)
            {
                case GroupState.WaitEntree:
                    table.Entree = true;
                    table.Group.State = GroupState.WaitPlate;
                    break;
                case GroupState.WaitPlate:
                    table.Plate = true;
                    table.Group.State = GroupState.WaitDessert;
                    break;
                case GroupState.WaitDessert:
                    table.Dessert = true;
                    table.Group.State = GroupState.WaitBill;
                    break;
            }
        }

        public static byte[] SerializeGroup(Group group)
        {
            string groupJSON = JsonConvert.SerializeObject(group);
            byte[] bytes = Encoding.ASCII.GetBytes(groupJSON);
            return bytes;
        }

        public static Group DeserializeGroup(byte[] bytes)
        {
            string groupJSON = Encoding.ASCII.GetString(bytes);
            Group group = JsonConvert.DeserializeObject<Group>(groupJSON);
            return group;
        }
    }
}
