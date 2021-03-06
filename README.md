# UniqueId

A simple library (Windows and Linux) to create an unique integer (32 and 64 bits) from a string.

**Windows 10**
```
$ ./UniqueIdCmd.exe  test
Id 32bits: 160394189 64bits: 688887797400064883
$ ./UniqueIdCmd.exe Test
Id 32bits: 213673489 64bits: 917720651393141712
```

**Ubuntu 18.06**
```
[~/prj/uniqueid/UniqueIdCppCmd] ./UniqueIdCppCmd test
Id 32bits: 160394189 64bits: 688887797400064883
[~/prj/uniqueid/UniqueIdCppCmd] ./UniqueIdCppCmd Test
Id 32bits: 213673489 64bits: 917720651393141712
```

The project has a C# and C++ library and command line program.

## Example of usage

### C-Sharp

```c#
// Generate the id
try
{
    var id = new UniqueId.UniqueId(args[0]);
    Console.WriteLine($"Id 32bits: {id.GetId()} 64bits: {id.GetId64()}");
}
catch (ArgumentException exception)
{
    Console.WriteLine(exception.Message);
    return 2;
}

```

### C++

```c++
// Generate the id
try
{
    const auto id = new unique_id(args[1]);
    std::cout << "Id 32bits: " << id->get_id();
#ifdef USE_64
	std::cout << " 64bits: " << id->get_id64();
#endif
    std::cout << std::endln;
	delete id;
}
catch (std::exception& exception)
{
    std::cout << exception.what();
    return 2;
}
```

Tested with Visual Studio 2015 and Ubuntu 18.04.

