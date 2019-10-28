autko = {
    marka: 'aston martin',
    model: 'db9',
    'rok produkcji': '2012',
    kolor: 'szary',
    silnik: {
        moc: '475',
        rodzaj: 'V6'
    },
    nic: 'dasdasd'
}

nic = {
    nic: 'nic'
}

console.log(autko.kolor);
console.log(autko['kolor']);
console.log(autko['rok produkcji']);

console.log(autko[3]);
console.log(autko[nic]);


tablica = ['szymon', 'zienkiewicz', 16, 11, 1998];

console.log(tablica[3]);
console.log(tablica['3']);
console.log(tablica.length)
tablica.length = 2;
console.log(tablica[1])
console.log(tablica.length)
tablica.length = 8;
console.log(tablica.length)
console.log(tablica[1])