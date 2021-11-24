# OceanWebSystems.EnumEntity
**An extension to build a lookup table for each enum type used in a DbContext model.**
## Install
**NuGet Package**
To install the package run the following command on the Package Manager Console:
```
PM> Install-Package OceanWebSystems.EnumEntity
```
[![NuGet Status](https://img.shields.io/nuget/v/OceanWebSystems.EnumEntity.svg?style=flat)](https://www.nuget.org/packages/OceanWebSystems.EnumEntity/)
## Usage
Add a using statement referencing `OceanWebSystems.EnumEntity`.
Override the `OnModelCreating` method in your `DbContext`. e.g.
```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	modelBuilder.CreateEnumEntityTables();
	base.OnModelCreating(modelBuilder);
}
```
Add a migration. e.g. (in the Package Manager Console)
```
PM> Add-Migration AddEnumEntityTables
```