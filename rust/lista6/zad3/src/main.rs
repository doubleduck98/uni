fn main() {
    println!("Hello, world!");
}

fn print(n: i32) -> Option<String> {
    if n < 0 || n % 2 == 0 {
        None
    }
    
}