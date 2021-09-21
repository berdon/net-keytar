# .NET Keytar

Cross-Platform (soon) access to OS keychain/password management.

Supports MacOS keychain only for right now.

## Specifics

.NET wrapper around [node-keytar's](https://github.com/atom/node-keytar) native implementation and OS bindings.

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