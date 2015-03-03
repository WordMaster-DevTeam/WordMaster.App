using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	[Serializable]
	public class Veteran : Ennemy
	{
		string _sentance;
		readonly Dictionary<int, string> _possibleAnswers;
		int _firstCorrectAnswer, _secondCorrectAnswer;

		internal Veteran( GlobalContext globalContext, string name, string description, int health, int experience, int level, int armor, string sentance, Dictionary<int, string> possibleAnswers, int firstCorrectAnswer, int secondCorrectAnswer )
			: base( globalContext, name, description, health, experience, level, armor )
		{
			_sentance = sentance;
			_possibleAnswers = possibleAnswers;
			_firstCorrectAnswer = firstCorrectAnswer;
			_secondCorrectAnswer = secondCorrectAnswer;
		}

		public string Sentance
		{
			get { return _sentance; }
			internal set { _sentance = value; }
		}

		public Dictionary<int, string> PossibleAnswers
		{
			get { return _possibleAnswers; }
		}

		public bool CheckAnwswer( int number, string answer)
		{
			if( number == 1 )
			{
				if( _possibleAnswers[_firstCorrectAnswer] == answer )
					return true;
			}
			else if(number == 2)
			{
				if( _possibleAnswers[_secondCorrectAnswer] == answer )
					return true;
			}
		
			return false;
		}
	}
}
