function przez_sume(num){
    var suma = 0;
    cyfry = Array.from(num.toString()).map(Number);
    for(var i = 0; i < cyfry.length; i++){
        suma += cyfry[i];
    }
    return num % suma == 0;
}

function przez_kazda(num){
    cyfry = Array.from(num.toString()).map(Number);
    for(var i = 0; i < cyfry.length; i++){
        if(num % cyfry[i] != 0) return false;
    }
    return true;
}

function fn2(){
    res = [];
    for(n = 1; n <= 100000; n++){
        if(przez_sume(n) && przez_kazda(n))
            res.push(n);
    }
    console.log(res);
}

fn2();