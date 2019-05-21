//
// Created by szipi on 12.03.2019.
//

#include "odcinek.h"
#include <iostream>

odcinek::odcinek(punkt ai, punkt bi) {
    if(punkt::same_as(ai, bi))
        throw std::invalid_argument("nie mozna stworzyc odcinka o dlugosci 0");
    a = ai;
    b = bi;
}

odcinek::odcinek(const odcinek &o) {
    a = o.a;
    b = o.b;
}

void odcinek::przesun(double wx, double wy) {
    a.przesun(wx, wy);
    b.przesun(wx, wy);
}

void odcinek::obroc(punkt p, double theta) {
    a.obroc(p, theta);
    b.obroc(p, theta);
}

double odcinek::dlugosc_odcinka() {
    return dystans_pomiedzy_punktami(a, b);
}

bool odcinek::czy_punkt_lezy_na_odcinku(punkt p) {
    return dystans_pomiedzy_punktami(a, p) + dystans_pomiedzy_punktami(p, b) == dlugosc_odcinka();
}

punkt odcinek::srodek_odcinka() {
    return {(a.get_x() + b.get_x())/2, (a.get_y() + b.get_y())/2};
}

std::ostream &operator<<(std::ostream &strm, const odcinek &o) {
    return strm << std::setprecision(3) << "{" << o.a << ", " << o.b << "}";
}


