using Ucu.Poo.Twitter;
using System;

namespace CompAndDel.Filters
{
    //Este filtro se usa para el ejercicio 3, utilizando la API de Twitter
    public class FilterTwitter : IFilter
    {
        
        private readonly string _text;

        public FilterTwitter(string text)
        {
            _text = text;
        }

        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(_text, @"luke_final.jpg"));
            return image; 
        }
    }
}