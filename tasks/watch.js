"use strict";
const chokidar = require("chokidar");
const shell = require( "shelljs");
const path = require( "path");
const exit = require( "exit-hook");
const pkg = require('package');

const watcher = chokidar.watch(['src/js', 'src/**/*.cs'], {
    ignored: /[/\\]\./,
    ignoreInitial: true
});

watcher.on("change", f => checkTypeOfEvent(f));
watcher.on("add", f => checkTypeOfEvent(f));

const checkTypeOfEvent = (f) => {
    const type = path.extname(f).split('.')[1];

    if(type === 'js') {}
    if(type === 'cs') {
        buildModule();
    }
}

const buildModule = () => {
  console.log(pkg.config.unicorn);
  shell.exec('msbuild src/Sitecore.Huebee.csproj /p:Configuration=Debug', function(code, output){
    console.log('Building Sitecore Module!!!');
  });
}

exit(function() {
    console.log('♻ Cleaning up!!!');
    watcher.close();
})