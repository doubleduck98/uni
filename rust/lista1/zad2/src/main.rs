fn main() {
    println!("{}", string_to_number("997"));
}

fn string_to_number(s: &str) -> i32 {
    return s.parse().unwrap();
}

#[test]
fn test0() {
    assert_eq!(string_to_number("42"), 42);
}
#[test]
fn test1() {
    assert_eq!(string_to_number("782365892"), 782365892);
}
#[test]
fn test2() {
    assert_eq!(string_to_number("997"), 997);
}
#[test]
fn test3() {
    assert_eq!(string_to_number("-2"), -2);
}
#[test]
fn test4() {
    assert_eq!(string_to_number("18"), 18);
}
#[test]
fn test5() {
    assert_eq!(string_to_number("0"), 0);
}
#[test]
fn test6() {
    assert_eq!(string_to_number("123456789"), 123456789);
}
#[test]
fn test7() {
    assert_eq!(string_to_number("2147483647"), 2147483647);
}
#[test]
fn test8() {
    assert_eq!(string_to_number("-2147483648"), -2147483648);
}
#[test]
fn test9() {
    assert_eq!(string_to_number("-42"), -42);
}
