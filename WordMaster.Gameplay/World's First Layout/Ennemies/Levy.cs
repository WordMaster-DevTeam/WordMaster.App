using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	public class Levy : Ennemy
	{
		string _sentance;
		readonly Dictionary<int, string> _possibleAnswers;
		int _correctAnswer;

		internal Levy( GlobalContext globalContext, string name, string description, int health, int experience, int level, int armor, string sentance, Dictionary<int, string> possibleAnswers, int correctAnswer )
			: base( globalContext, name, description, health, experience, level, armor )
		{
			_sentance = sentance;
			_possibleAnswers = possibleAnswers;
			_correctAnswer = correctAnswer;
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

		public bool CheckAnwswer( string answer )
		{
			if( _possibleAnswers[_correctAnswer] == answer )
				return true;

			return false;
		}
	}
}
