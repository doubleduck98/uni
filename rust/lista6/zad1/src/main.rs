fn main() {
    println!("{:?}", encode("xddd".to_string(), 15));
}

fn encode(msg: String, n: i32) -> Vec<i32> {
    let nvec: Vec<u32> = n
        .to_string()
        .chars()
        .map(|d| d.to_digit(10).unwrap())
        .collect();
    let mut mvec: Vec<i32> = msg.chars().map(|c| (c as i32) - ('a' as i32) + 1).collect();
    for i in 0..(mvec.len()) {
        mvec[i] += nvec[i % (nvec.len())] as i32;
    }
    mvec
}

#[test]
fn test0() {
    assert_eq!(encode("scout".to_string(), 1939), vec![20, 12, 18, 30, 21]);
}
#[test]
fn test1() {
    assert_eq!(
        encode("masterpiece".to_string(), 1939),
        vec![14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8]
    );
}
#[test]
fn test2() {
    assert_eq!(encode("essa".to_string(), 2115), vec![7, 20, 20, 6]);
}
#[test]
fn test3() {
    assert_eq!(encode("rust".to_string(), 3), vec![21, 24, 22, 23]);
}
#[test]
fn test4() {
    assert_eq!(encode("xdddddd".to_string(), 0), vec![24, 4, 4, 4, 4, 4, 4]);
}
#[test]
fn test5() {
    assert_eq!(encode("".to_string(), 1234), vec![]);
}
#[test]
fn test6() {
    assert_eq!(
        encode("iiuwr".to_string(), 445678536),
        vec![13, 13, 26, 29, 25]
    );
}
#[test]
fn test7() {
    assert_eq!(encode("jdasbc".to_string(), 42), vec![14, 6, 5, 21, 6, 5]);
}
#[test]
fn test8() {
    assert_eq!(
        encode("zienkiewicz".to_string(), 1939),
        vec![27, 18, 8, 23, 12, 18, 8, 32, 10, 12, 29]
    );
}
#[test]
fn test9() {
    assert_eq!(encode("cycle".to_string(), 997), vec![12, 34, 10, 21, 14]);
}
