function deleteByEmail() {
    let inputElement = document.getElementsByTagName("input")[0];

    let tableElements = document.querySelectorAll("#customers tr");
    let removed = false;
    let rows = Array.from(document.querySelectorAll('tbody tr'));
    for (const row of rows) {
        if (row.children[1].textContent == inputElement.value) {
            row.remove();
            removed = true;
            inputElement.innerHTML = "";
        }
    }
    document.getElementById('result').textContent = removed ? 'Deleted.' : 'Not found.';

}