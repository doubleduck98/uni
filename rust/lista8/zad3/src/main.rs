use std::convert::TryInto;

fn main() {
    println!("{}", fact_string_2dec("27A0533231100".to_string()))
}

fn dec2_fact_string(nb: u64) -> String {
    fn facts_vector(nb: u64) -> Vec<u64> {
        let mut vec = vec![];
        let mut cur = 1;
        let mut ctr = 0;
        while cur < nb {
            vec.push(cur);
            ctr += 1;
            cur *= ctr;
        }
        vec.reverse();
        vec
    }
    println!("{}", nb);
    let facts = facts_vector(nb);
    let mut res = String::new();
    let mut nb = nb;
    for fact in facts {
        match nb / fact {
            x @ 0..=9 => res.push(std::char::from_digit(x.try_into().unwrap(), 10).unwrap()),
            x @ 10..=35 => res.push((('A' as u64) - 10 + x) as u8 as char),
            _ => panic!(),
        }
        nb %= fact;
    }
    res
}

fn fact_string_2dec(s: String) -> u64 {
    fn facts_vector(n: u64) -> Vec<u64> {
        let mut vec = vec![];
        let mut cur = 1;
        let mut ctr = 0;
        while ctr < n {
            vec.push(cur);
            ctr += 1;
            cur *= ctr;
        }
        println!("{:?}", vec);
        vec
    }
    let mut facts = facts_vector(s.len() as u64);
    s.chars().fold(0, |acc, ch| match ch {
        'A'..='Z' => acc + facts.pop().unwrap() * ((ch as u64) - ('A' as u64) + 10),
        '0'..='9' => acc + facts.pop().unwrap() * ch.to_digit(10).unwrap() as u64,
        _ => panic!(),
    })
}

fn testing1(nb: u64, exp: &str) -> () {
    assert_eq!(&dec2_fact_string(nb), exp)
}

fn testing2(s: &str, exp: u64) -> () {
    assert_eq!(fact_string_2dec(s.to_string()), exp)
}

#[test]
fn test0() {
    testing1(2982, "4041000");
    testing2("4041000", 2982);
}
#[test]
fn test1() {
    testing1(463, "341010");
    testing2("341010", 463);
}
#[test]
fn test2() {
    testing1(12, "2000");
    testing2("2000", 12);
}
#[test]
fn test3() {
    testing1(71, "23210");
    testing2("23210", 71);
}
#[test]
fn test4() {
    testing1(997, "1212010");
    testing2("1212010", 997);
}
#[test]
fn test5() {
    testing1(42, "13000");
    testing2("13000", 42);
}
#[test]
fn test6() {
    testing1(74523, "165300110");
    testing2("165300110", 74523);
}
#[test]
fn test7() {
    testing1(0, "");
    testing2("", 0);
}
#[test]
fn test8() {
    testing1(4, "200");
    testing2("200", 4);
}
#[test]
fn test9() {
    testing1(9876543, "27174222110");
    testing2("27174222110", 9876543);
}