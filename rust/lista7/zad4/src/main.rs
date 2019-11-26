fn main() {
    println!("Hello, world!");
}

fn vectors(n: i32) -> (Vec<i32>, Vec<i32>) {
    let mut jv = vec![0];
    let mut av = vec![1];
    for i in 1..n {
        jv.push(i - av[jv[i as usize - 1] as usize]);
        av.push(i - jv[av[i as usize - 1] as usize]);
    }
    (jv, av)
}

fn john(n: i32) -> Vec<i32> {
    vectors(n).0
}
fn ann(n: i32) -> Vec<i32> {
    vectors(n).1
}
fn sum_john(n: i32) -> i32 {
    vectors(n).0.into_iter().sum()
}
fn sum_ann(n: i32) -> i32 {
    vectors(n).1.into_iter().sum()
}

fn test_john(n: i32, exp: Vec<i32>) -> () {
    assert_eq!(john(n), exp)
}
fn test_ann(n: i32, exp: Vec<i32>) -> () {
    assert_eq!(ann(n), exp)
}
fn test_sum_john(n: i32, exp: i32) -> () {
    assert_eq!(sum_john(n), exp)
}
fn test_sum_ann(n: i32, exp: i32) -> () {
    assert_eq!(sum_ann(n), exp)
}

#[test]
fn test_test_john() {
    test_john(11, vec![0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6]);
    test_john(14, vec![0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6, 7, 7, 8]);
    test_john(17, vec![0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6, 7, 7, 8, 9, 9, 10]);
}
#[test]
fn test_test_ann() {
    test_ann(6, vec![1, 1, 2, 2, 3, 3]);
    test_ann(15, vec![1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6, 7, 8, 8, 9]);
    test_ann(19, vec![1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6, 7, 8, 8, 9, 9, 10, 11, 11]);
}
#[test]
fn test_test_sum_john() {
    test_sum_john(75, 1720);
    test_sum_john(78, 1861);
    test_sum_john(99, 3005);
}
#[test]
fn test_test_sum_ann() {
    test_sum_ann(115, 4070);
    test_sum_ann(150, 6930);
    test_sum_ann(210, 13593);
}
