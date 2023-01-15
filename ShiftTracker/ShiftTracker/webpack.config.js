const path = require('path');
module.exports = {
    entry: './src/Index.ts',
    devtool: 'inline-source-map',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
            {
                test: /\.css$/,
                use: [
                    'style-loader',
                    'css-loader'
                ]
            },
            {
                test: /\.scss$/,
                use: [
                    'style-loader',
                    'css-loader',
                    'sass-loader'
                ]
            }
        ],
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js'],
    },
    output: {
        library: {
            name: 'ShiftTracker',
            type: 'var'
        },
        filename: 'bundle.js',
        path: path.resolve(__dirname, './wwwroot/js'),
    }
};
//# sourceMappingURL=webpack.config.js.map