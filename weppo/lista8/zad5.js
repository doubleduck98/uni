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
        const data_mp = await db.one('INSERT INTO miejsce_pracy (name) VALUES (\'inzynier wyscigowy\') RETURNING id');
        try {
            const data_os = await db.one(`INSERT INTO osoba (name, surname, age, sex, id_miejsce_pracy) VALUES (\'Peter\', \'Bonnington\', 38, \'M\', \'${data_mp.id}\') RETURNING id`);
            try {
                await db.none(`INSERT INTO osoba_miejsca (id_osoba, id_praca) VALUES(${data_os.id}, ${data_mp.id})`);
                console.log('pomyslnie uzupelniono');
            } catch (error) {
                console.log('error przy os_prac: ' + error);
            }
        } catch (error) {
            console.log('error przy osobie:' + error);
        }
    } catch (error) {
        console.log('error przy pracy:' + error);
    }
}

dodaj();