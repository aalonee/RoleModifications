using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features.DamageHandlers;
using Exiled.CustomRoles.API.Features;
using Exiled.CustomRoles.API;
using PlayerRoles;

namespace RoleModifications
{
    public class EventHandlers
    {
        private static Config config = RoleModifications.plugin.Config;
        public void OnSpawned(SpawnedEventArgs e)
        {
            if (e.Player.GetCustomRoles().Any() && config.IgnoreCustomRoles)
                return;
            var role = e.Player.Role;
            if (role.Type == RoleTypeId.Tutorial && config.GodmodeTutorial)
                e.Player.IsGodModeEnabled = true;
            if (config.SpawnCoordinates.TryGetValue(role, out var coords) && role.SpawnFlags.HasFlag(RoleSpawnFlags.UseSpawnpoint))
            {
                e.Player.Teleport(coords);
            }
            else if (config.SpawnRoom.TryGetValue(role, out var room) && role.SpawnFlags.HasFlag(RoleSpawnFlags.UseSpawnpoint))
            {
                e.Player.Teleport(room);
            }
            if (config.Health.TryGetValue(role, out var health))
            {
                e.Player.Health = health;
            }
            if (config.Inventory.TryGetValue(role, out var inventory) && role.SpawnFlags.HasFlag(RoleSpawnFlags.AssignInventory))
            {
                e.Player.ClearItems();
                inventory.ForEach(item => e.Player.AddItem(item));
            }
            if (config.Effects.TryGetValue(role, out var effects))
            {
                effects.ForEach(effect => e.Player.SyncEffect(effect));
            }
        }

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (ev.Player.IsGodModeEnabled && config.TeslaIgnoresGodmode)
                ev.IsAllowed = false;
        }

        public void OnChangingRole(ChangingRoleEventArgs e)
        {
            if (config.GodmodeTutorial && (e.Reason is SpawnReason.ForceClass or SpawnReason.None))
                e.Player.IsGodModeEnabled = e.NewRole == RoleTypeId.Tutorial;
        }

        public void OnHurting(HurtingEventArgs e)
        {
            if (e.Attacker == null || e.Attacker == e.Player)
                return;

            if (e.Attacker.Role.Type == RoleTypeId.Scp049 && config.scp049OneShot)
            {
                if (e.Player.GetCustomRoles().Any() && config.IgnoreCustomRoles)
                    return;
                e.DamageHandler.Damage = 9999999;
            }

            else if (e.Attacker.Role.Type == RoleTypeId.Scp106 && config.scp106OneShot)
            {
                if (e.Player.GetCustomRoles().Any() && config.IgnoreCustomRoles)
                    return;
                e.Player.EnableEffect(EffectType.PocketCorroding);
            }

            else if (e.Attacker.Role.Type == RoleTypeId.Scp096 && config.scp096OneShot)
            {
                if (e.Player.GetCustomRoles().Any() && config.IgnoreCustomRoles)
                    return;
                e.DamageHandler.Damage = 9999999;
            }
        }
    }
}
