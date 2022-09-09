function isAnagram(s: string, t: string): boolean {
    let sHmap = stringToHashMap(s);
    let tHmap = stringToHashMap(t);
    if (sHmap.size != tHmap.size) {
        // if size is not same, 
        // then there is some missmatch in characters
        return false;
    }

    for (let [character, occurance] of sHmap) {
        if (!tHmap.has(character)) {
            return false;
        }
        if (tHmap.get(character) != occurance) {
            return false;
        }
        sHmap.delete(character);
        tHmap.delete(character);
    }

    if(tHmap.size > 0) {
        // after iterating through first hash map
        // if any thing left in second hashmap
        // that means there is some missmatch in characters
        return false;
    }

    return true;
};

function stringToHashMap(str: string) {
    let hasMap = new Map<string, number>();
    for (let i = 0; i < str.length; i++) {
        if (!hasMap.has(str[i]))
            hasMap.set(str[i], 0);
        hasMap.set(str[i], hasMap.get(str[i])! + 1);
    }
    return hasMap;
}

let s = "anagram", t = "nagaram";
console.log(isAnagram(s, t));