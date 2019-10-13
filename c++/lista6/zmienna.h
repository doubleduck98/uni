//
// Created by szipi on 09.04.2019.
//

#ifndef LISTA6_ZMIENNA_H
#define LISTA6_ZMIENNA_H

#include <vector>
#include "wyrazenie.h"

class zmienna : public wyrazenie {
private:
    string nazwa;
public:
    explicit zmienna(string nazwa);

    double oblicz() override;

    double oblicz(const map<string, double> &zm) override;

    string opis() override {
        return nazwa;
    }
};

#endif //LISTA6_ZMIENNA_H
