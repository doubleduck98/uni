fn main() {
    println!(
        "{}",
        comp(
            vec![121, 144, 19, 161, 19, 144, 19, 11],
            vec![
                11 * 11,
                121 * 121,
                144 * 144,
                19 * 19,
                161 * 161,
                19 * 19,
                144 * 144,
                19 * 19
            ]
        )
    );
}

fn comp(a: Vec<i64>, b: Vec<i64>) -> bool {
    if a.is_empty() && b.is_empty() {
        return true;
    } else if a.len() != b.len() {
        return false;
    }
    
}
