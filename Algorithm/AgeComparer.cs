using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class AgeComparer
    {
        private readonly List<Person> _people;
        private readonly List<AgeComparison> _ageComparisonList;
        
        public AgeComparer(List<Person> people)
        { 
            _people = people; 
            _ageComparisonList = new List<AgeComparison>();
        }

        public AgeComparison GetAgeComparisonResult(AgeGap ageGap)
        {
            SortPeopleByBirthDate();
            var ageComparisonResult = _ageComparisonList.Count < 1 ? new AgeComparison() : GetSmallestOrLargestAgeGap(ageGap);
            return ageComparisonResult;
        }
        
        private void SortPeopleByBirthDate()
        {
            for (var i = 0; i < _people.Count - 1; i++)
            {
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var comparison = new AgeComparison();
                    _ageComparisonList.Add(comparison);
                    AssignOldestYoungest(i, j, comparison);
                    SetAgeDifference();
                }
            }
        }

        private void AssignOldestYoungest(int i, int j, AgeComparison ageComparison)
        {
            if (_people[i].BirthDate < _people[j].BirthDate)
            {
                ageComparison.Oldest = _people[i];
                ageComparison.Youngest = _people[j];
            }
            else
            {
                ageComparison.Oldest = _people[j];
                ageComparison.Youngest = _people[i];
            }
        }

        private void SetAgeDifference()
        {
            foreach (var comparison in _ageComparisonList)
            {
                comparison.AgeDifference = comparison.Youngest.BirthDate - comparison.Oldest.BirthDate;
            }
        }
        
        private AgeComparison GetSmallestOrLargestAgeGap(AgeGap ageGap)
        {
            var result = ageGap == AgeGap.Smallest ? GetSmallestAgeGap() : GetLargestAgeGap();
            return result;
        }

        private AgeComparison GetSmallestAgeGap()
        {
            var smallestComparison = _ageComparisonList.Min((x => x.AgeDifference));
            var result = FindAgeComparison(smallestComparison);
            return result;
        }

        private AgeComparison GetLargestAgeGap()
        {
            var largestComparison = _ageComparisonList.Max((x => x.AgeDifference));
            var result = FindAgeComparison(largestComparison);
            return result;
        }
        
        private AgeComparison FindAgeComparison(TimeSpan comparison)
        {
            return _ageComparisonList.Find(x => x.AgeDifference == comparison);
        }
        
    }
}