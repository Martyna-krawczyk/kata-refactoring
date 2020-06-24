using System.Collections.Generic;

namespace Algorithm
{
    public class PersonFinder
    {
        private readonly List<Person> _person;
        private readonly List<Comparison> _comparisonList;

        public PersonFinder(List<Person> person)
        {
            _person = person; 
           _comparisonList = new List<Comparison>();
        }

        public Comparison Find(AgeGap ageGap)
        {
            
            SortPeopleByBirthDate();

            if(_comparisonList.Count < 1) 
            {
                return new Comparison(); 
            }

            Comparison answer = _comparisonList[0]; 
            foreach(var result in _comparisonList)
            {
                switch(ageGap)
                {
                    case AgeGap.Smallest:
                        if(result.AgeDifference < answer.AgeDifference)
                        {
                            answer = result; 
                        }
                        break;
            
                    case AgeGap.Largest:
                        if(result.AgeDifference > answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;
                }
            }
            return answer;
        }

        private void SortPeopleByBirthDate()
        {
            for (var i = 0; i < _person.Count - 1; i++)
            {
                for (var j = i + 1; j < _person.Count; j++)
                {
                    var comparison = new Comparison();
                    _comparisonList.Add(comparison);
                    AssignOldestYoungest(i, j, comparison);
                    SetAgeDifference();
                   
                }
            }
        }

        private void AssignOldestYoungest(int i, int j, Comparison comparison)
        {
            
            if (_person[i].BirthDate < _person[j].BirthDate)
            {
                comparison.Oldest = _person[i];
                comparison.Youngest = _person[j];
            }
            else
            {
                comparison.Oldest = _person[j];
                comparison.Youngest = _person[i];
            }
        }

        private void SetAgeDifference()
        {
            //comparison.AgeDifference = comparison.Youngest.BirthDate - comparison.Oldest.BirthDate;
            foreach (var comparison in _comparisonList)
            {
                comparison.AgeDifference = comparison.Youngest.BirthDate - comparison.Oldest.BirthDate;
            }
            //_comparisonList.Add(comparison);
        }
    }
}