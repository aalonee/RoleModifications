# RoleModifications
## Config example:
```yaml
RoleModifications:
  is_enabled: true
  debug: false
  # Modifies HP of roles. You can add roles from here: https://discord.com/channels/656673194693885975/1168331896187519086/1168331896187519086
  health:
    NtfCaptain: 100
  # Gives provided effects to player on spawn
  effects:
    Tutorial:
    -
    # The effect type
      type: MovementBoost
      # The effect duration
      duration: 0
      # The effect intensity
      intensity: 1
      # If the effect is already active, setting to true will add this duration onto the effect.
      add_duration_if_active: false
      # Indicates whether the effect should be enabled or not
      is_enabled: false
  # Modifies spawn room of the role
  spawn_room:
    Scp3114: Hcz049
  # Modifies inventory of the role
  inventory:
    ClassD:
    - Coin
  # SCP-049 kills people with 1 hit?
  scp049_one_shot: true
  # SCP-106 banishes players to the PD with 1 hit?
  scp106_one_shot: true
  # SCP-096 kills people with 1 hit?
  scp096_one_shot: true
  godmode_tutorial: true
  # Will tesla ignore players in godmode?
  tesla_ignores_godmode: true
  # Will CustomRoles be ignored?
  ignore_custom_roles: true
```
