# BasketballLeague

Task:

Design a relational database to store the results of a basketball league. There is a home team, and away team that are playing.
Add 6 teams to the database.
Add random results, about 20.
 
Create an Angular application with .NET backend communicating to the database that will have the following functionality:
 
There is a navigation menu that allows you to choose one of the following views:
 
1. List of all Teams (sortable/searchable is a plus)
2. Match results in the form of:
Home team    | Away team            | Score
--------------------------------------------------------------
Phoenix Suns | New Orleans Pelicans | 112:97
 
3. Top 5 Best offensive teams (teams who scored the maximum number of points home and away combined)
4. Top 5 Best defensive teams (teams whose opponents scored the smallest number of points, home and away combined)
5. Show the highlight match (Most points scored on a single match by both teams)
 
Important notes:
•	You can use UI components of your choice
•	All the database queries should be in a form of SQL Server stored procedures returning the result.
•	Stored procedures themselves can be triggered via Entity Framework or other ORM of choice.
