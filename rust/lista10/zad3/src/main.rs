fn main() {
    println!("{}", good_vs_evil("0 0 0 0 0 10", "0 0 0 0 0 0 0"));
}

fn good_vs_evil(good: &str, evil: &str) -> String {
    let good_vals: Vec<u32> = vec![1, 2, 3, 3, 4, 10];
    let evil_vals: Vec<u32> = vec![1, 2, 2, 2, 3, 5, 10];
    let good_worth: u32 = good
        .split_whitespace()
        .collect::<Vec<_>>()
        .iter()
        .map(|s| s.to_string().parse().unwrap())
        .zip(good_vals.iter())
        .fold(0, |acc, (a, b): (u32, &u32)| acc + a * b);
    let evil_worth: u32 = evil
        .split_whitespace()
        .collect::<Vec<_>>()
        .iter()
        .map(|s| s.to_string().parse().unwrap())
        .zip(evil_vals.iter())
        .fold(0, |acc, (a, b): (u32, &u32)| acc + a * b);
    if good_worth > evil_worth {
        String::from("Battle Result: Good triumphs over Evil")
    } else if good_worth == evil_worth {
        String::from("Battle Result: No victor on this battle field")
    } else {
        String::from("Battle Result: Evil eradicates all trace of Good")
    }
}

#[test]
fn test0() {
    assert_eq!(
        good_vs_evil("0 0 0 0 0 10", "0 0 0 0 0 0 0"),
        "Battle Result: Good triumphs over Evil"
    );
}
#[test]
fn test1() {
    assert_eq!(
        good_vs_evil("0 0 0 0 0 0", "0 0 0 0 0 0 10"),
        "Battle Result: Evil eradicates all trace of Good"
    );
}
#[test]
fn test2() {
    assert_eq!(
        good_vs_evil("0 0 0 0 0 10", "0 0 0 0 0 0 10"),
        "Battle Result: No victor on this battle field"
    );
}
#[test]
fn test3() {
    assert_eq!(
        good_vs_evil("1 1 1 1 1 1", "0 0 0 0 0 0 0"),
        "Battle Result: Good triumphs over Evil"
    );
}
#[test]
fn test4() {
    assert_eq!(
        good_vs_evil("0 0 0 0 0 0", "1 1 1 1 1 1 1"),
        "Battle Result: Evil eradicates all trace of Good"
    );
}
#[test]
fn test5() {
    assert_eq!(
        good_vs_evil("0 0 0 0 0 0", "0 0 0 0 0 0 0"),
        "Battle Result: No victor on this battle field"
    );
}
#[test]
fn test6() {
    assert_eq!(
        good_vs_evil("1 2 3 4 5 6", "1 2 3 4 5 6 7"),
        "Battle Result: Evil eradicates all trace of Good"
    );
}
#[test]
fn test7() {
    assert_eq!(
        good_vs_evil("1 2 3 4 5 7", "1 2 7 3 4 5 6"),
        "Battle Result: Evil eradicates all trace of Good"
    );
}
#[test]
fn test8() {
    assert_eq!(
        good_vs_evil("0 0 0 0 1 0", "4 0 0 0 0 0 0"),
        "Battle Result: No victor on this battle field"
    );
}
#[test]
fn test9() {
    assert_eq!(
        good_vs_evil("51 512 635 12 5 1", "45 872 12 4 12 0 12"),
        "Battle Result: Good triumphs over Evil"
    );
}
