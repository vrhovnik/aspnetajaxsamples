using System.Collections.Generic;

namespace AjaxWebDemo.Models
{
    public static class StaticDataSource
    {
        public static List<Person> Data { get; } = new()
        {
            new() {Name = "Janez", Surname = "Novak", Age = 32},
            new() {Name = "Mitja", Surname = "BeGood", Age = 25},
            new() {Name = "Johnny", Surname = "BeGood", Age = 21},
            new() {Surname = "Vrhovnik", Name = "Bojan", Age = 30},
            new() {Surname = "Vrhovnik", Name = "Sandra", Age = 31},
            new() {Surname = "Zofic", Name = "Oliver", Age = 40}
        };
    }
}