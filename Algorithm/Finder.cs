using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _person;

        public Finder(List<Person> person)
        {
            _person = person;
        }

        public Comparison Find(FT ft)
        {
            var comparisonList = new List<Comparison>();

            for(var i = 0; i < _person.Count - 1; i++)
            {
                for(var j = i + 1; j < _person.Count; j++)
                {
                    var comparison = new Comparison();
                    if(_person[i].BirthDate < _person[j].BirthDate)
                    {
                        comparison.Oldest = _person[i];
                        comparison.Youngest = _person[j];
                    }
                    else
                    {
                        comparison.Oldest = _person[j];
                        comparison.Youngest = _person[i];
                    }
                    comparison.AgeDifference = comparison.Youngest.BirthDate - comparison.Oldest.BirthDate;
                    comparisonList.Add(comparison); 
                                            
                }
            }

            if(comparisonList.Count < 1) 
            {
                return new Comparison(); 
            }

            Comparison answer = comparisonList[0]; 
            foreach(var result in comparisonList)
            {
                switch(ft)
                {
                    case FT.One:
                        if(result.AgeDifference < answer.AgeDifference)
                        {
                            answer = result; 
                        }
                        break;

                    case FT.Two:
                        if(result.AgeDifference > answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}