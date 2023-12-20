# ChestStackMultiplier

Allows higher stack sizes in storage containers (wood box, furnace, quarry output, dropbox, etc).

## Permissions

* `cheststackmultiplier.useshift` -- Allows player to use Shift hotkey

## Features

**Chest Stack Multiplier** allows to change stack sizes in storage containers (wood box, furnace, quarry output, dropbox, etc). Initial settings has some containers you can use "out of the box". All newly detected containers will be added to list automaticly using default multiplier. You can add them by hand if you need them before that time [RUST Prefab List](https://www.corrosionhour.com/rust-prefab-list/)

### Hotkeys
  
* `Shift`   `Right Click In a Storage Box` to pull the whole stack out.
* `Shift`   `Right Click In Your Inventory` to store all of that item in the chest.
  
### Furnaces Run Longer
  
Players can leave furnaces running longer, and split ore to be smelted easily

### Base Storage Is Condensed

Players can store materials without needing to make multiple chests for each item type (Can store all components in a single chest, and less of a need for multiple chests of stone)  

### Balance Upkeep

Players can store a reasonable amount of resources, allowing decent sized bases to last a few days, and giant bases will only need to be refilled daily instead of every few hours. **You will still need to farm upkeep but tool cupboard storage wont be the bottleneck anymore.**  

## Configuration

```json
{
  "Default Multiplier for new containers": 1.0,
  "Containers list (PrefabName: multiplier)": {
    "assets/prefabs/deployable/fridge/fridge.deployed.prefab": 1.0,
    "assets/prefabs/deployable/large wood storage/box.wooden.large.prefab": 1.0,
    "assets/prefabs/deployable/vendingmachine/npcvendingmachines/shopkeeper_vm_invis.prefab": 1.0,
    "assets/prefabs/deployable/woodenbox/woodbox_deployed.prefab": 1.0,
    "assets/prefabs/misc/decor_dlc/storagebarrel/storage_barrel_a.prefab": 1.0,
    "assets/prefabs/misc/decor_dlc/storagebarrel/storage_barrel_b.prefab": 1.0,
    "assets/prefabs/misc/decor_dlc/storagebarrel/storage_barrel_c.prefab": 1.0,
    "assets/prefabs/misc/halloween/coffin/coffinstorage.prefab": 1.0,
    "Backpack": 1.0
  }
}
```

## Credits

[**Jake_Rich**](https://umod.org/user/JakeRich), the original author of this plugin
