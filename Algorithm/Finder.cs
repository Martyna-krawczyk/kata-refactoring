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
                        comparison.Younger = _person[i];
                        comparison.Older = _person[j];
                    }
                    else
                    {
                        comparison.Younger = _person[j];
                        comparison.Older = _person[i];
                    }
                    comparison.AgeDifference = comparison.Older.BirthDate - comparison.Younger.BirthDate;
                    comparisonList.Add(comparison); 
                                            //mike(Younger) & greg(Older) (ageDiff = 27)
                                            //mike(Older) & Sarah(Younger) (ageDiff = 3)
                                            //sarah(Younger) & sue(Older) (ageDiff = 32)
                }
            }

            if(comparisonList.Count < 1) //if there is no one in the list
            {
                return new Comparison(); //create a new instance of age
            }

            Comparison answer = comparisonList[0]; //mike(Younger) & greg(Older) (ageDiff = 27)
            foreach(var result in comparisonList)
            {
                switch(ft)
                {
                    case FT.One:
                        if(result.AgeDifference < answer.AgeDifference)
                        {
                            answer = result; //mike(Older) & Sarah(Younger) (ageDiff = 3)
                        }
                        break;

                    case FT.Two:
                        if(result.AgeDifference > answer.AgeDifference)
                        {
                            answer = result; //sarah(Younger) & sue(Older) (ageDiff = 32)
                        }
                        break;
                }
            }

            return answer;
        }
    }
}