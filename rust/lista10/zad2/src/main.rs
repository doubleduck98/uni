use std::collections::HashMap;

fn main() {
    let a = vec!["BBAR 150", "CDXE 515", "BKWR 250", "BTSQ 890", "DRTY 600"];
    let b = vec!["A", "B", "C", "D"];
    println!("{}", stock_list(a, b))
}

fn stock_list(list_art: Vec<&str>, list_cat: Vec<&str>) -> String {
    if list_art.is_empty() || list_cat.is_empty() {
        return String::new();
    }
    let mut map: HashMap<String, u32> = HashMap::new();
    let mut res: Vec<String> = Vec::new();
    for art in list_art {
        let art_type: String = art.chars().nth(0).unwrap().to_string();
        let quantity: u32 = art.split_whitespace().next_back().unwrap().parse().unwrap();
        *map.entry(art_type).or_insert(0) += quantity;
    }
    for cat in list_cat {
        res.push(format!("({} : {})", cat, map.get(cat).unwrap_or(&0)))
    }
    res.join(" - ")
}

#[test]
fn test0() {
    let a = vec!["BBAR 150", "CDXE 515", "BKWR 250", "BTSQ 890", "DRTY 600"];
    let b = vec!["A", "B", "C", "D"];
    assert_eq!(
        stock_list(a, b),
        "(A : 0) - (B : 1290) - (C : 515) - (D : 600)"
    );
}
#[test]
fn test1() {
    let a = vec![
        "BTSQZFG 239",
        "BKWR 250",
        "RHODODE 123",
        "RHODODEF 123",
        "BKWRK 25",
        "RHODODEC 123",
    ];
    let b = vec!["C", "R", "W", "X"];
    assert_eq!(stock_list(a, b), "(C : 0) - (R : 369) - (W : 0) - (X : 0)");
}
#[test]
fn test2() {
    let a = vec![
        "BTSQ 890",
        "XILO 32",
        "BKWRK 25",
        "ROXANNEC 102",
        "DRTYMKH 060",
    ];
    let b = vec!["U", "F", "R"];
    assert_eq!(stock_list(a, b), "(U : 0) - (F : 0) - (R : 102)");
}
#[test]
fn test3() {
    let a = vec![
        "ROB 530",
        "BTSQZ 89",
        "RHODODEA 123",
        "CDXEG 50",
        "BKWRKAE 125",
        "DRTYMKA 060",
        "BKWRKAA 125",
        "XILO 32",
    ];
    let b = vec!["B", "A", "U"];
    assert_eq!(stock_list(a, b), "(B : 339) - (A : 0) - (U : 0)");
}
#[test]
fn test4() {
    let a = vec![
        "BKWRK 25",
        "DRTYMKH 060",
        "DRTYMD 060",
        "DRTYME 060",
        "ROXANNEB 102",
    ];
    let b = vec!["F", "A", "W", "B"];
    assert_eq!(stock_list(a, b), "(F : 0) - (A : 0) - (W : 0) - (B : 25)");
}
#[test]
fn test5() {
    let a = vec![
        "RO 530",
        "UZO 32000",
        "BKWRKAE 125",
        "DRTYMKB 060",
        "ROXANNEC 102",
    ];
    let b = vec!["W", "X", "B", "A"];
    assert_eq!(stock_list(a, b), "(W : 0) - (X : 0) - (B : 125) - (A : 0)");
}
#[test]
fn test6() {
    let a = vec![
        "BKWRKAD 125",
        "DRTYMKA 060",
        "ROXANNEB 102",
        "ROXANNEA 102",
        "BKWRKAA 125",
        "DRTY 600",
        "RHIB 1230",
    ];
    let b = vec!["A", "C", "X", "W"];
    assert_eq!(stock_list(a, b), "(A : 0) - (C : 0) - (X : 0) - (W : 0)");
}
#[test]
fn test7() {
    let a = vec![
        "ABAR 200",
        "ROXANNEA 102",
        "BTSQZ 89",
        "RHODODEF 123",
        "CDXEF 500",
        "BKWRKAD 125",
    ];
    let b = vec!["U", "A", "R"];
    assert_eq!(stock_list(a, b), "(U : 0) - (A : 200) - (R : 225)");
}
#[test]
fn test8() {
    let a = vec![
        "RHODODEF 123",
        "BTSQZE 239",
        "DRTYMC 060",
        "BKWRK 25",
        "BTSQZC 239",
        "BTSQA 890",
        "BKWRKAD 125",
        "ROXANNEB 102",
    ];
    let b = vec!["A", "R", "C", "F"];
    assert_eq!(stock_list(a, b), "(A : 0) - (R : 225) - (C : 0) - (F : 0)");
}
#[test]
fn test9() {
    let a = vec![];
    let b = vec![];
    assert_eq!(stock_list(a, b), "");
}
