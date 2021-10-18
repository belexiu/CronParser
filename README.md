# CronParser
This is a command line application that parses a cron string and expands each field to show the times at which it will run.
It accespts only the standard cron format with five time fields (minute, hour, day of month, month, and day of weeek) plus a command. 
The program does not handle special time string such as "@yearly". The input should be provided on a single line.

## Run
To run the application and pass a cron string execute the following command inside the folder containing the CronParser project.
```
dotnet run -- "*/15 0 1,15 * 1-5 /usr/bin/find"
```

## Test
To run the tests execute the following command inside the root folder.
```
dotnet test
```

## Examples
```
dotnet run -- "*/15 0 1,15 * 1-5 /usr/bin/find"
```

should yeld the following output:

```
minute         0 15 30 45
hour           0
day of month   1 15
month          1 2 3 4 5 6 7 8 9 10 11 12
day of week    1 2 3 4 5
command        /usr/bin/find
```
