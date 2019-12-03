fn main() {
    order(r"is2 Thi1s T4est 3a");
}

fn order(sentence: &str) -> String {
    let mut vec = Vec::<(String, u32)>::new();
    let mut res = String::new();
    sentence.split_whitespace().for_each(|w| {
        let num: u32 = w.matches(char::is_numeric).collect::<String>().parse().unwrap();
        vec.push((w.to_string(), num));
    });
    vec.sort_by(|a, b| a.1.cmp(&b.1));
    vec.iter().for_each(|p| res.push_str(format!("{} ", p.0)));
    res.trim_end().to_string()
}