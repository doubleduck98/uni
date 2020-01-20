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

// takie głupie dla jednej kolumny
async function update(kolumna, co, czym) {
    try {
        await db.none(`UPDATE osoba SET ${kolumna}='${czym}' WHERE ${kolumna}='${co}'`);
        console.log('pomyślnie zaktualizowano');
    } catch (error) {
        console.log(error);
    }
}


async function usun(kolumna, co) {
    try {
        const result = await db.result(`DELETE FROM osoba WHERE ${kolumna}='${co}'`);
        // rowCount = number of rows affected by the query
        console.log('usunieto ' + result.rowCount + ' wierszy');
    } catch (error) {
        console.log(error);
    }
}

async function res() {
    update('name', 'Szipi', 'Szymon');
    // usun('name', 'Charles');
}

res();