const pgp = require('pg-promise')();

// configuration object
const cn = {
    host: 'localhost',
    port: 5432,
    database: 'weppol8',
    user: 'postgres'
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

function insert(name, surname, pesel, sex) {
    return db.one(`INSERT INTO osoba (name, surname, PESEL, sex) VALUES ('${name}', '${surname}', '${pesel}', '${sex}') RETURNING id`)
        .then(data => {
            console.log(data.id);
        })
        .catch(error => {
            console.log('ERROR:', error);
        });
}

async function res() {
    await select;
    await insert('Lewis', 'Hamilton', '85010789344', 'M');
}

res();