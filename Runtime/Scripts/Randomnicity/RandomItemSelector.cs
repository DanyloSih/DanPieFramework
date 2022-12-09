using System;
using System.Collections.Generic;

namespace DanPie.Framework.Randomnicity
{
    public class RandomItemSelector<T>
        where T : IRandomSelectableItem
    {
        private readonly Random _random = new Random();   
        private readonly List<T> _selectableItems;

        public RandomItemSelector(List<T> selectableItems)
        {
            if (selectableItems == null && selectableItems.Count == 0)
            {
                throw new ArgumentException($"{nameof(selectableItems)} list must contain at least one element!");
            }

            _selectableItems = new List<T>(selectableItems);
        }

        public T GetRandomItem()
        {
            int sum = 0;
            _selectableItems.ForEach((x) => sum += x.SelectionChance);
            int pointer = (int)Math.Round((double)sum * _random.NextDouble());

            while (pointer > 0)
            {
                foreach (var item in _selectableItems)
                {
                    pointer -= item.SelectionChance;
                    if (pointer <= 0)
                    {
                        return item;
                    }
                } 
            }
            return _selectableItems[0];
        }
    }
}
