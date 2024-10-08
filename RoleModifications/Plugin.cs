﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using Exiled.API.Features;
using Exiled;
using Exiled.Events;
using Exiled.API.Enums;
using Exiled.Events.Handlers;

namespace RoleModifications
{
    public class RoleModifications : Plugin<Config>
    {
        public override string Name { get; } = "RoleModifications";
        public override string Author { get; } = "alone";
        public override string Prefix { get; } = "RoleModifications";
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override Version Version { get; } = new Version(1, 0, 0);

        public static RoleModifications plugin { get; private set; }
        private EventHandlers _EventHandlers;
        public Dictionary<string, ZoneType> PlayerZones { get; set; } = new Dictionary<string, ZoneType>();
        public List<RoomType> SafeRooms { get; set; } = new List<RoomType> { RoomType.LczAirlock, RoomType.LczCrossing, RoomType.LczCurve, RoomType.LczStraight, RoomType.LczTCross, RoomType.HczTCross, RoomType.HczCrossing, RoomType.HczStraight, RoomType.EzCrossing, RoomType.EzStraight, RoomType.EzTCross };

        public override void OnEnabled()
        {
            plugin = this;
            _EventHandlers = new EventHandlers();

            Exiled.Events.Handlers.Player.Spawned += _EventHandlers.OnSpawned;
            Exiled.Events.Handlers.Player.Hurting += _EventHandlers.OnHurting;
            Exiled.Events.Handlers.Player.ChangingRole += _EventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Player.TriggeringTesla += _EventHandlers.OnTriggeringTesla;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            plugin = null;
            _EventHandlers = null;

            Exiled.Events.Handlers.Player.Spawned -= _EventHandlers.OnSpawned;
            Exiled.Events.Handlers.Player.Hurting -= _EventHandlers.OnHurting;
            Exiled.Events.Handlers.Player.ChangingRole -= _EventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Player.TriggeringTesla -= _EventHandlers.OnTriggeringTesla;

            base.OnDisabled();
        }
    }
}
