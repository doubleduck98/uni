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

async function dodaj() {
    try {
        const data_mp = await db.one('INSERT INTO miejsce_pracy (name) VALUES (\'kierowca wyscigowy\') RETURNING id');
        console.log(data_mp);
        try {
            await db.none(`INSERT INTO osoba (name, surname, PESEL, sex, id_miejsce_pracy) VALUES (\'Kimi\', \'Raikkonen\', \'79101700234\', \'M\', \'${data_mp.id}\')`);
        } catch (error) {
            console.log('error przy osobie:' + error);
        }
    } catch (error) {
        console.log('error przy pracy:' + error);
    }
}

dodaj();