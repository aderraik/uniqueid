# UniqueId

A simple library (Windows, Linux, and Python) to create an unique integer (32 and 64 bits) from a string.

## Windows 10

```shell
$ ./UniqueIdCmd.exe  test
Id 32bits: 160394189 64bits: 688887797400064883
$ ./UniqueIdCmd.exe Test
Id 32bits: 213673489 64bits: 917720651393141712
```

## Linux

```shell
$ ./UniqueIdCppCmd test
Id 32bits: 160394189 64bits: 688887797400064883
$ ./UniqueIdCppCmd Test
Id 32bits: 213673489 64bits: 917720651393141712
$ python -m uniqueid test
Id 32bits: 160394189 64bits: 688887797400064883
$ python -m uniqueid Test
Id 32bits: 213673489 64bits: 917720651393141712
```

The project has a C#, C++, and Python library and command line program.

## Example of usage

### C-Sharp

```cs
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

```cpp
// Generate the id
try
{
    const auto id = new unique_id(args[1]);
    std::cout << "Id 32bits: " << id->get_id();
#ifdef USE_64
    std::cout << " 64bits: " << id->get_id64();
#endif
    std::cout << std::endl;
    delete id;
}
catch (std::exception& exception)
{
    std::cout << exception.what();
    return 2;
}
```

### Python

```python
from uniqueid import UniqueId

# Generate the id
try:
    uid = UniqueId("test")
    print(f"Id 32bits: {uid.get_id()} 64bits: {uid.get_id64()}")
except ValueError as e:
    print(e)
    sys.exit(2)
```

**CLI:** `python -m uniqueid "test"` or, after `pip install .`, run `uniqueid "test"`.

**Tests:** `python -m pytest tests/` or `python -m unittest discover -s tests -p "test_*.py"`.

Tested with Visual Studio 2015, Ubuntu 18.04, and Python 3.8+.
