const path = require('path');

module.exports = {
    entry: './ClientScripts/app.ts',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ],
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js'],
    },
    output: {
        library: {
            name: 'MYAPP',
            type: 'var'
        },
        filename: 'app.js',
        path: path.resolve(__dirname, './wwwroot/js'),
    }
};