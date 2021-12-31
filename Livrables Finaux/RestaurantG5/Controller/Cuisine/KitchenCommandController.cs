using Newtonsoft.Json;
using RestaurantG5.Controller.Cuisine;
using RestaurantG5.Model.Common;
using RestaurantG5.Model.Salle.Role;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantG5.Controller
{
    public class KitchenCommandController
    {
        private IPAddress localIP;
        private IPEndPoint iPEndPoint;
        private Socket listener;
        private static List<Thread> commandsThread;

        public static List<Thread> CommandsThread { get => commandsThread; set => commandsThread = value; }

        static KitchenCommandController()
        {
            commandsThread = new List<Thread>();
        }

        public async Task InitSocketServerAsync()
        {
            this.localIP = IPAddress.Parse(Param.KICHEN_SERVER_LOCAL_IP);
            this.iPEndPoint = new IPEndPoint(localIP, Param.KITCHEN_SERVER_COMMAND_PORT);
            this.listener = new Socket(localIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Param.KITCHEN_SERVER_STARTED = true;
            await LoggerController.AppendLineToFile(Param.LOG_PATH, "Kitchen commands server started");
        }

        public void CloseSocketServer()
        {
            Param.KITCHEN_SERVER_STARTED = false;
            this.listener.Shutdown(SocketShutdown.Both);
            this.listener.Close();
            this.listener.Dispose();
        }

        public void SocketListen()
        {
            try
            {
                listener.Bind(this.iPEndPoint);
                listener.Listen(Param.SALLE_NUMBER);

                while (Param.KITCHEN_SERVER_STARTED == true)
                {
                    Thread command = new Thread(KitchenChiefTreatment);
                    CommandsThread.Add(command);
                    command.Start(listener);
                }
            }
#pragma warning disable CS0168 // La variable 'e' est déclarée, mais jamais utilisée
            catch (Exception e)
#pragma warning restore CS0168 // La variable 'e' est déclarée, mais jamais utilisée
            {
                //TODO LOG
            }
        }

#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone. Utilisez l'opérateur 'await' pour attendre les appels d'API non bloquants ou 'await Task.Run(…)' pour effectuer un travail utilisant le processeur sur un thread d'arrière-plan.
        private async void KitchenChiefTreatment(Object socket)
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone. Utilisez l'opérateur 'await' pour attendre les appels d'API non bloquants ou 'await Task.Run(…)' pour effectuer un travail utilisant le processeur sur un thread d'arrière-plan.
        {
            Socket listener = ((Socket)socket).Accept();
            byte[] bytes = new Byte[2048];
            int requestResult = listener.Receive(bytes);
            Group command = DeserializeGroup(bytes);
            List<Thread> recipesExecutions = new List<Thread>();
            //await LoggerController.AppendLineToFile(Parameters.LOG_PATH, "Command received : " + command.ID);

            //TODO COOKING TREATMENT HERE
            //comment
            if (command.State == GroupState.WaitEntree)
            {
                foreach (Client client in command.Clients)
                {
                    if (client.Entree != null)
                    {
                        Thread t = new Thread(KitchenReceipeController.GetReceipe);
                        recipesExecutions.Add(t);
                        t.Start(client.Entree);
                    }
                        

                }
            }
            else if (command.State == GroupState.WaitPlate)
            {
                foreach (Client client in command.Clients)
                {
                    if (client.Plate != null)
                    {
                        Thread t = new Thread(KitchenReceipeController.GetReceipe);
                        recipesExecutions.Add(t);
                        t.Start(client.Plate);
                    }
                }
            }
            else if (command.State == GroupState.WaitDessert)
            {
                foreach (Client client in command.Clients)
                {
                    if (client.Dessert != null)
                    {
                        Thread t = new Thread(KitchenReceipeController.GetReceipe);
                        recipesExecutions.Add(t);
                        t.Start(client.Dessert);
                    }
                }
            }
            //herte
            SpinWait.SpinUntil(() => Param.SPEED != 0);
            Thread.Sleep(10000 / Param.SPEED);
            listener.Send(SerializeGroup(command));
            Console.WriteLine("Command finished : " + command.ID);
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
