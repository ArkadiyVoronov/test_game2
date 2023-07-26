using System;
using System.Linq;

namespace game_bulls_and_cows
{
    class Program
    {

        static void Main(string[] args)
        {
            // Создаем массив цифр от 1 до 9
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            // Перемешиваем массив чисел
            KnuthShuffle(ref nums);
            
            // Выбираем случайное число из массива
            int chosenNum = nums[random.Next(nums.Length)];

            //Выводим правила игры
            Console.WriteLine("Lets play the game 'Bulls and cows'! Short rules :");
            Console.WriteLine("You have to guess the number.");
            Console.WriteLine("The number is four-digit and does not contain zero !");
            Console.WriteLine("If the figure from the named number is in the guessed number, then this situation is called 'cow'.");
            Console.WriteLine("If the figure from the named number is in the guessed number and stands in the same place, then this situation is called 'bull'.");
            Console.WriteLine("Good luck !");
            
            //Запрашиваем у игрока ввод
            Console.WriteLine("Your Guess ?");

            //Играем, пока игрок не угадает число
            while (!game(Console.ReadLine(), chosenNum))
            {
                Console.WriteLine("Your next Guess ?");
            }
            
            // Поздравляем игрока с победой
            Console.WriteLine("Congratulations! You have won!");

            // Закрываем консоль
            Console.ReadKey();
        }
        
        // Функция перемешивания массива чисел
        public static void KnuthShuffle<T>(ref T[] array)
        {
            System.Random random = new System.Random();
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(array.Length);
                T temp = array[i]; array[i] = array[j]; array[j] = temp;
            }
        }

        //Функция игры
        public static bool game(string guess, int[] num)
        {
            // Преобазуем строку в массив чисел
            int[] guessed = guess.Select(x => int.Parse(x)).ToArray();
            
            // 
            int bullsCount = 0, cowsCount = 0; //Инициируем счетчик, для подсчета быков и коров

            if (guessed.Length != 4) //Проверяем длину ввода числа игрока
            {
                Console.WriteLine("Not a valid guess. Please enter 4 NUMS, 1 - 9 only"); //Выводим сообщение о недопустимом вводе, просим вводить только 4 цифры, от 1 до 9
                return false;
            }
            //Проверяем на недопустимость ввода 0
            for (int i = 0; i < 4; i++)
            {
                int curguess = (int)char.GetNumericValue(guessed[i]);
                if (curguess < 1 || curguess > 9)
                {
                    Console.WriteLine("Not a valid guess. Please Enter only numbers 1 through 9."); //Выводим сообщение о недопустимом вводе нуля, ввод должен содержать цифру больше нуля и меньше 10
                    return false;
                }
                if (curguess == num[i])
                {
                    bullsCount++; //Считаем количество угаданных быков
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (curguess == num[j])
                            cowsCount++; //Считаем количество угаданных коров
                    }
                }
            }
            
            //Правило выйгрыша
            //Угаданны все 4 числа, в нужной последовательности
            if (bullsCount == 4)
            {
                Console.WriteLine("Congratulations! You have won!"); //Поздравления для игрока
                return true;
            }
            else
            {
                Console.WriteLine("Your Score is {0} bulls and {1} cows", bullsCount, cowsCount); //Сообщение для игрока о количестве быков и коров, в его варианте
                return false;
            }
        }
    }
}