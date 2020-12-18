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


Scenario: Errar Palabra ingresada
	Given la palabra en juego esta definida
	When la palabra distinta a la en juego es agragada en el campo de palabra 
	And el boton arriesgar es apretado
	Then se deberia bajar el contador de vidas


Scenario: Acertar Letra ingresada
	Given la palabra en juego esta definida
	When la primer letra de la palabra es ingresada
	And el boton arriesgar letra es apretado
	Then se deberia aumentar el score

Scenario: Errar Letra ingresada
	Given la palabra en juego esta definida
	When la una letra erronea es ingresada
	And el boton arriesgar letra es apretado
	Then se deberia bajar el contador de vidas


Scenario: morir
	Given la palabra en juego esta definida
	When se ingresa la palabra erronea cinco veces
	Then el contador de vidas deveria ser cero
