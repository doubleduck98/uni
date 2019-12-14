fn main() {
    println!("{}", good_vs_evil("0 0 0 0 0 10", "0 0 0 0 0 0 0"));
}

fn good_vs_evil(good: &str, evil: &str) -> String {
    let good_vals: Vec<u32> = vec![1, 2, 3, 3, 4, 10];
    let evil_vals: Vec<u32> = vec![1, 2, 2, 2, 3, 5, 10];
    let good_worth: u32;
    let evil_worth: u32;
    good_worth = good
        .split_whitespace()
        .collect::<Vec<_>>()
        .iter()
        .map(|s| s.to_string().parse().unwrap())
        .zip(good_vals.iter())
        .fold(0, |acc, (a, b): (u32, &u32)| acc + a * b);
    evil_worth = evil
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
