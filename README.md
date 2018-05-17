<div style="display: inline-block; width: 100%; clear: both;">
<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 200 200" width="100" height="100" style="float: left;">
<polygon fill="#19F" points="100,170 65,135 135,135 "></polygon>
<rect fill="#EA0" x="65" y="110" width="70" height="25"></rect>
<rect fill="#E62" x="65" y="85" width="70" height="25"></rect>
<polygon fill="#C25" points="135,85 65,85 65,70 80,55 120,55 135,70 "></polygon>
<path stroke="#333" fill="none" stroke-width="15" d="M140 90c0-22-18-40-39-40C78 50 60 68 60 91V110c0 14 5 27 15 37 l25 25l25-25c10-10 15-23 15-37V90z"></path>
<path stroke="#333" fill="none" stroke-width="15" d="M60 74v50c0 11-9 21-21 21h0c-18 0-27-22-15-35L60 74z"></path>
<path stroke="#333" fill="none" stroke-width="15" d="M140 74v50c0 11 9 21 21 21h0c18 0 27-22 15-35L140 74z"></path>
<line stroke="#333" fill="none" stroke-width="15" stroke-linecap="round" x1="60" y1="30" x2="80" y2="50"></line>
<line stroke="#333" fill="none" stroke-width="15" stroke-linecap="round" x1="140" y1="30" x2="120" y2="50"></line>
</svg>
<div style="font-size: 5em; float: left; display: block;">+</div>
<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" x="0px" y="0px" viewBox="0 0 48 48" xml:space="preserve" width="100" height="100" style="float: left;"><path d="M24 4C12.96 4 4 12.96 4 24c0 11.05 8.96 20 20 20s20-8.96 20-20S35.04 4 24 4zm0 34.98c-8.81 0-14.98-6.79-14.98-14.98 0-8.18 6.79-14.98 14.98-14.98 8.18 0 15.02 6.68 15.02 14.86 0 8.19-6.21 15.1-15.02 15.1z" fill="#C62828"/><path d="M35.59 31.129s-4.197 7.217-13.375 6.246c-8.894-.951-10.6-8.423-10.688-8.894 1.912 3.52 4.756 6.217 11.58 6.217 7.129 0 9.806-5.354 9.806-5.354l2.677 1.785z" fill="#C62828"/><path d="M36.482 30.236l-3.569-1.775s-3.569 5.344-9.806 5.344c-6.903 0-8.796-3.354-8.903-3.559 3.412 3.402 8.09 3.059 11.58 1.775 7.815-2.863 7.129-9.806 7.129-9.806h4.462s.892 5.354-.893 8.021z" fill="#C62828"/><path d="M32.021 21.323s.392 7.227-6.236 9.806c-3.491 1.363-6.884.098-7.129 0 0 0 2.628.471 4.452 0 3.569-.892 5.256-2.491 6.236-4.452 2.677-5.354-.883-8.913-.883-8.913l4.452-3.569s4.256 3.677 4.462 7.129h-5.354z" fill="#C62828"/><metadata><rdf:RDF xmlns:rdf="http://www.w3.org/1999/02/22-rdf-syntax-ns#" xmlns:rdfs="http://www.w3.org/2000/01/rdf-schema#" xmlns:dc="http://purl.org/dc/elements/1.1/"><rdf:Description about="https://iconscout.com/legal#licenses" dc:title="sitecore" dc:description="sitecore" dc:publisher="Iconscout" dc:date="2017-12-15" dc:format="image/svg+xml" dc:language="en"><dc:creator><rdf:Bag><rdf:li>Icons8</rdf:li></rdf:Bag></dc:creator></rdf:Description></rdf:RDF></metadata></svg>
</div>

[![Build status](https://ci.appveyor.com/api/projects/status/3r00y6b4swh3tb7s?svg=true)](https://ci.appveyor.com/project/edames/sitecore-huebee)

Sitecore Huebee is a sitecore module that provides a color picker field for data templates and renderings.

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