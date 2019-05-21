//
// Created by szipi on 09.04.2019.
//

#include <stdexcept>
#include <iostream>
#include <map>
#include "zmienna.h"

zmienna::zmienna(string nazwa) {
    this->nazwa = std::move(nazwa);
}

double zmienna::oblicz(const map<string, double> &zm) {
    return zm.at(this->nazwa);
}

double zmienna::oblicz() {
    return 0;
}
