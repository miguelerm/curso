'use strict';

const express = require('express');
const os = require('os');

const hostname = os.hostname();
const PORT = 80;

const app = express();

app.set('views', './views');
app.set('view engine', 'jade');


app.get('/', function(req, res) {
    res.render('index', { title: 'Express App', message: 'Hello there (' + hostname + ')!' });
});

app.listen(PORT, function () {
    console.log('Running on http://localhost:' + PORT + ' on machine ' + hostname);
});
