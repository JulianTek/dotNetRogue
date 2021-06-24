# dotNetRogue
FHICT S3 Individual project
Contains both front-end and back-end for dotNetRogue, API required to run Game can be found [here](https://github.com/JulianTek/dotNetRogue-loot-API)

# End points
> /enemy GET: Returns a list of all enemies.
>  - Returns NoContent when list returned is empty
>  - Returns Ok when list contains enemies

> /enemy POST: Creates a new enemy, requires enemy data be parsed in the request body
>  - Returns NotFound when adding entity to database fails
>  - Returns Ok when adding entity to database succeeds

> /enemy/{id} PUT: Updates enemy with specific ID, requires data of new enemy to be parsed in request body
>  - Returns NotFound when enemy could not be found
>  - Returns Ok when updating entity succeeds

> /enemy/{id} DELETE: Deletes enemy with specific ID
>  - Returns NotFound when enemy could not be found
>  - Returns Ok when enemy is successfully deleted

> /enemygenerator GET: Returns a random enemy
>  - This end point is tested so it always returns Ok.

> /weapongenerator GET: Returns a random weapon
>  - This end point is tested so it always returns Ok.
