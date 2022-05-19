function largestNum(a,b,c){
    let temp=-100;

    let i;
    for(i=0;i<arguments.length;i++){
        
        if(arguments[i]>temp){
            temp=arguments[i];
         }
        
    }
    console.log('The largest number is ' + temp + '.')
    }
