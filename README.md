# INIParser
Very basic INI parser/serializer

# Getting started
All code examples expect the following using clauses:

```csharp
using INIParser;
```

## Read

### Initialize parser

#### With default settings
```csharp
var parser = new IniDataParser();
```
#### With custom settings
```csharp
var parser = new IniDataParser(new IniConfiguration
{ AssignmentSymbol = "->", CommentSymbol = "//", SkipInvalidLines = true });
```

### Read from file
```csharp
var parser = new IniDataParser();
var data = parser.ParseFromFile("config.ini");
```
### Read from string
```csharp
var ini = @"
[General]
Nickname = Roxxel";
var parser = new IniDataParser();
var data = parser.Parse(ini);
```


## Retrieve data
Values are always retrieved as `string`s.
```csharp
var nick = data["General"]["Nickname"];
```

`Note that you must put your properties into Section, otherwise it won't work`

## Write (Serialize)

```csharp
var serializer = new IniSerializer();
string serialized = serializer.Serialize(objectToSerialize);
```
`Serializer supports only primitive types and string`

## Contributing
Do you have an idea to improve this library, or did you happen to run into a bug? Please share your idea or the bug you found in the issues page, or even better: feel free to fork and contribute to this project with a Pull Request.
