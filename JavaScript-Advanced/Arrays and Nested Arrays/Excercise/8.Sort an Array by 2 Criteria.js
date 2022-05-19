function sort(i = []) {
    i.sort((a, b) => a.length - b.length || a.localeCompare(b));

    console.log(i.join('\n'));
}

sort(['alpha',
    'beta',
    'gamma']
)
sort(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']

)
sort(['test',
    'Deny',
    'omen',
    'Default']
)