# .NET Keytar

## Building

### Native Wrapper

git submodule update/init

```bash
cd ./native-wrapper
autoreconf -i
./configure
make
cd -
```

### net-keytar

```bash
dotnet build
dotnet test
dotnet pack -o ./pack -c Release
```