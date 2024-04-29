const mysql = require('mysql2');

const dbConnection = mysql.createPool({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'khlebnikova_login',
    port: "3306"
});

module.exports = dbConnection.promise();