fn main() {
    println!("{:?}", game(204));
    println!("{:?}", game(807));
}

fn game(n: u64) -> Vec<u64> {
    if n % 2 == 0 {
        vec![n.pow(2) / 2]
    } else {
        vec![n.pow(2), 2]
    }
}

#[test]
fn test0() {
    assert_eq!(game(204), vec![20808]);
}
#[test]
fn test1() {
    assert_eq!(game(807), vec![651249, 2]);
}
#[test]
fn test2() {
    assert_eq!(game(750001), vec![562501500001, 2]);
}
#[test]
fn test3() {
    assert_eq!(game(5014), vec![12570098]);
}
#[test]
fn test4() {
    assert_eq!(game(13), vec![169, 2]);
}
#[test]
fn test5() {
    assert_eq!(game(71), vec![5041, 2]);
}
#[test]
fn test6() {
    assert_eq!(game(123), vec![15129, 2]);
}
#[test]
fn test7() {
    assert_eq!(game(2115), vec![4473225, 2]);
}
#[test]
fn test8() {
    assert_eq!(game(1337), vec![1787569, 2]);
}
#[test]
fn test9() {
    assert_eq!(game(0), vec![0]);
}
