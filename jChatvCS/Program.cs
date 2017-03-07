using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;
using System.Collections;

namespace jChatvCS
{
    class Program
    {

        static void Main(string[] args)
        {

        }
    }

    class ClientServer
    {
        //Structure for Holding Information About connection
        //  Clients -   Use it to hold information about servers they
        //              they are connected to and the rooms that are
        //              available on that server
        //  Server  -   
        public struct conn
        {
            string ip;                  //IP to connect to or listen on
            int port;                   //Port to connect to or listen on. Default is 8088
                                        //  
            private struct room         //Structure for handling basic functionality of a group chat
            {
                int ID;                 //The Name/ID of the room
                string key;             //A key to allow clients to enter room
                List<string> roomLog;   //Lines of strings of communication in the room since
                                        //  its inception or joining (for clients)
                bool connStat;          //Boolean of Whether you're subscribed to communication
                                        //  from this room. (Default to True for servers)
            };

            List<room> rooms;       //List of rooms
                                    //  Clients ->  Represents a list of available rooms on each
                                    //              server specified in the conn object (this)
                                    //  Servers ->  Represents a list of rooms on the server
                                    //              that the client specified in the conn object is 
                                    //              connected to

            NetworkStream stream;   //NetworkStream object that handles all incoming and outgoing
                                    //  communication with the client/server specified in the conn
                                    //      Clients ->  stream Routes incoming communication from the 
                                    //                  server conn into the appropriate room based on
                                    //                  their room ID in rooms if the client is subscribed.
                                    //                  stream Routes outgoing messages to the appropriate
                                    //                  room on the server by signing it with a room ID based
                                    //                  on clients roomList.
                                    //      Servers ->  stream routes all incoming messages from the client
                                    //                  into the appropriate room based on their room ID and
                                    //                  then broadcast it to all other client conns
                                    //                  stream routes all outgoing broadcast messages to
                                    //                  all clients currently subscribed to the room
                                    //

        };

        
        private bool mode;          // {True, False} -> {Server, CLient} 
        private TcpListener server; // Server For Server Mode
        private TcpClient   client; // Client For Client Mode

        //Array of Connections 
        private conn[] connections;

        //Network Information
        private string ip;
        private List<string> ARP;  

        //Default Constructor
        //  -Mode       -> Client Mode
        //  -Connections-> Array of Connections 
        public ClientServer()
        {
            //Set to Client Mode
            mode = false;


        }

        //Constructor For creating ClientServers with predefined connections/rooms
        //  - Client Mode
        //      + conns ->  Specifies a list of ip addresses to look for servers on
        //                  and by default the feedback loop address is added. 
        //                  **The rooms parameter of conns is ignored for clients
        //  - Server Mode
        //      + conns ->  Specifies  
        //  
        //  
        //
        public ClientServer(bool mode, conn[] conns)
        {

        }

        public void init()
        {
            if (mode)
            {
                initServer();
            }
            else
            {
            };
        }

        public TcpClient initClient()
        {
            TcpClient client = new TcpClient();

            return client;
        }

        public TcpListener initServer()
        {
            TcpListener server = new TcpListener(System.Net.IPAddress("127.0.0.1"), 8088);

            return server;
        }

    }
}
