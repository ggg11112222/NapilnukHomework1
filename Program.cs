using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapilnikHomeWork1
{
    internal class Program
    {
        private static Weapon _weapon = new Weapon(22, 5);
        private static Bot _bot = new Bot(_weapon);
        private static Player _player = new Player(100);

        static void Main(string[] args)
        {
            for (int i = 0; i < 7; i++)
            {
                _bot.Weapon.Fire(_player);
                if(_bot.Weapon.Bullets > 0)
                Console.WriteLine($"Игрок принял урон на {_bot.Weapon.Damage} ед. урона\nОстолось жизней: {_player.Health}\nОсталось патронов: {_bot.Weapon.Bullets}\n");
            }

            Console.WriteLine($"\nИгрок погиб\nОсталось патронов: {_bot.Weapon.Bullets}\n");

            Console.ReadKey();
        }

        class Weapon
        {
            public Weapon(int damage, int bullets)
            {
                if (bullets < 0) throw new ArgumentOutOfRangeException(nameof(bullets));

                Damage = damage;
                Bullets = bullets;
            }

            public int Damage { get; private set; }
            public int Bullets { get; private set; }

            public void Fire(Player player)
            {
                if (Bullets == 0)
                {
                    Console.WriteLine("\nПопытка выстрела неуспешна, магазин пуст");
                    return;
                }

                player.TakeDamage(Damage);
                Bullets -= 1;
            }
        }

        class Player
        {
            public Player(int health)
            {
                if (health <= 0) throw new ArgumentOutOfRangeException(nameof(health));

                Health = health;
            }

            public int Health { get; private set; }

            public void TakeDamage(int damage)
            {
                if(damage < 0) throw new ArgumentOutOfRangeException(nameof(damage));

                Health -= damage;
            }
        }

        class Bot
        {
            public Bot(Weapon weapon)
            {
                Weapon = weapon;
            }

            public Weapon Weapon { get; private set; }

            public void OnSeePlayer(Player player)
            {
                Weapon.Fire(player);
            }
        }
    }
}
