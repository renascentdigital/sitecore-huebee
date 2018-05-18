![Sitecore + Huebee](sitecore-huebee.png)

[![Build status](https://ci.appveyor.com/api/projects/status/3r00y6b4swh3tb7s?svg=true)](https://ci.appveyor.com/project/edames/sitecore-huebee)

Sitecore Huebee is a module that provides a color picker field for data templates and renderings.

## Pre-requisites

* Visual Studio 2017 Community Edition or higher
* NodeJS
* Yarn

## Getting Started

Run:
```
yarn install
```

### Starting Watcher

Run:
```
npm start
```

If you don't want to run the watcher and just build out the JavaScript, run:

```
npm run build:js
```

### Publish Project

The solution assumes that a blank Sitecore 9 instance is setup under `C:\inetpub\wwwroot\sc900.local\`.  If you need to change this, create a `.user` file in the same location `publishsettings.targets` exists.  Configure by setting the `publishUrl`:

```
<Project ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
        <publishUrl>http://sc900.local</publishUrl>
        <ExcludeFilesFromDeployment>packages.config, Web.config</ExcludeFilesFromDeployment>
    </PropertyGroup>
    <Import Project="./publishsettings.targets.user" Condition="exists('./publishsettings.targets.user')" /> 
</Project>
```

Publish will copy what WebPack builds out under the dist folder and includes it to publish to site indicated under `publishsettings.targets`.

### Credits

Sitecore Huebee is dependent on the package Huebee by Metafizzy - [https://github.com/metafizzy/huebee](https://github.com/metafizzy/huebee). Version 2.0.0 is licensed under MIT license.