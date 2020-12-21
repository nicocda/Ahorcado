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
	Then el contador de vidas deberia ser cero


Scenario: apretar boton otra partida
	Given la palabra en juego esta definida
	When se aprieta el boton de otra partida
	Then el score las vidas y la palabra en juego deben resetearse


Scenario: apretar boton otra partida en pagina derrota
	Given estamos en la pagina de derrota
	When se aprieta el boton de siguiente partida
	Then el score las vidas y la palabra en juego deben resetearse


Scenario: apretar boton otra continuar en pagina victoria
	Given estamos en la pagina victoria despues de acertar la palabra a adivinar
	When se aprieta el boton de continuar
	Then el score se mantiene y las vidas y la palabra en juego deben resetearse


Scenario: mostrar lista de 2 letras 
  Given la palabra en juego esta definida
  	When se ingresa la letra a
	And el boton arriesgar letra es apretado
	And se ingresa la letra b
	And el boton arriesgar letra es apretado
	Then la lista de letras ingresadas debe mostrar que se ingresaron las letras a y b

Scenario:  bajar el score
	Given la palabra en juego esta definida
	When la primer letra de la palabra es ingresada
	And el boton arriesgar letra es apretado
	When la una letra erronea es ingresada
	And el boton arriesgar letra es apretado
	Then el score deberia terminar en 50

Scenario:  palabra oculta
	Given la palabra en juego esta definida
	When la primer letra de la palabra es ingresada
	And el boton arriesgar letra es apretado
	Then la palabra oculta deberia mostrar la letra adivinada

Scenario:  Acertar Todas las letras de la palabra
	Given la palabra en juego esta definida
	When se ingresan todas las letras de la palabra 
	Then se deberia mostrar un mensaje de victoria