const path = require('path');
const {CleanWebpackPlugin} = require('clean-webpack-plugin');
module.exports = {
    entry: {
        scss: './src/scss/site.scss',
        index: './src/typescript/index.ts',
    },
    mode: 'development',
    optimization: {
        minimize: false
    },
    devtool: 'inline-source-map',
    plugins: [
        new CleanWebpackPlugin(),
    ],
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
            name: 'JS',
            type: 'var'
        },
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, './wwwroot/js'),
    },

};
//# sourceMappingURL=webpack.config.js.map