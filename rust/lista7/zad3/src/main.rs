fn main() {
    println!("{}", fcn(4));
}

fn fcn(n: i32) -> i64 {
    2_i64.pow(n as u32)
}

#[test]
fn test0() {
    assert_eq!(fcn(0), 1);
}
#[test]
fn test1() {
    assert_eq!(fcn(1), 2);
}
#[test]
fn test2() {
    assert_eq!(fcn(17), 131072);
}
#[test]
fn test3() {
    assert_eq!(fcn(21), 2097152);
}
#[test]
fn test4() {
    assert_eq!(fcn(2), 4);
}
#[test]
fn test5() {
    assert_eq!(fcn(5), 32);
}
#[test]
fn test6() {
    assert_eq!(fcn(6), 64);
}
#[test]
fn test7() {
    assert_eq!(fcn(10), 1024);
}
#[test]
fn test8() {
    assert_eq!(fcn(8), 256);
}
#[test]
fn test9() {
    assert_eq!(fcn(25), 33554432);
}
