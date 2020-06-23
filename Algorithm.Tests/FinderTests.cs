using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class FinderTests
    {
        
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new PersonFinder(list);
        
            var result = finder.Find(AgeGap.Smallest);
        
            Assert.Null(result.Oldest);
            Assert.Null(result.Youngest);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new PersonFinder(list);
        
            var result = finder.Find(AgeGap.Smallest);
        
            Assert.Null(result.Oldest);
            Assert.Null(result.Youngest);
        }
        
        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new PersonFinder(list);
        
            var result = finder.Find(AgeGap.Largest);
        
            Assert.Same(sue, result.Oldest);
            Assert.Same(greg, result.Youngest);
        }
        
        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new PersonFinder(list);
        
            var result = finder.Find(AgeGap.Smallest);
        
            Assert.Same(greg, result.Oldest);
            Assert.Same(mike, result.Youngest);
        }
        
        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new PersonFinder(list);
        
            var result = finder.Find(AgeGap.Largest);
        
            Assert.Same(sue, result.Oldest);
            Assert.Same(sarah, result.Youngest);
        }
        
        
        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { mike, greg, sue, sarah };
            var finder = new PersonFinder(list);
        
            var result = finder.Find(AgeGap.Smallest);
        
            Assert.Same(sue, result.Oldest);
            Assert.Same(greg, result.Youngest);
        }
        
        [Fact]
        public void TestingEnumOneBehaviour()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new PersonFinder(list);
        
            var result = finder.Find(AgeGap.Smallest);
        
            Assert.Same(sue, result.Oldest);
            Assert.Same(greg, result.Youngest);
        }
        
        //own test
        [Fact]
        public void Mike_Is_Younger_Than_Greg()
        {
            var list = new List<Person>(){greg, mike};
            var finder = new PersonFinder(list);
        
            var result = finder.Find(AgeGap.Smallest);
            
            Assert.Same(greg, result.Oldest);
            Assert.Same(mike, result.Youngest);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
        
        
    }
}