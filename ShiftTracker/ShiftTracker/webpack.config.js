const path = require('path');

module.exports = {
    entry: './src/typescript/main.ts',
    module: {
        rules: [
            {
                test: /\.css$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: 'style-loader',
                    },
                    {
                        loader: 'css-loader',
                        options: {
                            importLoaders: 1,
                        }
                    },
                    {
                        loader: 'postcss-loader'
                    }
                ]
            }
        ]
    }
    output: {
        filename: [__filename, 'bundle.js'].join(''),
        path: path.resolve(__dirname, './wwwroot/dist'),
    },
};