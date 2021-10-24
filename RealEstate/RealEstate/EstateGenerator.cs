using System;
using System.Collections.Generic;
using RealEstate.Models;

namespace RealEstate
{
    public static class EstateGenerator
    {
        public static List<Estate> GenerateEstates()
        {
            return new List<Estate>
            {
                new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },
                new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },new Estate
                {
                    FirstName = "Ivan",
                    LastName = "Djikovski",
                    PhotoUrl = $"https://picsum.photos/{GetRandomSize()}"
                },
            };
        }

        public static int GetRandomSize()
        {
            Random rnd = new Random();
            return rnd.Next(200, 300);
        }
    }
}
