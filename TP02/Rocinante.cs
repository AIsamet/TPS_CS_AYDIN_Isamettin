﻿using Aydin_Isamettin_Tp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Aydin_Isamettin_Tp1.Weapon;

namespace TP02
{
    public class Rocinante : Spaceship
    {
        //2.c.1
        public Rocinante()
        {
            MaxStructure = 3;
            MaxShield = 5;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            WeaponsList.Add(new Weapon("Torpille", 3, 3, Weapon.EWeaponType.Guided, 2));
        }

        public Rocinante(string name)
        {
            Name = name;
            MaxStructure = 3;
            MaxShield = 5;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            WeaponsList.Add(new Weapon("Torpille", 3, 3, Weapon.EWeaponType.Guided, 2));
        }

        //2.b.2
        public override void TakeDamages(Weapon weapon)
        {
            Random random = new Random();
            int chance;

            if (weapon.weaponType == EWeaponType.Direct)
            {
                chance = random.Next(1, 11); // creates a number between 1 and 11
                if (chance == 1)
                {
                    if (weapon.Shoot() != 0)
                    {
                        Console.WriteLine("Attaque esquivé par Rocinante");
                    }
                }
                else { base.TakeDamages(weapon); }
                Console.WriteLine("------------------------------------------------------------\n");
            }

            else if (weapon.weaponType == EWeaponType.Explosive)
            {
                chance = random.Next(1, 5); // creates a number between 1 and 4
                if (chance == 1)
                {
                    if (weapon.Shoot() != 0)
                    {
                        Console.WriteLine("Attaque esquivé par Rocinante");
                    }
                }
                else { base.TakeDamages(weapon); }
                Console.WriteLine("------------------------------------------------------------\n");
            }

            else if (weapon.weaponType == EWeaponType.Guided)
            {
                chance = random.Next(1, 5); // creates a number between 1 and 4
                if (chance == 1 || chance == 2 || chance == 3)
                {
                    if (weapon.Shoot() != 0)
                    {
                        Console.WriteLine("Attaque esquivé par Rocinante");
                    }
                }
                else { base.TakeDamages(weapon); }
                Console.WriteLine("------------------------------------------------------------\n");
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();

            if (WeaponsList.Count() != 0)
            {
                int randomWeapon = random.Next(0, WeaponsList.Count());
                Weapon weapon = WeaponsList[randomWeapon];

                Console.WriteLine("Vous passez a l'attaque ! ");

                target.TakeDamages(WeaponsList[randomWeapon]);
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami"); }
        }
    }
}