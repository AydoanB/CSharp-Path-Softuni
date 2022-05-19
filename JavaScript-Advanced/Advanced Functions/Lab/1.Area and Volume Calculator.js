function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solution(area, vol, data) {
    data = JSON.parse(data);
    let output = [];
    for (const cube of data) {
        const cubeArea = area.apply(cube);
        const cubeVolume = vol.apply(cube);
        output.push({
            area: cubeArea,
            volume: cubeVolume
        });
    }
    return output;

}
console.log(solution(area, vol, `[
    { "x": "1", "y": "2", "z": "10" },
    { "x": "7", "y": "7", "z": "10" },
    { "x": "5", "y": "2", "z": "10" }
]`
));
