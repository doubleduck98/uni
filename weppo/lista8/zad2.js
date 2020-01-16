const pgp = require('pg-promise')();

// configuration object
const cn = {
    host: 'localhost',
    port: 5432,
    database: 'weppol8',
    user: 'postgres'
};

const db = pgp(cn);

function select() {
    return new Promise((result, rejected) => {
        db.one('SELECT * FROM osoba')
            .then(data => {
                result(data);
            })
            .catch(error => {
                rejected(error);
            });
    });
}

async function res() {
    let res = await select();
    console.log(res);
}

res();