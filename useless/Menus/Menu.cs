using System;
using System.Collections.Generic;

namespace useless
{
    public abstract class Menu
    {
        protected List<IMenuOperation> _operations;

        public void DrawMenu()
        {
            for (var i = 0; i < _operations.Count; i++)
            {
                Console.WriteLine($"{i} -> {_operations[i].Description}");
            }

            var strInput = Console.ReadLine();

            int value = int.Parse(strInput); //Здесь нужны проверки на корректность, конечно
            ChooseOperation(value);
        }

        public void ChooseOperation(int index)
        {
            _operations[index].Execute();
        }
        public void Exit()
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }
    }
}
