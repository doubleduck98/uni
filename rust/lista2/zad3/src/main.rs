fn main() {
    print!("{}", summy("9 9 7"))
}

fn summy(strng: &str) -> i32 {
    strng
        .split_whitespace()
        .map(|s| s.parse::<i32>().unwrap())
        .sum()
}

#[test]
fn test0() {
    assert_eq!(summy("1 2 3"), 6);
}
#[test]
fn test1() {
    assert_eq!(summy("1 2 3 4"), 10);
}
#[test]
fn test2() {
    assert_eq!(summy("1 2 3 4 5"), 15);
}
#[test]
fn test3() {
    assert_eq!(summy("10 10"), 20);
}
#[test]
fn test4() {
    assert_eq!(summy("0 0"), 0);
}
#[test]
fn test5() {
    assert_eq!(summy("1 4 1 0"), 6);
}
#[test]
fn test6() {
    assert_eq!(summy("1 9 7 8"), 25);
}
#[test]
fn test7() {
    assert_eq!(summy("9 8 1 1 1 6"), 26);
}
#[test]
fn test8() {
    assert_eq!(summy("-2 -1 -5 -6"), -14);
}
#[test]
fn test9() {
    assert_eq!(summy("4 2 4 2 4 2 4 2 4 2 4 2 4 2"), 42);
}
