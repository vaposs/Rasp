using System;

namespace DZ_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Weapon weapon = new Weapon(1, 3);
            //Weapon weapon1 = new Weapon(-1, -3);  //ERROR
            //Weapon weapon2 = new Weapon(1, -3);   //ERROR
            Weapon weapon3 = null;

            Player player = new Player(10);
            //Player player1 = new Player(-2);  //ERROR
            //Player player2 = new Player(0);   //ERROR
            Player player3 = null;

            Bot bot = new Bot(weapon);
            //Bot bot1 = new Bot(weapon3); //ERROR

            weapon.Fire(player);
            //weapon.Fire(player3); //ERROR

            player.TakeDamage(1);
            //player.TakeDamage(-1);    //ERROR
            player.TakeDamage(0);

            bot.OnSeePlayer(player);
            //bot.OnSeePlayer(player3); //ERROR
        }
    }

    class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            _damage = damage >= 0 ? damage : throw new ArgumentOutOfRangeException(nameof(bullets), " не может быть меньше 0"); ;
            _bullets = bullets >= 0 ? bullets : throw new ArgumentOutOfRangeException(nameof(bullets), " не может быть меньше 0");
        }

        public void Fire(Player player)
        {
            if (player != null)
            {
                if (_bullets > 0)
                {
                    player.TakeDamage(_damage);
                    _bullets--;
                }
            }
            else
            {
                throw new ArgumentNullException("переменная не инициализирована", nameof(player));
            }
        }
    }

    class Player
    {
        private int _health;

        public Player(int health)
        {
            _health = health > 0 ? health : throw new ArgumentOutOfRangeException(nameof(health), " не может быть 0 или меньше 0");
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException("урон меньше ноля", nameof(damage));
            }
            else
            {
                _health -= damage;
            }
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon != null ? weapon : throw new ArgumentNullException("переменная не инициализирована", nameof(weapon));
        }

        public void OnSeePlayer(Player player)
        {
            if (player != null)
            {
                _weapon.Fire(player);
            }
            else
            {
                throw new ArgumentNullException("переменная не инициализирована", nameof(player));
            }
        }
    }
}
