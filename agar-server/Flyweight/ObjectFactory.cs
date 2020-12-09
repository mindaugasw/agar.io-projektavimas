using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using agar_server.Game;
using agar_server.Game.Objects;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static agar_server.Game.Utils;

namespace agar_server.Flyweight
{
    class ObjectFactory
    {
        // HashMap stores the reference to the object
        private static Dictionary<String, MapObject> hm = new Dictionary<String, MapObject>();

        public static MapObject getObject(String type)
        {
            MapObject p = null;

            /* If an object for TS or CT has already been 
               created simply return its reference */
            if (hm.ContainsKey(type))
                p = hm[type].Clone();
            else
            {
                switch (type)
                {
                    case "GreenFood":
                    case "RedFood":
                        p = new Food() { Id = "0", Position = new Point(), Name = type };
                    break;
                    case "GreenVirus":
                    case "RedVirus":
                        p = new Virus() { Id = "0", Position = new Point(), Name = type };
                    break;
                    case "BluePoison":
                    case "CyanPoison":
                    case "DarkBluePoison":
                        p = new Poison() { Id = "0", Position = new Point(), Name = type };
                    break;
                }
                hm.Add(type, p);
            }

            // Once created insert it into the HashMap 
            return p;
        }
    }
}