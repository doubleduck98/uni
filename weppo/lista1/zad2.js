function przez_sume(num){
    suma = 0;
    str = num.toString();
    for(i = 0; i < str.length; i++){
        suma += parseInt(str.charAt(i));
    }
    return num % suma == 0;
}

function przez_kazda(num){
    str = num.toString();
    for(i = 0; i < str.length; i++){
        if(num % parseInt(str.charAt(i)) != 0)
            return false;
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