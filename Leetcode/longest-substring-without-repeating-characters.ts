function lengthOfLongestSubstring(s: string): number {
    let len = s.length;
    let currLen = 0;
    let maxLen = 0;
    for (let i = 0; i < len; i++) {
        let visited = new Map();
        for (let j = i; j < len; j++) {
            if (visited.has(s[j])) {
                break;
            } else {
                visited.set(s[j], true);
                currLen = j - i + 1;
                maxLen = Math.max(maxLen, currLen);
            }
        }
    }
    return maxLen;
};