Feature: Ahorcado
	Para detectar que se inserto la palabra correcta 
	Como sistema
	Quiero mostrar un mensaje de victoria. 

@mytag
Scenario: Acertar Palabra ingresada
	Given la palabra en juego esta definida
	When la palabra en juego es agragada en el campo de palabra 
	And el boton arriesgar es apretado
	Then se deberia motrar un mensaje de victoria