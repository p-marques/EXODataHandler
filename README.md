# EXO Data Handler

**Project 1 - Linguagens de Programação II 2020/2021**

**Videojogos - Universidade Lusófona**

### Authors

- Pedro Dias Marques Nº 21900800
- Gonçalo Vila Verde Nº 21901395
- Miguel Martinho Nº 21901530

### Repository

[GitHub](https://github.com/p-marques/EXODataHandler)

### Work Distribution

- Miguel Martinho: Unity interface.
- Pedro Dias Marques: File reading and validation.
- Gonçalo Vila Verde: Data fields and structure parsing after validation.

## Solution Architecture

**Form:** Interactive in Unity

### Projects

The EXO Data Handler is broken up into 4 projects:

- EXODataHandler.API
- EXODataHandler.Core
- EXODataHandler.Parser
- EXODataHandler.Unity

#### EXODataHandler.API

The .API is the point of entry to the application.

This is where the `IEXODataRepository` interface is declared and implemented in
`EXODataRepository`. The interface declares all the methods required by .Unity
to perform its duties.

The methods `GetPlanets()`, `GetStars()`, `OrderPlanets<T>()` and
`OrderStars<T>()` receive delegates to be used by the appropriate LINQ methods.
The first two methods also support cumulative filtering by passing a list of
the appropriate type that will be used for filtering, instead of the entire file.
The ordering methods support a secondary delegate to break ties.

The class `EXODataSet` is also declared here. It represents the entire dataset
in the parsed file.

We used an enum, `OrderByType` which must be passed in as an argument in the
ordering methods to specify if the ordering should be descending or ascending.

All method return `APIResponse<T>`, with `T` being the appropriate type for the
method. `APIResponse` and its generic version are described in .Core.

References: EXODataHandler.Core and EXODataHandler.Parser

#### EXODataHandler.Core

In the .Core we describe the *core* types of the entire application.

The `Star`, `Planet` and `AstronomicalBody` classes are declared here.
`AstronomicalBody` is an abstract class and holds the common properties of
`Star` and `Planet`, which in this case is only the property `Name`.

The classes `APIResponse` and its generic version are also declared here.
They contain the appropriate properties to communicate the result of a API call.
`APIResponse.Success` is a boolean letting the caller know of the success of
the call. `APIResponse.Message` is for communicating with the caller. We use
this to let the caller know what went wrong if `APIResponse.Success` is deemed
to be false. The generic version also has the property `APIResponse<T>.Result`,
result being of type `T`. This holds the object resultant of the API call.

References: nothing

#### EXODataHandler.Parser

The .Parser is capable of reading the .csv file, validate it and create the
appropriate objects to be handled by the rest of the application.

The `IEXODataParser` interface is declared and implemented here in
`EXODataParser`. This interface only has one method `TryParse()`. The return
type is `APIResponse`, non generic, since the object resultant of the parse, if
successful, is set inside of the method to the variable passed in as an out
parameter. This was done to resemble methods in .Net like `int.TryParse()`.

An internal static class called `EXOExtensions` is declared here, containing two
extensions methods that are helpful elsewhere in the .Parser. LINQ was avoided
on purpose. Only .API uses LINQ.

The class `EXODataHandler` is capable of holding the identifier and the position
index of a header in the file.

The `EXODataStructure` struct holds the information about the structure of the
file, meaning the headers. The headers line is also parsed in by the `Parse()`
method. This method is static since its the method we use to create the
`EXODataStructure` object from the headers line in the file. The validity of
the file is done here, meaning determining if the must have headers are in the
file.

`EXOParsedData` represents the result of the parse. `AddPlanet()` is responsible
for parsing a line and turning the data in it into a `Planet` and `Star`. It's
internal since this method should only be accessible by the .Parser.

References: EXODataHandler.Core

#### EXODataHandler.Unity

This is the Unity project containing the user interface.

References: EXODataHandler.Core, EXODataHandler.Parser and EXODataHandler.API

### UML Diagram

![uml](images/uml.jpg "UML Diagram")

**Figura 1** - UML Diagram. Made with [Draw.io](https://www.draw.io/).

### References


