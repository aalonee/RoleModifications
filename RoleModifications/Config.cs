using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using Exiled.API.Features;
using System.ComponentModel;
using PlayerRoles;
using Exiled.API.Enums;
using PluginAPI.Roles;
using UnityEngine;

namespace RoleModifications
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Modifies HP of roles. You can add roles from here: https://discord.com/channels/656673194693885975/1168331896187519086/1168331896187519086")]
        public Dictionary<RoleTypeId, int> Health { get; set; } = new Dictionary<RoleTypeId, int>()
        {
            { RoleTypeId.NtfCaptain, 100 },
        };

        [Description("Gives provided effects to player on spawn")]
        public Dictionary<RoleTypeId, List<Effect>> Effects { get; set; } = new Dictionary<RoleTypeId, List<Effect>>()
        {
            { RoleTypeId.Tutorial, new List<Effect> { new Effect() { Type = EffectType.MovementBoost, Intensity = 1, IsEnabled = false } } },
        };

        [Description("Modifies spawn room of the role")]
        public Dictionary<RoleTypeId, RoomType> SpawnRoom { get; set; } = new Dictionary<RoleTypeId, RoomType>()
        {
            { RoleTypeId.Spectator, RoomType.Surface }
        };

        [Description("Modifies spawn coordinates of the role (overrides spawn room)")]
        public Dictionary<RoleTypeId, Vector3> SpawnCoordinates { get; set; } = new Dictionary<RoleTypeId, Vector3>()
        {
            { RoleTypeId.Spectator, new Vector3(0, 0, 0) }
        };

        [Description("Modifies inventory of the role")]
        public Dictionary<RoleTypeId, List<ItemType>> Inventory { get; set; } = new Dictionary<RoleTypeId, List<ItemType>>()
        {
            { RoleTypeId.ClassD, new List<ItemType> { ItemType.Coin } }
        };

        [Description("SCP-049 kills people with 1 hit?")]
        public bool scp049OneShot { get; set; } = true;

        [Description("SCP-106 banishes players to the PD with 1 hit?")]
        public bool scp106OneShot { get; set; } = true;

        [Description("SCP-096 kills people with 1 hit?")]
        public bool scp096OneShot { get; set; } = true;

        public bool GodmodeTutorial { get; set; } = true;

        [Description("Will tesla ignore players in godmode?")]
        public bool TeslaIgnoresGodmode { get; set; } = true;

        [Description("Will CustomRoles be ignored?")]
        public bool IgnoreCustomRoles { get; set; } = true;
    }
}
