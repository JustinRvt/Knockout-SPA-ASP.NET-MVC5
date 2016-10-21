require('../css/app')
let ko = require('knockout')
let $ = require('jQuery')
let req = require('requirejs')
const content = require('../html/index')

document.body.innerHTML = content

$(document).ready(function () {
  ko.applyBindings({})
})

console.log('Webpack loaded')
