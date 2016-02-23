# Rogero.Autofac.Helpers
A simple library that provides a few extensions to Autofac.

## Install
```
Install-Package Rogero.Autofac.Helpers
```
[https://www.nuget.org/packages/Rogero.Autofac.Helpers/](https://www.nuget.org/packages/Rogero.Autofac.Helpers/)

## Helpers

##### Register self
```csharp
builder.RegisterSelf<SomeObject>();
```
##### Register Default interface - Register IDateTimeRepository provided DateTimeRepository
```csharp
builder.RegisterDefaultInterface<DateTimeRepository>();
```
##### Register Singleton
```csharp
builder.RegisterSingleton<SomeObject>();
```
##### Register Singleton by providing instance
```csharp
builder.RegisterSingleton(new SomeObject());
```

