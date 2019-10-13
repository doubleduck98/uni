//
// Created by szipi on 12.03.2019.
//

#include "trojkat.h"
#include <iostream>
double pole(punkt a, punkt b, punkt c){
    return 0.5 * (a.get_x()*b.get_y() + b.get_x()*c.get_y() + c.get_x()*a.get_y() - c.get_x()*b.get_y() - a.get_x()*c.get_y() - b.get_x()*a.get_y());
}

trojkat::trojkat(punkt ai, punkt bi, punkt ci) {
    if(::pole(ai, bi, ci) == 0)
        throw std::invalid_argument("nie mozna skonstruowac trojkata o podanych punktach");

    a = ai;
    b = bi;
    c = ci;
}

trojkat::trojkat(const trojkat &t) {
    a = t.a;
    b = t.b;
    c = t.c;
}

void trojkat::przesun(double wx, double wy) {
    a.przesun(wx, wy);
    b.przesun(wx, wy);
    c.przesun(wx, wy);
}

void trojkat::obroc(punkt p, double theta) {
    a.obroc(p, theta);
    b.obroc(p, theta);
    c.obroc(p, theta);
}

double trojkat::pole() {
    return ::pole(a, b, c);
}

double trojkat::obwod() {
    return dystans_pomiedzy_punktami(a, b) + dystans_pomiedzy_punktami(b, c) + dystans_pomiedzy_punktami(a, c);
}

double sign (punkt p1, punkt p2, punkt p3){
    return (p1.get_x() - p3.get_x()) * (p2.get_y() - p3.get_y()) - (p2.get_x() - p3.get_x()) * (p1.get_y() - p3.get_y());
}

bool trojkat::punkt_w_srodku(punkt p) {
    double d1, d2, d3;
    bool has_neg, has_pos;

    d1 = sign(p, get_a(), get_b());
    d2 = sign(p, get_b(), get_c());
    d3 = sign(p, get_c(), get_a());

    has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
    has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

    return !(has_neg && has_pos);
}

punkt trojkat::srodek() {
    return {(get_a().get_x() + get_b().get_x() + get_c().get_x()) / 3,
            (get_a().get_y() + get_b().get_y() + get_c().get_y()) / 3};
}

std::ostream &operator<<(std::ostream &strm, const trojkat &t) {
    return strm << std::setprecision(3) << "{" << t.a << ", " << t.b << ", " << t.c << "}";
}
