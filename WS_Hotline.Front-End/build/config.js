var path = require('path');
var nodes_modules_dir = path.resolve(__dirname, 'nodes_modules');

// La seule configuration a modifier.
module.exports = {
    entry: {
        app: ['./src/js/main.js']
    },
    output: {
        path: path.resolve(__dirname, '../dist/assets'), // attention ce dossier sera vidé systématiquement (ne rien y mettre !)
        //filename: '[name]-[hash:7].js',
        publicPath: '/assets/'
    },
    // Fichiers / dossiers à copier
    directories: [],
    files: [],
    port: 3002,
    // proxy: 'http://localhost:8000', // Pour PHP / Ruby ou autre
    base: './src',
    support: ['last 2 versions'], // Pour autoprefixer
    forceReload: ['./src/index.html'],
    extractsHtml: [
        { filename: 'index.html', template: './src/html/index.pug' } // Chemin par rapport où on lance la commande !
    ]
}
