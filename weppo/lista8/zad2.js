const pgp = require('pg-promise')();

// configuration object
const cn = {
    host: 'localhost',
    port: 5432,
    database: 'weppol8',
    user: 'postgres',
    password: 123
};

const db = pgp(cn);

// any(query, valuesopt) → {external:Promise.<Array>}
let select = db.any('SELECT * FROM osoba')
    .then(function (data) {
        console.log(data);
        return data;
    })
    .catch(function (error) {
        console.log(error);
    });

async function insert(name, surname, age, sex) {
    try {
        const data = await db.one(`INSERT INTO osoba (name, surname, age, sex) VALUES ('${name}', '${surname}', ${age}, '${sex}') RETURNING id`);
        console.log(data.id);
    }
    catch (error) {
        console.log('ERROR:', error);
    }
}

async function res() {
    await select;
    // await insert('Lewis', 'Hamilton', 36, 'M');
}

res();