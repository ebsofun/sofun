@api
Feature: Now Playing
	People all over the world wish to know what movies are playing in their area, and TMDB is happy 
	to share that information.


Scenario Outline: Only friends allowed
If a user does not have a valid API key, may they walk the plank.
	Given I have a <keyType> api key
	When I request the list of movies now playing in the world
	Then the server responds with <response>

	Scenarios:
		    | keyType  | response     |
		    | valid    | OK           |
		    | invalid  | Unauthorized |
		    | blank    | Unauthorized |
	@ignore 
	Scenarios: 
		    | keyType  | response     |
		    | inactive | Unauthorized |
 
@ignore
Scenario: No movies now playing in region
	Given no movies are now playing in Peru
	When I request the list of movies now playing in Peru
	Then there are 0 total results

@ignore
Scenario Outline: Support multiple languages
	Given my language is <language>
	And the following movies are now playing in Mexico:
		| Original Title                 |
		| Guardians of the Galaxy Vol. 2 |
		| Loneliness Square              |
	When I request the list of movies now playing in Mexico
	Then there are 2 total results
	And the following movies are in the list:
		| Title    | Original Title                 |
		| <title1> | Guardians of the Galaxy Vol. 2 |
		| <title2> | Plaza de la soledad            |

	Scenarios:
		| case       | language | title1                            | title2              |
		| US English | en-US    | Guardians of the Galaxy Vol. 2    | Loneliness Square   |
		| French     | fr       | Les Gardiens de la Galaxie Vol. 2 | Plaza de la soledad |

@ignore
Scenario: Use pages when many results found
	Given each page has 20 movies
	And there are 756 movies now playing in the world
	When I request the list of movies now playing in the world
	Then there are 756 total results
	And there are 38 total pages
	And there are 20 movies in the list

@ignore
Scenario: Return the requested page's list of movies
# this would verify that changing the request's page number would change the results accordingly

@ignore
Scenario: English is the default language
# If this is the requirement, but maybe it looks at IP when language code is blank

@ignore
Scenario: Region does not exist
# non-existent, invalid region code testing

@ignore
Scenario: Page does not exist
# non-existent, invalid page number testing

@ignore
Scenario: Language does not exist 
# non-existint, invalid language code testing





