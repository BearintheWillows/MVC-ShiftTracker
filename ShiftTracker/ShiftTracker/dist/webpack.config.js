const path = require('path');
module.exports = {
    entry: './ClientScripts/Index.ts',
    devtool: 'inline-source-map',
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
        filename: 'bundle.js',
        path: path.resolve(__dirname, './wwwroot/js'),
    }
};
//# sourceMappingURL=webpack.config.js.map