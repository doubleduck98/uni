//
// Created by szipi on 12.03.2019.
//

#ifndef LISTA3_TROJKAT_H
#define LISTA3_TROJKAT_H


#include "punkt.h"

class trojkat {

private:
    punkt a;
    punkt b;
    punkt c;
    friend std::ostream& operator<<(std::ostream&, const trojkat&);

public:
    trojkat(punkt ai, punkt bi, punkt ci);
    trojkat(const trojkat &t);
    punkt get_a(){
        return a;
    }
    punkt get_b(){
        return b;
    }
    punkt get_c(){
        return c;
    }
    void przesun(double wx, double wy);
    void obroc(punkt p, double theta);
    double pole();
    double obwod();
    bool punkt_w_srodku(punkt p);
    punkt srodek();
};

inline bool czy_trojkaty_rozlaczne(trojkat a, trojkat b){
    return !(a.punkt_w_srodku(b.get_a()) &&
    a.punkt_w_srodku(b.get_b()) &&
    a.punkt_w_srodku(b.get_c()));
}

inline bool czy_zawieraja_sie(trojkat a, trojkat b){
    return (a. punkt_w_srodku(b.get_a()) && a.punkt_w_srodku(b.get_b()) && a.punkt_w_srodku(b.get_c())) ||
            (b.punkt_w_srodku(a.get_a()) && b.punkt_w_srodku(a.get_b()) && b.punkt_w_srodku(a.get_c()));
}


#endif //LISTA3_TROJKAT_H
