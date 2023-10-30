using System;
using System.Collections.Generic;

namespace Rebar.Models
{
    public class ShakeMenu
    {
        public record Shakes(string shakeName, string description, decimal priceLarge, decimal priceMedium, decimal priceSmall, Guid ShakeId);

        Shakes shake1 = new Shakes("Coffee", "Hot", 12, 15, 20, Guid.NewGuid());
        Shakes shake2 = new Shakes("Tea", "Iced", 10, 12, 16, Guid.NewGuid());
        Shakes shake3 = new Shakes("Milkshake", "Chocolate", 14, 18, 24, Guid.NewGuid());
        Shakes shake4 = new Shakes("Smoothie", "Fruit", 9, 11, 15, Guid.NewGuid());

        //List<Shakes> shakes = new List<Shakes>();
        //shakes.Add(shake1);
        //shakes.Add(shake2);
        //shakes.Add(shake3);
        //shakes.Add(shake4);


    }
}
