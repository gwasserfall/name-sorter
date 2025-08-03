### NameSorter

A small cli application to sort a name of lists in text file. Names will be sorted
by last name first, then given name


#### Usage

`./name-sorter.exe ./unsorted-names.txt`

This will output the sorted names to stdout and write the names to an output file in the same directory
`sorted-names-list.txt`

#### Build from source

`dotnet restore`

`dotnet build --configuration Release`

`cp NameSorter/bin/Release/net8.0/name-sorter.exe ./`

