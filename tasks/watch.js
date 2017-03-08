"use strict";
const chokidar = require("chokidar");

const watcher = chokidar.watch(['src/js'], {
    ignored: /[/\\]\./,
    ignoreInitial: true
});

watcher.on("change", f => checkTypeOfEvent(f));
watcher.on("add", f => checkTypeOfEvent(f));

const checkTypeOfEvent = (f) => {
    const type = path.extname(f).split('.')[1];

    if(type === 'js') {}
}

exit(function() {
    console.log('♻ Cleaning up!!!');
    watcher.close();
})