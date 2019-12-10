use std::collections::HashMap;

fn main() {
    let a = vec!["BBAR 150", "CDXE 515", "BKWR 250", "BTSQ 890", "DRTY 600"];
    let b = vec!["A", "B", "C", "D"];
    println!("{}", stock_list(a, b))
}

fn stock_list(list_art: Vec<&str>, list_cat: Vec<&str>) -> String {
    if list_art.is_empty() || list_cat.is_empty() {
        return String::new();
    }
    let mut map: HashMap<String, u32> = HashMap::new();
    let mut res: Vec<String> = Vec::new();
    for art in list_art {
        let art_type: String = art.chars().nth(0).unwrap().to_string();
        let quantity: u32 = art.split_whitespace().next_back().unwrap().parse().unwrap();
        *map.entry(art_type).or_insert(0) += quantity;
    }
    for cat in list_cat {
        res.push(format!("({} : {})", cat, map.get(cat).unwrap_or(&0)))
    }
    res.join(" - ")
}
