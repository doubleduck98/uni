fn main() {
    println!("{}", count_bits(997));
}

fn count_bits(n: i64) -> u32 {
    n.count_ones()
}

#[test]
fn test0() {
    assert_eq!(count_bits(0), 0);
}
#[test]
fn test1() {
    assert_eq!(count_bits(4), 1);
}
#[test]
fn test2() {
    assert_eq!(count_bits(7), 3);
}
#[test]
fn test3() {
    assert_eq!(count_bits(9), 2);
}
#[test]
fn test4() {
    assert_eq!(count_bits(10), 2);
}
#[test]
fn test5() {
    assert_eq!(count_bits(-5), 63);
}
#[test]
fn test6() {
    assert_eq!(count_bits(42), 3);
}
#[test]
fn test7() {
    assert_eq!(count_bits(997), 7);
}
#[test]
fn test8() {
    assert_eq!(count_bits(71), 4)
}
#[test]
fn test9() {
    assert_eq!(count_bits(std::i64::MAX), 63);
}
