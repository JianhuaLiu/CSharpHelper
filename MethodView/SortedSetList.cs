using System;
using System.Collections.Generic;

namespace MethodView
{
    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    /// <summary>
    /// 自定义排序功能
    /// </summary>
    public class SortedSetList
    {
        public SortedSetList()
        {
            SortedSet<Person> setPer = Load();
            foreach (var item in setPer)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        public SortedSet<Person> Load()
        {
            return new SortedSet<Person>(new SortPeopleByAge()) {
                 new Person { FirstName="Homer",LastName="Simpson",Age=47 },
                new Person { FirstName="Marge",LastName="Simpson",Age=45 },
                new Person { FirstName="Lisa",LastName="Simpson",Age=77 },
                new Person { FirstName="Bart",LastName="Simpson",Age=8 }
            };
        }

        public class SortPeopleByAge : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                if (x.Age > y.Age)
                {
                    return 1;
                }
                if (x.Age < y.Age)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}