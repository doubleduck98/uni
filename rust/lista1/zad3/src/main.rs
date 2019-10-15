fn main() {
    println!("{}", count_red_beads(17));
}

fn count_red_beads(n: u32) -> u32 {
    if n == 0 {
        return 0;
    }
    (n - 1) * 2
}

#[test]
fn test0() {
    assert_eq!(count_red_beads(0), 0);
}
#[test]
fn test1() {
    assert_eq!(count_red_beads(1), 0);
}
#[test]
fn test2() {
    assert_eq!(count_red_beads(3), 4);
}
#[test]
fn test3() {
    assert_eq!(count_red_beads(997), 1992);
}
#[test]
fn test4() {
    assert_eq!(count_red_beads(178), 354);
}
#[test]
fn test5() {
    assert_eq!(count_red_beads(522), 1042);
}
#[test]
fn test6() {
    assert_eq!(count_red_beads(42), 82);
}
#[test]
fn test7() {
    assert_eq!(count_red_beads(6), 10);
}
