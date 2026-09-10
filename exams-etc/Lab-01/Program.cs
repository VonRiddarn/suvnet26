using ConsoleAtHome;

namespace Lab_01;

class Program
{
	static void Main()
	{
		SceneManager.SwitchScene(Scenes.Main);
	}
}

/*
NOTES FOR ASSIGNMENT BOARD (Clean before posting on page): 


Man kan argumentera för att en singleton som scene manager inte är så clean.
Detta är pga tidspress. Tror att ett genomtänkt DI system hade varit bättre.
Alternativet hade varit att göra scener till objekt istället för interfaces och passera ned repo och manager.
Då hade man också kunnat utveckla sub-scener / context.


10.19 : Fungerande state machine för menyer!!! Lesfuggin goo
 */
