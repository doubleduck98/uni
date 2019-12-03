fn main() {
    println!("{}", order(r"is2 Thi1s T4est 3a"));
}

fn order(sentence: &str) -> String {
    let mut vec = Vec::<(String, u32)>::new();
    let mut res = Vec::<String>::new();
    sentence.split_whitespace().for_each(|w| {
        let num: u32 = w
            .matches(char::is_numeric)
            .collect::<String>()
            .parse()
            .unwrap();
        vec.push((w.to_string(), num));
    });
    vec.sort_by(|a, b| a.1.cmp(&b.1));
    vec.iter().for_each(|p| res.push(p.0.clone()));
    res.join(" ")
}

#[test]
fn test0() {
    assert_eq!(order("is2 Thi1s T4est 3a"), "Thi1s is2 3a T4est");
}
#[test]
fn test1() {
    assert_eq!(order(""), "");
}
#[test]
fn test2() {
    assert_eq!(order("Zienkiewic2z Sz1ymon"), "Sz1ymon Zienkiewic2z");
}
#[test]
fn test3() {
    assert_eq!(order("Ru8st"), "Ru8st");
}
#[test]
fn test4() {
    assert_eq!(order("heniu2 siem1a"), "siem1a heniu2");
}
#[test]
fn test5() {
    assert_eq!(order("t1he quic2k 8dog ove6r l7azy brow3n fo4x ju5mped"), "t1he quic2k brow3n fo4x ju5mped ove6r l7azy 8dog");
}
#[test]
fn test6() {
    assert_eq!(order("a4 b5 c1 d4 e2"), "c1 e2 a4 d4 b5");
}
#[test]
fn test7() {
    assert_eq!(order("jh5 a4 lasdj3o ia1sdoais d2ax c6z"), "ia1sdoais d2ax lasdj3o a4 jh5 c6z");
}
#[test]
fn test8() {
    assert_eq!(order("a4 e1 s2 s3"), "e1 s2 s3 a4");
}
#[test]
fn test9() {
    assert_eq!(order("no4t th3e e2xact 1order"), "1order e2xact th3e no4t");
}
