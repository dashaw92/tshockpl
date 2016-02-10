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

        public override string Name { get { return "Hello World"; } }
        public override string Author { get { return "Daniel Shaw"; } }
        public override string Description { get { return base.Description; } }
        public override Version Version { get { return new Version(1, 0); } }


        public override void Initialize() {
            TShockAPI.GetDataHandlers.PlayerInfo += PlayerInfo;
        }

        void PlayerInfo(object sender, TShockAPI.GetDataHandlers.PlayerInfoEventArgs args) {
            Console.WriteLine(args.Name + " just called a PlayerInfo event.");
            Console.WriteLine(args.Name + " has " + args.Hair + " hair!");
        }
    }
}
