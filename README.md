### NameSorter

[![.NET Build and Test](https://github.com/gwasserfall/name-sorter/actions/workflows/pr-build.yml/badge.svg)](https://github.com/gwasserfall/name-sorter/actions/workflows/pr-build.yml)

A small CLI application that sorts names in a text file. Names are sorted by **last name** first, then **given names**.
The sorted list is written to sorted-names-list.txt and also printed to stdout.

#### Usage

```
./name-sorter.exe ./Namelists/baseline-unsorted.txt

Alice James
Mary Jane
John Wilkens
```

Input file should contain one name per line e.g.

```
Wayne Norton
Yehuda Anders
Layton Nolan
Iker JoJo Wilkens
Ada Norris
Haley Nunez
Rhett Chuck Norris
Alisson Nolan
```


#### Build from source

Requires [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) or later.

```
dotnet restore
```

```
dotnet publish ./NameSorter/NameSorter.csproj -c Release -r win-x64 --self-contained false /p:PublishSingleFile=true /p:DebugType=none -o .
```

