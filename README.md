# Welcome to my pokemon app!

This project was created as my assignment for recruitement process at Esatto. It is a simple web application created using ASP.NET MVC - Model | View | Controller pattern. 
You take on the role of organizer of a big Pokemon tournament. Your task is to sign up trainers who want to participate in the tournament, also verify if they data is correct. You also have access to simple poxedex system to give information about pokemons to trainers who dont have their own pokedex.

## Structure of the website

- Pokemon | Home page
  On this page you can input all necesary trainer data
- Traineras
  On this page you can see all signed up trainers and their data (huh, rodo? Nah we dont do that here, we live in a world where pokemons are real!), edit their data or delete them if they decide not to be part of this amazing even.
- Pokedex
  On this website you can swipe beetwe pages (20 pokemons per page - due to the pokemon API structure), search for pokemons on current page, sort pokemons alphabetically and in reverse, or click button to see more details about specyfic pokemon.
- Pokemon
  Page with all necesary infromations about pokemon

## How to run project

Running project is very simple. I used docker and docker compose to create fast way for running my app. To run it succesfully you have to:

```
git clone https://github.com/LukaszWilk1/Pokemon.git
```

Then you enter clonned file:
```
cd Pokemon
```

And finally to run application

- For Linux:
```
docker-compose up --build
```
In case of permision denied error:
```
sudo docker-compose up --build
```
- For Windows
```
docker-compose up --build
```

To stop application just press ctrl + c or use command (is u started docker-compose in detached mode):

```
sudo docker-compose down -v
```