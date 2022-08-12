using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name):base(name,100,50,40,new Satchel())
        {

        }
        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.GetType().Name == character.GetType().Name && this.Name == character.Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                if (character.GetType().Name == "Warrior")
                {
                character.TakeDamage(this.AbilityPOints);
                }
            }
        }
    }
}
