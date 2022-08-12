using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private List<Item> itemPool;
        public WarController()
        {
            characters = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string [] args)
        {
            Character character;
            if (args[0] != nameof(Warrior) && args[0] != nameof(Priest))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCharacterType,args[0]);
            }
            if (args[0] == nameof(Warrior))
            {
                character = new Warrior(args[1]);
            }
            else
            {
                character = new Priest(args[1]);
            }
            characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, args[1]);
        }

        public string AddItemToPool(string[] args)
        {
            Item item;
            if (args[0] != nameof(FirePotion) && args[0] != nameof(HealthPotion))
            {
                throw new ArgumentException(ExceptionMessages.InvalidItem, args[0]);
            }
            if (args[0] == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else
            {
                item = new HealthPotion();
            }
            itemPool.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, args[0]);
        }

        public string PickUpItem(string[] args)
        {
            if (!characters.Any(s => s.Name == args[0]))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);
            }
            if (!itemPool.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            Character character = characters.First(s => s.Name == args[0]);
            Item item = itemPool.Last();
            character.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, character.Name, item.GetType().Name);
        }

        public string UseItem(string [] args)
        {
            if (!characters.Any(s => s.Name == args[0]))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);
            }
            Character character = characters.FirstOrDefault(s => s.Name == args[0]);
            Item item = character.Bag.GetItem(args[1]);
            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            string lifeStatus = "";
            StringBuilder sb = new StringBuilder();
            foreach (var character in characters.OrderByDescending(s => s.IsAlive).ThenByDescending(s => s.Health))
            {
                if (character.IsAlive)
                {
                    lifeStatus = "Alive";
                }
                else
                {
                    lifeStatus = "Dead";
                }
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {lifeStatus}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            Character characterAttack = characters.FirstOrDefault(c => c.Name == args[0]);
            Character characterDeffence = characters.FirstOrDefault(c => c.Name == args[1]);
            if (characterAttack == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);
            }
            if (characterDeffence == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[1]);
            }
            if (characterAttack.GetType().Name == nameof(Priest))
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, characterAttack.Name); ;
            }
            Warrior warrior = characterAttack as Warrior;
            if (characterAttack.Health == 0 || characterDeffence.Health == 0)
            {
                return $"Invalid Operation: Must be alive to perform this action!";
            }
            
            warrior.Attack(characterDeffence);
            StringBuilder sb = new StringBuilder();

           sb.AppendLine($"{args[0]} attacks {args[1]} for {characterAttack.AbilityPoints} hit points! {args[1]} has {characterDeffence.Health}/{characterDeffence.BaseHealth} HP and {characterDeffence.Armor}/{characterDeffence.BaseArmor} AP left!");
            if (characterDeffence.IsAlive == false)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter,characterDeffence.Name));
            }
            return sb.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            Character healer = characters.FirstOrDefault(s => s.Name == args[0]);
            Character healingReceiver = characters.FirstOrDefault(s => s.Name == args[1]);
            if (healer == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healer.Name);
            }
            if (healer.GetType().Name == "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }
            if (healingReceiver == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty,healingReceiver.Name);
            }
           
            Priest priest = healer as Priest;
            priest.Heal(healingReceiver);

            return $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!";
        }
    }
}
