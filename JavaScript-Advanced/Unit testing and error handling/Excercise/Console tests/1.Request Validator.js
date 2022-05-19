function validate(obj = {}) {
    let methods = ["GET", "POST", "DELETE", "CONNECT"]
    let versions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"]
    let uriPattern = /(^[\w.]+$)/g;
    let messagePattern = /([<>\\&'"])/g;
    if (methods.includes(obj.method) == false || !obj.method) {
        throw Error(`Invalid request header: Invalid Method`)
    }
    if (!uriPattern.test(obj.uri) || !obj.uri || obj.uri == "") {
        throw Error(`Invalid request header: Invalid URI`)

    }
    if (versions.includes(obj.version) == false || !obj.version) {
        throw Error(`Invalid request header: Invalid Version`)
    }
    if (obj.message == undefined || messagePattern.test(obj.message)) {
        throw Error(`Invalid request header: Invalid Message`)
    }
    return obj;
}
console.log(validate({
    method: 'GET',
    uri: 's2vn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}
));
console.log(validate({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
  }
  ));
console.log(validate({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
}
));
