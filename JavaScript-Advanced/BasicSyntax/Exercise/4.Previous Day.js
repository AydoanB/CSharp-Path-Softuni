function theDayBefore(year, month, day) {
    let date = new Date(year, month, day - 1);
    let dayBefore = day - 1;
    if (date.getDate() == 31) {
        date.setDate(day - 1);
    }
    console.log(date.getFullYear() + '-' + Number(date.getMonth()) + '-' + date.getDate())
}

theDayBefore(2016, 9, 30)
theDayBefore(2016, 10, 1)