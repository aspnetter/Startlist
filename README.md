**An API for browsing and adding event entries**

**2 endpoints:**

1. GET startlist/entries to query the entries
2. POST startlist/entries to add a new entry

I've done it all in one project for simplicity now as it's only 1 controller, service, repository. It could be easily converted to a standard 3-tier or even DDD (Application, Domain, Infrastructure) solution if needed.
It uses dependency injection, although I extracted interfaces mostly hoping to write some unit tests in this case so it's possible to mock these services.

**Compulsory things I did not finish:**

1. Mapping between Dtos and Repository objects / business entities, straightforward, just ran out of time. I would really create a cool mapper between filter criteria and Repository object fields which would probably be based on attributes (custom or not).
2 .Write tests:
   - Unit - for mappers, the controller (mocking the service) and the service (mocking the repository)
   - Integration - with pre-set up test data, simulating proper HTTP requests

**Optional things I did not do:**

1. Generate Swagger UI docs as part of the build process
2. Better exception handling and logging (using middleware for centralized way)
3. Partial match search by filter fields (like, first 3 symbols for first name, last name, event name, email etc.)
4. Just nicer / more detailed filter




