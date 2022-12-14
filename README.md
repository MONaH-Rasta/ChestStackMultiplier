# ChestStackMultiplier
Allows higher stack sizes in storage containers (wood box, furnace, quarry output, dropbox, etc).

## Features

**Chest Stack Multiplier** allows to change stack sizes in storage containers (wood box, furnace, quarry output, dropbox, etc). Initial settings has some containers you can use "out of the box". All newly detected containers will be added to list automaticly using default multiplier. You can add them by hand if you need them before that time [RUST Prefab List](https://www.corrosionhour.com/rust-prefab-list/)

### Hotkeys
  
* `Shift`   `Right Click In a Storage Box` to pull the whole stack out. (**Example**)
* `Shift`   `Right Click In Your Inventory` to store all of that item in the chest. (**Example**)
  
### Furnaces Run Longer
  
Players can leave furnaces running longer, and split ore to be smelted easily

### Base Storage Is Condensed

Players can store materials without needing to make multiple chests for each item type (Can store all components in a single chest, and less of a need for multiple chests of stone)  

### Balance Upkeep

Players can store a reasonable amount of resources, allowing decent sized bases to last a few days, and giant bases will only need to be refilled daily instead of every few hours. **You will still need to farm upkeep but tool cupboard storage wont be the bottleneck anymore.**  

## Configuration

```json
{
  "Global settings": {
    "Default Multiplier for new containers": 1.0
  },
  "Stack settings": {
    "Containers list (PrefabName: multiplier)": {
      "assets/bundled/prefabs/static/bbq.static.prefab": 1.0,
      "assets/bundled/prefabs/static/hobobarrel_static.prefab": 1.0,
      "assets/bundled/prefabs/static/recycler_static.prefab": 1.0,
      "assets/bundled/prefabs/static/repairbench_static.prefab": 1.0,
      "assets/bundled/prefabs/static/researchtable_static.prefab": 1.0,
      "assets/bundled/prefabs/static/small_refinery_static.prefab": 1.0,
      "assets/bundled/prefabs/static/wall.frame.shopfront.metal.static.prefab": 1.0,
      "assets/bundled/prefabs/static/water_catcher_small.static.prefab": 1.0,
      "assets/bundled/prefabs/static/workbench1.static.prefab": 1.0,
      "assets/content/props/fog machine/fogmachine.prefab": 1.0,
      "assets/content/structures/excavator/prefabs/engine.prefab": 1.0,
      "assets/content/structures/excavator/prefabs/excavator_output_pile.prefab": 1.0,
      "assets/content/vehicles/boats/rhib/subents/fuel_storage.prefab": 1.0,
      "assets/content/vehicles/boats/rhib/subents/rhib_storage.prefab": 1.0,
      "assets/content/vehicles/boats/rowboat/subents/fuel_storage.prefab": 1.0,
      "assets/content/vehicles/boats/rowboat/subents/rowboat_storage.prefab": 1.0,
      "assets/content/vehicles/minicopter/subents/fuel_storage.prefab": 1.0,
      "assets/content/vehicles/modularcar/2module_car_spawned.entity.prefab": 1.0,
      "assets/content/vehicles/modularcar/3module_car_spawned.entity.prefab": 1.0,
      "assets/content/vehicles/modularcar/4module_car_spawned.entity.prefab": 1.0,
      "assets/content/vehicles/modularcar/subents/modular_car_1mod_storage.prefab": 1.0,
      "assets/content/vehicles/modularcar/subents/modular_car_2mod_fuel_tank.prefab": 1.0,
      "assets/content/vehicles/modularcar/subents/modular_car_fuel_storage.prefab": 1.0,
      "assets/content/vehicles/modularcar/subents/modular_car_i4_engine_storage.prefab": 1.0,
      "assets/content/vehicles/modularcar/subents/modular_car_v8_engine_storage.prefab": 1.0,
      "assets/content/vehicles/scrap heli carrier/subents/fuel_storage_scrapheli.prefab": 1.0,
      "assets/prefabs/building/wall.frame.shopfront/wall.frame.shopfront.metal.prefab": 1.0,
      "assets/prefabs/deployable/bbq/bbq.deployed.prefab": 1.0,
      "assets/prefabs/deployable/campfire/campfire.prefab": 1.0,
      "assets/prefabs/deployable/composter/composter.prefab": 1.0,
      "assets/prefabs/deployable/dropbox/dropbox.deployed.prefab": 1.0,
      "assets/prefabs/deployable/fireplace/fireplace.deployed.prefab": 1.0,
      "assets/prefabs/deployable/fridge/fridge.deployed.prefab": 1.0,
      "assets/prefabs/deployable/furnace.large/furnace.large.prefab": 1.0,
      "assets/prefabs/deployable/furnace/furnace.prefab": 1.0,
      "assets/prefabs/deployable/hitch & trough/hitchtrough.deployed.prefab": 1.0,
      "assets/prefabs/deployable/hot air balloon/subents/hab_storage.prefab": 1.0,
      "assets/prefabs/deployable/jack o lantern/jackolantern.angry.prefab": 1.0,
      "assets/prefabs/deployable/jack o lantern/jackolantern.happy.prefab": 1.0,
      "assets/prefabs/deployable/lantern/lantern.deployed.prefab": 1.0,
      "assets/prefabs/deployable/large wood storage/box.wooden.large.prefab": 1.0,
      "assets/prefabs/deployable/liquidbarrel/waterbarrel.prefab": 1.0,
      "assets/prefabs/deployable/locker/locker.deployed.prefab": 1.0,
      "assets/prefabs/deployable/mailbox/mailbox.deployed.prefab": 1.0,
      "assets/prefabs/deployable/mixingtable/mixingtable.deployed.prefab": 1.0,
      "assets/prefabs/deployable/oil jack/crudeoutput.prefab": 1.0,
      "assets/prefabs/deployable/oil jack/fuelstorage.prefab": 1.0,
      "assets/prefabs/deployable/oil refinery/refinery_small_deployed.prefab": 1.0,
      "assets/prefabs/deployable/planters/planter.large.deployed.prefab": 1.0,
      "assets/prefabs/deployable/planters/planter.small.deployed.prefab": 1.0,
      "assets/prefabs/deployable/playerioents/generators/fuel generator/small_fuel_generator.deployed.prefab": 1.0,
      "assets/prefabs/deployable/playerioents/poweredwaterpurifier/poweredwaterpurifier.deployed.prefab": 1.0,
      "assets/prefabs/deployable/playerioents/poweredwaterpurifier/poweredwaterpurifier.storage.prefab": 1.0,
      "assets/prefabs/deployable/playerioents/waterpump/water.pump.deployed.prefab": 1.0,
      "assets/prefabs/deployable/quarry/fuelstorage.prefab": 1.0,
      "assets/prefabs/deployable/quarry/hopperoutput.prefab": 1.0,
      "assets/prefabs/deployable/repair bench/repairbench_deployed.prefab": 1.0,
      "assets/prefabs/deployable/research table/researchtable_deployed.prefab": 1.0,
      "assets/prefabs/deployable/single shot trap/guntrap.deployed.prefab": 1.0,
      "assets/prefabs/deployable/small stash/small_stash_deployed.prefab": 1.0,
      "assets/prefabs/deployable/survivalfishtrap/survivalfishtrap.deployed.prefab": 1.0,
      "assets/prefabs/deployable/tier 1 workbench/workbench1.deployed.prefab": 1.0,
      "assets/prefabs/deployable/tier 2 workbench/workbench2.deployed.prefab": 1.0,
      "assets/prefabs/deployable/tier 3 workbench/workbench3.deployed.prefab": 1.0,
      "assets/prefabs/deployable/tool cupboard/cupboard.tool.deployed.prefab": 1.0,
      "assets/prefabs/deployable/tuna can wall lamp/tunalight.deployed.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_attire.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_building.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_components.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_extra.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_farming.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_resources.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_tools.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_vehicleshigh.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/npcvendingmachine_weapons.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/npcvendingmachines/shopkeeper_vm_invis.prefab": 1.0,
      "assets/prefabs/deployable/vendingmachine/vendingmachine.deployed.prefab": 1.0,
      "assets/prefabs/deployable/water catcher/water_catcher_large.prefab": 1.0,
      "assets/prefabs/deployable/water catcher/water_catcher_small.prefab": 1.0,
      "assets/prefabs/deployable/water well/waterwellstatic.prefab": 1.0,
      "assets/prefabs/deployable/waterpurifier/waterpurifier.deployed.prefab": 1.0,
      "assets/prefabs/deployable/waterpurifier/waterstorage.prefab": 1.0,
      "assets/prefabs/deployable/woodenbox/woodbox_deployed.prefab": 1.0,
      "assets/prefabs/io/electric/switches/fusebox/fusebox.prefab": 1.0,
      "assets/prefabs/misc/casino/bigwheel/bigwheelbettingterminal.prefab": 1.0,
      "assets/prefabs/misc/chinesenewyear/chineselantern/chineselantern.deployed.prefab": 1.0,
      "assets/prefabs/misc/halloween/coffin/coffinstorage.prefab": 1.0,
      "assets/prefabs/misc/halloween/cursed_cauldron/cursedcauldron.deployed.prefab": 1.0,
      "assets/prefabs/misc/halloween/skull_fire_pit/skull_fire_pit.prefab": 1.0,
      "assets/prefabs/misc/halloween/trophy skulls/skulltrophy.deployed.prefab": 1.0,
      "assets/prefabs/misc/item drop/item_drop.prefab": 1.0,
      "assets/prefabs/misc/item drop/item_drop_backpack.prefab": 1.0,
      "assets/prefabs/misc/marketplace/marketterminal.prefab": 1.0,
      "assets/prefabs/misc/summer_dlc/abovegroundpool/abovegroundpool.deployed.prefab": 1.0,
      "assets/prefabs/misc/summer_dlc/paddling_pool/paddlingpool.deployed.prefab": 1.0,
      "assets/prefabs/misc/summer_dlc/photoframe/photoframe.landscape.prefab": 1.0,
      "assets/prefabs/misc/summer_dlc/photoframe/photoframe.large.prefab": 1.0,
      "assets/prefabs/misc/summer_dlc/photoframe/photoframe.portrait.prefab": 1.0,
      "assets/prefabs/misc/supply drop/supply_drop.prefab": 1.0,
      "assets/prefabs/misc/twitch/hobobarrel/hobobarrel.deployed.prefab": 1.0,
      "assets/prefabs/misc/xmas/snow_machine/models/snowmachine.prefab": 1.0,
      "assets/prefabs/misc/xmas/xmastree/xmas_tree.deployed.prefab": 1.0,
      "assets/prefabs/npc/autoturret/autoturret_deployed.prefab": 1.0,
      "assets/prefabs/npc/flame turret/flameturret.deployed.prefab": 1.0,
      "assets/prefabs/npc/sam_site_turret/sam_site_turret_deployed.prefab": 1.0,
      "Backpack": 1.0
    }
  }
}
```

## Credits

[**Jake_Rich**](https://umod.org/user/JakeRich), the original author of this plugin