fn main() {
    println!("{}", dig_pow(3456789, 5));
}

fn dig_pow(n: i64, p: i32) -> i64 {
    let nvec: Vec<i64> = n
        .to_string()
        .chars()
        .map(|d| i64::from(d.to_digit(10).unwrap()))
        .collect();
    let mut exp: u32 = p as u32;
    let i: i64 = nvec.iter().fold(0, |acc, x| {
        exp += 1;
        acc + x.pow(exp - 1)
    });
    let hm = (i as f64) / (n as f64);
    if hm.fract() != 0.0 {
        return -1;
    }
    i / n
}

#[test]
fn test0() {
    assert_eq!(dig_pow(89, 1), 1)
}
#[test]
fn test1() {
    assert_eq!(dig_pow(92, 1), -1)
}
#[test]
fn test2() {
    assert_eq!(dig_pow(695, 2), 2)
}
#[test]
fn test3() {
    assert_eq!(dig_pow(46288, 3), 51)
}
#[test]
fn test4() {
    assert_eq!(dig_pow(3456789, 5), -1)
}
#[test]
fn test5() {
    assert_eq!(dig_pow(9, 1), 1)
}
#[test]
fn test6() {
    assert_eq!(dig_pow(512125, 2), -1)
}
#[test]
fn test7() {
    assert_eq!(dig_pow(997, 1), -1)
}
#[test]
fn test8() {
    assert_eq!(dig_pow(10, 1), -1)
}
#[test]
fn test9() {
    assert_eq!(dig_pow(24, 2), -1)
}
