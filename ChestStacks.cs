using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Core.Plugins;

namespace Oxide.Plugins
{
    [Info("ChestStacks", "MON@H", "1.3.0")]
    [Description("Higher stack sizes in storage containers.")]

    public class ChestStacks : RustPlugin //Hobobarrel_static, item_drop
    {
        #region Class Fields

        [PluginReference] private RustPlugin WeightSystem;

        #endregion

        #region Initialization

        private void OnServerInitialized()
        {
            SaveConfig();
        }

        #endregion Initialization

        #region Configuration

        private ConfigData configData;

        private class ConfigData
        {
            [JsonProperty(PropertyName = "Global settings")]
            public GlobalSettings globalSettings = new GlobalSettings();

            [JsonProperty(PropertyName = "Stack settings")]
            public ChatSettings stacksSettings = new ChatSettings();

            public class GlobalSettings
            {
                [JsonProperty(PropertyName = "Default Multiplier for new containers")]
                public int defaultContainerMultiplier = 1;
            }

            public class ChatSettings
            {
                [JsonProperty(PropertyName = "Containers list (shortPrefabName: multiplier)")]
                public Dictionary<string, int> containers = new Dictionary<string, int>()
                {
                        {"autoturret_deployed", 1},
                        {"bbq.deployed", 1},
                        {"bigwheelbettingterminal", 1},
                        {"box.wooden.large", 1},
                        {"campfire", 1},
                        {"coffinstorage", 1},
                        {"composter", 1},
                        {"crudeoutput", 1},
                        {"cupboard.tool.deployed", 1},
                        {"cursedcauldron.deployed", 1},
                        {"engine", 1},
                        {"excavator_output_pile", 1},
                        {"fireplace.deployed", 1},
                        {"fridge.deployed", 1},
                        {"fuel_storage", 1},
                        {"fuelstorage", 1},
                        {"furnace", 1},
                        {"furnace.large", 1},
                        {"fusebox", 1},
                        {"guntrap.deployed", 1},
                        {"hitchtrough.deployed", 1},
                        {"hopperoutput", 1},
                        {"item_drop", 1},
                        {"item_drop_backpack", 1},
                        {"lantern.deployed", 1},
                        {"locker.deployed", 1},
                        {"mixingtable.deployed", 1},
                        {"modular_car_fuel_storage", 1},
                        {"npcvendingmachine_attire", 1},
                        {"npcvendingmachine_components", 1},
                        {"npcvendingmachine_extra", 1},
                        {"npcvendingmachine_farming", 1},
                        {"npcvendingmachine_resources", 1},
                        {"planter.large.deployed", 1},
                        {"recycler_static", 1},
                        {"refinery_small_deployed", 1},
                        {"repairbench_deployed", 1},
                        {"repairbench_static", 1},
                        {"researchtable_deployed", 1},
                        {"researchtable_static", 1},
                        {"rowboat_storage", 1},
                        {"shopkeeper_vm_invis", 1},
                        {"skull_fire_pit", 1},
                        {"small_refinery_static", 1},
                        {"supply_drop", 1},
                        {"survivalfishtrap.deployed", 1},
                        {"testridablehorse", 1},
                        {"vendingmachine.deployed", 1},
                        {"water.pump.deployed", 1},
                        {"waterbarrel", 1},
                        {"woodbox_deployed", 1},
                        {"workbench1.deployed", 1},
                        {"workbench1.static", 1},
                        {"workbench2.deployed", 1},
                        {"workbench3.deployed", 1}
                };
            }
        }

        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                configData = Config.ReadObject<ConfigData>();
                if (configData == null)
                    LoadDefaultConfig();
            }
            catch
            {
                PrintError("The configuration file is corrupted");
                LoadDefaultConfig();
            }
            SaveConfig();
        }

        protected override void LoadDefaultConfig()
        {
            PrintWarning("Creating a new configuration file");
            configData = new ConfigData();
        }

        protected override void SaveConfig() => Config.WriteObject(configData);

        #endregion Configuration

        private bool WeightSystemLoaded()
        {
            return WeightSystem != null && WeightSystem.IsLoaded;
        }

        #region Hooks

        object OnMaxStackable(Item item)
        {
            if (WeightSystemLoaded())
            {
                return null;
            }

            if (item.info.itemType == ItemContainer.ContentsType.Liquid)
            {
                return null;
            }
            if (item.info.stackable == 1)
            {
                return null;
            }
            if (TargetContainer != null)
            {
                var entity = TargetContainer.entityOwner ?? TargetContainer.playerOwner;
                if (entity != null)
                {
                    int stacksize = Mathf.FloorToInt(GetStackSize(entity) * item.info.stackable);
                    TargetContainer = null;
                    return stacksize;
                }
            }
            if (item?.parent?.entityOwner != null)
            {
                int stacksize = Mathf.FloorToInt(GetStackSize(item.parent.entityOwner) * item.info.stackable);
                return stacksize;
            }
            return null;
        }

        private ItemContainer TargetContainer;

        object CanMoveItem(Item movedItem, PlayerInventory playerInventory, uint targetContainerID, int targetSlot, int amount)
        {
            if (WeightSystemLoaded())
            {
                return null;
            }

            var container = playerInventory.FindContainer(targetContainerID);
            var player = playerInventory.GetComponent<BasePlayer>();
            var lootContainer = playerInventory.loot?.FindContainer(targetContainerID);

            TargetContainer = container;

            //Puts($"TargetSlot {targetSlot} Amount {amount} TargetContainer {targetContainerID}");

            #region Right-Click Overstack into Player Inventory

            if (targetSlot == -1)  
            {
                //Right click overstacks into player inventory
                if (lootContainer == null) 
                {
                    if (movedItem.amount > movedItem.info.stackable)
                    {
                        int loops = 1;
                        if (player.serverInput.IsDown(BUTTON.SPRINT))
                        {
                            loops = Mathf.CeilToInt((float)movedItem.amount / movedItem.info.stackable);
                        }
                        for (int i = 0; i < loops; i++)
                        {
                            if (movedItem.amount <= movedItem.info.stackable)
                            {
                                if (container != null)
                                {
                                    movedItem.MoveToContainer(container, targetSlot);
                                }
                                else
                                {
                                    playerInventory.GiveItem(movedItem);
                                }
                                break;
                            }
                            var itemToMove = movedItem.SplitItem(movedItem.info.stackable);
                            bool moved = false;
                            if (container != null)
                            {
                                moved = itemToMove.MoveToContainer(container, targetSlot);
                            }
                            else
                            {
                                moved = playerInventory.GiveItem(itemToMove);
                            }
                            if (moved == false)
                            {
                                movedItem.amount += itemToMove.amount;
                                itemToMove.Remove();
                                break;
                            }
                            if (movedItem != null)
                            {
                                movedItem.MarkDirty();
                            }
                        }
                        playerInventory.ServerUpdate(0f);
                        return false;
                    }
                }
                //Shift Right click into storage container
                else
                {
                    if (player.serverInput.IsDown(BUTTON.SPRINT))
                    {
                        foreach (var item in playerInventory.containerMain.itemList.Where(x => x.info == movedItem.info).ToList())
                        {
                            if (!item.MoveToContainer(lootContainer))
                            {
                                continue;
                            }
                        }
                        foreach (var item in playerInventory.containerBelt.itemList.Where(x => x.info == movedItem.info).ToList())
                        {
                            if (!item.MoveToContainer(lootContainer))
                            {
                                continue;
                            }
                        }
                        playerInventory.ServerUpdate(0f);
                        return false;
                    }
                }
            }

            #endregion

            #region Moving Overstacks Around In Chest

            if (amount > movedItem.info.stackable && lootContainer != null)
            {
                var targetItem = container.GetSlot(targetSlot);
                if (targetItem == null)
                {
                    //Split item into chest
                    if (amount < movedItem.amount)
                    {
                        ItemHelper.SplitMoveItem(movedItem, amount, container, targetSlot);
                    }
                    else
                    {
                        //Moving items when amount > info.stacksize
                        movedItem.MoveToContainer(container, targetSlot);
                    }
                }
                else
                {
                    if (!targetItem.CanStack(movedItem) && amount == movedItem.amount)
                    {
                        //Swapping positions of items
                        ItemHelper.SwapItems(movedItem, targetItem);
                    }
                    else
                    {
                        if (amount < movedItem.amount)
                        {
                            ItemHelper.SplitMoveItem(movedItem, amount, playerInventory);
                        }
                        else
                        {
                            movedItem.MoveToContainer(container, targetSlot);
                        }
                        //Stacking items when amount > info.stacksize

                    }
                }
                playerInventory.ServerUpdate(0f);
                return false;
            }

            #endregion

            #region Prevent Moving Overstacks To Inventory  

            if (lootContainer != null)
            {
                var targetItem = container.GetSlot(targetSlot);
                if (targetItem != null)
                {
                    if (movedItem.parent.playerOwner == player)
                    {
                        if (!movedItem.CanStack(targetItem))
                        {
                            if (targetItem.amount > targetItem.info.stackable)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            #endregion

            return null;
        }
        
        //Hook not implmented, using OnItemDropped for now
        object OnDropItem(PlayerInventory inventory, Item item, int amount)
        {
            /*var player = inventory.GetComponent<BasePlayer>();
            if (inventory.loot.entitySource == null)
            {
                return null;
            }
            if (item.amount > item.info.stackable)
            {
                int loops = Mathf.CeilToInt((float)item.amount / item.info.stackable);
                for (int i = 0; i < loops; i++)
                {
                    if (item.amount <= item.info.stackable)
                    {
                        item.Drop(player.eyes.position, player.eyes.BodyForward() * 4f + Vector3Ex.Range(-1f, 1f));
                        break;
                    }
                    var splitItem = item.SplitItem(item.info.stackable);
                    if (splitItem != null)
                    {
                        splitItem.Drop(player.eyes.position, player.eyes.BodyForward() * 4f + Vector3Ex.Range(-1f, 1f));
                    }
                }
                player.SignalBroadcast(BaseEntity.Signal.Gesture, "drop_item", null);
                return false;
            }*/
            return null;
        }

        //Covers dropping overstacks from chests onto the ground
        void OnItemDropped(Item item, BaseEntity entity)
        {
            item.RemoveFromContainer();
            int stackSize = item.MaxStackable();
            if (item.amount > stackSize)
            {
                int loops = Mathf.FloorToInt((float)item.amount / stackSize);
                if (loops > 20)
                {
                    return;
                }
                for (int i = 0; i < loops; i++)
                {
                    if (item.amount <= stackSize)
                    {
                        break;
                    }
                    var splitItem = item.SplitItem(stackSize);
                    if (splitItem != null)
                    {
                        splitItem.Drop(entity.transform.position, entity.GetComponent<Rigidbody>().velocity + Vector3Ex.Range(-1f, 1f));
                    }
                }
            }
        }

        #endregion

        #region Plugin API

        [HookMethod("GetChestSize")]
        object GetChestSize_PluginAPI(BaseEntity entity)
        {
            if (entity == null)
            {
                return 1f;
            }
            return GetStackSize(entity);
        }

        #endregion

        #region Helpers

        public class ItemHelper
        {
            public static bool SplitMoveItem(Item item, int amount, ItemContainer targetContainer, int targetSlot)
            {
                var splitItem = item.SplitItem(amount);
                if (splitItem == null)
                {
                    return false;
                }
                if (!splitItem.MoveToContainer(targetContainer, targetSlot))
                {
                    item.amount += splitItem.amount;
                    splitItem.Remove();
                }
                return true;
            }

            public static bool SplitMoveItem(Item item, int amount, BasePlayer player)
            {
                return SplitMoveItem(item, amount, player.inventory);
            }

            public static bool SplitMoveItem(Item item, int amount, PlayerInventory inventory)
            {
                var splitItem = item.SplitItem(amount);
                if (splitItem == null)
                {
                    return false;
                }
                if (!inventory.GiveItem(splitItem))
                {
                    item.amount += splitItem.amount;
                    splitItem.Remove();
                }
                return true;
            }

            public static void SwapItems(Item item1, Item item2)
            {
                var container1 = item1.parent;
                var container2 = item2.parent;
                var slot1 = item1.position;
                var slot2 = item2.position;
                item1.RemoveFromContainer();
                item2.RemoveFromContainer();
                item1.MoveToContainer(container2, slot2);
                item2.MoveToContainer(container1, slot1);
            }
        }

        public int GetStackSize(BaseEntity entity)
        {
            if (entity is LootContainer || entity is BaseCorpse || entity is BasePlayer)
            {
                return 1;
            }

            return GetContainerMultiplier(entity.ShortPrefabName);;
        }

        private int GetContainerMultiplier(string containerName)
        {
            int multiplier;
            if (configData.stacksSettings.containers.TryGetValue(containerName, out multiplier))
            {
                return multiplier;
            }

            configData.stacksSettings.containers[containerName] = configData.globalSettings.defaultContainerMultiplier;
            configData.stacksSettings.containers = SortDictionary(configData.stacksSettings.containers);
            SaveConfig();
            return configData.globalSettings.defaultContainerMultiplier;
        }

        private Dictionary<string, int> SortDictionary(Dictionary<string, int> dic)
        {
            return dic.OrderBy(key => key.Key)
                .ToDictionary(key => key.Key, value => value.Value);
        }

        #endregion Helpers
    }
}