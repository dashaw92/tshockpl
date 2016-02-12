using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//These are required to make a plugin
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace TShock_Hello
{
    //1.3.0.8
    [ApiVersion(1, 22)]
    public class HelloWorld : TerrariaPlugin
    {                                                                                                                   
        public HelloWorld(Main game) : base(game) { }

        public override string Name { get { return "Testing"; } }
        public override string Author { get { return "Daniel Shaw"; } }
        public override string Description { get { return base.Description; } }
        public override Version Version { get { return new Version(1, 0); } }


        public override void Initialize()
        {
			TShockAPI.Commands.ChatCommands.Add(new Command("", ListCommand, new string[] { "list" }));
			TShockAPI.Commands.ChatCommands.Add(new Command("", ClearCommand, new string[] { "ci" }));
			//TShockAPI.GetDataHandlers.ItemDrop += ItemDropEvent;
        }

		void ClearCommand(CommandArgs args)
		{
			args.Player.SendData(PacketTypes.ConnectRequest);
		}

		void ListCommand(CommandArgs args)
		{
			bool listID = false;
			if (!(args.Parameters.Count < 1))
			{
				if (args.Parameters[0].Trim().ToLower().Equals("true"))
				{
					listID = true;
				}
			}
			string result = "";
			foreach (String s in TShock.Utils.GetPlayers(listID))
			{
				result = result + ", " + s;
			}
			Color temp = new Color();
			temp.R = 0;
			temp.G = 125;
			temp.B = 0;
			args.Player.SendMessage("Players online: " + result, temp);
		}

		void PlayerInfo(object sender, TShockAPI.GetDataHandlers.PlayerInfoEventArgs args)
		{
			
		}
    }
}
