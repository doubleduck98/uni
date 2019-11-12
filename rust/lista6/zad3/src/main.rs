fn main() {
    println!("{:?}", print(5));
}

fn print(n: i32) -> Option<String> {
    if n < 1 || n % 2 == 0 {
        return None;
    }
    let mut res: String = String::new();
    for i in 0..n {
        let row: String;
        if i <= n / 2 {
            row = "*".repeat((i * 2 + 1) as usize);
        } else {
            row = "*".repeat(((n - i) * 2 - 1) as usize);
        }
        res.push_str(&" ".repeat(((n - row.len() as i32) / 2) as usize));
        res.push_str(&row);
        res.push_str(&"\n");
    }
    Some(res)
}
