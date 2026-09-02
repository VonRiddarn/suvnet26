# cli-todo

Simple TODO application using a CLI. written using restrictions made up by the teacher.

## 🚫 Restrictions

Everything is stored in arrays and handled using loops and conditions. No `List<>` or `LINQ`  
No new classes shall be created.  
No new methods shall be created.

## 💻 How to run

Run these commands in order:

`dotnet build --configuration release --output ./build`  
_This builds a release version of the project to a local `build` directory._

`cd build`  
_This changes the current working directory to the `build` directory._

`todo add "my first task"`  
_This runs the program and adds a task._

Tip:  
Use `todo -h` to see other available commands.

## 🤔 How it works

All tasks are saved in a separate `tasks.csv` file as comma separated values.  
When running the command `todo add` we load the file into memory using `File.ReadAllLines`
and merge it with the arguments of the new command using a collection expression.

We then re-write the data to file using `File.WriteAllLines`.

The process of loading the data from file to memory, mutating it and re-writing it is the same
for basically every other command, with certain nuances for each one.

## 🫠 The comma hack

Since the `tasks.csv` file is a CSV file, commas will break the parsing.  
Thus I added a simple hack where I replace commas in the stored name with a HTML-like placeholder: `&cm;`.  
All user facing instances of the name then replaces the `&cm;` placeholder with a regular comma `,`.

This is done using a simple `string.Replace`.
