﻿using System.Runtime.Serialization;
using PacManBot.Games.Concrete.RPG.Buffs;
using PacManBot.Extensions;

namespace PacManBot.Games.Concrete.RPG.Enemies
{
    public class Skeleton : Enemy
    {
        public override string Name => "Skeleton";
        public override string Description => "Only the first of many.";
        public override int Level => 3;
        public override int ExpYield => 3;
        public override int BaseDamage => 5;
        public override int BaseDefense => 1;
        public override double BaseCritChance => 0.2;

        public override void SetStats()
        {
            MaxLife = 26;
            DamageType = DamageType.Pierce;
            DamageResistance[DamageType.Pierce] = 0.2;
        }
    }


    public class Skeleton2 : Enemy
    {
        public override string Name => "Skellington";
        public override string Description => "A skeleton's wacky brother.";
        public override int Level => 8;
        public override int ExpYield => 7;
        public override int BaseDamage => 8;
        public override int BaseDefense => 2;
        public override double BaseCritChance => 0.2;

        public override void SetStats()
        {
            MaxLife = 42;
            DamageType = DamageType.Cutting;
            DamageResistance[DamageType.Pierce] = 0.2;
        }
    }


    public class Skeleton3 : Enemy
    {
        public override string Name => "Spookington";
        public override string Description => "Be careful, it's spooky!";
        public override int Level => 11;
        public override int ExpYield => 7;
        public override int BaseDamage => 16;
        public override int BaseDefense => -2;
        public override double BaseCritChance => 0.1;

        public override void SetStats()
        {
            MaxLife = 37;
            DamageType = DamageType.Pierce;
            DamageResistance[DamageType.Pierce] = -0.2;
        }
    }


    public class Skeleton4 : Enemy
    {
        public override string Name => "Swoleton";
        public override string Description => "Milk makes your bones stronger!";
        public override int Level => 15;
        public override int ExpYield => 9;
        public override int BaseDamage => 12;
        public override int BaseDefense => 2;
        public override double BaseCritChance => 0.02;

        [DataMember] private bool milk = false;

        public override void SetStats()
        {
            MaxLife = 60;
            DamageType = DamageType.Blunt;
            DamageResistance[DamageType.Blunt] = 0.3;
        }

        public override string Attack(Entity target)
        {
            string msg = "";
            if (Life < MaxLife / 2 && !milk)
            {
                milk = true;
                msg = $"{Name} drank some milk and became stronger!\n";
                Damage += 4;
                Defense += 4;
                Life += MaxLife / 2;
                MaxLife += MaxLife / 2;
            }

            return msg + base.Attack(target);
        }
    }


    public class SkeletonKing : Enemy
    {
        public override string Name => "Skeleton King";
        public override string Description => "He's actually just a count, but don't tell him.";
        public override int Level => 20;
        public override int ExpYield => 10;
        public override int BaseDamage => 24;
        public override int BaseDefense => 2;
        public override double BaseCritChance => 0.1;

        public override void SetStats()
        {
            MaxLife = 100;
            DamageType = DamageType.Blunt;
            DamageResistance[DamageType.Magic] = 0.15;
            DamageResistance[DamageType.Blunt] = 0.15;
        }

        public override string Attack(Entity target)
        {
            string msg = "";
            if (Bot.Random.OneIn(4))
            {
                msg = $"{target} is overwhelmed!";
                target.AddBuff(nameof(Burn), 2);
                target.AddBuff(nameof(Vulnerable), 2);
                target.AddBuff(nameof(Wet), 2);
            }
            return base.Attack(target) + msg;
        }
    }


    public class Skeleton5 : Enemy
    {
        public override string Name => "Swingeton";
        public override string Description => "Its dance is unpredictable.";
        public override int Level => 30;
        public override int ExpYield => 16;
        public override int BaseDamage => 999;
        public override int BaseDefense => 6;
        public override double BaseCritChance => 0;

        public override void SetStats()
        {
            MaxLife = 74;
            DamageType = DamageType.Cutting;
            DamageResistance[DamageType.Cutting] = 0.1;
        }

        public override string Attack(Entity target)
        {
            Damage = Bot.Random.Next(18, 58);
            string msg = base.Attack(target);
            Damage = BaseDamage;
            return msg;
        }
    }
}
